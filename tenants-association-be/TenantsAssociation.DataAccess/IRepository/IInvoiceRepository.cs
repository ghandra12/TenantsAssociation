using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.DataAccess.IRepository
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
        List<Invoice> GetInvoicesByUserId(int Id);
    }
}
