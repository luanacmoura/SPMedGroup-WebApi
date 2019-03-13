using SPMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SPMedGroup.WebApi.Domains;

namespace SPMedGroup.WebApi.Repositories
{
    public class ProntuarioPacienteRepository : IProntuarioPacienteRepository
    {
        public void Cadastrar(ProntuarioPaciente paciente)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.ProntuarioPaciente.Add(paciente);
                ctx.SaveChanges();
            }
        }
    }
}
