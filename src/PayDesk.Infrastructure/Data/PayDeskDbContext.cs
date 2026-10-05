using Microsoft.EntityFrameworkCore;
using PayDesk.Domain;

namespace PayDesk.Infrastructure.Data
{
    public class PayDeskDbContext : DbContext
    {
        public PayDeskDbContext(DbContextOptions<PayDeskDbContext> options): base(options)
        {
        }

        public DbSet<Merchant> Merchants => Set<Merchant>();
        public DbSet<Terminal> Terminals => Set<Terminal>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PayDeskDbContext).Assembly);
        }
    }
}