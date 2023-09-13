using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codeFisrt.tarde.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do jogo obrigatório !")]
        public string Nome { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Descricao do jogo")]
        public string? Descricao { get; set; }


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lancamento do jogo eh obrigatoria!")]
        public DateTime DataLancamento { get; set; }


        [Column(TypeName = "Decimal(4,2)")]
        [Required(ErrorMessage ="Preco do jogo eh obrigatorio !")]
        public decimal Preco { get; set; }

        //referencia da tabela estudio (FK)

        public Guid IdEstudio { get; set; }


        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set; }
    }

}
