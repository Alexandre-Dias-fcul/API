using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Interfaces
{
    public interface IStaffService:IService<CreateStaffDto,StaffDto,int>
    {
        public void ContactAdd(int staffId, CreateContactDto createContactDto);
        public void AddressAdd(int staffId, CreateAddressDto createAddressDto);
        public void AccountAdd(int staffId, CreateAccountDto createAccountDto);
        public StaffAllDto GetByIdWithAll(int id);
    }
}
