using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scryfall_Admin.Models
{
    public class CartaLegalidades
    {
        [Key]
        public int Id { get; set; }
        public string Standard { get; set; }
        public string Modern { get; set; }
        public string Legacy { get; set; }
        public string Pauper { get; set; }
        public string Duel { get; set; }
        public string Predh { get; set; }

        // Chaves estrangeiras
        public virtual ICollection<Carta>? Cartas { get; set; }
    }
}
