using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;
using System;

namespace Ioc
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<ICDBService, CDBService>();
        }
    }
}
