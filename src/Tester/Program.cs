using API_3_1.Repo;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var baseUrl = @"http://localhost:5000";

            var client = new WeatherForecastClient(baseUrl, new HttpClient());
            var listado = await client.GetAsync();

            Debug.WriteLine(listado);
            Console.ReadLine();
        }
    }
}
