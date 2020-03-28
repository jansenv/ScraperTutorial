using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net.Http;

namespace ScraperTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHtmlAsync();
            Console.ReadLine();
        }

        // Method for scraping HTML
        private static async void GetHtmlAsync()
        {
            // Url you want to scrape from
            var url = "https://jamesnitz.com/";

            var httpClient = new HttpClient();

            // Stringify & store all html on page
            var html = await httpClient.GetStringAsync(url);

            // Loads html into document so that it can be parsed
            // From nuget package: HtmlAgilityPack
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Find all the head tags in the HTML and put them in a list
            var h1s = htmlDocument.DocumentNode.Descendants("h1").ToList();
            var h2s = htmlDocument.DocumentNode.Descendants("h2").ToList();

            // Loop through the list and print to console

            Console.WriteLine("----- All <h1> Tags-----");
            Console.WriteLine("");
            foreach (var h1 in h1s)
            {
                Console.WriteLine($"{h1.InnerHtml}");
            }

            Console.WriteLine("");
            Console.WriteLine("----- All <h2> Tags-----");
            Console.WriteLine("");
            foreach (var h2 in h2s)
            {
                Console.WriteLine($"{h2.InnerHtml}");
            }
        }
    }
}
