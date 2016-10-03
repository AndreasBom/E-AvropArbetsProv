using E_AvropArbetsProv.Http;
using E_AvropArbetsProv.Utility;
using System;

namespace E_AvropArbetsProv
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Collecting data, please wait...");

            var fetcher = new HttpFetcher();
            const string baseUrl = "https://www.poromaa.com/assignment_data/";
            const string apiUrl = "transactions.json";

            //Get list with objects
            var data = fetcher.GetData(baseUrl, apiUrl, args[0], args[1]);
            var balance = Calculation.GetBalance(data);

            Console.Clear();
            Console.WriteLine($"Balance: {balance}");

            Console.ReadKey();
        }


    }
}
