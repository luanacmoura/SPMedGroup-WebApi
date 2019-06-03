using SPMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SPMedGroup.WebApi.Domains;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

                listadomedico = ctx.Consulta.Where(consulta => consulta.IdUsuarioMedico == usuarioid).Include(x => x.IdProntuarioPacienteNavigation).Include(x => x.IdUsuarioMedicoNavigation).Include(x => x.IdUsuarioPacienteNavigation).ToList();

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
                listadopaciente = ctx.Consulta.Where(consulta => consulta.IdUsuarioPaciente == usuarioid).Include(x => x.IdProntuarioPacienteNavigation).Include(x => x.IdUsuarioMedicoNavigation).Include(x => x.IdUsuarioMedicoNavigation.Medicos).Include(x => x.IdUsuarioPacienteNavigation).ToList();

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
                return (ctx.Consulta.Include(x => x.IdProntuarioPacienteNavigation).Include(x => x.IdUsuarioMedicoNavigation).Include(x => x.IdUsuarioPacienteNavigation).ToList());
            }
        }
    }
}
