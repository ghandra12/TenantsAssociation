using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TenantsAssociationDBContext db;
        private IUserRepository? usersRepository;
        private IInvoiceRepository? invoicesRepository;
        private IAnnouncementRepository? announcementRepository;

        public UnitOfWork(TenantsAssociationDBContext dbContext)
        {
            db = dbContext;
        }
        public IUserRepository Users
        {
            get
            {
                if (this.usersRepository == null)
                {
                    this.usersRepository = new UserRepository(db);
                }
                return this.usersRepository;
            }
        }
        public IInvoiceRepository Invoices
        {
            get
            {
                if (this.invoicesRepository == null)
                {
                    this.invoicesRepository = new InvoiceRepository(db);
                }
                return this.invoicesRepository;
            }
        }
        public IAnnouncementRepository Announcements
        {
            get
            {
                if (this.announcementRepository == null)
                {
                    this.announcementRepository = new AnnouncementRepository(db);
                }
                return this.announcementRepository;
            }
        }
        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
