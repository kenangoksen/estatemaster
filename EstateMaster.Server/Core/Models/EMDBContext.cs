using Microsoft.EntityFrameworkCore;
using EstateMaster.Server.Core.Models;

namespace EstateMaster
{
    public class EMDBContext : DbContext
    {
        public EMDBContext(DbContextOptions<EMDBContext> options) : base(options) { }

        public DbSet<users> users { get; set; }
    }
}
