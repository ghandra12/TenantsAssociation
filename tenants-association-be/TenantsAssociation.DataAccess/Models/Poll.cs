using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.DataAccess.Models
{
    public class Poll
    {
        public int Id { get; set; }

        public string Question { get; set; } = " ";
        public ICollection<PollAnswer> Answers { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
      
    }
}
