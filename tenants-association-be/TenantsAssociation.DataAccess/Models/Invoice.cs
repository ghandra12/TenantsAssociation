using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.DataAccess.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int InvoiceNumber { get; set; }
        public string Description { get; set; } = "";

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Sum { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public bool IsPaid { get; set; }


    }
}
