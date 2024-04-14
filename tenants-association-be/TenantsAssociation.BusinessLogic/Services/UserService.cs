using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.DataAccess.IRepository;

namespace TenantsAssociation.BusinessLogic.Services
{
    public class UserService:IUserService
    {
        IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public bool Login(UserDto user)
        {
            bool ans = _unitOfWork.Users.VerifyUser(user.Email,user.Password);
            return ans; 
        }
       

    }
}
