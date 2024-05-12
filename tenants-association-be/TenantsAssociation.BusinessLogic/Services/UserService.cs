using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
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
          User dbUser = _unitOfWork.Users.VerifyUser(user.Email,user.Password);

            if (dbUser == null)
            {
                var loginDto = new LoginDto() {
                    UserId = null,
                    LoginResult = LoginResult.UserNotFound,
                    Token=null
                };
             return loginDto;
            }

            string encodedJwt = GenerateAuthorizationToken(dbUser.Id, dbUser.FirstName);

            if (dbUser.IsAdmin == true)
            {
                var loginDto = new LoginDto()
                {
                    UserId = dbUser.Id,
                    LoginResult = LoginResult.LoggedInAsAdmin,
                    Token=encodedJwt

                };
                return loginDto;
            }
            else 
            {
                var loginDto = new LoginDto()
                {
                    UserId = dbUser.Id,
                    LoginResult = LoginResult.LoggedInAsTenant,
                    Token = encodedJwt
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
                PaswordSalt=salt,
            };
            await _unitOfWork.Users.InsertAsync(user);
            _unitOfWork.SaveChanges();
        }

        private string GenerateAuthorizationToken(int userId, string userName)
        {
            var now = DateTime.UtcNow;
            var secret = _configuration.GetValue<string>("Secret");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

            var userClaims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            };

            var expires = now.Add(TimeSpan.FromMinutes(600));

            var jwt = new JwtSecurityToken(
                    notBefore: now,
                    claims: userClaims,
                    expires: expires,
                    audience: "https://localhost:7066/",
                    issuer: "https://localhost:7066/",
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            //we don't know about thread safety of token handler

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }

}

