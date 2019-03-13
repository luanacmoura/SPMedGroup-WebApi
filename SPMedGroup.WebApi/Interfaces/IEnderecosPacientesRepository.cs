using SPMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPMedGroup.WebApi.Interfaces
{
    interface IEnderecosPacientesRepository
    {
        void Cadastrar(EnderecosPacientes endereco);
    }
}
