using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEvento
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
