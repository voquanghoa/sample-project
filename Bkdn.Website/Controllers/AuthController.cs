using System.Threading.Tasks;
using Bkdn.Website.Models;
using Bkdn.Website.Providers;
using BusinessLogic.Models;
using BusinessLogic.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Bkdn.Website.Controllers
{
    [Route("api/auth")]
    public class AuthController: ControllerBase
    {
        
        private readonly ITokenGenerator tokenGenerator;

        public AuthController(ITokenGenerator tokenGenerator)
        {
            this.tokenGenerator = tokenGenerator;
        }

        /// <summary>
        /// Đăng nhập người dùng
        /// </summary>
        /// <param name="userLogin">Chứa thông tin đăng nhập</param>
        /// <returns>Thông tin token nếu đăng nhập thành công</returns>
        [HttpPost]
        public async Task<TokenResponse> Login([FromBody] UserLogin userLogin)
        {
            return new TokenResponse
            {
                Token = await tokenGenerator.GenerateToken(userLogin)
            };
        }
    }
}