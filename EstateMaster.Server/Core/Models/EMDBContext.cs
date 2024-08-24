using Microsoft.EntityFrameworkCore;
using EstateMaster.Server.Core.Models;

namespace EstateMaster
{
    public class EMDBContext : DbContext
    {
        public EMDBContext(DbContextOptions<EMDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
