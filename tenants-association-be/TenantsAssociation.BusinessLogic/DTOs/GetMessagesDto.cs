using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.BusinessLogic.DTOs
{
    public class GetMessagesDto
    {   public int Id { get; set; }
        public string Description { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string UserEmail { get; set; } = "";
        public DateTime CreationDate { get; set; }
        public bool IsRead {  get; set; }

    }
}
