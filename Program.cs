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
            //List the drink categories
            ApiHelper.listCategoriesCall();

            //select a category and view the drinks in that category
            ApiHelper.categoryCall();

            //select a drink and view the instructions to make it
            ApiHelper.drinkCall();

            Console.Read();
        }
    }
}