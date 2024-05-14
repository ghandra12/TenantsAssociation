using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.DataAccess.Models
{
    public class PollResponse
    {
        public int Id { get; set; }
        public PollAnswer PollAnswer { get; set; } = null!;
        public int PollAnswerId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
