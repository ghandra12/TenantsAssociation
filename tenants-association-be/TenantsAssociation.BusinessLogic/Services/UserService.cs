using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.enums;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.BusinessLogic.Services
{
    public class UserService:IUserService
    {
        IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public LoginResult Login(UserDto user)
        {
          User ans = _unitOfWork.Users.VerifyUser(user.Email,user.Password);
            if (ans == null)
                return LoginResult.UserNotFound;
            if (ans.IsAdmin == true)
            {
                return LoginResult.LoggedInAsAdmin;
            }
            else 
            {
                return LoginResult.LoggedInAsTenant;
            }
           
         
        }
       

    }
}
