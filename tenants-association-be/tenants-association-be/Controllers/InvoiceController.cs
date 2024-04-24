using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.enums;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.DataAccess.IRepository;

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

    }
}
