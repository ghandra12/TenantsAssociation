﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.DataAccess.IRepository
{
    public interface IMessageRepository:IBaseRepository<Message>
    {
      public IQueryable<Message> GetAllMessages();
        public Message GetMessageById(int messageId);
    }
}
