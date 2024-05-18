namespace AnimecatalogAPI.Core.Entities
{
    public class ListaDesejos
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public List<ListaDesejosAnimes> ListaDesejosAnimes { get; set; }

        // Chave estrangeira
        public Usuario Usuario { get; set; }
    }

}
