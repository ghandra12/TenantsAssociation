using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.DataAccess.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        User? User { get; set; }
        public int? UserId {  get; set; }
    }
}
