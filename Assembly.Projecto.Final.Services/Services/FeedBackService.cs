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
        private readonly IFeedBackRepository _feedBackRepository;
        public FeedBackService(IFeedBackRepository feedBackRepository) 
        { 
            _feedBackRepository = feedBackRepository;   
        }
        public FeedBack Add(FeedBack feedBack)
        {
            return _feedBackRepository.Add(feedBack);
        }

        public FeedBack Delete(FeedBack feedBack)
        {
            return _feedBackRepository.Delete(feedBack);
        }

        public FeedBack? Delete(int id)
        {
            return _feedBackRepository.Delete(id);
        }

        public List<FeedBack> GetAll()
        {
            return _feedBackRepository.GetAll();
        }

        public FeedBack? GetById(int id)
        {
            return _feedBackRepository.GetById(id);
        }

        public FeedBack Update(FeedBack feedBack)
        {
            return _feedBackRepository.Update(feedBack);
        }
    }
}
