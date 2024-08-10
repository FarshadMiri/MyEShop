using MyEShop.Data.Repositories;
using MyEShop.Models;

namespace MyEShop.Data.Services
{
    public class UserRepository : IUserRepository
    {
        private MyEshopContext _context;
        public UserRepository(MyEshopContext context)
        {
            _context = context;
        }
        public void Add(Users users)
        {
            _context.users.Add(users);
            _context.SaveChanges();
        }

        public bool ExistUserByEmail(string email)
        {
            return _context.users.Any(u => u.Email == email);
        }

        public Users GetUserForLogin(string email, string password)
        {
            return _context.users
                  .SingleOrDefault(c => c.Email == email.ToLower() && c.Password == password);
        }
    }
}
