using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.enums;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;
using TenantsAssociation.DataAccess.Repository;

namespace TenantsAssociation.BusinessLogic.Services
{
    public class UserService:IUserService
    {
        IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<UserDto> GetTenants()
        {
            List<User> users = _unitOfWork.Users.GetTenants();

            var userDtos = users.Select(u => new UserDto()
            {
                Id=u.Id,
                Name=u.FirstName + " " + u.LastName,
                ApartmentNumber=u.ApartmentNumber


            }).ToList();

            return userDtos;
        }

        public LoginDto Login(UserDto user)
        {
          User ans = _unitOfWork.Users.VerifyUser(user.Email,user.Password);
            if (ans == null)
            {
                var loginDto = new LoginDto() {
                    UserId = ans.Id,
                    LoginResult = LoginResult.UserNotFound
                };
             return loginDto;
            }
            if (ans.IsAdmin == true)
            {
                var loginDto = new LoginDto()
                {
                    UserId = ans.Id,
                    LoginResult = LoginResult.LoggedInAsAdmin
                };
                return loginDto;
            }
            else 
            {
                var loginDto = new LoginDto()
                {
                    UserId = ans.Id,
                    LoginResult = LoginResult.LoggedInAsTenant
                };
                return loginDto;
            }
           
        }
        public async Task AddUser(UserDto userDto)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: userDto.Password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            User user = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber,
                ApartmentNumber = userDto.ApartmentNumber,
                IsAdmin = userDto.IsAdmin,
                Email = userDto.Email,

                Password = hashed,
            };
            await _unitOfWork.Users.InsertAsync(user);
            _unitOfWork.SaveChanges();
        }
    }

}

