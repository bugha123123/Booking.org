using Hotel.org.DTO;

namespace Hotel.org.Interface
{
    public interface IAccountService
    {

        Task RegisterUser(RegisterViewModel RegisterviewModel);
        Task SignInUser(LoginViewModel loginViewModel);

        Task SignOutUser();
    }
}
