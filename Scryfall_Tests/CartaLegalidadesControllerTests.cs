using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scryfall_Admin.Controllers;
using Scryfall_Admin.Data;
using Scryfall_Admin.Models;
using Xunit;

namespace Scryfall_Admin.Tests
{
    public class CartaLegalidadesControllerTests
    {
        private readonly ApplicationDbContext _context;

        public static CartaLegalidades CreateValidLegalidade(int? id)
        {
            var legalidade = new CartaLegalidades
            {

                Id = id ?? 0,
                Standard = "Standard",
                Modern = "Modern",
                Legacy = "Legacy",
                Pauper = "Pauper",
                Duel = "Duel",
                Predh = "Predh"
            };

            return legalidade;
        }

        public CartaLegalidadesControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
        }

        [Fact]
        public async Task Index_RetornaViewResult()
        {
            // Arrange
            var controller = new CartaLegalidadesController(_context);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Detalhes_RetornaNaoEncontrado_QuandoIdEhNulo()
        {
            // Arrange
            var controller = new CartaLegalidadesController(_context);

            // Act
            var result = await controller.Details(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // Adicione testes semelhantes para as outras ações (Criar, Editar, Excluir).

        [Fact]
        public async Task Criar_RetornaViewResult_QuandoModelStateNaoEhValido()
        {
            // Arrange
            var controller = new CartaLegalidadesController(_context);
            controller.ModelState.AddModelError("Standard", "O campo Standard é obrigatório.");

            // Act
            var result = await controller.Create(new CartaLegalidades());

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        // Implemente testes semelhantes para os métodos Editar e Excluir.

        [Fact]
        public async Task ExcluirConfirmado_RetornaRedirectToActionResult()
        {
            // Arrange
            var legalidade = CreateValidLegalidade(1);
            _context.Legalidades.Add(legalidade);
            _context.SaveChanges();

            var controller = new CartaLegalidadesController(_context);

            // Act
            var result = await controller.DeleteConfirmed(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void CartaLegalidadesExiste_RetornaVerdadeiro_QuandoExiste()
        {
            // Arrange
            var legalidade = CreateValidLegalidade(1);
            _context.Legalidades.Add(legalidade);
            _context.SaveChanges();

            var controller = new CartaLegalidadesController(_context);

            // Act
            var existe = controller.CartaLegalidadesExists(1);

            // Assert
            Assert.True(existe);
        }

        [Fact]
        public void CartaLegalidadesExiste_RetornaFalso_QuandoNaoExiste()
        {
            // Arrange
            var controller = new CartaLegalidadesController(_context);

            // Act
            var existe = controller.CartaLegalidadesExists(999);

            // Assert
            Assert.False(existe);
        }
    }
}
