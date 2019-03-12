using SPMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SPMedGroup.WebApi.Domains;

namespace SPMedGroup.WebApi.Repositories
{
    class ConsultaRepository : IConsultaRepository
    {
        public void Cadastrar(Consulta consulta)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Consulta.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public void CancelarConsulta(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                
            }
        }

        public void Editar(int id, Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ListardoMedico()
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ListardoPaciente()
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ListarTodas()
        {
            throw new NotImplementedException();
        }
    }
}
