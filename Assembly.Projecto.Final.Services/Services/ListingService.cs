using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;
        public ListingService(IListingRepository listingRepository) 
        { 
            _listingRepository = listingRepository;
        }
        public Listing Add(Listing listing)
        {
            return _listingRepository.Add(listing);
        }

        public Listing Delete(Listing listing)
        {
            return _listingRepository.Delete(listing);
        }

        public Listing? Delete(int id)
        {
            return _listingRepository.Delete(id);
        }

        public List<Listing> GetAll()
        {
             return _listingRepository.GetAll();
        }

        public Listing? GetById(int id)
        {
            return _listingRepository.GetById(id);
        }

        public Listing Update(Listing listing)
        {
            return _listingRepository.Update(listing);
        }
    }
}
