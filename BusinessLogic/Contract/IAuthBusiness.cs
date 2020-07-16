using System.Threading.Tasks;
using BusinessLogic.Models;
using DataModels.Entities;

namespace BusinessLogic.Contract
{
    public interface IAuthBusiness
    {
        Task<User> GetUser(string username);
        Task<User> Login(User user);
        Task<User> Login(UserLogin userLogin);
        Task<User> Login(string username);
    }
}