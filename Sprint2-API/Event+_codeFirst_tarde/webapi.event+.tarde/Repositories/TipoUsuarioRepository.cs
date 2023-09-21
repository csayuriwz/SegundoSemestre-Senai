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
            throw new NotImplementedException();
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
                TipoEvento usuarioB = _eventContext.TipoEvento.Find(id);

                if (usuarioB != null)
                {
                    _eventContext.TipoEvento.Remove(usuarioB);
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
