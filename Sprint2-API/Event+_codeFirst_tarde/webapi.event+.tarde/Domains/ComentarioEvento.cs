using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(ComentarioEvento))]
    public class ComentarioEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descricao do evento é obrigatória!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "informacoes sobre a exibicao sao obrigatorias!")]
        public bool Exibe { get; set; }

        //ref. tabela Usuario
        [Required(ErrorMessage = "Usuario obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }


        //ref. tabela Evento

        [Required(ErrorMessage = "Evento obrigatório!")]
        public Guid IdEvento { get; set; }


        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
