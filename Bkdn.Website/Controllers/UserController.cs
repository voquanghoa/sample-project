using System.Threading.Tasks;
using BusinessLogic.Contract;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bkdn.Website.Controllers
{
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        private readonly IUserBusiness business;

        public UserController(IUserBusiness business)
        {
            this.business = business;
        }
        
        [HttpPost][Authorize]
        public async Task Signin([FromBody] UserCreate userCreate) => await business.Create(userCreate);
    }
}