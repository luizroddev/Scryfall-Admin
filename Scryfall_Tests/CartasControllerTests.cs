using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Scryfall_Admin.Controllers;
using Scryfall_Admin.Data;
using Scryfall_Admin.Enums;
using Scryfall_Admin.Models;
using Xunit;

namespace Scryfall_Admin.Tests
{
    public class CartasControllerTests
    {
        private ApplicationDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);

            return context;
        }

        private Carta CreateValidCarta(int? id)
        {
            return new Carta
            {
                Id = id ?? 0,
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

        [Fact]
        public async Task Index_ReturnsAViewResult_WithACachedCardList2()
        {
            // Arrange
            var serviceProvider = new ServiceCollection()
                .AddMemoryCache()
                .BuildServiceProvider();

            var memoryCache = serviceProvider.GetRequiredService<IMemoryCache>();
            var dbContext = CreateInMemoryContext();

            var controller = new CartasController(dbContext, memoryCache);

            var fakeCachedCardList = new List<Carta>
        {
            CreateValidCarta(1),
            CreateValidCarta(2),
        };

            memoryCache.Set("cachedCardList", fakeCachedCardList, TimeSpan.FromMinutes(10));

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Carta>>(viewResult.Model);
            Assert.Equal(fakeCachedCardList, model);
        }

        [Fact]
        public async Task Details_ReturnsAViewResult_WithCard()
        {
            // Arrange
            using var context = CreateInMemoryContext();
            var carta = CreateValidCarta(0);
            context.Cartas.Add(carta);
            context.SaveChanges();

            // Arrange
            var serviceProvider = new ServiceCollection()
                .AddMemoryCache()
                .BuildServiceProvider();

            var memoryCache = serviceProvider.GetRequiredService<IMemoryCache>();
            var controller = new CartasController(context, memoryCache);

            memoryCache.Set($"cachedCardDetails_0", carta, TimeSpan.FromMinutes(10));


            // Act
            var result = await controller.Details(0);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Carta>(viewResult.ViewData.Model);
            Assert.Equal("Nome válido", model.Nome);
        }

        [Fact]
        public IActionResult Create_ReturnsViewResult()
        {
            // Arrange
            using var context = CreateInMemoryContext();
            var mockContext = new Mock<ApplicationDbContext>();
            var mockMemoryCache = new Mock<IMemoryCache>();
            var controller = new CartasController(context, mockMemoryCache.Object);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);

            return result;
        }

        [Fact]
        public async Task Create_Post_ReturnsRedirectToActionResult_WithValidModel()
        {
            // Arrange
            using var context = CreateInMemoryContext();
            var mockMemoryCache = new Mock<IMemoryCache>();
            var controller = new CartasController(context, mockMemoryCache.Object);
            var carta = CreateValidCarta(3);

            // Act
            var result = await controller.Create(carta);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        // Outros testes...

        [Fact]
        public async Task Delete_ReturnsAViewResult_WithCard()
        {
            // Arrange
            using var context = CreateInMemoryContext();
            var carta = CreateValidCarta(3);
            context.Cartas.Add(carta);
            context.SaveChanges();

            var mockMemoryCache = new Mock<IMemoryCache>();
            var controller = new CartasController(context, mockMemoryCache.Object);

            // Act
            var result = await controller.Delete(3);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Carta>(viewResult.ViewData.Model);
            Assert.Equal("Nome válido", model.Nome);
        }
    }
}
