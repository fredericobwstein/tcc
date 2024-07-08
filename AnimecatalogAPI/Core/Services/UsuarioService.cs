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
            try
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
            catch (Exception ex) 
            {
                throw new Exception("Email já cadastrado.");
            }
        }

        public PostLoginResponse Autenticar(LoginRequest request)
        {
            var usuario = _usuarioRepository.GetAll<Usuario>(new { Email = request.Email }).FirstOrDefault();

            if (usuario != null)
            {
                var senhaValida = BC.Verify(request.Senha, usuario?.Senha);

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
