using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.DataAccess.Repository
{
    public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository {
        public AnnouncementRepository(TenantsAssociationDBContext _db) : base(_db)
        {

        }
        public List<Announcement> GetUnexpiredAnnouncements()
        {
            DateTime currentDate = DateTime.Today;
            return GetAll().Where(a=>a.ExpirationDate>=currentDate).ToList();
        }

    }
}
