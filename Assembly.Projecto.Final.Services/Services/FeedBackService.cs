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
    public class FeedBackService : IFeedBackService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FeedBackService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork; 
        }
        public FeedBack Add(FeedBack feedBack)
        {
            return _unitOfWork.FeedBackRepository.Add(feedBack);
        }

        public FeedBack Delete(FeedBack feedBack)
        {
            return _unitOfWork.FeedBackRepository.Delete(feedBack);
        }

        public FeedBack? Delete(int id)
        {
            return _unitOfWork.FeedBackRepository.Delete(id);
        }

        public List<FeedBack> GetAll()
        {
            return _unitOfWork.FeedBackRepository.GetAll();
        }

        public FeedBack? GetById(int id)
        {
            return _unitOfWork.FeedBackRepository.GetById(id);
        }

        public FeedBack Update(FeedBack feedBack)
        {
            return _unitOfWork.FeedBackRepository.Update(feedBack);
        }
    }
}
