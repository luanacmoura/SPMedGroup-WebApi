using SPMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SPMedGroup.WebApi.Domains;

namespace SPMedGroup.WebApi.Repositories
{
    public class AreaClinicaRepository : IAreaClinicaRepository
    {
        public void Cadastrar(AreaClinica area)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.AreaClinica.Add(area);
                ctx.SaveChanges();
            }
        }
    }
}
