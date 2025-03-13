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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public User Add(User user)
        {
            return _unitOfWork.UserRepository.Add(user);
        }

        public User Delete(User user)
        {
            return _unitOfWork.UserRepository.Delete(user);
        }

        public User? Delete(int id)
        {
            return _unitOfWork.UserRepository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        public User? GetById(int id)
        {
            return _unitOfWork.UserRepository.GetById(id);
        }

        public User Update(User user)
        {
            return _unitOfWork.UserRepository.Update(user);
        }
    }
}
