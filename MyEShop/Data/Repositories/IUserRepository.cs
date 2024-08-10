using MyEShop.Models;

namespace MyEShop.Data.Repositories
{
    public interface IUserRepository
    {
        bool ExistUserByEmail(string email);
        void Add(Users users);
        Users GetUserForLogin(string email, string password);
    }
}
