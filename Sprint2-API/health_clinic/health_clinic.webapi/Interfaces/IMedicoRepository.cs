using health_clinic.webapi.Domain;

namespace health_clinic.webapi.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);

        void Deletar(Guid id);

        void Atualizar(Guid id, Medico medico);

        Medico BuscarPorEspecialidade(Especialidade especialidade);

        List<Consulta> ListarMinhasConsultasM(Guid id);
    }
}
