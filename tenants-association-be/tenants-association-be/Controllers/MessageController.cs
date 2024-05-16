using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.enums;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.BusinessLogic.Services;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace tenants_association_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpPost]
        [Route("addmessage")]
        public async Task AddMessage([FromBody] MessageDto messageDto)
        { var usr = this.User;
            int id = Int32.Parse(usr.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier).Value);
            await _messageService.AddMessage(messageDto,id);
        }
        [HttpGet]
        [Route("getallmessages")]
        public ActionResult<List<GetMessagesDto>> GetAllMessages()
        {
            return _messageService.GetAllMessages();
            
        }
        [HttpPut]
        [Route("readmessage/{messageId}")]
        public void UpdateMessageReadStatus(int messageId)
        {
            _messageService.UpdateMessageReadStatus(messageId);
        }
        [HttpPut]
        [Route("deletemessage/{messageId}")]
        public void DeleteMessage(int messageId)
        {
            _messageService.DeleteMessage(messageId);
        }
    }
}
