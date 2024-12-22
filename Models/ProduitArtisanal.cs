namespace ArtisanShop.Models
{
    public class ProduitArtisanal
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public DateTime DateDeCreation { get; set; }
        public CategorieArtisanale Categorie { get; set; } 
    }
}
