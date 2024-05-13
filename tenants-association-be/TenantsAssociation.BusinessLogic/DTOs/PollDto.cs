using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.BusinessLogic.DTOs
{
    public class PollDto
    {
        public string Question { get; set; } = " ";
        public List<string> Answers { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
