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

        public void UpdateInvoiceStatus(int invoiceId)
        {
            var invoice = _unitOfWork.Invoices.GetInvoiceById(invoiceId);
            if (invoice != null)
            {
                invoice.IsPaid = true;
                _unitOfWork.Invoices.Update(invoice);
                _unitOfWork.SaveChanges();
            }
        }

        public List<InvoiceDto> GetInvoices(int id)
        {
            var invoices = _unitOfWork.Invoices.GetInvoicesByUserId(id);

            var invoiceDtos = invoices.Select(i => new InvoiceDto()
            {
                Description = i.Description,
                DueDate = i.DueDate,
                InvoiceNumber = i.InvoiceNumber,
                ReleaseDate = i.ReleaseDate,
                Sum = i.Sum,
                IsPaid=i.IsPaid,
                Id = i.Id,
                Remaining = i.Sum - i.Payments.Sum(p => p.Sum)
            }).ToList();

            return invoiceDtos;
        }
        public List<InvoiceDto> GetUnpaidInvoices(int id)
        {
            List<Invoice> invoices = _unitOfWork.Invoices.GetUnpaidInvoicesByUserId(id);

            var invoiceDtos = invoices.Select(i => new InvoiceDto()
            {
                Description = i.Description,
                DueDate = i.DueDate,
                InvoiceNumber = i.InvoiceNumber,
                ReleaseDate = i.ReleaseDate,
                Sum = i.Sum,
                Id = i.Id,
            }).ToList();

            return invoiceDtos;
        }
        public async Task AddInvoice(InvoiceDto invoiceDto)
        {
            Invoice inv = new Invoice()
            {
                InvoiceNumber=invoiceDto.InvoiceNumber,
                ReleaseDate=invoiceDto.ReleaseDate,
                Sum=invoiceDto.Sum,
                DueDate=invoiceDto.DueDate,
                Description=invoiceDto.Description, 
                UserId=invoiceDto.UserId,
            };
           await _unitOfWork.Invoices.InsertAsync(inv);
            _unitOfWork.SaveChanges();
        }

        public async Task AddPayment(int invoiceId, double sum)
        {
            var invoice = _unitOfWork.Invoices.GetInvoiceById(invoiceId);
            var payments = _unitOfWork.Payments.GetPaymentsByInvoiceId(invoiceId);

            if(invoice == null)
            {
                throw new Exception("Invoice not found");
            }

            if (invoice.IsPaid)
            {
                throw new Exception("Invoice already paid!");
            }

            var remaining = invoice.Sum - payments.Sum(p => p.Sum);

            if(sum > remaining)
            {
                throw new Exception("Cannot pay more than remaining");
            }

            var payment = new Payment()
            {
                Sum = sum,
                InvoiceId = invoiceId,
            };

            await _unitOfWork.Payments.InsertAsync(payment);
            _unitOfWork.SaveChanges();

            if(remaining == sum) {
                invoice.IsPaid = true;
                _unitOfWork.Invoices.Update(invoice);
                _unitOfWork.SaveChanges();
            }
        }
    }
}
