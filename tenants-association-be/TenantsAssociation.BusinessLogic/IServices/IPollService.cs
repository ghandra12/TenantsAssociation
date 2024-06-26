﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;

namespace TenantsAssociation.BusinessLogic.IServices
{
    public interface IPollService
    {
       public Task AddPoll(PollDto pollDto);
        public GetPollDto? GetPoll(int userId);
        public List<GetPollDto> GetAllPolls();
        public Task AddPollResponse(PollAnswerDto pollAnswerDto, int id);
     
    }
}
