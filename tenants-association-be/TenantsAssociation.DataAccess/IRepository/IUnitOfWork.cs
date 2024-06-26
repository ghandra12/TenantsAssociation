﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.DataAccess.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get;  }
        IInvoiceRepository Invoices { get; }
        IAnnouncementRepository Announcements { get; }
        IPollRepository Polls { get; }
        IPollResponseRepository Responses { get; }
        IMessageRepository Messages { get; }
        IPaymentRepository Payments { get; }
        int SaveChanges();
    }
}
