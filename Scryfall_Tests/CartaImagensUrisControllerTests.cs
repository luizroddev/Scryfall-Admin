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
    public class CartaImagensUrisControllerTests
    {
        private readonly ApplicationDbContext _context;

        public static CartaImagensUris CreateValidImagemUri(int? id)
        {
            var imagemUri = new CartaImagensUris
            {
                Id = id ?? 0,
                Small = "SmallUri",
                Normal = "NormalUri",
                Large = "LargeUri"
            };

            return imagemUri;
        }

        public CartaImagensUrisControllerTests()
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
            var controller = new CartaImagensUrisController(_context);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Detalhes_RetornaNaoEncontrado_QuandoIdEhNulo()
        {
            // Arrange
            var controller = new CartaImagensUrisController(_context);

            // Act
            var result = await controller.Details(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Criar_RetornaViewResult_QuandoModelStateNaoEhValido()
        {
            // Arrange
            var controller = new CartaImagensUrisController(_context);
            controller.ModelState.AddModelError("Small", "O campo Small é obrigatório.");

            // Act
            var result = await controller.Create(new CartaImagensUris());

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task ExcluirConfirmado_RetornaRedirectToActionResult()
        {
            // Arrange
            var imagemUri = CreateValidImagemUri(1);
            _context.ImageUris.Add(imagemUri);
            _context.SaveChanges();

            var controller = new CartaImagensUrisController(_context);

            // Act
            var result = await controller.DeleteConfirmed(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void CartaImagensUrisExiste_RetornaVerdadeiro_QuandoExiste()
        {
            // Arrange
            var imagemUri = CreateValidImagemUri(1);
            _context.ImageUris.Add(imagemUri);
            _context.SaveChanges();

            var controller = new CartaImagensUrisController(_context);

            // Act
            var existe = controller.CartaImagensUrisExists(1);

            // Assert
            Assert.True(existe);
        }

        [Fact]
        public void CartaImagensUrisExiste_RetornaFalso_QuandoNaoExiste()
        {
            // Arrange
            var controller = new CartaImagensUrisController(_context);

            // Act
            var existe = controller.CartaImagensUrisExists(999);

            // Assert
            Assert.False(existe);
        }
    }
}
