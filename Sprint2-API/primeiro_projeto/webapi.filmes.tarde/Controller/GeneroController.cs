using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.tarde.Controller
{

    /// <summary>
    /// essa route define que a rota de uma requisicao sera no seguinte formato
    /// dominio/API/controller
    /// exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// define que eh um controlador de api
    /// </summary>
    [ApiController]

    ///<sumary>
    ///defini que o tipo e resposta da api eh json
    ///<sumary>
    [Produces("Application/json")]
    public class GeneroController : ControllerBase
    {

        /// <summary>
        /// Objeto que ira receber os metodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }


        /// <summary>
        /// instancia do objeto _generorepository para que haja referencia aos metodos no repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }


        /// <summary>
        /// Endpoint que acessa o metodo de listar os generos
        /// </summary>
        /// <returns>Lista de generos e um statuscode</returns>
        [HttpGet]
        public IActionResult Get() 
        {

            try
            {
                //Cria uma lista para receber generos
                List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();

                //retorna o status code 200 ok e a lista no formato JSON
                return Ok(ListaGeneros);
                //retorna OK lista generos
            }
            catch (Exception erro) 
            {
                //retorna um status code 400 - bad request, mensagem de erro
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o metodo de cadastrar generos
        /// </summary>
        /// <param name="novoGenero">Objeto recebido a requisicao</param>
        /// <returns>StatusCode(201)</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {

            try
            {
                _generoRepository.Cadastrar(novoGenero);

                return Created("Objeto criado", novoGenero);
                //return StatusCode(201, novoGenero);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return Ok( id);
                //return StatusCode(201, int id);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id)
        { 
             
        }



    }
}
