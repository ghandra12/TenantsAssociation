using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.IServices;

namespace tenants_association_be.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PollController:ControllerBase
    {
        IPollService _pollService;

        public PollController(IPollService pollService)
        {
            _pollService = pollService;
        }
        [HttpPost]
        [Route("addpoll")]
        public async Task AddPoll([FromBody] PollDto pollDto)
        {
           await _pollService.AddPoll(pollDto);
        } 
    }
}
