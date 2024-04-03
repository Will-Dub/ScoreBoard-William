namespace ScoreBoard.Models
{
    public static class InitialiseurBD
    {
        public static List<Jeu> _jeux = new List<Jeu>
        {
            new Jeu(),
        };

        private static Dictionary<string, Jeu> _NomJeuDict;
        public static Dictionary<string, Jeu> NomJeuDict
        {
            get
            {
                _NomJeuDict = new Dictionary<string, Jeu>();
                foreach (Jeu jeu in _jeux)
                {
                    _NomJeuDict.Add(jeu.Nom, jeu);
                }

                return _NomJeuDict;
            }
        }

        public static List<Joueur> _joueurs = new List<Joueur>
        {
            new Joueur(),
        };

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            CatalogueJeuxDbContext catalogueJeuxDbContext = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetService<CatalogueJeuxDbContext>();

            if (!catalogueJeuxDbContext.Jeux.Any())
            {
                catalogueJeuxDbContext.Jeux.AddRange(NomJeuDict.Values);
            }

            catalogueJeuxDbContext.SaveChanges();

            if (!catalogueJeuxDbContext.Joueur.Any())
            {
                catalogueJeuxDbContext.Joueur.AddRange(_joueurs);
            }

            catalogueJeuxDbContext.SaveChanges();
        }

    }
}
