using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Domains
{
    public class InfoAtendimento
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("latitude")]
        [BsonRequired]
        public string Latitude { get; set; }
        [BsonElement("longitude")]
        public string Longitude { get; set; }
        [Required(ErrorMessage = "Insira o id da área clínica!")]
        public int IdAreaClinica { get; set; }

        public AreaClinica IdAreaClinicaNavigation { get; set; }
        [Required(ErrorMessage = "Insira a idade do paciente!")]
        public int IdadePaciente { get; set; }
    }
}
