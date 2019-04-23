using SPMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SPMedGroup.WebApi.Domains;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SPMedGroup.WebApi.Repositories
{
    public class MedicosRepository : IMedicosRepository
    {
        public Medicos Cadastrar(Medicos medico)
        {
            Usuarios usuario = new Usuarios();

            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                usuario = ctx.Usuarios.Find(medico.IdUsuario);

                if (usuario.IdTipoUsuarios != 2)
                {
                    return null;
                }

                if (ctx.ProntuarioPaciente.Find(medico.IdUsuario) != null) //Pra que ele não possa cadastrar um paciente num usuário que já exista!
                {
                    return null;
                }
                else
                {
                    ctx.Medicos.Add(medico);
                    ctx.SaveChanges();
                    return medico;
                }
            }
        }

        
    }
}
