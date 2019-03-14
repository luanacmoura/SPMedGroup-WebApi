﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.WebApi.Domains
{
    public partial class Medicos
    {
        [Required(ErrorMessage = "Insira o CRM", AllowEmptyStrings = false)]
        [MinLength(5, ErrorMessage = "O CRM precisa conter no mínimo 5 caracteres!")]
        public string Crm { get; set; }

        [Required(ErrorMessage = "Insira o nome!", AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "O nome precisa conter no mínimo 3 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o telefone!", AllowEmptyStrings = false)]
        [MinLength(8, ErrorMessage = "O telefone precisa contr no mínimo 8 caracteres!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Insira o id da área clínica!", AllowEmptyStrings = false)]
        public int IdAreaClinica { get; set; }

        [Required(ErrorMessage = "Insira o id do endereço!", AllowEmptyStrings = false)]
        public int IdEndereco { get; set; }

        [Required(ErrorMessage = "Insira o id do usuário do tipo médico!", AllowEmptyStrings = false)]
        public int IdUsuario { get; set; }

        public AreaClinica IdAreaClinicaNavigation { get; set; }
        public EnderecosMedicos IdEnderecoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
