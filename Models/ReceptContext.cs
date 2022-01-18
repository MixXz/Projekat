using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class ReceptContext : DbContext
    {
        public DbSet<Recept> Recepti { get; set; }
        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<TezinaPripreme> TezinePripreme { get; set; }
        public DbSet<Tip> Tipovi { get; set; }
        public ReceptContext(DbContextOptions options) : base(options) {}
    }
}