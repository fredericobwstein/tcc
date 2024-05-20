namespace AnimecatalogAPI.Core.Entities
{
    public class ListaDesejos
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public List<ListaDesejosAnimes> ListaDesejosAnimes { get; set; }

        public Usuario Usuario { get; set; }
    }

}
