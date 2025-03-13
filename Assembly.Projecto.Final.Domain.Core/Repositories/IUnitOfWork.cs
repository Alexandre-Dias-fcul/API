using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Core.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        public IUserRepository UserRepository { get; }
        public IStaffRepository StaffRepository { get; }
        public IReassignRepository ReassignRepository { get; }
        public IPersonalContactRepository PersonalContactRepository { get; }
        public IPersonalContactDetailRepository PersonalContactDetailRepository { get; }
        public IParticipantRepository ParticipantRepository { get; }
        public IListingRepository ListingRepository { get; }
        public IFeedBackRepository FeedBackRepository { get; }
        public IFavoriteRepository FavoriteRepository { get; }
        public IEntityLinkRepository EntityLinkRepository { get; }
        public IContactRepository ContactRepository { get; }
        public IAppointmentRepository AppointmentRepository { get; }
        public IAgentRepository AgentRepository { get; }
        public IAccountRepository AccountRepository { get; }
        public IAddressRepository AddressRepository { get; }


        void BeginTransaction();

        public bool Commit();
    }
}
