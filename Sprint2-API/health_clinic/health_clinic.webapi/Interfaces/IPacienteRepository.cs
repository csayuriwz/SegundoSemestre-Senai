using health_clinic.webapi.Domain;

namespace health_clinic.webapi.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);

        void Deletar(Guid id);

        Paciente BuscarPorCPF(Guid id);

        List<Consulta> ListarMinhasConsultasP();

    }
}
// catarina é insana