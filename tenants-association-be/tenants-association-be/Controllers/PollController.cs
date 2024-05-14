using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.BusinessLogic.Services;
using TenantsAssociation.DataAccess.Models;

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
        [HttpGet]
        [Route("getpoll")]
        public ActionResult<GetPollDto?> GetPoll()
        {
            var usr = this.User;
            int id = Int32.Parse(usr.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier).Value);
            return _pollService.GetPoll(id);
        }
        [HttpGet]
        [Route("getallpolls")]
        public ActionResult<List<GetPollDto>> GetAllPolls()
        {
          
            return _pollService.GetAllPolls();
        }
        [HttpPost]
        [Route("addpollanswer")]
        public async Task AddPollAnswer([FromBody] PollAnswerDto pollAnswerDto)
        {
            var usr = this.User;
            int id = Int32.Parse(usr.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier).Value);
            await _pollService.AddPollResponse(pollAnswerDto, id);
        }
    }
}
