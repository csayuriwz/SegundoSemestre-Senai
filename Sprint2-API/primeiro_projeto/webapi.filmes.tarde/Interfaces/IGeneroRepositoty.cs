using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    ///  Interface responsavel pelo repositorio GeneroRepository
    ///  Definir os metodos que serao implementados pelo repositorio
    /// </summary>
    public interface IGeneroRepositoty
    {
        //CRUD

        //TipoDeRetorno, Nome do metodo(TipoParametro NomeParametros)


        /// <summary>
        /// Cadastrar um novo objeto(genero)
        /// </summary>
        /// <param name="novoGenero">objeto que sera cadastrado</param>

        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Retornar todos os generos cadastrados
        /// </summary>
        /// <returns>Uma Lista De Generos</returns>

        List<GeneroDomain> ListarTodos();


        /// <summary>
        /// Biscar um objeto atraves do seu id
        /// </summary>
        /// <param name="id">id do objeto que sera buscado</param>
        /// <returns>objeto que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);


        /// <summary>
        /// Atualiza um genero existentr passando o ID pelo corpo da requisicao
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informacoes</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar um genero existente passando o id pela URL da requisicao
        /// </summary>
        /// <param name="id"Id do objeto a ser atualizado></param>
        /// <param name="genero">objeto com as novas informacoes</param>
        void atualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deleta um genero existente pelo id
        /// </summary>
        /// <param name="id">id do objeto a ser deletado</param>
        void Deletar(int id);

        




    }
}
