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
    public class ReassignService : IReassignService
    {
        private readonly IReassignRepository _reassignRepository;
        public ReassignService(IReassignRepository reassignRepository) 
        { 
            _reassignRepository = reassignRepository;   
        }
        public Reassign Add(Reassign reassign)
        {
            return _reassignRepository.Add(reassign);
        }

        public Reassign Delete(Reassign reassign)
        {
            return _reassignRepository.Delete(reassign);
        }

        public Reassign? Delete(int id)
        {
            return _reassignRepository.Delete(id);
        }

        public List<Reassign> GetAll()
        {
            return _reassignRepository.GetAll();
        }

        public Reassign? GetById(int id)
        {
            return _reassignRepository.GetById(id);
        }

        public Reassign Update(Reassign reassign)
        {
            return _reassignRepository.Update(reassign);
        }
    }
}
