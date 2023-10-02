using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_clinic.webapi.Domain
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "A data da consulta é obrigatória!")]
        public DateTime DataConsulta{ get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? Prontuario { get; set; }


        //referencias para a tabela paciente

        [Required(ErrorMessage = "O paciente é obrigatório!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        //referencias para a tabela medico

        [Required(ErrorMessage = "O medico é obrigatório!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }
    }
}
