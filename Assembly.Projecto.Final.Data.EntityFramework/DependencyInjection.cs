using Assembly.Projecto.Final.Data.EntityFramework.Repositories;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Interfaces;
using Assembly.Projecto.Final.Domain.Models;
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
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
