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


        /// <summary>
        /// EndPoint que acessa o metodo para deletar generos cadastrados
        /// </summary>
        /// <param name="id">Id do objeto cadastrado</param>
        /// <returns>status code</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return Ok(id);
                //return StatusCode(201, int id);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
        /// <summary>
        /// EndPoint para acessar um metodo que busca generos por seu ID
        /// </summary>
        /// <param name="id">id do objeto a ser buscado</param>
        /// <returns>genero buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado == null)
                {
                    return NotFound("o genero buscado nao foi encontrado !");
                }
                return Ok(generoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint para acessar um metodo que atualiza os generos por seus respectivos id's
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);

                if (generoBuscado != null)
                {

                    try
                    {
                       _generoRepository.AtualizarIdCorpo(genero);
                       return NoContent();
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);
                    }
                           
                }
                return NotFound("Genero nao encontrado !");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);

            }

        }


        /// <summary>
        /// EndPoint que atualiza os generos por sua URL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id,GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado != null)
                {

                    try
                    {
                        _generoRepository.atualizarIdUrl(id,genero);
                        return NoContent();
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);
                    }

                }
                return NotFound("Genero nao encontrado !");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);

            }
        }
        
    }
}
