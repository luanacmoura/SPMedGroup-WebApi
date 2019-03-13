using SPMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SPMedGroup.WebApi.Domains;

namespace SPMedGroup.WebApi.Repositories
{
    public class EnderecosPacientesRepository : IEnderecosPacientesRepository
    {
        public void Cadastrar(EnderecosPacientes endereco)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.EnderecosPacientes.Add(endereco);
                ctx.SaveChanges();
            }
        }
    }
}
