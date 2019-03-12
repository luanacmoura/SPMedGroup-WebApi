using Microsoft.EntityFrameworkCore;
using SPMedGroup.WebApi.Domains;
using SPMedGroup.WebApi.Interfaces;
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
                if (Usuario != null)
                {
                    return Usuario;
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
    }
}
