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
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public Staff Add(Staff staff)
        {
            return _unitOfWork.StaffRepository.Add(staff);
        }

        public Staff Delete(Staff staff)
        {
            return _unitOfWork.StaffRepository.Delete(staff);
        }

        public Staff? Delete(int id)
        {
            return _unitOfWork.StaffRepository.Delete(id);
        }

        public List<Staff> GetAll()
        {
            return _unitOfWork.StaffRepository.GetAll();
        }

        public Staff? GetById(int id)
        {
            return _unitOfWork.StaffRepository.GetById(id);
        }

        public Staff Update(Staff staff)
        {
            return _unitOfWork.StaffRepository.Update(staff);
        }
    }
}
