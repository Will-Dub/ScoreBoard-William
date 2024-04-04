using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;
using System.Diagnostics;

namespace ScoreBoard.Controllers
{
    public class JoueurController : Controller
    {
        private IJoueurRepository _LesJoueurs;

        public JoueurController(IJoueurRepository IJoueurRepo)
        {
            _LesJoueurs = IJoueurRepo;
        }


        public IActionResult Afficher()
        {
            return View("Liste", _LesJoueurs.ListeJoueurs);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        public IActionResult Create(Joueur joueur)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View("Liste", _LesJoueurs.GetJoueur);
        }

        public IActionResult Details(Joueur joueur)
        {
            return View("Details", joueur);
        }

        public IActionResult Edit(Joueur joueur)
        {
            return View("Edit", joueur);
        }

        public IActionResult Modifier(Joueur joueur)
        {
            return View("Liste", _LesJoueurs.GetJoueur);
        }

        public IActionResult Delete(int NumeroJoueur)
        {
            _LesJoueurs.Supprimer(NumeroJoueur);
            return View("Liste", _LesJoueurs.GetJoueur);
        }
    }
}
