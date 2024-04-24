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
            return GetAll().Where(c => c.UserId== Id).ToList();
        }
    }
}
