using SPMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SPMedGroup.WebApi.Domains;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

namespace SPMedGroup.WebApi.Repositories
{
    class ConsultaRepository : IConsultaRepository
    {
        public Consulta BuscarPorId(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Consulta.Find(id);
            }
        }

        public void Cadastrar(Consulta consulta)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Consulta.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public void Cancelar(int id)
        {
            Consulta consulta = new Consulta();
            consulta.Id = id;
            consulta.DataConsulta = BuscarPorId(id).DataConsulta;
            consulta.IdProntuarioPaciente = BuscarPorId(id).IdProntuarioPaciente;
            consulta.IdUsuarioMedico = BuscarPorId(id).IdUsuarioMedico;
            consulta.IdUsuarioPaciente = BuscarPorId(id).IdUsuarioPaciente;
            consulta.StatusConsulta = "Cancelada";

            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Consulta.Update(consulta);
                ctx.SaveChanges();
            }
        }

        public void Editar(Consulta consulta)
        {
            consulta.DataConsulta = BuscarPorId(consulta.Id).DataConsulta;
            consulta.IdProntuarioPaciente = BuscarPorId(consulta.Id).IdProntuarioPaciente;
            consulta.IdUsuarioMedico = BuscarPorId(consulta.Id).IdUsuarioMedico;
            consulta.IdUsuarioPaciente = BuscarPorId(consulta.Id).IdUsuarioPaciente;
            consulta.StatusConsulta = "Realizada";

            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Consulta.Update(consulta);
                ctx.SaveChanges();
            }
        }

        public List<Consulta> ListardoMedico(int usuarioid)
        {
            List<Consulta> listadomedico = new List<Consulta>();
         

            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                int contador = ctx.Consulta.Count();
                int i = 1;

                while (i <= contador)
                {
                    Consulta consulta = new Consulta();
                    consulta = ctx.Consulta.Find(i);
                    if (consulta != null)
                    {
                        if (consulta.IdUsuarioMedico == usuarioid)
                        {
                            listadomedico.Add(consulta);
                        }
                    }
                    i++;
                }

                if (listadomedico.Count > 0)
                {
                    return listadomedico;
                }
                return null;
            }
        }

        public List<Consulta> ListardoPaciente(int usuarioid)
        {
            List<Consulta> listadopaciente = new List<Consulta>();


            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                int contador = ctx.Consulta.Count();
                int i = 1;

                while (i <= contador)
                {
                    Consulta consulta = new Consulta();
                    consulta = ctx.Consulta.Find(i);
                    if (consulta != null)
                    {
                        if (consulta.IdUsuarioMedico == usuarioid)
                        {
                            listadopaciente.Add(consulta);
                        }
                    }
                    i++;
                }

                if (listadopaciente.Count > 0)
                {
                    return listadopaciente;
                }
                return null;
            }
        }

        public List<Consulta> ListarTodas()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return (ctx.Consulta.ToList());
            }
        }
    }
}
