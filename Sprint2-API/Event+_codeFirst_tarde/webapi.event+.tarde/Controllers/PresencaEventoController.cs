using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaEventoController : ControllerBase
    {
        private IPresencaEventoRepository _presencaEventoRepository { get; set; }

        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();
        }

        [HttpPost]
        public IActionResult Post(PresencaEvento pevento)
        {
            try
            {
                _presencaEventoRepository.Cadastrar(pevento);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_presencaEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaEventoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencaEventoRepository.ListarTodos());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.Atualizar(id, presencaEvento);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(Guid id)   
        {
            try
            {
                List<PresencaEvento> ListarMinhasPresencas = _presencaEventoRepository.ListarMinhasPresencas(id);

                return Ok(ListarMinhasPresencas);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}

