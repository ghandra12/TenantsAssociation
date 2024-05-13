using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.BusinessLogic.DTOs
{
    public class MessageDto
    {
        public string Description { get; set; } = "";
        public int UserId { get; set; }
        
    }
}
