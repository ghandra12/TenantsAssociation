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
    public class MessageService:IMessageService
    {
        IUnitOfWork _unitOfWork;

        public MessageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddMessage(MessageDto messageDto,int id)
        {
            Message message = new Message()
            { 
                UserId = id,
                Description = messageDto.Description,
                CreationDate=DateTime.Now,

            };
            await _unitOfWork.Messages.InsertAsync(message);
            _unitOfWork.SaveChanges();
        }
        public List<GetMessagesDto> GetAllMessages()
        {
            var messages = _unitOfWork.Messages.GetAllMessages();
            var messageDtos = messages.Select(m => new GetMessagesDto()
            {  
                Description = m.Description,
                FirstName=m.User.FirstName,
                LastName=m.User.LastName,
                UserEmail = m.User.Email,
                CreationDate=m.CreationDate,
                IsRead=m.IsRead,
                Id=m.Id
              
            }).ToList();

            return messageDtos;

        }
        public void UpdateMessageReadStatus(int messageId)
        {

            var message = _unitOfWork.Messages.GetMessageById(messageId);
            if (message != null)
            {
                message.IsRead = true;
                _unitOfWork.Messages.Update(message);
                _unitOfWork.SaveChanges();
            }
        }
        public void DeleteMessage(int messageId)
        {
            var message = _unitOfWork.Messages.GetMessageById(messageId);
            if (message != null)
            {
                
                _unitOfWork.Messages.Delete(message.Id);
                _unitOfWork.SaveChanges();
            }
        }
    }
}
