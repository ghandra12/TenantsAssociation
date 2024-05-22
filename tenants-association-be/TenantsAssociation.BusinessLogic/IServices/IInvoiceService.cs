using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.BusinessLogic.IServices
{
    public interface IInvoiceService
    {
        public List<InvoiceDto> GetInvoices(int id);
        public List<InvoiceDto> GetUnpaidInvoices(int id);
        public Task AddInvoice(InvoiceDto invoice);
        void UpdateInvoiceStatus(int invoiceId);
        Task AddPayment(int invoiceId, double sum);
    }
}
