using System.Collections.Generic;
using System.Threading.Tasks;
using DataModels.Base;

namespace BusinessLogic.Contract
{
    public interface IGenericBusiness<in T> where T : IdBase
    {
        Task<TO> GetById<TO>(int id);
        Task<List<TO>> GetAll<TO>();
        Task Update(IdBase o);
        Task<TO> Create<TO>(object o);
        Task Delete(int id);
        Task Delete(T entry);
    }
}