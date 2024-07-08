using AnimecatalogAPI.Core.Entities;

namespace AnimecatalogAPI
{
    public class UsuarioListasDesejoResponse
    {
        public int MalId { get; set; }

        public UsuarioListasDesejoResponse(UsuarioListaDesejo usuarioListaDesejo)
        {
            MalId = usuarioListaDesejo.MalId;
        }
    }
}