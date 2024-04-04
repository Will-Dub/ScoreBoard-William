namespace ScoreBoard.Models
{
    public class BDJoueurRepository : IJoueurRepository
    {
        private readonly CatalogueJoueurDbContext _catalogueJoueurContext;

        public BDJoueurRepository(CatalogueJoueurDbContext catalogueJoueurDbContext)
        {
            _catalogueJoueurContext = catalogueJoueurDbContext;
        }

        public List<Joueur> ListeJoueurs {
            get
            {
                return _catalogueJoueurContext.Joueur.OrderBy(g=>g.Nom).ToList();
            }
        }

        public Joueur GetJoueur(int joueurId)
        {
            return _catalogueJoueurContext.Joueur.FirstOrDefault(g=>g.Id == joueurId);
        }

        public void Modifier(Joueur joueur)
        {
            _catalogueJoueurContext.Joueur.Update(joueur);
            _catalogueJoueurContext.SaveChanges();
        }

        public void Supprimer(int joueurId)
        {
            _catalogueJoueurContext.Joueur.Remove(GetJoueur(joueurId));
        }
    }
}
