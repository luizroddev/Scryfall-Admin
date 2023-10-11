using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scryfall_Admin.Models
{
    public class CartaLegalidades
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Standard é obrigatório.")]
        [MaxLength(255)] // Defina o comprimento máximo apropriado
        public string Standard { get; set; }

        [Required(ErrorMessage = "O campo Modern é obrigatório.")]
        [MaxLength(255)] // Defina o comprimento máximo apropriado
        public string Modern { get; set; }

        [Required(ErrorMessage = "O campo Legacy é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo Legacy deve ter no mínimo 3 caracteres.")]
        [MaxLength(255)] // Defina o comprimento máximo apropriado
        public string Legacy { get; set; }

        [Required(ErrorMessage = "O campo Pauper é obrigatório.")]
        [MaxLength(255)] // Defina o comprimento máximo apropriado
        public string Pauper { get; set; }

        [Required(ErrorMessage = "O campo Duel é obrigatório.")]
        [MaxLength(255)] // Defina o comprimento máximo apropriado
        public string Duel { get; set; }

        [Required(ErrorMessage = "O campo Predh é obrigatório.")]
        [MaxLength(255)] // Defina o comprimento máximo apropriado
        public string Predh { get; set; }

        // Chaves estrangeiras
        public virtual ICollection<Carta>? Cartas { get; set; }
    }
}
