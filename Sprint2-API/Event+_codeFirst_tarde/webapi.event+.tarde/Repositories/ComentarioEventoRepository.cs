using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, ComentarioEvento comentarioevento)
        {
            ComentarioEvento comentarioB = _eventContext.ComentarioEvento.Find(id)!;

            if (comentarioB != null)
            {
                comentarioB.Descricao = comentarioevento.Descricao;

                comentarioB.Exibe = comentarioevento.Exibe;

                comentarioB.IdUsuario = comentarioevento.IdUsuario;

                comentarioB.IdEvento = comentarioB.IdEvento;
            }

            _eventContext.ComentarioEvento.Update(comentarioB!);

            _eventContext.SaveChanges();
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            return _eventContext.ComentarioEvento.FirstOrDefault(e => e.IdComentarioEvento == id)!;
        }

        public void Cadastrar(ComentarioEvento comentarioevento)
        {
            _eventContext.ComentarioEvento.Add(comentarioevento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoEvento comentarioB = _eventContext.TipoEvento.Find(id);

                if (comentarioB != null)
                {
                    _eventContext.TipoEvento.Remove(comentarioB);
                }

                _eventContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> ListarTodos()
        {
            return _eventContext.ComentarioEvento.ToList();
        }

    }
}
