using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    ///  Interface responsavel pelo repositorio de filmes FilmeRepository
    ///  Definir os metodos que serao implementados pelo repositorio
    /// </summary>
    public interface IFilmeRepository
    {

        //CRUD

        //TipoDeRetorno, Nome do metodo(TipoParametro NomeParametros)


        /// <summary>
        /// Cadastrar um novo objeto(filme)
        /// </summary>
        /// <param name="novoFilme">objeto que sera cadastrado</param>

        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Retornar todos os generos cadastrados
        /// </summary>
        /// <returns>Uma Lista De Generos</returns>

        List<FilmeDomain> ListarTodos();


        /// <summary>
        /// Biscar um objeto atraves do seu id
        /// </summary>
        /// <param name="id">id do objeto que sera buscado</param>
        /// <returns>objeto que foi buscado</returns>
        FilmeDomain BuscarPorId(int id);


        /// <summary>
        /// Atualiza um filme existentr passando o ID pelo corpo da requisicao
        /// </summary>
        /// <param name="filme">Objeto filme com as novas informacoes</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualizar um filme existente passando o id pela URL da requisicao
        /// </summary>
        /// <param name="id"Id do objeto a ser atualizado></param>
        /// <param name="genero">objeto com as novas informacoes</param>
        void atualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um filme existente pelo id
        /// </summary>
        /// <param name="id">id do objeto a ser deletado</param>
        void Deletar(int id);
    }
}
