using AnimecatalogAPI.Core.Entities;
using AnimecatalogAPI.Core.Messaging;
using AnimecatalogAPI.Core.Repository;
using BC = BCrypt.Net.BCrypt;

namespace AnimecatalogAPI.Core.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void AddUsuario(PostUsuarioRequest request)
        {
            var usuario = new Entities.Usuario
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                Senha = BC.HashPassword(request.Senha),
                DataCadastro = DateTime.Now,
            };

            _usuarioRepository.Insert(usuario);
        }

        public PostLoginResponse Autenticar(string email, string senha)
        {
            var usuario = _usuarioRepository.GetAll<Usuario>(new { Email = email }).FirstOrDefault();

            if (usuario != null)
            {
                var senhaValida = BC.Verify(senha, usuario?.Senha);

                if (senhaValida)
                {
                    var token = Autenticacao.GenerateToken(new Usuario
                    {
                        Nome = usuario.Nome,
                        Id = usuario.Id
                    });
                    return new PostLoginResponse(usuario, token);

                }
            }
            throw new Exception("Email ou senha inválidos.");
        }
    }
}
