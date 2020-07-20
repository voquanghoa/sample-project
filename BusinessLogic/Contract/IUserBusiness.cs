using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.Models.User;

namespace BusinessLogic.Contract
{
    public interface IUserBusiness
    {
        Task Create(UserCreate userCreate);
    }
}