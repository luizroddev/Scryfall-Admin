using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scryfall_Admin.Models
{
    public partial class Carta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(200)]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O campo Mana é obrigatório.")]
        [MaxLength(50)]
        public string Mana { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage = "O campo Custo de Mana deve ser um número não negativo.")]
        public int CustoDeMana { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        [MaxLength(100)]
        public string Tipo { get; set; } = null!;

        [Required(ErrorMessage = "O campo Texto é obrigatório.")]
        public string Texto { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage = "O campo Poder deve ser um número não negativo.")]
        public int Poder { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O campo Resistência deve ser um número não negativo.")]
        public int Resistencia { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O campo Lealdade deve ser um número não negativo.")]
        public int? Lealdade { get; set; }

        [Required(ErrorMessage = "O campo FlavorText é obrigatório.")]
        [MaxLength(200)]
        public string FlavorText { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage = "O campo Raridade deve ser um número não negativo.")]
        public int Raridade { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O campo LegalidadesId deve ser um número não negativo.")]
        public int LegalidadesId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O campo ImagemUrisId deve ser um número não negativo.")]
        public int ImagemUrisId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O campo ColecaoId deve ser um número não negativo.")]
        public int ColecaoId { get; set; }

        public virtual CartaImagensUris? ImagemUris { get; set; } = null!;

        public virtual CartaLegalidades? Legalidades { get; set; } = null!;
        public virtual Colecao? Colecao { get; set; } = null!;
    }
}
