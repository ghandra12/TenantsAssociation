using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;

namespace TenantsAssociation.BusinessLogic.IServices
{
    public interface IAnnouncementService
    {
         List<AnnouncementDto> GetUnexpiredAnnouncements();
        Task AddAnnouncement(AnnouncementDto announcementDto);
    }
}
