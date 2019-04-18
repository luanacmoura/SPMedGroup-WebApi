using SPMedGroup.WebApi.Domains;
using System.Collections.Generic;

namespace SPMedGroup.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
         Usuarios BuscarPorEmailSenha(string email, string senha);

        void Cadastrar(Usuarios usuario);
    }
}
