using AnimecatalogAPI.Core.Entities;

namespace AnimecatalogAPI.Core.Messaging
{
    public class PostLoginResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Token { get; set; }

        public PostLoginResponse(Usuario usuario, string token)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Token = token;
        }
    }
}
