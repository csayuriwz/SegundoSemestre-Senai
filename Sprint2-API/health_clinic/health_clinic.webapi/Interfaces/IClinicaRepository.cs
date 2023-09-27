using health_clinic.webapi.Domain;
using webapi.event_.tarde.Domains;

namespace health_clinic.webapi.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);

        void Deletar(Guid id);

        void Atualizar(Guid id, Clinica clinica);
    }
}
