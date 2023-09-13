using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codeFisrt.tarde.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();



        [Column(TypeName = "VARCHAR(100)")]
        [Required (ErrorMessage = "O tipo do usuario eh obrigatorio!")]
        public string Titulo { get; set; }

    }
}
