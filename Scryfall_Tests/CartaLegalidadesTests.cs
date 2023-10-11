using System;
using System.Collections.Generic;
using Xunit;
using Scryfall_Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace Scryfall_Admin.Tests
{
    public class CartaLegalidadesTests
    {
        [Fact]
        public void TestCartaLegalidadesValid()
        {
            // Arrange
            var cartaLegalidades = new CartaLegalidades
            {
                Standard = "Standard",
                Modern = "Modern",
                Legacy = "Legacy",
                Pauper = "Pauper",
                Duel = "Duel",
                Predh = "Predh"
            };

            var validationContext = new ValidationContext(cartaLegalidades, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(cartaLegalidades, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid, "A validação falhou. Erros de validação: " + string.Join(", ", validationResults));
        }

        [Fact]
        public void TestCartaLegalidadesMissingStandard()
        {
            // Arrange
            var cartaLegalidades = new CartaLegalidades
            {
                Modern = "Modern",
                Legacy = "Legacy",
                Pauper = "Pauper",
                Duel = "Duel",
                Predh = "Predh"
            };

            var validationContext = new ValidationContext(cartaLegalidades, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(cartaLegalidades, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "A validação deveria falhar, pois o campo Standard está ausente.");
        }

        [Fact]
        public void TestCartaLegalidadesModernTooLong()
        {
            // Arrange
            var cartaLegalidades = new CartaLegalidades
            {
                Standard = "Standard",
                Modern = "ModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModernModern",
                Legacy = "Legacy",
                Pauper = "Pauper",
                Duel = "Duel",
                Predh = "Predh"
            };

            var validationContext = new ValidationContext(cartaLegalidades, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(cartaLegalidades, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "A validação deveria falhar, pois o campo Modern tem muitos caracteres.");
        }

        [Fact]
        public void TestCartaLegalidadesLegacyTooShort()
        {
            // Arrange
            var cartaLegalidades = new CartaLegalidades
            {
                Standard = "Standard",
                Modern = "Modern",
                Legacy = "Lg", // Legacy deve ter pelo menos 3 caracteres
                Pauper = "Pauper",
                Duel = "Duel",
                Predh = "Predh"
            };

            var validationContext = new     ValidationContext(cartaLegalidades, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(cartaLegalidades, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "A validação deveria falhar, pois o campo Legacy é muito curto.");
        }

        [Fact]
        public void TestCartaLegalidadesEmptyFields()
        {
            // Arrange
            var cartaLegalidades = new CartaLegalidades();

            var validationContext = new ValidationContext(cartaLegalidades, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(cartaLegalidades, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "A validação deveria falhar, pois todos os campos estão vazios.");
        }
    }
}
