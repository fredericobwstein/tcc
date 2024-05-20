namespace AnimecatalogAPI.Core.Entities
{
    public class Anime
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Genero { get; set; }
        public DateTime DataLancamento { get; set; }
        public float Avaliacao { get; set; }
        public string Imagem { get; set; }

        public List<ListaDesejosAnimes> ListaDesejosAnimes { get; set; }
    }

}
