using Assembly.Projecto.Final.Data.InMemory.Repositories;
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
            services.AddScoped(typeof(IRepository<,>),typeof(Repository<,>));
            services.AddScoped<IAccountRepository,AccountRepository>();
            services.AddScoped<IAddressRepository,AddressRepository>();
            services.AddScoped<IAgentRepository,AgentRepository>();
            services.AddScoped<IAppointmentRepository,AppointmentRepository>();
            services.AddScoped<IContactRepository,ContactRepository>();
            services.AddScoped<IFavoriteRepository,FavoriteRepository>();
            services.AddScoped<IFeedBackRepository,FeedBackRepository>();
            services.AddScoped<IListingRepository,ListingRepository>();
            services.AddScoped<IPersonalContactRepository,PersonalContactRepository>();
            services.AddScoped<IReassignRepository, ReassignRepository>();
            services.AddScoped<IStaffRepository,StaffRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
           
            return services;
        }
    }
}
