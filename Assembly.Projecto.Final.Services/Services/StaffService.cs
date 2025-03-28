using Assembly.Projecto.Final.Domain.Common;
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

        public StaffDto Add(CreateStaffDto createStaffDto)
        {
            Staff addedStaff;

            using(_unitOfWork) 
            {
                var name = Name.Create(createStaffDto.Name.FirstName, createStaffDto.Name.MiddleNames,
                    createStaffDto.Name.LastName);

                var staff = Staff.Create(name, createStaffDto.DateOfBirth, createStaffDto.Gender,
                    createStaffDto.PhotoFileName, createStaffDto.IsActive,createStaffDto.HiredDate,
                    createStaffDto.DateOfTermination);

                addedStaff = _unitOfWork.StaffRepository.Add(staff);

                _unitOfWork.Commit();
            }

            return _mapper.Map<StaffDto>(addedStaff);
        }

        public StaffDto Delete(StaffDto staffDto)
        {
            Staff deletedStaff;

            using (_unitOfWork) 
            {
                var foundedStaff = _unitOfWork.StaffRepository.GetById(staffDto.Id);

                if(foundedStaff is null) 
                {
                    throw new ArgumentNullException(nameof(foundedStaff), "Não foi encontrado.");
                }

                deletedStaff = _unitOfWork.StaffRepository.Delete(foundedStaff);

                _unitOfWork.Commit();
            }

            return _mapper.Map<StaffDto>(deletedStaff);
        }

        public StaffDto Delete(int id)
        {
            Staff deletedStaff;

            using (_unitOfWork)
            {
                var foundedStaff = _unitOfWork.StaffRepository.GetById(id);

                if (foundedStaff is null)
                {
                    throw new ArgumentNullException(nameof(foundedStaff), "Não foi encontrado.");
                }

                deletedStaff = _unitOfWork.StaffRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<StaffDto>(deletedStaff);
        }

        public List<StaffDto> GetAll()
        {
            var list = new List<StaffDto>();

            foreach(var staff in _unitOfWork.StaffRepository.GetAll()) 
            {
                var staffDto = _mapper.Map<StaffDto>(staff);

                list.Add(staffDto);
            }

            return list;
        }

        public StaffDto GetById(int id)
        {
            var staff = _unitOfWork.StaffRepository.GetById(id);

            return _mapper.Map<StaffDto>(staff);
        }

        public StaffDto Update(StaffDto staffDto)
        {

            Staff updatedStaff;

            using (_unitOfWork)
            {
                var foundedStaff = _unitOfWork.StaffRepository.GetById(staffDto.Id);

                if (foundedStaff is null)
                {
                    throw new ArgumentNullException(nameof(foundedStaff), "Não foi encontrado.");
                }

                var name = Name.Create(staffDto.Name.FirstName,staffDto.Name.MiddleNames,
                   staffDto.Name.LastName);

                foundedStaff.Update(name, staffDto.DateOfBirth, staffDto.Gender,
                    staffDto.PhotoFileName, staffDto.IsActive, staffDto.HiredDate,
                    staffDto.DateOfTermination);

                updatedStaff = _unitOfWork.StaffRepository.Update(foundedStaff);

                _unitOfWork.Commit();
            }

            return _mapper.Map<StaffDto>(updatedStaff);
        }
    }
}
