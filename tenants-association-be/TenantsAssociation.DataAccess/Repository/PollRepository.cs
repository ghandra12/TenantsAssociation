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
        public Poll? GetUnexpiredPoll()
        {
            return GetAll().Include(a => a.Answers).Where(a => a.ExpirationDate >= DateTime.Now).OrderBy(p => p.ExpirationDate).FirstOrDefault();
        }

    }


}
