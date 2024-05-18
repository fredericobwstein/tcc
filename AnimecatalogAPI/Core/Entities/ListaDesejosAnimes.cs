namespace AnimecatalogAPI.Core.Entities
{
    public class ListaDesejosAnimes
    {
        public int ListaDesejosId { get; set; }
        public ListaDesejos ListaDesejos { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }
    }

}
