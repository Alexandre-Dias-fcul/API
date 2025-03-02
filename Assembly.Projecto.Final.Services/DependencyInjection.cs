using Assembly.Projecto.Final.Services.Interfaces;
using Assembly.Projecto.Final.Services.Mappings;
using Assembly.Projecto.Final.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IEntityLinkService, EntityLinkService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IFeedBackService, FeedBackService>();
            services.AddScoped<IListingService, ListingService>();
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<IPersonalContactDetailService,PersonalContactDetailService>();
            services.AddScoped<IPersonalContactService, PersonalContactService>();
            services.AddScoped<IReassignService, ReassignService>();    
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IUserService,UserService>();

            return services;
        }
    }
}
