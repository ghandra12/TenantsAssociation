using Microsoft.AspNetCore.Mvc;
using TenantsAssociation.BusinessLogic.IServices;

namespace tenants_association_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcememntService)
        {
            _announcementService = announcememntService;
        }
    }
}
