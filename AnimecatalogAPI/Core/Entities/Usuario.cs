using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimecatalogAPI.Core.Entities
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("senha")]
        public string Senha { get; set; }
        [Column("datacadastro")]
        public DateTime DataCadastro { get; set; }
    }

}
