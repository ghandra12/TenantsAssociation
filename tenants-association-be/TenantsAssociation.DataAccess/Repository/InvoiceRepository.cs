using System;
using System.Collections.Generic;
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
       public  List<Invoice> GetInvoicesByUserId(int Id)
        {
            return GetAll().Where(c => c.UserId == Id).ToList();
        }

        public Invoice? GetInvoiceById(int id)
        {
            return GetAll().FirstOrDefault(i => i.Id == id);
        }

       public List<Invoice> GetUnpaidInvoicesByUserId(int Id)
        {
            return GetAll().Where(c => c.UserId == Id && c.IsPaid==false).ToList();
        }
    }
}
