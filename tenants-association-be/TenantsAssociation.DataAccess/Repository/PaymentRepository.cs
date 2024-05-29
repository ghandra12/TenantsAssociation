using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.DataAccess.Repository
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(TenantsAssociationDBContext _db) : base(_db)
        {

        }

        public List<Payment> GetPaymentsByInvoiceId(int invoiceId)
        {
            return GetAll().Where(p => p.InvoiceId == invoiceId).ToList();
        }   
    }
}
