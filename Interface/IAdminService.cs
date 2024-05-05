using Hotel.org.Models;

namespace Hotel.org.Interface
{
    public interface IAdminService
    {

        Task<List<BookedHotels>> GetBookedHotelsForEveryUser();


        //gets reviews for user
        Task<List<Reviews>> GetReviewsForEveryUser();
    }
}
