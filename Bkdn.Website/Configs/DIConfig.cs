using Bkdn.Website.Handlers;
using BusinessLogic;
using Microsoft.Extensions.DependencyInjection;

namespace Bkdn.Website.Configs
{
    public static class DIConfig
    {
        public static void RegisterDI(this IServiceCollection services)
        {
            services.RegisterBusinessDI();
            
            services.AddScoped<ValidateModelAttribute>();
        }
    }
}