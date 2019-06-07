using MongoDB.Driver;
using SPMedGroup.WebApi.Domains;
using SPMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Repositories
{
    public class InfoAtendimentoRepository : IInfoAtendimentoRepository
    {
        private readonly IMongoCollection<InfoAtendimento> _informacoes;

        public InfoAtendimentoRepository()
        {
            // var client = new MongoClient("mongodb://localhost:27017");
            var client = new MongoClient("mongodb+srv://admin:admin@spmedgrouplocal-ih6yy.mongodb.net/test?retryWrites=true&w=majority");

            var database = client.GetDatabase("SPMedGroupLocal");
            _informacoes = database.GetCollection<InfoAtendimento>("InfoAtendimento");
        }

        public void Cadastrar(InfoAtendimento informacoes)
        {   

                    _informacoes.InsertOne(informacoes);
            
        }
    }
}
