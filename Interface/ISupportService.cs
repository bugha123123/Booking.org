using Hotel.org.Models;

namespace Hotel.org.Interface
{
    public interface ISupportService
    {

        Task AddSupportMessage(Support support);


        //gets support list for logged in user
        Task<List<Support>> GetSupportList();
    }
}
