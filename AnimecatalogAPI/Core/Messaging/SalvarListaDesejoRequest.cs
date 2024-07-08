namespace AnimecatalogAPI.Core.Messaging
{
    public class SalvarListaDesejoRequest
    {
        List<string> maiId { get; set; }
        Guid IdUsuario { get; set; }
    }
}
