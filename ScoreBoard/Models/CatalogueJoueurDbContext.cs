using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class CatalogueJoueurDbContext : DbContext
    {
        public CatalogueJoueurDbContext(DbContextOptions<CatalogueJoueurDbContext> options) : base(options)
        {

        }

        public DbSet<Jeu> Jeux { get; set; }
        public DbSet<Joueur> Joueur { get; set; }
    }
}
