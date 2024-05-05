﻿using Hotel.org.ApplicationDBContext;
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

        public async Task<User> GetLoggedInUserAsync()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name!;

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
        public async Task SignInUser(LoginViewModel loginViewModel)
        {
             await _signInManager.PasswordSignInAsync(loginViewModel.EmailAddress, loginViewModel.Password, isPersistent:false, lockoutOnFailure: false);

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
    }
}
