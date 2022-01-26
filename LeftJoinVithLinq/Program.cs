using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftJoinVithLinq
{
    class Program
    {
        class City
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Client
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? CityId { get; set; }
        }
        static void Main(string[] args)
        {
            List<Client> GetClients()
            {
                return new List<Client>()
                {
                    new Client { Id = 1, Name = "Alex", CityId = 1 },
                    new Client { Id = 2, Name = "Mila", CityId = 2 },
                    new Client { Id = 3, Name = "Jora", CityId = null },
                    new Client { Id = 4, Name = "Slava", CityId = 2},
                };
            }

            List<City> GetCities()
            {
                return new List<City>()
                {
                    new City { Id = 1, Name = "Chisinau"},
                    new City { Id = 2, Name = "Bucuresti"},
                    new City { Id = 3, Name = "Cainari"}
                };
            }

            var result =
                from clients in GetClients()
                join cities in GetCities()
                on clients.CityId equals cities.Id into clientCityGroup
                from subCities in clientCityGroup.DefaultIfEmpty()
                select new { clientName = clients.Name, cityName = subCities?.Name };


            foreach (var item in result)
            {
                Console.WriteLine($"{item.clientName} from cities {item?.cityName}");
            }
        }
    }
}
