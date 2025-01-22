using Assembly.Projecto.Final.Data.EntityFramework.Repositories;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataEntityFrameworkServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
