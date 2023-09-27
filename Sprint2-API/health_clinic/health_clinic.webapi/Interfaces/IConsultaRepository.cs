using health_clinic.webapi.Domain;
using webapi.event_.tarde.Domains;

namespace health_clinic.webapi.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);

        void Deletar(Guid id);

        void Atualizar(Guid id, Consulta consulta);

        //usado somente por adm
        List<Consulta> ListarTodos();

    }
}
