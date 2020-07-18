using BusinessLogic.Business;
using BusinessLogic.Contract;
using DataModels.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
    public static class ConfigService
    {
        public static void RegisterBusinessDI(this IServiceCollection services)
        {
            services.AddTransient<IAuthBusiness, AuthBusiness>();
            services.AddTransient<IGenericBusiness<Faculty>, FacultyBusiness>();
        }
    }
}