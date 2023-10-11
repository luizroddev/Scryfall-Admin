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
    public class ColecaosControllerTests
    {
        private readonly ApplicationDbContext _context;

        public static Colecao CreateValidColecao(int? id)
        {
            var colecao = new Colecao
            {
                ColecaoId = id ?? 0,
                Nome = "Nome da Colecao",
                Descricao = "Descrição da Colecao"
            };

            return colecao;
        }

        public ColecaosControllerTests()
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
            var controller = new ColecaosController(_context);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Detalhes_RetornaNaoEncontrado_QuandoIdEhNulo()
        {
            // Arrange
            var controller = new ColecaosController(_context);

            // Act
            var result = await controller.Details(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Criar_RetornaViewResult_QuandoModelStateNaoEhValido()
        {
            // Arrange
            var controller = new ColecaosController(_context);
            controller.ModelState.AddModelError("Nome", "O campo Nome é obrigatório.");

            // Act
            var result = await controller.Create(new Colecao());

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task ExcluirConfirmado_RetornaRedirectToActionResult()
        {
            // Arrange
            var colecao = CreateValidColecao(1);
            _context.Colecao.Add(colecao);
            _context.SaveChanges();

            var controller = new ColecaosController(_context);

            // Act
            var result = await controller.DeleteConfirmed(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void ColecaoExiste_RetornaVerdadeiro_QuandoExiste()
        {
            // Arrange
            var colecao = CreateValidColecao(1);
            _context.Colecao.Add(colecao);
            _context.SaveChanges();

            var controller = new ColecaosController(_context);

            // Act
            var existe = controller.ColecaoExists(1);

            // Assert
            Assert.True(existe);
        }

        [Fact]
        public void ColecaoExiste_RetornaFalso_QuandoNaoExiste()
        {
            // Arrange
            var controller = new ColecaosController(_context);

            // Act
            var existe = controller.ColecaoExists(999);

            // Assert
            Assert.False(existe);
        }
    }
}
