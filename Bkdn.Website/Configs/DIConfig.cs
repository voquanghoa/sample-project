using Bkdn.Website.Handlers;
using Bkdn.Website.Providers;
using BusinessLogic;
using BusinessLogic.Business;
using BusinessLogic.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Bkdn.Website.Configs
{
    public static class DIConfig
    {
        public static void RegisterDI(this IServiceCollection services)
        {
            services.RegisterBusinessDI();
            services.AddHttpContextAccessor();
            services.AddSingleton<TokenProviderMiddleware>();

            services.AddScoped<ValidateModelAttribute>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUserBusiness, UserBusiness>();
        }
    }
}