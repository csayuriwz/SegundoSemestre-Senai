using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_clinic.webapi.Domain
{
    [Table(nameof(Feedback))]
    public class Feedback
    {
        [Key]
        public Guid IdFeedBack { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A descricao da consulta é obrigatória!")]
        public string? Descricao { get; set; }

        //referencia a tabela de consulta

        [Required(ErrorMessage = "A Consulta é obrigatória!")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
