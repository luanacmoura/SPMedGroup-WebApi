using SPMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SPMedGroup.WebApi.Domains;

namespace SPMedGroup.WebApi.Repositories
{
    class ClinicaRepository : IClinicaRepository
    {

        public void Cadastrar(Clinica clinica)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();
            }
        }
    }
}
