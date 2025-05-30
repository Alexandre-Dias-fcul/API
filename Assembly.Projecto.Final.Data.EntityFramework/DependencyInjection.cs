﻿using Assembly.Projecto.Final.Data.EntityFramework.Context;
using Assembly.Projecto.Final.Data.EntityFramework.Interceptors;
using Assembly.Projecto.Final.Data.EntityFramework.Repositories;
using Assembly.Projecto.Final.Data.EntityFramework.UOW;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Interfaces;
using Assembly.Projecto.Final.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public static IServiceCollection AddDataEntityFrameworkServices(this IServiceCollection services, 
            IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var cs = config.GetConnectionString("ProjectoFinalCS");
                options.UseSqlServer(cs);

                options.AddInterceptors(new AuditInterceptor());
                options.AddInterceptors(new SoftDeleteInterceptor());
            });

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IEntityLinkRepository, EntityLinkRepository>();  
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<IFeedBackRepository,FeedBackRepository>();
            services.AddScoped<IListingRepository, ListingRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IPersonalContactDetailRepository, PersonalContactDetailRepository>();
            services.AddScoped<IPersonalContactRepository, PersonalContactRepository>();
            services.AddScoped<IReassignRepository, ReassignRepository>();
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
