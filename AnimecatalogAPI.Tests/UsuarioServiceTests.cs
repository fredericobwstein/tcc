using AnimecatalogAPI.Core.Entities;
using AnimecatalogAPI.Core.Exception;
using AnimecatalogAPI.Core.Messaging;
using AnimecatalogAPI.Core.Services;
using AnimecatalogAPI.Tests.Mock;

using Moq;

namespace AnimecatalogAPI.Tests
{
    public class UsuarioServiceTests
    {
        private readonly UsuarioMock _usuarioMock;
        private readonly UsuarioService _usuarioService;

        public UsuarioServiceTests()
        {
            _usuarioMock = new UsuarioMock();
            _usuarioService = new UsuarioService(_usuarioMock.SetupQueries().Object);
        }

        [Fact]
        public void CadastrarUsuario_UsuarioNomeInvalido_DeveEstourarException()
        {
            // Arrange
            var request = new PostUsuarioRequest
            {
                Nome = "",
                Email = "Teste",
                Senha = "1234",
            };

            // Act & Assert
            var ex = Assert.Throws<AnimecatalogException>(() => _usuarioService.AddUsuario(request));
            Assert.Equal("Nome é obrigatório.", ex.Message);
        }

        [Fact]
        public void CadastrarUsuario_EmailInvalido_DeveEstourarException()
        {
            // Arrange
            var request = new PostUsuarioRequest
            {
                Nome = "Teste",
                Email = "",
                Senha = "1234",
            };

            // Act & Assert
            var ex = Assert.Throws<AnimecatalogException>(() => _usuarioService.AddUsuario(request));
            Assert.Equal("Email é obrigatório.", ex.Message);
        }

        [Fact]
        public void CadastrarUsuario_SenhaInvalida_DeveEstourarException()
        {
            // Arrange
            var request = new PostUsuarioRequest
            {
                Nome = "Teste",
                Email = "Teste",
                Senha = "",
            };

            // Act & Assert
            var ex = Assert.Throws<AnimecatalogException>(() => _usuarioService.AddUsuario(request));
            Assert.Equal("Senha é obrigatório.", ex.Message);
        }
    }
}