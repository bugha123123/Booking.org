using Hotel.org.ApplicationDBContext;
using Hotel.org.DTO;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace Hotel.org.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly AppDbContext _dbcontext;
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor, AppDbContext dbcontext, IWebHostEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _dbcontext = dbcontext;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<User?> GetLoggedInUserAsync()
        {
            // Check if the user is authenticated and has a name
            if (_httpContextAccessor.HttpContext.User.Identity?.IsAuthenticated != true)
            {
                // User is not authenticated, return null or handle the case accordingly
                return null;
            }

            // Get the user name
            string? userName = _httpContextAccessor.HttpContext.User.Identity?.Name;

            // Check if the user name is null
            if (userName == null)
            {
                // Handle the case where the user name is null
                // You can return null or throw an exception, depending on your requirements
                return null;
            }

            // Find the user by username
            var user = await _userManager.FindByNameAsync(userName);

            return user;
        }



        //registers user using identity
        public async Task RegisterUser(RegisterViewModel registerViewModel)
        {
            var user = new User
            {
                UserName = registerViewModel.EmailAddress,
                Email = registerViewModel.EmailAddress,
         
                
            };
            //gets the result
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);


            //register === success
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
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
            await _signInManager.SignOutAsync();
        }

        public async Task UpdateCardDetailsForUser(User user)
        {
            var LoggedInUser = await GetLoggedInUserAsync();

            LoggedInUser.CardCV = user.CardCV;
            LoggedInUser.CardNumber = user.CardNumber;
            LoggedInUser.CardExpirationDate= user.CardExpirationDate;

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

                if (result.Succeeded)
                {
                    // Additional actions like logging, notifications, etc.
                }
                else
                {
                    // Handle errors
                    throw new InvalidOperationException($"Error deleting user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
            else
            {
                throw new InvalidOperationException("User not found");
            }
        }
    }
}
