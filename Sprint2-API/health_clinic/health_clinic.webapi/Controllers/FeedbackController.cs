using health_clinic.webapi.Domain;
using health_clinic.webapi.Interfaces;
using health_clinic.webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace health_clinic.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FeedbackController : ControllerBase
    {
        private IFeedbackRepository _feedbackRepository { get; set; }

        public FeedbackController()
        {
            _feedbackRepository = new FeedbackRepository();
        }

        [HttpPost]
        public IActionResult Post(Feedback feedback)
        {
            try
            {
                _feedbackRepository.Cadastrar(feedback);

                return StatusCode(201);
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
                _feedbackRepository.Deletar(id);

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
                return Ok(_feedbackRepository.ListarTodos());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
