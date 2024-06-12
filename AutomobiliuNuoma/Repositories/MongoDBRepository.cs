using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AutomobiliuNuoma.Repositories
{
    public class MongoDBRepository : IMongoDBRepository
    {
        private readonly IMongoCollection<Automobilis> _Automobilis;
        private readonly IMongoCollection<Klientas> _Klientai;

        public MongoDBRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Learning");
            _Automobilis = database.GetCollection<Automobilis>("automobilis");
            _Klientai = database.GetCollection<Klientas>("klientai");
        }

        // Automobiliai Methods
        public async Task<List<Automobilis>> GetAllAutomobiliai()
        {
            return await _Automobilis.Find(automobilis => true).ToListAsync();
        }

        public async Task AddAutomobilis(Automobilis automobilis)
        {
            await _Automobilis.InsertOneAsync(automobilis);
        }

        public async Task AddAllAutomobiliai(List<Automobilis> automobiliai)
        {
            await _Automobilis.InsertManyAsync(automobiliai);
        }

        public async Task DeleteAllAutomobiliai()
        {
            _Automobilis.DeleteMany(automobilis => true);
            Console.WriteLine("Automobiliai pasalinti is MongoDB!");
        }

        // Klientai Methods
        public async Task<List<Klientas>> GetAllKlientai()
        {
            return await _Klientai.Find(klientas => true).ToListAsync();
        }

        public async Task<List<Klientas>> GetKlientaiPagalPavadinima(string pavadinimas)
        {
            var filter = Builders<Klientas>.Filter.Or(
                Builders<Klientas>.Filter.Regex("Vardas", new BsonRegularExpression(pavadinimas, "i")),
                Builders<Klientas>.Filter.Regex("Pavarde", new BsonRegularExpression(pavadinimas, "i"))
            );
            return await _Klientai.Find(filter).ToListAsync();
        }

        public async Task AddKlientas(Klientas klientas)
        {
            await _Klientai.InsertOneAsync(klientas);
        }

        public async Task AddAllKlientai(List<Klientas> klientai)
        {
            await _Klientai.InsertManyAsync(klientai);
        }
    }
}
