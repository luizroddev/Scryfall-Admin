using System.ComponentModel.DataAnnotations;

namespace Scryfall_Admin.Models
{
    public class Colecao
    {
        [Key]
        public int ColecaoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(500)]
        public string Descricao { get; set; }

        // Chaves estrangeiras
        public virtual ICollection<Carta>? Cartas { get; set; }
    }
}
