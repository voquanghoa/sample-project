using System.Threading.Tasks;
using BusinessLogic.Contract;
using BusinessLogic.Models;
using BusinessLogic.Utils;
using DataModels;
using DataModels.Entities;
using DataModels.Exceptions;

namespace BusinessLogic.Business
{
    public class UserBusiness: GenericBusiness<User>, IUserBusiness
    {
        public UserBusiness(BkdnContext context) : base(context)
        {
        }

        public async Task Create(UserCreate userCreate)
        {
            var user = userCreate.ConvertTo<User>();
            user.Password = user.Password.Encode();

            if (await Exist(x => x.Username == user.Username))
            {
                throw new BadRequestException("Người dùng đã tồn tại.");
            }
            
            await base.Create<Void>(user);
        }
    }
}