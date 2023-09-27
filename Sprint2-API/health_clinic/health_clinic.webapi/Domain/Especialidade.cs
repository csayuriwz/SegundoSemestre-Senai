using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.event_.tarde.Domains;

namespace health_clinic.webapi.Domain
{
    [Table(nameof(Especialidade))]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Titulo do tipo da especialidade é obrigatório!")]
        public string? Titulo { get; set; }
    }
}
