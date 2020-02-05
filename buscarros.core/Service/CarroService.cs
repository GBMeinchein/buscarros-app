using buscarros.core.Config;
using buscarros.infra.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace buscarros.core.Service
{
    public class CarroService
    {
        private readonly IMongoCollection<Carro> _books;

        public CarroService(IBuscarrosDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Carro>(settings.BuscarrosCollectionName);
        }

        public List<Carro> Get() =>
            _books.Find(book => true).ToList();

        public Carro Get(string id) =>
            _books.Find<Carro>(book => book.Id == id).FirstOrDefault();
    }
}
