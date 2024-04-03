using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class CatalogueJeuxDbContext : DbContext
    {
        public CatalogueJeuxDbContext(DbContextOptions<CatalogueJeuxDbContext> options) : base(options)
        {

        }

        public DbSet<Jeu> Jeux { get; set; }
        public DbSet<Joueur> Joueur { get; set; }
    }
}
