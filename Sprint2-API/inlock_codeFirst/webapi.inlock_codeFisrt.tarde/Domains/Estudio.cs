using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codeFisrt.tarde.Domains
{
    [Table("Estudip")]
    public class Estudio
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Nome Obrigatório!")]
        public string Nome { get; set; }

        public List<Jogo>? Jogos { get; set; }
    }
}
