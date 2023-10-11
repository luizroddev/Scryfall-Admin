using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Scryfall_Admin.Models;
using Xunit;

namespace Scryfall_Admin.Tests
{
    public class CartaTests
    {
        private Carta CreateValidCarta()
        {
            return new Carta
            {
                Nome = "Nome válido",
                Mana = "Mana válida",
                CustoDeMana = 1,
                Tipo = "Tipo válido",
                Texto = "Texto válido",
                Poder = 1,
                Resistencia = 1,
                Lealdade = 1,
                FlavorText = "FlavorText válido",
                Raridade = 1,
                LegalidadesId = 1,
                ImagemUrisId = 1,
                ColecaoId = 1
            };
        }

        private List<ValidationResult> GetValidationResults(Carta carta)
        {
            var context = new ValidationContext(carta, null, null);
            var result = new List<ValidationResult>();
            Validator.TryValidateObject(carta, context, result, true);
            return result;
        }

        [Fact]
        public void NomeDeveSerObrigatorio()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.Nome = null;

            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo Nome é obrigatório."));
        }

        [Fact]
        public void ManaDeveSerObrigatorio()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.Mana = null;

            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo Mana é obrigatório."));
        }

        [Fact]
        public void CustoDeManaDeveSerNaoNegativo()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.CustoDeMana = -1;

            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo Custo de Mana deve ser um número não negativo."));
        }

        [Fact]
        public void TipoDeveSerObrigatorio()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.Tipo = null;

            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo Tipo é obrigatório."));
        }

        [Fact]
        public void TextoDeveSerObrigatorio()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.Texto = null;

            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo Texto é obrigatório."));
        }

        [Fact]
        public void PoderDeveSerNaoNegativo()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.Poder = -1;

            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo Poder deve ser um número não negativo."));
        }

        [Fact]
        public void ResistenciaDeveSerNaoNegativa()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.Resistencia = -1;

            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo Resistência deve ser um número não negativo."));
        }

        [Fact]
        public void LealdadeDeveSerNaoNegativa()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.Lealdade = -1;

            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo Lealdade deve ser um número não negativo."));
        }

        [Fact]
        public void FlavorTextDeveSerObrigatorio()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.FlavorText = null;

            // Act
            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo FlavorText é obrigatório."));
        }

        [Fact]
        public void RaridadeDeveSerNaoNegativa()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.Raridade = -1;

            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo Raridade deve ser um número não negativo."));
        }

        [Fact]
        public void LegalidadesIdDeveSerNaoNegativo()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.LegalidadesId = -1;

            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo LegalidadesId deve ser um número não negativo."));
        }

        [Fact]
        public void ImagemUrisIdDeveSerNaoNegativo()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.ImagemUrisId = -1;

            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo ImagemUrisId deve ser um número não negativo."));
        }

        [Fact]
        public void ColecaoIdDeveSerNaoNegativo()
        {
            // Arrange
            var carta = CreateValidCarta();
            carta.ColecaoId = -1;

            // Act
            var result = GetValidationResults(carta);

            // Assert
            Assert.True(result.Count > 0);
            Assert.True(result.Exists(r => r.ErrorMessage == "O campo ColecaoId deve ser um número não negativo."));
        }
    }
}

