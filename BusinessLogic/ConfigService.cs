using BusinessLogic.Business;
using BusinessLogic.Contract;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
    public static class ConfigService
    {
        public static void RegisterBusinessDI(this IServiceCollection services)
        {
            services.AddTransient<IAuthBusiness, AuthBusiness>();
        }
    }
}