using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domain
{
    public class JogosDomain
    {
        public int IdJogos { get; set; }

        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O Nome eh obrigatorio !")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descricao eh obrigatoria !")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data eh obrigatoria !")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O Valor eh obrigatorio !")]
        public decimal Valor { get; set; }

        public EstudiosDomain Estudio { get; set; }
    }
}
