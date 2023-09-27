using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.event_.tarde.Domains;

namespace health_clinic.webapi.Domain
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "A CNPJ é obrigatória!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereco é obrigatório!")]
        public string? Endereco { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome Fantasia é obrigatório!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A razão social é obrigatória!")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "O horario de funcionamento é obrigatório!")]
        public DateTime? HorarioFuncionamento { get; set; }

    }
}
