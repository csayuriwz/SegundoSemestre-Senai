using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface ITipoEventoRepository
    {
        void Cadastrar(TipoEvento tipoevento);

        void Deletar(Guid id);

        TipoEvento BuscarPorId(Guid id);

        void Atualizar(Guid id, TipoEvento tipoevento);

        List<TipoEvento> ListarTodos();
    }
}
