using System;
using System.Net.Http;

namespace ScraperTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Url you want to scrape from
            var url = "https://jamesnitz.com/";

            var httpClient = new HttpClient();

            // Stringify & store all html on page
            var html = httpClient.GetStringAsync(url);

            Console.WriteLine(html.Result);
        }
    }
}
