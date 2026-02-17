using TvRepairWebsite.Models;

namespace TvRepairWebsite.Repository
{
    public interface IUserRepository : IDisposable
    { 

        List<User> GetUsers();
        User FindUserByPhone(string phone);  
        void InsertUser(User user); 
        void UpdateUser(User user);
        void DeleteUser(int userId);
        void Save();


    }
}
