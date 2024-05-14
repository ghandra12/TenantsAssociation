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
    public class PollService:IPollService
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
                Answers = pollDto.Answers.Select(a => new PollAnswer()
                {
                    Answer = a,
                }).ToList(),
                CreationDate = DateTime.Now,
                ExpirationDate = pollDto.ExpirationDate,
            };
    
            await _unitOfWork.Polls.InsertAsync(poll);
            _unitOfWork.SaveChanges();
        }
        public GetPollDto? GetPoll(int userId)
        {
            Poll? poll = _unitOfWork.Polls.GetUnexpiredPoll(userId);
            GetPollDto? pollDto = null;
            if (poll != null)
            {
                pollDto = new GetPollDto()
                {
                    Answers = poll.Answers.Select(a => new PollAnswerDto()
                    {
                        Answer = a.Answer,
                        Id = a.Id,
                        Count = a.Responses.Count(),
                    }).ToList(),
                    Question = poll.Question,
                    CreationDate = poll.CreationDate,
                    ExpirationDate = poll.ExpirationDate,
                };
            }
            return pollDto;
        }
        public List<GetPollDto> GetAllPolls()
        {
            List<Poll> polls=_unitOfWork.Polls.GetAllPolls();
            List<GetPollDto> pollDtos = polls.Select(p => new GetPollDto()
            {
                Question = p.Question,
                Answers = p.Answers.Select(a => new PollAnswerDto()
                {
                    Answer = a.Answer,
                    Id = a.Id,
                    Count = a.Responses.Count(),
                }).ToList(),
                CreationDate = p.CreationDate,
                ExpirationDate = p.ExpirationDate,
            }).ToList();

            return pollDtos;
        }
        public async Task AddPollResponse(PollAnswerDto pollAnswerDto, int id)
        {
            PollResponse pollResponse = new PollResponse()
            {
                UserId = id,
                PollAnswerId= pollAnswerDto.Id,

            };
            await _unitOfWork.Responses.InsertAsync(pollResponse);
            _unitOfWork.SaveChanges();

        }
    }
}
