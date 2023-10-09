using System;
using System.Collections.Generic;

namespace Scryfall_Admin.Models;

public partial class Carta
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Mana { get; set; } = null!;

    public int CustoDeMana { get; set; }

    public string Tipo { get; set; } = null!;

    public string Texto { get; set; } = null!;

    public int Poder { get; set; }

    public int Resistencia { get; set; }

    public int? Lealdade { get; set; }

    public string FlavorText { get; set; } = null!;

    public int Raridade { get; set; }

    public int LegalidadesId { get; set; }

    public int ImagemUrisId { get; set; }

    public virtual CartaImagensUris? ImagemUris { get; set; } = null!;

    public virtual CartaLegalidades? Legalidades { get; set; } = null!;
}
