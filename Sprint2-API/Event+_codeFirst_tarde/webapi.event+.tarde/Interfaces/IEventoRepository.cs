using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IEventoRepository
    {
        //CRUD

        //TipoDeRetorno, Nome do metodo(TipoParametro NomeParametros)
        void Cadastrar(Evento evento);

        void Deletar(Guid id);

        Evento BuscarPorId(Guid id);

        void Atualizar(Guid id, Evento evento);

        List<Evento> ListarTodos();
    }
}
