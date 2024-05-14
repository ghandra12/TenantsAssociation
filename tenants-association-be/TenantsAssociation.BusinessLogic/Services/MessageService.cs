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

            };
            await _unitOfWork.Messages.InsertAsync(message);
            _unitOfWork.SaveChanges();
        }
    }
}
