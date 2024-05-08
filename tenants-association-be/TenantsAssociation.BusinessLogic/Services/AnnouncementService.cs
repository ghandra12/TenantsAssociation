using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.BusinessLogic.Services
{
   public class AnnouncementService: IAnnouncementService
    {
        IUnitOfWork _unitOfWork;

        public AnnouncementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public
         List<AnnouncementDto> GetUnexpiredAnnouncements()
        {
          
             List < Announcement > announcements = _unitOfWork.Announcements.GetUnexpiredAnnouncements();

             var announcementsDtos = announcements.Select(a => new AnnouncementDto()
            {
               Content = a.Content,
               Title = a.Title,
               Date = a.Date,
              
            }).ToList();

            return announcementsDtos;
        }
        public async Task AddAnnouncement(AnnouncementDto announcementDto)
        {
            Announcement announcement = new Announcement()
            {
                Title = announcementDto.Title,
                Content = announcementDto.Content,
                ExpirationDate = announcementDto.ExpirationDate,
                Date = DateTime.Now,
               
            };
            await _unitOfWork.Announcements.InsertAsync(announcement);
            _unitOfWork.SaveChanges();
        }

    }
}
