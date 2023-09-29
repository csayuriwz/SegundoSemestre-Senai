using health_clinic.webapi.Context;
using health_clinic.webapi.Domain;
using health_clinic.webapi.Interfaces;
using webapi.event_.tarde.Domains;

namespace health_clinic.webapi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly ClinicContext _clinicContext;

        public TipoUsuarioRepository()
        {
            _clinicContext = new ClinicContext();
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            return _clinicContext.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id)!;
        }

        public void Cadastrar(TipoUsuario tipousuario)
        {
            _clinicContext.TipoUsuario.Add(tipousuario);

            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoUsuario tusuarioB = _clinicContext.TipoUsuario.Find(id);

                if (tusuarioB != null)
                {
                    _clinicContext.TipoUsuario.Remove(tusuarioB);
                }

                _clinicContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> ListarTodos()
        {
            return _clinicContext.TipoUsuario.ToList();
        }
    }
}
