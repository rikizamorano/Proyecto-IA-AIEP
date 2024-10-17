using Microsoft.EntityFrameworkCore;


namespace ProyAI_MVC.Models
{
    public class MiDbContext : DbContext
    {
        public MiDbContext(DbContextOptions<MiDbContext> options) : base(options) { }

        public DbSet<Consulta> Consultas { get; set; }

    }
}
