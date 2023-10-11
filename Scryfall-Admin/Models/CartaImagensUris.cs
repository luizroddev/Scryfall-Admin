using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scryfall_Admin.Models
{
    public class CartaImagensUris
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)] // Defina o comprimento máximo apropriado
        public string Small { get; set; }

        [MaxLength(255)] // Defina o comprimento máximo apropriado
        public string Normal { get; set; }

        [MaxLength(255)] // Defina o comprimento máximo apropriado
        public string Large { get; set; }

        // Chaves estrangeiras
        public virtual ICollection<Carta>? Cartas { get; set; }
    }
}
