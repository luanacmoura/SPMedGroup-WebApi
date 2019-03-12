using SPMedGroup.WebApi.Domains;

namespace SPMedGroup.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
         Usuarios BuscarPorEmailSenha(string email, string senha);

        void Cadastrar(Usuarios usuario);
    }
}
