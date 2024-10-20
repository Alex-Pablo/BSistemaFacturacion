using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.Models.Entities;

namespace SistemaFacturacion.DAL
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { }

        public DbSet<DTE_type> DTE_type { get; set; }

        public DbSet<DTE> DTE { get; set; }

        public DbSet<DTE_detail> DTE_detail { get; set; }
    }
}
