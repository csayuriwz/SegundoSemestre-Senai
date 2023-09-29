using health_clinic.webapi.Context;
using health_clinic.webapi.Domain;
using health_clinic.webapi.Interfaces;

namespace health_clinic.webapi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ClinicContext _clinicContext;

        public MedicoRepository()
        {
            _clinicContext = new ClinicContext();
        }
        public void Atualizar(Guid id, Medico medico)
        {
            throw new NotImplementedException();
        }

        public Medico BuscarPorEspecialidade(Especialidade especialidade)
        { throw new NotImplementedException(); }

        

        public void Cadastrar(Medico medico)
        {
            _clinicContext.Medico.Add(medico);

            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Medico medicoB = _clinicContext.Medico.Find(id);

                if (medicoB != null)
                {
                    _clinicContext.Medico.Remove(medicoB);
                }

                _clinicContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> ListarMinhasConsultasM(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
