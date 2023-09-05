using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scryfall_Admin.Models
{
    public class Carta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Mana { get; set; }
        public int CustoDeMana { get; set; }
        public string Tipo { get; set; }
        public string Texto { get; set; }
        public int Poder { get; set; }
        public int Resistencia { get; set; }
        public Legalidades Legalidades { get; set; }
        public ImageUris ImageUris { get; set; }
        public int? Lealdade { get; set; }
        public string Raridade { get; set; }
        public string FlavorText { get; set; }
    }
}
