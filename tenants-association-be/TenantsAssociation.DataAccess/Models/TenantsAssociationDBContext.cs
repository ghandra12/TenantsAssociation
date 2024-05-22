using Microsoft.EntityFrameworkCore;

namespace TenantsAssociation.DataAccess.Models
{
    public class TenantsAssociationDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet <Announcement> Announcements { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollAnswer> Answers { get; set; }
        public DbSet<PollResponse> Responses { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public TenantsAssociationDBContext(DbContextOptions<TenantsAssociationDBContext> options) : base(options)
        { }
    }
}
