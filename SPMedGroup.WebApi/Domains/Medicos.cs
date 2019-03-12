using System;
using System.Collections.Generic;

namespace SPMedGroup.WebApi.Domains
{
    public partial class Medicos
    {
        public string Crm { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int IdAreaClinica { get; set; }
        public int IdEndereco { get; set; }
        public int IdUsuario { get; set; }

        public AreaClinica IdAreaClinicaNavigation { get; set; }
        public EnderecosMedicos IdEnderecoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
