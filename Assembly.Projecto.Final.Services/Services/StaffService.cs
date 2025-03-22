using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public StaffService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public StaffDto Add(CreateStaffDto obj)
        {
            throw new NotImplementedException();
        }

        public StaffDto Delete(StaffDto obj)
        {
            throw new NotImplementedException();
        }

        public StaffDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<StaffDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public StaffDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public StaffDto Update(StaffDto obj)
        {
            throw new NotImplementedException();
        }
    }
}
