using SPMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Interfaces
{
    interface IInfoAtendimentoRepository
    {
         void Cadastrar(InfoAtendimento informacoes);
    }
}
