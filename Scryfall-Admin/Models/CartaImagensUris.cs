using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scryfall_Admin.Models
{
    public class CartaImagensUris
    {
        [Key]
        public int Id { get; set; }
        public string Small { get; set; }
        public string Normal { get; set; }
        public string Large { get; set; }

        // Chaves estrangeiras
        public virtual ICollection<Carta>? Cartas { get; set; }
    }
}
