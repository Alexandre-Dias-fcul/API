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
        private readonly IUnitOfWork _unitOfWork;
        public ReassignService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public Reassign Add(Reassign reassign)
        {
            return _unitOfWork.ReassignRepository.Add(reassign);
        }

        public Reassign Delete(Reassign reassign)
        {
            return _unitOfWork.ReassignRepository.Delete(reassign);
        }

        public Reassign? Delete(int id)
        {
            return _unitOfWork.ReassignRepository.Delete(id);
        }

        public List<Reassign> GetAll()
        {
            return _unitOfWork.ReassignRepository.GetAll();
        }

        public Reassign? GetById(int id)
        {
            return _unitOfWork.ReassignRepository.GetById(id);
        }

        public Reassign Update(Reassign reassign)
        {
            return _unitOfWork.ReassignRepository.Update(reassign);
        }
    }
}
