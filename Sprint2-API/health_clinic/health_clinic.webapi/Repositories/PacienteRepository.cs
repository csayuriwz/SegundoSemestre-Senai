using health_clinic.webapi.Context;
using health_clinic.webapi.Domain;
using health_clinic.webapi.Interfaces;

namespace health_clinic.webapi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ClinicContext _clinicContext;

        public PacienteRepository()
        {
            _clinicContext = new ClinicContext();
        }
        public Paciente BuscarPorCPF(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Paciente paciente)
        {
            _clinicContext.Paciente.Add(paciente);

            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Paciente pacienteB = _clinicContext.Paciente.Find(id);

                if (pacienteB != null)
                {
                    _clinicContext.Paciente.Remove(pacienteB);
                }

                _clinicContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> ListarMinhasConsultasP()
        {
            throw new NotImplementedException();
        }
    }
}
