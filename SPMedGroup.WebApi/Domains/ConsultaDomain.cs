using SPMedGroup.WebApi.Domains.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Domains
{
    [Table("Consulta")]
    public class ConsultaDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsultaId { get; set; }

        [Required (ErrorMessage = "Insira o id do paciente!")]
        public int ProntuarioPacienteId { get; set; }

        [ForeignKey("ProntuarioPacienteId")]
        public ProntuarioPacientesDomain paciente { get; set; }

        [Required(ErrorMessage = "Insira o id do médico!")]
        public int MedicoId { get; set; }

        [ForeignKey("MedicoId")]
        public MedicoDomain Medico { get; set; }

        [Required (ErrorMessage = "Informe a data da consulta!")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida!")] //nesse caso a data pode passar da data atual pq pode agendar a consulta pra dps
        public DateTime DataConsulta { get; set; }

        [Column(TypeName = "varchar(250)")]
        [DefaultValue(3)] //O valor padrão é 3 - aguardando!
        public EnStatusConsulta StatusConsulta { get; set; }
    }
}
