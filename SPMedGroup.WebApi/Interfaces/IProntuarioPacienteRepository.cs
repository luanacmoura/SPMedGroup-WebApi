﻿using SPMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPMedGroup.WebApi.Interfaces
{
    interface IProntuarioPacienteRepository
    {
        void Cadastrar(ProntuarioPaciente paciente);
    }
}