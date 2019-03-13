using SPMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPMedGroup.WebApi.Interfaces
{
    interface IAreaClinicaRepository
    {
        void Cadastrar(AreaClinica area);
    }
}
