using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimecatalogAPI.Core.Entities
{
    [Table("usuario_listadesejo")]
    public class UsuarioListaDesejo
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("usuario_id")]
        public Guid UsuarioId { get; set; }

        [Column("mal_id")]
        public int MalId { get; set; }

        [Column("datacadastro")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
