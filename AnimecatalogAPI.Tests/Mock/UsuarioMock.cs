using AnimecatalogAPI.Core.Entities;
using AnimecatalogAPI.Core.Repository.Usuario;
using AnimecatalogAPI.Tests.Mock.Base;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimecatalogAPI.Tests.Mock
{
    public class UsuarioMock : IMockBase<IUsuarioRepository>
    {   
        private readonly Mock<IUsuarioRepository> _mock;

        public UsuarioMock() => _mock = new Mock<IUsuarioRepository>();

        public Mock<IUsuarioRepository> SetupQueries()
        {
            _mock.Setup(repo => repo.GetAll<Usuario>())
                .Returns(new List<Usuario>
                {
                    new Usuario
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Teste",
                        Email = "Teste",
                        Senha = "Teste",
                        DataCadastro = DateTime.Now
                    }
                });
            return _mock;
        }
    }
}
