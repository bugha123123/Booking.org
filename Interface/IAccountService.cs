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
    }
}
