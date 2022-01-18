using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Drinks
{
    class Program
    {
        static void Main(string[] args)
        {

            var options = new RestClientOptions("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list")
            {
                ThrowOnAnyError = true,
                Timeout = 1000
            };
            var client = new RestClient(options);

            var request = new RestRequest();

            var response = client.GetAsync(request).Result;

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content);

            for (int i = 0; i < myDeserializedClass.drinks.Count; i++)
            {
                Console.WriteLine(myDeserializedClass.drinks[i].strCategory);
            }

            Console.Read();

        }
    }
}