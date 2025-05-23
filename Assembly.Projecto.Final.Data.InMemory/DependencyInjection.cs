﻿
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataInMemoryServices(this IServiceCollection services)
        {
            services.AddSingleton<Database>();
           
            return services;
        }
    }
}
