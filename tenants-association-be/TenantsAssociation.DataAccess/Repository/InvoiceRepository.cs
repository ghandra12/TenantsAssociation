using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.DataAccess.Repository
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {

        public InvoiceRepository(TenantsAssociationDBContext _db) : base(_db)
        {

        }
       public  IQueryable<Invoice> GetInvoicesByUserId(int Id)
        {
            return GetAll().Include(i => i.Payments).Where(c => c.UserId == Id);
        }

        public Invoice? GetInvoiceById(int id)
        {
            return GetAll().FirstOrDefault(i => i.Id == id);
        }

       public List<Invoice> GetUnpaidInvoicesByUserId(int Id)
        {
            return GetAll().Where(c => c.UserId == Id && c.IsPaid==false).ToList();
        }

        public Invoice? GetInvoiceWithPaymentsById(int invoiceId)
        {
            return GetAll().FirstOrDefault(i => i.Id == invoiceId);
        }
    }
}
