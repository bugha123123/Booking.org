using Hotel.org.DTO;
using Hotel.org.Models;

namespace Hotel.org.Interface
{
    public interface IAccountService
    {

        Task RegisterUser(RegisterViewModel RegisterviewModel);
        Task SignInUser(LoginViewModel loginViewModel);

        Task SignOutUser();

        Task<User> GetLoggedInUserAsync();


        //saves user card details for  payment

        Task SaveCardDetailsForUser(User user);


        //updates user card details

        Task UpdateCardDetailsForUser(User user);

        //changes user profile
        Task UpdateUserProfile(IFormFile profileImage);

    }
}
