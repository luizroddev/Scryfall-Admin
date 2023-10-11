using System;
using System.Collections.Generic;
using Xunit;
using Scryfall_Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace Scryfall_Admin.Tests
{
    public class ColecaoTests
    {
        [Fact]
        public void TestColecaoValid()
        {
            // Arrange
            var colecao = new Colecao
            {
                Nome = "Minha Colecao",
                Descricao = "Esta é uma coleção de cartas."
            };

            var validationContext = new ValidationContext(colecao, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(colecao, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid, "A validação falhou. Erros de validação: " + string.Join(", ", validationResults));
        }

        [Fact]
        public void TestColecaoMissingNome()
        {
            // Arrange
            var colecao = new Colecao
            {
                Descricao = "Esta é uma coleção de cartas."
            };

            var validationContext = new ValidationContext(colecao, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(colecao, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "A validação deveria falhar, pois o campo Nome está ausente.");
        }

        [Fact]
        public void TestColecaoDescricaoTooLong()
        {
            // Arrange
            var colecao = new Colecao
            {
                Nome = "Minha Colecao",
                Descricao = new string('a', 501) // A descrição excede o comprimento máximo permitido (500)
            };

            var validationContext = new ValidationContext(colecao, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(colecao, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "A validação deveria falhar, pois o campo Descrição é muito longo.");
        }
    }
}
