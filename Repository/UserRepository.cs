using TvRepairWebsite.Data;
using TvRepairWebsite.Models;

namespace TvRepairWebsite.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {

        private readonly TvRepairWebSiteDbContext context;   
        public UserRepository(TvRepairWebSiteDbContext cntx)
        {
           this.context = cntx;
        }

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User FindUserByPhone(string phone)
        {
            return context.Users.FirstOrDefault(x => x.Phone == phone);   
        }

        public void InsertUser(User user)
        {
            context.Users.Add(user);    
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
        }
        public void DeleteUser(int userId)
        {
            User user = context.Users.Find(userId);
            context.Users.Remove(user); 
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }

    }
}
