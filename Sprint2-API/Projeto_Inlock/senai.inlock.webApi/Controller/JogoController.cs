using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using senai.inlock.webApi_.Repository;

namespace senai.inlock.webApi_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    public class JogoController : ControllerBase
    {

        private IJogosRepositorycs _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogosRepository();
        }

        [HttpPost]
        public IActionResult Post(JogosDomain novoJogo)
        {

            try
            {
                _jogoRepository.Cadastrar(novoJogo);

                return Created("Objeto criado", novoJogo);
                //return StatusCode(201, novoGenero);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
           
            
            }




        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _jogoRepository.Deletar(id);

                return Ok(id);
                //return StatusCode(201, int id);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                List<JogosDomain> ListaJogos = _jogoRepository.ListarJogos();

                //retorna o status code 200 ok e a lista no formato JSON
                return Ok(ListaJogos);
                //retorna OK lista de jogos
            }
            catch (Exception erro)
            {
                //retorna um status code 400 - bad request, mensagem de erro
                return BadRequest(erro.Message);
            }
        }

    }
}
