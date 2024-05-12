using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.DataAccess.Models
{
    public class PollAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; } = "";
        public int PollId { get; set; }
        public Poll Poll { get; set; } = null!;
    }
}
