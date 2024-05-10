using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.DataAccess.Repository
{
    public class PollRepository: BaseRepository<Poll>, IPollRepository
    {
        public PollRepository(TenantsAssociationDBContext _db) : base(_db)
        {

        }
    }

}
