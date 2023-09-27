using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_clinic.webapi.Domain
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O telefone é obrigatório!")]
        public string? Telefone { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public DateTime? DataNascimento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereco é obrigatório!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O CPF é obrigatório!")]
        public string? CPF { get; set; }

        //referencias para a tabela de usuario

        [Required(ErrorMessage = "O usuario é obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
