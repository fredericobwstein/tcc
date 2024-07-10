using AnimecatalogAPI.Core.Entities;
using AnimecatalogAPI.Core.Exception;
using AnimecatalogAPI.Core.Messaging;
using AnimecatalogAPI.Core.Repository;
using AnimecatalogAPI.Core.Repository.Usuario;

using BC = BCrypt.Net.BCrypt;

namespace AnimecatalogAPI.Core.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;
        private IUsuarioRepository @object;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioService(IUsuarioRepository @object)
        {
            this.@object = @object;
        }

        public void AddUsuario(PostUsuarioRequest request)
        {

            if(string.IsNullOrEmpty(request.Email))
                throw new AnimecatalogException("Email é obrigatório.");

            if (string.IsNullOrEmpty(request.Nome))
                throw new AnimecatalogException("Nome é obrigatório.");

            if (string.IsNullOrEmpty(request.Senha))
                throw new AnimecatalogException("Senha é obrigatório.");

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
            catch (System.Exception ex) 
            {
                throw new AnimecatalogException("Email já cadastrado.");
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

            return null;
        }
    }
}
