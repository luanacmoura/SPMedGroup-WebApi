using SPMedGroup.WebApi.Domains;
using System.Collections.Generic;

namespace SPMedGroup.WebApi.Interfaces
{
    interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);

        void Editar( Consulta consulta);

        void Cancelar(int id);

        Consulta BuscarPorId(int id);

        List<Consulta> ListarTodas();

        List<Consulta> ListardoMedico(int id);

        List<Consulta> ListardoPaciente();
    }
}
