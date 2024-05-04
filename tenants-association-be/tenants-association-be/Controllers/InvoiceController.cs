using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.enums;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace tenants_association_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class InvoiceController : ControllerBase
    {
        IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        [Route("{userId}")]
        public ActionResult<List<InvoiceDto>> GetUserInvoices(int userId)
        {
            return _invoiceService.GetInvoices(userId);
        }
        [HttpGet]
        [Route("getunpaidinvoices/{userId}")]
        public ActionResult<List<InvoiceDto>> GetUnpaidUserInvoices(int userId)
        {
            return _invoiceService.GetUnpaidInvoices(userId);
        }
        [HttpPost]
        [Route("addinvoice")]
        public async Task AddInvoice([FromBody]  InvoiceDto invoiceDto)
        {
           await _invoiceService.AddInvoice(invoiceDto);
        }

        [HttpPut]
        [Route("payinvoice/{invoiceId}")]
        public void UpdateInvoiceStatus(int invoiceId)
        {
            _invoiceService.UpdateInvoiceStatus(invoiceId);
        }

    }
}
