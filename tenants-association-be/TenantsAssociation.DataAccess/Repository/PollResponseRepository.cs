using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.DataAccess.Repository
{
    public class PollResponseRepository:BaseRepository<PollResponse>,IPollResponseRepository
    {
        public PollResponseRepository(TenantsAssociationDBContext _db) : base(_db)
        {

        }
    }
}
