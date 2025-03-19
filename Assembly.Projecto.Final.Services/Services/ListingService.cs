using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class ListingService : IListingService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public ListingService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ListingDto Add(CreateListingDto obj)
        {
            throw new NotImplementedException();
        }

        public ListingDto Delete(ListingDto obj)
        {
            throw new NotImplementedException();
        }

        public ListingDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ListingDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ListingDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ListingDto Update(ListingDto obj)
        {
            throw new NotImplementedException();
        }
    }
}
