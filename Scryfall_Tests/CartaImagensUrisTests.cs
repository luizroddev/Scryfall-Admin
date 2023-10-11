using System;
using System.Collections.Generic;
using Xunit;
using Scryfall_Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace Scryfall_Admin.Tests
{
    public class CartaImagensUrisTests
    {
        [Fact]
        public void TestCartaImagensUrisValid()
        {
            // Arrange
            var imagensUris = new CartaImagensUris
            {
                Small = "small.jpg",
                Normal = "normal.jpg",
                Large = "large.jpg"
            };

            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(imagensUris, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(imagensUris, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid, "A validação falhou. Erros de validação: " + string.Join(", ", validationResults));
        }

        [Fact]
        public void TestCartaImagensUrisLargeTooLong()
        {
            // Arrange
            var imagensUris = new CartaImagensUris
            {
                Small = "small.jpg",
                Normal = "normal.jpg",
                Large = new string('a', 256) // O campo Large excede o comprimento máximo permitido (255)
            };

            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(imagensUris, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(imagensUris, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "A validação deveria falhar, pois o campo Large é muito longo.");
        }
    }
}
