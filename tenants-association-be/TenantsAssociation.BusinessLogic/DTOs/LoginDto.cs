using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.enums;

namespace TenantsAssociation.BusinessLogic.DTOs
{
   public class LoginDto
    {
      public int UserId { get; set; }
      public LoginResult LoginResult { get; set; }  
    }
}
