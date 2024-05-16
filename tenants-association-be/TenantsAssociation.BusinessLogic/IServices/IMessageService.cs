using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.BusinessLogic.IServices
{
    public interface IMessageService
    {
       public Task AddMessage(MessageDto messageDto,int id);
       public List<GetMessagesDto> GetAllMessages();
        public void UpdateMessageReadStatus(int messageId);
        public void DeleteMessage(int messageId);
    }
}
