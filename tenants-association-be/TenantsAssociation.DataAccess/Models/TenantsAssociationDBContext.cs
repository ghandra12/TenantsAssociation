using Microsoft.EntityFrameworkCore;

namespace TenantsAssociation.DataAccess.Models
{
    public class TenantsAssociationDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet <Announcement> Announcements { get; set; }
        public TenantsAssociationDBContext(DbContextOptions<TenantsAssociationDBContext> options) : base(options)
        { }
    }
}
