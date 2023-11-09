using System.Net.Http.Json;

namespace SuperProductsClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // get product details from remote api


            // Discover the api url
            string url = "https://localhost:44381/api/Products";

            // send GET request to the service url
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(url);
            //string result = client.GetStringAsync(url).GetAwaiter().GetResult();
            var items = client.GetFromJsonAsync<List<Item>>(url).GetAwaiter().GetResult();

            foreach (var item in items)
            {


                Console.WriteLine(item.name);
            }


            // Async programming in C# : async await Task
        }
    }


    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public double price { get; set; }
        public string brand { get; set; }
        public string country { get; set; }
        public bool isAvailable { get; set; }
    }
}