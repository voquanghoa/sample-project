using System;
using System.Threading.Tasks;
using BusinessLogic.Contract;
using BusinessLogic.Models;
using BusinessLogic.Utils;
using DataModels;
using DataModels.Entities;
using DataModels.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Business
{
    public class AuthBusiness: BaseBusiness, IAuthBusiness
    {
        public AuthBusiness(BkdnContext context) : base(context)
        {
        }
        
        public async Task<User> GetUser(string username)
        {
            var users = Context.Users;

            return await users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<User> Login(User user)
        {
            if (!user.Valid)
            {
                throw new ForbiddenException("Người dùng bị không hợp lệ.");
            }

            user.LastOnline = DateTime.Now;
            await Context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Login(UserLogin userLogin)
        {
            var user = await GetUser(userLogin.Username) ??
                       throw new BadRequestException("Tên đăng nhập không tồn tại");
            
            if (!userLogin.Password.Verify(user.Password))
            {
                throw new BadRequestException("Mật khẩu không hợp lệ");
            }

            return await Login(user);
        }

        public async Task<User> Login(string username)
        {
            var user = await GetUser(username) ?? throw new BadRequestException("Tên đăng nhập không tồn tại");

            return await Login(user);
        }
    }
}