using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TipoUsuarioRepository()  
        {
            _eventContext = new EventContext();
        }
      
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            TipoUsuario tusuarioB = _eventContext.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);

            if (tusuarioB != null)
            {
                tusuarioB.Titulo = tipoUsuario.Titulo;

            }

            _eventContext.TipoUsuario.Update(tusuarioB);

            _eventContext.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            return _eventContext.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id)!;
        }

        public void Cadastrar(TipoUsuario tipousuario)
        {
            try
            {
                _eventContext.TipoUsuario.Add(tipousuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoEvento tusuarioB = _eventContext.TipoEvento.Find(id);

                if (tusuarioB != null)
                {
                    _eventContext.TipoEvento.Remove(tusuarioB);
                }

                _eventContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> ListarTodos()
        {
            return _eventContext.TipoUsuario.ToList();
        }
    }
}
