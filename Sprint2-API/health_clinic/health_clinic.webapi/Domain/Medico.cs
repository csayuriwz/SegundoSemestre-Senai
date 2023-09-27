using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.event_.tarde.Domains;

namespace health_clinic.webapi.Domain
{

    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A CRM é obrigatória!")]
        public string? CRM { get; set; }

        //referencias para a tabela clinica

        [Required(ErrorMessage = "A clinica é obrigatória!")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }

        //referencias para a tabela especialidade

        [Required(ErrorMessage = "A especialidade é obrigatória!")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        //referencias para a tabela usuario

        [Required(ErrorMessage = "O usuario é obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

    }
}
