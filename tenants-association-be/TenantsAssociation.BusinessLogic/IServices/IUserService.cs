using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.enums;

namespace TenantsAssociation.BusinessLogic.IServices
{
    public interface IUserService
    {
        LoginDto Login(UserDto user);
        List<UserDto> GetTenants();
    }
}
