using Assembly.Projecto.Final.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assembly.Projecto.Final.Data.EntityFramework.Context;

namespace Assembly.Projecto.Final.Data.EntityFramework.UOW
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _dbContextTransaction;
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

        public UnitOfWork(ApplicationDbContext context,IUserRepository userRepository,IStaffRepository staffRepository,
            IReassignRepository reassignRepository, IPersonalContactRepository personalContactRepository,
            IPersonalContactDetailRepository personalContactDetailRepository, IParticipantRepository participantRepository,
            IListingRepository listingRepository, IFeedBackRepository feedBackRepository,
            IFavoriteRepository favoriteRepository, IEntityLinkRepository entityLinkRepository,
            IContactRepository contactRepository, IAppointmentRepository appointmentRepository,
            IAgentRepository agentRepository, IAccountRepository accountRepository, IAddressRepository addressRepository) 
        {
            _context = context;
            UserRepository = userRepository;
            StaffRepository = staffRepository;
            ReassignRepository = reassignRepository;
            PersonalContactRepository = personalContactRepository;
            PersonalContactDetailRepository = personalContactDetailRepository;
            ParticipantRepository = participantRepository;
            ListingRepository = listingRepository;
            FeedBackRepository = feedBackRepository;
            FavoriteRepository = favoriteRepository;
            EntityLinkRepository = entityLinkRepository;
            ContactRepository = contactRepository;
            AppointmentRepository = appointmentRepository;
            AgentRepository = agentRepository;
            AccountRepository = accountRepository;
            AddressRepository = addressRepository;
        }
        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public bool Commit()
        {
            bool commited = false;
            try
            {
                var affectedRows = _context.SaveChanges();
                _dbContextTransaction.Commit();
                return affectedRows != 0;
            }
            catch
            {
                _dbContextTransaction.Rollback();
            }
            finally
            {
                Dispose();
            }

            return commited;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
