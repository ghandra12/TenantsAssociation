using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.BusinessLogic.Services;

namespace tenants_association_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnnouncementController : ControllerBase
    {
        IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcememntService)
        {
            _announcementService = announcememntService;
        }
        [HttpGet]
        [Route("getunexpiredannouncements")]
        public List<AnnouncementDto> GetUnexpiredAnnouncements()
        {
            return _announcementService.GetUnexpiredAnnouncements();
        }
        [HttpPost]
        [Route("addannouncement")]
        public async Task AddAnnouncement([FromBody] AnnouncementDto announcementDto)
        {
            await _announcementService.AddAnnouncement(announcementDto);
        }

    }
}
