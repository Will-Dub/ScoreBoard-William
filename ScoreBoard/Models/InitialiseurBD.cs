namespace ScoreBoard.Models
{
    public static class InitialiseurBD
    {

        public static List<Joueur> _joueurs = new List<Joueur>
        {
            new Joueur
            {
                Nom ="Dub",
                Prenom = "William",
                Courriel= "test@gmail.com",
                Jeux = new List<Jeu>()
            },
            new Joueur
            {
                Nom ="Dubf",
                Prenom = "Anto",
                Courriel= "test123@gmail.com",
                Jeux = new List<Jeu>()
            },
            new Joueur
            {
                Nom ="Dube",
                Prenom = "Emy",
                Courriel= "aefafea@afeaef.com",
                Jeux = new List<Jeu>()
            },
        };

        private static Dictionary<string, Joueur> _NomJoueurDict;
        public static Dictionary<string, Joueur> NomJoueurDict
        {
            get
            {
                _NomJoueurDict = new Dictionary<string, Joueur>();
                foreach (Joueur joueur in _joueurs)
                {
                    _NomJoueurDict.Add(joueur.Nom, joueur);
                }

                return _NomJoueurDict;
            }
        }

        public static List<Jeu> _jeux = new List<Jeu>
        {
            new Jeu
            {
                Nom = "Tetris",
                DateEnregistrement = DateTime.Now,
                Description = "Jeu très vieux",
                ScoreJoueur = 10,
                DateSortie = DateTime.Now,
                JoueurId = NomJoueurDict["Dub"].Id,
                Joueur = NomJoueurDict["Dub"]
            },
        };

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            CatalogueJoueurDbContext catalogueJoueurDbContext = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetService<CatalogueJoueurDbContext>();

            if (!catalogueJoueurDbContext.Joueur.Any())
            {
                catalogueJoueurDbContext.Joueur.AddRange(NomJoueurDict.Values);
            }

            catalogueJoueurDbContext.SaveChanges();

            
            if (!catalogueJoueurDbContext.Jeux.Any())
            {
                catalogueJoueurDbContext.Jeux.AddRange(_jeux);
            }

            catalogueJoueurDbContext.SaveChanges();
        }

    }
}
