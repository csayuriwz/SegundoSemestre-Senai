using health_clinic.webapi.Context;
using health_clinic.webapi.Domain;
using health_clinic.webapi.Interfaces;

namespace health_clinic.webapi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly ClinicContext _clinicContext;

        public ClinicaRepository()
        {
            _clinicContext = new ClinicContext();
        }
        public void Atualizar(Guid id, Clinica clinica)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Clinica clinica)
        {
            _clinicContext.Clinica.Add(clinica);

            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
