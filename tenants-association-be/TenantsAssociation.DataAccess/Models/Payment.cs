using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.DataAccess.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public double Sum { get; set; }
        public Invoice Invoice { get; set; } = null!;
        public int InvoiceId { get; set; }
    }
}
