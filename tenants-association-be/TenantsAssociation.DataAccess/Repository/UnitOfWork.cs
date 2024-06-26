﻿using System;
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
        private IPollRepository? pollRepository;
        private IPollResponseRepository? pollResponseRepository;    
        private IMessageRepository? messageRepository;
        private IPaymentRepository? paymentRepository;
        public UnitOfWork(TenantsAssociationDBContext dbContext)
        {
            db = dbContext;
        }
        public IMessageRepository Messages
        {
            get
            {
                if (this.messageRepository == null)
                {
                    this.messageRepository = new MessageRepository(db);
                }
                return this.messageRepository;
            }
        }
        public IPaymentRepository Payments
        {
            get
            {
                if (this.paymentRepository == null)
                {
                    this.paymentRepository = new PaymentRepository(db);
                }
                return this.paymentRepository;
            }
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
        public IPollRepository Polls
        {
            get
            {
                if (this.pollRepository == null)
                {
                    this.pollRepository = new PollRepository(db);
                }
                return this.pollRepository;
            }
        }
        public IPollResponseRepository Responses
        {
            get
            {
                if (this.pollResponseRepository == null)
                {
                    this.pollResponseRepository = new PollResponseRepository(db);
                }
                return this.pollResponseRepository;
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
