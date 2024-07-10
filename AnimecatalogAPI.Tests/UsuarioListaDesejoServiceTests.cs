using AnimecatalogAPI.Core.Entities;
using AnimecatalogAPI.Core.Exception;
using AnimecatalogAPI.Core.Messaging;
using AnimecatalogAPI.Core.Services;
using AnimecatalogAPI.Tests.Mock;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimecatalogAPI.Tests
{
    public class UsuarioListaDesejoServiceTests
    {
        private readonly UsuarioListaDesejoMock _usuarioListaDesejoMock;
        private readonly UsuarioListaDesejoService _usuarioListaDesejoService;

        public UsuarioListaDesejoServiceTests()
        {
            _usuarioListaDesejoMock = new UsuarioListaDesejoMock();
            _usuarioListaDesejoService = new UsuarioListaDesejoService(_usuarioListaDesejoMock.SetupQueries().Object);
        }

        [Fact]
        public void AdicionarListaDesejo_RequestValida_DeveInserirItem()
        {
            // Arrange
            var request = new PostUsuarioListaDesejoRequest
            {
                MalId = 1,
                UserId = new Guid("ef0ec399-0b10-4ffd-bd7a-6380979e5896"),
            };

            _usuarioListaDesejoService.AddListaDesejo(request);

            // Act
            _usuarioListaDesejoMock.SetupQueries().Verify(repo => repo.Insert(It.IsAny<UsuarioListaDesejo>()), Times.Once);
        }

        [Fact]
        public void AdicionarListaDesejo_UsuarioNaoLogado_DeveEstourarException()
        {
            // Arrrange
            var request = new PostUsuarioListaDesejoRequest
            {
                MalId = 1,
                UserId = Guid.Empty
            };

            // Act & Assert
            var ex = Assert.Throws<AnimecatalogException>(() => _usuarioListaDesejoService.AddListaDesejo(request));
            Assert.Equal("Você precisa estar logado para adicionar um item na lista.", ex.Message);
        }

        [Fact]
        public void RemoverItemListaDesejo_RequestValida_DeveRemoverItem()
        {
            // Arrange
            var request = new DeleteUsuarioListaDesejoRequest
            {
                Id = new Guid("8d171c19-81c0-468e-a4b5-bdcf52e2c2dd"),
                MalId = 14,
                UserId = new Guid("ef0ec399-0b10-4ffd-bd7a-6380979e5896"),
            };

            _usuarioListaDesejoService.RemoveItemListaDesejo(request);

            // Act
            _usuarioListaDesejoMock.SetupQueries().Verify(repo => repo.Insert(It.IsAny<UsuarioListaDesejo>()), Times.Once);
        }
    }
}
