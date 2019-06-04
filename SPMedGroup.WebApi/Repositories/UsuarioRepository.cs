using Microsoft.EntityFrameworkCore;
using SPMedGroup.WebApi.Domains;
using SPMedGroup.WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SPMedGroup.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                Usuarios Usuario = new Usuarios();
                Usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
                // busca o nome do tipo de usuário na tabela correspondente
                if (Usuario != null)
                {
                    return Usuario;
                }
                return null;
            }
        }

        public Usuarios BuscarPorId (int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                Usuarios usuario = new Usuarios();
                usuario = ctx.Usuarios.FirstOrDefault(x => x.Id == id);
                if (usuario != null)
                {
                    return usuario;
                }
                return null;
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Editar (Usuarios usuario) {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> ListarUsuarios()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Usuarios.Include(x => x.Medicos).Include(x => x.ProntuarioPaciente).ToList();
            }
        }
    }

    }

