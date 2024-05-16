using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.DataAccess.Repository
{
    public class MessageRepository:BaseRepository<Message>,IMessageRepository
    {
        public MessageRepository(TenantsAssociationDBContext _db) : base(_db)
        {

        }
        public IQueryable<Message> GetAllMessages()
        {
            return GetAll().Include(u=>u.User).OrderByDescending(m=>m.CreationDate);
        }
        public Message GetMessageById(int messageId)
        {
            return GetAll().FirstOrDefault(m => m.Id == messageId);
        }
    }
}
