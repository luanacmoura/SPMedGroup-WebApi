using SPMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SPMedGroup.WebApi.Domains;

namespace SPMedGroup.WebApi.Repositories
{
    public class MedicosRepository : IMedicosRepository
    {
        public void Cadastrar(Medicos medico)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Medicos.Add(medico);
                ctx.SaveChanges();
            }
        }
    }
}
