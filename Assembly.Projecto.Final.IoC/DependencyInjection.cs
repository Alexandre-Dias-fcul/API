using Assembly.Projecto.Final.Data.EntityFramework;
using Assembly.Projecto.Final.Data.InMemory;
using Assembly.Projecto.Final.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.IoC
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddApplicationServices();
            services.AddDataEntityFrameworkServices(config);
        }
    }
}
