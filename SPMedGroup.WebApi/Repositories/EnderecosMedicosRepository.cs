using SPMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SPMedGroup.WebApi.Domains;

namespace SPMedGroup.WebApi.Repositories
{
    public class EnderecosMedicosRepository : IEnderecosMedicosRepository
    {
        public void Cadastrar(EnderecosMedicos endereco)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.EnderecosMedicos.Add(endereco);
                ctx.SaveChanges();
            }
        }
    }
}
