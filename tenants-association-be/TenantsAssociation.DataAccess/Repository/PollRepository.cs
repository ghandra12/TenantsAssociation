using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TenantsAssociation.DataAccess.Repository
{
    public class PollRepository: BaseRepository<Poll>, IPollRepository
    {
        public PollRepository(TenantsAssociationDBContext _db) : base(_db)
        {

        }
        public Poll? GetUnexpiredPoll(int userId)
        {
            return GetAll().Include(a => a.Answers).ThenInclude(a => a.Responses)
                .Where(a => a.ExpirationDate >= DateTime.Now && !a.Answers.Any(a => a.Responses.Any(r => r.UserId == userId)))
                .OrderBy(p => p.ExpirationDate)
                .FirstOrDefault();
           
        }
        public List<Poll> GetAllPolls()
        {
            return GetAll().Include(a => a.Answers).ThenInclude(a => a.Responses).OrderByDescending(p => p.ExpirationDate).ToList();   
        }

    }
}
