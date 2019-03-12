using System;
using System.Collections.Generic;

namespace SPMedGroup.WebApi.Domains
{
    public partial class AreaClinica
    {
        public AreaClinica()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
