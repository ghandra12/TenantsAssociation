using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.BusinessLogic.Services
{
    public class PollService
    {
        IUnitOfWork _unitOfWork;

        public PollService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task AddPoll(PollDto pollDto)
        {
            Poll poll = new Poll()
            {
                Question = pollDto.Question,
                Answers = pollDto.Answers,
                CreationDate = DateTime.Now,
                ExpirationDate = pollDto.ExpirationDate,
            };
    
            await _unitOfWork.Polls.InsertAsync(poll);
            _unitOfWork.SaveChanges();
        }
    }
}
