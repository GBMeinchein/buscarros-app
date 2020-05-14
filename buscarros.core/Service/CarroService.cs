using buscarros.core.Config;
using buscarros.core.DTO;
using buscarros.infra.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace buscarros.core.Service
{
    public class CarroService
    {
        private readonly IMongoCollection<Carro> _cars;

        public CarroService(IBuscarrosDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cars = database.GetCollection<Carro>(settings.BuscarrosCollectionName);
        }

        public List<CarroDTO> Get(string brand = null, string city = null)
        {
            var carros = _cars.Find(o => (o.Brand == brand || string.IsNullOrEmpty(brand)) &&
                                         (o.Adress == city || string.IsNullOrEmpty(city))).ToList().OrderBy(o => o.Title);

            return carros.Select(o => new CarroDTO
            {
                Adress = o.Adress,
                Brand = o.Brand,
                Href = o.Href,
                Id = o.Id,
                Image = o.Image,
                Price = o.Price.ToString("C", CultureInfo.CurrentCulture),
                Site = o.Site,
                Title = o.Title
            }).ToList();
        }

        public CarroDTO Get(string id)
        {
            var carro = _cars.Find<Carro>(book => book.Id == id).FirstOrDefault();

            return new CarroDTO
            {
                Adress = carro.Adress,
                Brand = carro.Brand,
                Href = carro.Href,
                Id = carro.Id,
                Image = carro.Image,
                Price = carro.Price.ToString("C", CultureInfo.CurrentCulture),
                Site = carro.Site,
                Title = carro.Title
            };
        }
    }
}
