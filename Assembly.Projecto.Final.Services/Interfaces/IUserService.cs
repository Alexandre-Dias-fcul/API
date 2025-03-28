using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Interfaces
{
    public interface IUserService:IService<CreateUserDto,UserDto,int>
    {
        public void ContactAdd(int userId, CreateContactDto createContactDto);
        public void AddressAdd(int userId, CreateAddressDto createAddressDto);
        public void AccountAdd(int userId, CreateAccountDto createAccountDto);
    }
}
