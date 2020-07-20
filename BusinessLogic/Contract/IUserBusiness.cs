using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Contract
{
    public interface IUserBusiness
    {
        Task Create(UserCreate userCreate);
    }
}