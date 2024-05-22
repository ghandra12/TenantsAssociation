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
        IQueryable<Invoice> GetInvoicesByUserId(int Id);
        List<Invoice> GetUnpaidInvoicesByUserId(int Id);
        Invoice? GetInvoiceById(int id);
        Invoice? GetInvoiceWithPaymentsById(int invoiceId);
    }
}
