namespace ScoreBoard.Models
{
    public class BDJeuRepository : IJeuRepository
    {
        private readonly CatalogueJoueurDbContext _catalogueJoueurContext;

        public BDJeuRepository(CatalogueJoueurDbContext catalogueJoueurDbContext)
        {
            _catalogueJoueurContext = catalogueJoueurDbContext;
        }

        public List<Jeu> ListeJeux
        {
            get
            {
                return _catalogueJoueurContext.Jeux.OrderBy(g => g.Nom).ToList();
            }
        }

        public Jeu GetJeu(int jeuId)
        {
            return _catalogueJoueurContext.Jeux.FirstOrDefault(g => g.Id == jeuId);
        }

        public void Modifier(Jeu jeu)
        {
            _catalogueJoueurContext.Jeux.Update(jeu);
            _catalogueJoueurContext.SaveChanges();
        }

        public void Supprimer(int jeuId)
        {
            _catalogueJoueurContext.Jeux.Remove(GetJeu(jeuId));
        }
    }
}
