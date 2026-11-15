namespace test1.Models
{
    using Microsoft.EntityFrameworkCore;
    public class ProvinciasDbContext : DbContext
    {
        public ProvinciasDbContext(DbContextOptions<ProvinciasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Canton> Cantones { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
