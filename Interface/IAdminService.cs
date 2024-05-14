using Hotel.org.Models;

namespace Hotel.org.Interface
{
    public interface IAdminService
    {

        Task<List<BookedHotels>> GetBookedHotelsForEveryUser();


        //gets 3  reviews for user
        Task<List<Reviews>> GetReviewsForEveryUser();


        //gets all revies by user

        Task<List<Reviews>> GetAllReviewsForEveryUser();

        //gets 3 users

        Task<List<User>> GetUsers();


        //gets all users

        Task<List<User>> GetUserDataForEveryUser();
    }
}
