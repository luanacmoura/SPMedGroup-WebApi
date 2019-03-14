﻿using SPMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SPMedGroup.WebApi.Domains;

namespace SPMedGroup.WebApi.Repositories
{
    public class ProntuarioPacienteRepository : IProntuarioPacienteRepository
    {

        public ProntuarioPaciente Cadastrar(ProntuarioPaciente paciente)
        {   

            Usuarios usuario = new Usuarios();

            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                usuario = ctx.Usuarios.Find(paciente.IdUsuario);

                if (usuario.IdTipoUsuarios != 3)
                {
                    return null;
                }

                if (ctx.ProntuarioPaciente.Find(paciente.IdUsuario)!=null) //Pra que ele não possa cadastrar um paciente num usuário que já exista!
                {
                    return null;
                }
                if (paciente.DataNasc > DateTime.Now)
                {
                    return null;
                }
                else
                {
                    ctx.ProntuarioPaciente.Add(paciente);
                    ctx.SaveChanges();
                    return paciente;

                }

            }

        }

    }
}
