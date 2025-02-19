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
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository) 
        {
            _staffRepository = staffRepository;
        }
        public Staff Add(Staff staff)
        {
            return _staffRepository.Add(staff);
        }

        public Staff Delete(Staff staff)
        {
            return _staffRepository.Delete(staff);
        }

        public Staff? Delete(int id)
        {
            return _staffRepository.Delete(id);
        }

        public List<Staff> GetAll()
        {
            return _staffRepository.GetAll();
        }

        public Staff? GetById(int id)
        {
            return _staffRepository.GetById(id);
        }

        public Staff Update(Staff staff)
        {
            return _staffRepository.Update(staff);
        }
    }
}
