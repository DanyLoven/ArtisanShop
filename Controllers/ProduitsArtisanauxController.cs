using Microsoft.AspNetCore.Mvc;
using ArtisanShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace ArtisanShop.Controllers
{
    public class ProduitsArtisanauxController : Controller
    {
        // Liste statique pour stocker les produits (remplacez cela par une base de données dans un projet réel)
        private static List<ProduitArtisanal> produits = new List<ProduitArtisanal>
        {
            new ProduitArtisanal { Id = 1, Nom = "Savon Bio", Description = "Savon fait main avec des ingrédients bio", Prix = 5.99m, DateDeCreation = new DateTime(2024, 1, 10), Categorie = CategorieArtisanale.Hygiène },
            new ProduitArtisanal { Id = 2, Nom = "Bougie Parfumée", Description = "Bougie parfumée à la vanille", Prix = 12.50m, DateDeCreation = new DateTime(2024, 2, 5), Categorie = CategorieArtisanale.Décoration }
        };

        // Action pour afficher la liste des produits
        public IActionResult Index()
        {
            return View(produits);
        }

        // Action pour afficher les détails d'un produit
        public IActionResult Details(int id)
        {
            var produit = produits.FirstOrDefault(p => p.Id == id);
            if (produit == null)
            {
                return NotFound();
            }
            return View(produit);
        }

        // Action pour afficher la page de création d'un produit
        public IActionResult Create()
        {
            return View();
        }

        // Action pour traiter la création d'un produit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nom,Description,Prix,DateDeCreation,Categorie")] ProduitArtisanal produit)
        {
            if (ModelState.IsValid)
            {
                produit.Id = produits.Max(p => p.Id) + 1;
                produits.Add(produit);
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        // Action pour afficher la page de modification d'un produit
        public IActionResult Edit(int id)
        {
            var produit = produits.FirstOrDefault(p => p.Id == id);
            if (produit == null)
            {
                return NotFound();
            }
            return View(produit);
        }

        // Action pour traiter la modification d'un produit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nom,Description,Prix,DateDeCreation,Categorie")] ProduitArtisanal produit)
        {
            if (id != produit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingProduit = produits.FirstOrDefault(p => p.Id == id);
                if (existingProduit == null)
                {
                    return NotFound();
                }

                existingProduit.Nom = produit.Nom;
                existingProduit.Description = produit.Description;
                existingProduit.Prix = produit.Prix;
                existingProduit.DateDeCreation = produit.DateDeCreation;
                existingProduit.Categorie = produit.Categorie;

                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        // Action pour afficher la page de confirmation de suppression
        public IActionResult Delete(int id)
        {
            var produit = produits.FirstOrDefault(p => p.Id == id);
            if (produit == null)
            {
                return NotFound();
            }
            return View(produit);
        }

        // Action pour traiter la suppression d'un produit
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var produit = produits.FirstOrDefault(p => p.Id == id);
            if (produit != null)
            {
                produits.Remove(produit);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
