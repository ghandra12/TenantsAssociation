using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.BusinessLogic.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public int InvoiceNumber { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Sum { get; set; }
        public int UserId { get; set; }
        public bool IsPaid {  get; set; }
        public double Remaining { get; set; }
    }
}
