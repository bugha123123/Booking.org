﻿using Hotel.org.ApplicationDBContext;
using Hotel.org.DTO;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Web;
namespace Hotel.org.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly AppDbContext _dbcontext;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor, AppDbContext dbcontext, IWebHostEnvironment hostingEnvironment, IPasswordHasher<User> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _dbcontext = dbcontext;
            _hostingEnvironment = hostingEnvironment;
            _passwordHasher = passwordHasher;
        }
        public async Task<User?> GetLoggedInUserAsync()
        {
            // Check if the user is authenticated and has a name
            if (_httpContextAccessor.HttpContext.User.Identity?.IsAuthenticated != true)
            {
                // User is not authenticated, return null
                return null;
            }

            // Get the user name
            string? userName = _httpContextAccessor.HttpContext.User.Identity?.Name;

            // Check if the user name is null
            if (userName == null)
            {
                
                return null;
            }

            // Find the user by username
            var user = await _userManager.FindByNameAsync(userName);

            return user;
        }



        //registers user using identity
        public async Task<bool> RegisterUser(RegisterViewModel registerViewModel)
        {
            // Check if a user with the provided email already exists
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
                if (existingUser != null)
                {
                    // User with the email already exists, return false to indicate failure
                    return false;
                }

                var user = new User
                {
                    UserName = registerViewModel.EmailAddress,
                    Email = registerViewModel.EmailAddress,
                    EmailConfirmed = false // Ensure email is not confirmed initially
                };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    var verificationCode = GenerateVerificationCode();

                    // Store the verification code and its expiration time in the database
                    // For simplicity, assume you have a UserVerificationCode entity
                    var userVerificationCode = new UserVerificationCode
                    {
                        UserId = user.Id,
                        user = user,
                        Code = verificationCode,
                        ExpiresAt = DateTime.UtcNow.AddMinutes(5) // Code valid for 5 minutes
                    };
                    await _dbcontext.UserVerificationCodes.AddAsync(userVerificationCode);
                    await _dbcontext.SaveChangesAsync();

                    await SendVerificationEmail(registerViewModel.EmailAddress, verificationCode);

                    // Registration successful, return true
                    return true;
                }
                else
                {
                    // User creation failed, return false
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task SendVerificationEmail(string email, string verificationCode)
        {
            // finds user with email in DB
            var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Email == email);


            // USED FOR SENDING EMAILS TO A USER
            using (var client = new SmtpClient())
            {
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("irakliberdzena314@gmail.com", "coca mmba ywsy lvyz");

                using (var message = new MailMessage(
                    from: new MailAddress("irakliberdzena314@gmail.com", "tryhardgamer"),
                    to: new MailAddress(email))
                )
                {
                    message.Subject = "Email Verification";
                    message.IsBodyHtml = true; // Ensure that the body is treated as HTML

                    // Create the HTML view for verification email
                    string htmlBody = $@"
                <p>Dear {user.UserName},</p>
                <p>Thank you for registering with us!</p>
                <p>Your verification code is: <strong>{verificationCode}</strong></p>
                <p>Please use this code to verify your email address.</p>
                <p>Best regards,<br>Verification Service Team</p>
            ";

                    message.Body = htmlBody;

                    // Send the email
                    await client.SendMailAsync(message);
                }
            }
        }




        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public async Task SaveCardDetailsForUser(User user)
        {
            var LoggedInUser = await GetLoggedInUserAsync();

            LoggedInUser.CardCV = user.CardCV;
            LoggedInUser.CardNumber = user.CardNumber;
            LoggedInUser.CardExpirationDate = user.CardExpirationDate;

            await _dbcontext.SaveChangesAsync();


        }


        //signs in user
        public async Task<bool> SignInUser(LoginViewModel loginViewModel)
        {
            // Find the user by email
            var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

            if (user == null)
            {
                // Email not found
                return false;
            }

            // Check if the password is correct
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);

            if (!isPasswordCorrect)
            {
                // Password is incorrect
                return false;
            }

            // Both email and password are correct, proceed to sign in
            await _signInManager.SignInAsync(user, isPersistent: false);
            return true;
        }


        public async Task SignOutUser()
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(-1),
                Path = "/",
                SameSite = SameSiteMode.None,
                Secure = true
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append("IsVerified", "", cookieOptions);
            await _signInManager.SignOutAsync();
        }

        public async Task UpdateCardDetailsForUser(User user)
        {
            var LoggedInUser = await GetLoggedInUserAsync();

            LoggedInUser.CardCV = user.CardCV;
            LoggedInUser.CardNumber = user.CardNumber;
            LoggedInUser.CardExpirationDate = user.CardExpirationDate;

            await _dbcontext.SaveChangesAsync();


        }

        public async Task UpdateUserProfile(IFormFile profileImage)
        {

            var LoggedInUser = await GetLoggedInUserAsync();
            var userToUpdate = await _dbcontext.Users.FirstOrDefaultAsync(u => u.Id == LoggedInUser.Id);

            if (userToUpdate != null)
            {

                if (profileImage != null && profileImage.Length > 0)
                {

                    string uniqueFileName = ProcessUploadedFile(profileImage);

                    userToUpdate.ProfileImageFileName = uniqueFileName;
                }

                _dbcontext.Users.Update(userToUpdate);
                await _dbcontext.SaveChangesAsync();
            }

        }
        private string ProcessUploadedFile(IFormFile profileImage)
        {
            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImage");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + profileImage.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var image = System.Drawing.Image.FromStream(profileImage.OpenReadStream()))
            {
                // Resize the image if needed (adjust dimensions accordingly)
                var resizedImage = ResizeImage(image, 200, 200);

                // Save the resized image to the file system
                resizedImage.Save(filePath, ImageFormat.Png);
            }

            return uniqueFileName;
        }

        private System.Drawing.Image ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public async Task DeleteUser()
        {
            var user = await GetLoggedInUserAsync();

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);

            
            }
            else
            {
                throw new InvalidOperationException("User not found");
            }
        }

        public async Task<bool> VerifyVerificationCode(string code, string email)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.Email == email);

            // Find the verification code for the logged-in user
            var verificationCodeForUserFromDB = await _dbcontext.UserVerificationCodes.FirstOrDefaultAsync(x => x.UserId == user.Id);

            // Check if a verification code was found for the user
            if (verificationCodeForUserFromDB != null)
            {
                // Check if the code provided matches the code stored in the database (case-insensitive comparison)
                if (!string.IsNullOrWhiteSpace(code) && verificationCodeForUserFromDB.Code.Trim().Equals(code.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    // Check if the verification code has not expired
                    if (DateTime.UtcNow <= verificationCodeForUserFromDB.ExpiresAt)
                    {
                        user.EmailConfirmed = true;
                        var cookieOptions = new CookieOptions
                        {
                            HttpOnly = true,
                            Expires = DateTime.UtcNow.AddDays(1),
                            Path = "/",
                            SameSite = SameSiteMode.None,
                            Secure = true
                        };

                        _httpContextAccessor.HttpContext.Response.Cookies.Append("IsVerified", "True", cookieOptions);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            // No matching verification code found or code does not match
            return false;
        }

        public async Task ResetPassword(string email)
        {


            string token = GenerateResetPasswordToken();

            DateTime expiresAt = DateTime.UtcNow.AddMinutes(3);
            long expiresAtUnixTimestamp = new DateTimeOffset(expiresAt).ToUnixTimeSeconds();

            // check if email exists in database
            if (await _dbcontext.Users.AnyAsync(x => x.Email == email))
            {


                using (var client = new SmtpClient())
                {
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("irakliberdzena314@gmail.com", "coca mmba ywsy lvyz");

                    using (var message = new MailMessage(
                        from: new MailAddress("irakliberdzena314@gmail.com", "tryhardgamer"),
                        to: new MailAddress(email, email)
                    ))
                    {
                        message.Subject = "Reset Your Password";
                        message.IsBodyHtml = true;

                        string resetLink = $"https://localhost:7206/Account/ResetPassword?email={HttpUtility.UrlEncode(email)}&token={HttpUtility.UrlEncode(token)}&TokenExpiresAt={expiresAtUnixTimestamp}";
                        string htmlBody = $@"
            <html>
            <body>
                <h2>Password Reset Request</h2>
                <p>Dear {email},</p>
                <p>We received a request to reset your password. Click the link below to reset your password:</p>
                <p><a href='{resetLink}'>Reset Password</a></p>
                <p>If you did not request a password reset, please ignore this email or contact support if you have questions.</p>
                <p>Thanks,<br/>The BookingService Team</p>
            </body>
            </html>";

                        message.Body = htmlBody;


                        // Send the email
                        client.Send(message);
                    }

                }
            }
        }

        public static string GenerateResetPasswordToken()
        {
            const int tokenSize = 32; // Token size in bytes
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[tokenSize];
                try
                {
                    rng.GetBytes(tokenData);
                    return Convert.ToBase64String(tokenData);
                }
                catch (CryptographicException)
                {
                    // Handle potential cryptographic exceptions
                    throw new InvalidOperationException("An error occurred while generating a secure token.");
                }
            }
        }


        public async Task<string> UpdatePassword(string email, string token, string newPassword)
        {
            // Find the user by email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return "User not found";
            }

           
      

            // Hash the new password
            user.PasswordHash = _passwordHasher.HashPassword(user, newPassword);

       

            // Update the user in the database
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return "Password updated successfully";
            }

            return "Error updating password: " + string.Join(", ", result.Errors.Select(e => e.Description));
        }
    }
}