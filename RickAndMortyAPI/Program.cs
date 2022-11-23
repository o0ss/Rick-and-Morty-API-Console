using System.Net;

namespace RickAndMortyAPI
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main()
        {
            Console.WriteLine("Rick & Morty API");

            client.BaseAddress = new Uri("https://rickandmortyapi.com/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        static async Task<bool> ObtenPersonaje()
        {
            HttpResponseMessage response = await client.GetAsync("character/2");
        }
    }
}