using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.BusinessLogic.Services
{
    public class InvoiceService: IInvoiceService
    {
        IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        List<Invoice> GetInvoices(InvoiceDto invoice)
        {
            //List<Invoice> invoices = _unitOfWork.Invoices.GetInvoicesByUserId(int id);
            return;
        }

    }
}
