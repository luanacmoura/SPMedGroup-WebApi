using SPMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPMedGroup.WebApi.Interfaces
{
    interface IMedicosRepository
    {
        Medicos Cadastrar(Medicos medico);


    }
}
