using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks
{
    public static class ApiHelper
    {
        public static void listCategoriesCall()
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

            Console.WriteLine("\n\nChoose a category:");
        }

        public static void categoryCall()
        {
            string category = Console.ReadLine();

            string categoryApiLink = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=";

            var categoryOptions = new RestClientOptions($"{categoryApiLink}{category}")
            {
                ThrowOnAnyError = true,
                Timeout = 1000
            };
            var categoryClient = new RestClient(categoryOptions);

            var categoryRequest = new RestRequest();

            var categoryResponse = categoryClient.GetAsync(categoryRequest).Result;

            Root categoryDeserializedClass = JsonConvert.DeserializeObject<Root>(categoryResponse.Content);

            Console.Clear();

            for (int i = 0; i < categoryDeserializedClass.drinks.Count; i++)
            {
                Console.WriteLine(categoryDeserializedClass.drinks[i].strDrink);
            }

            Console.WriteLine("Choose a drink: (enter 1 to return to categories)");
        }

        public static void drinkCall()
        {
            string drink = Console.ReadLine();

            string drinkApiLink = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=";

            var drinkOptions = new RestClientOptions($"{drinkApiLink}{drink}")
            {
                ThrowOnAnyError = true,
                Timeout = 1000
            };
            var drinkClient = new RestClient(drinkOptions);

            var drinkRequest = new RestRequest();

            var drinkResponse = drinkClient.GetAsync(drinkRequest).Result;

            Root drinkDeserializedClass = JsonConvert.DeserializeObject<Root>(drinkResponse.Content);

            Console.Clear();

            Console.WriteLine($"Instructions to create the drink: {drink}\n\n");

            for (int i = 0; i < drinkDeserializedClass.drinks.Count; i++)
            {
                Console.WriteLine(drinkDeserializedClass.drinks[i].strInstructions);
            }
        }
    }
}
