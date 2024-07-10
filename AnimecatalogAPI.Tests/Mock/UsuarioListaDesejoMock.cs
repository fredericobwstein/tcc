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
    public class UsuarioListaDesejoMock : IMockBase<IUsuarioListaDesejoRepository>
    {
        private readonly Mock<IUsuarioListaDesejoRepository> _mock;

        public UsuarioListaDesejoMock() => _mock = new Mock<IUsuarioListaDesejoRepository>();

        public Mock<IUsuarioListaDesejoRepository> SetupQueries()
        {
            _mock.Setup(repo => repo.GetAll<UsuarioListaDesejo>())
                .Returns(new List<UsuarioListaDesejo>
                {
                    new UsuarioListaDesejo
                    {
                        Id = Guid.NewGuid(),
                        UsuarioId = Guid.NewGuid(),
                        MalId = 1,
                        DataCadastro = DateTime.Now,
                    }
                });
            return _mock;
        }
    }
}
