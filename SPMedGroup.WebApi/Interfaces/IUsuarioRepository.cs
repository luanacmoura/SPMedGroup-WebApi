using SPMedGroup.WebApi.Domains;
using System.Collections.Generic;

namespace SPMedGroup.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
         Usuarios BuscarPorEmailSenha(string email, string senha);

        Usuarios BuscarPorId(int id);

        void Cadastrar(Usuarios usuario);

        void Editar(Usuarios usuario);
    }
}
