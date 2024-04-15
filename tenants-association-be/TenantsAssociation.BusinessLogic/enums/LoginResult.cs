using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.BusinessLogic.enums
{
    public enum LoginResult: ushort
    {
        UserNotFound = 0,
        LoggedInAsAdmin = 1,
        LoggedInAsTenant = 2
    }
}
