using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IComentarioEvento
    {
        void Cadastrar( ComentarioEvento comentarioevento);

        void Deletar(Guid id);

        ComentarioEvento BuscarPorId(Guid id);

        void Atualizar(Guid id, ComentarioEvento comentarioevento);

        List<ComentarioEvento> ListarTodos();
    }
}
