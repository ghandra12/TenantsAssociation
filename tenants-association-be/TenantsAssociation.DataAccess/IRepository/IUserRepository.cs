using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.Models;
using TenantsAssociation.DataAccess.IRepository;
using System.ComponentModel.DataAnnotations;

namespace TenantsAssociation.DataAccess.IRepository
{
    public interface IUserRepository :IBaseRepository<User>
    {
        List<User> GetAdministrators();
        List<User> GetTenants();
        User VerifyUser(string email, string password);
    }
}
