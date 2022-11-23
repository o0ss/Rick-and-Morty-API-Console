using System.Net.Http;
using System.Net.Http.Json;

namespace RickAndMortyAPI
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main()
        {
            Console.WriteLine("Rick & Morty API");

            client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Random rand = new Random();
                    Personaje respuesta = ObtenPersonaje(rand.Next(1, Personaje.TOTAL_CHARS)).GetAwaiter().GetResult();
                    Console.WriteLine(respuesta.ToString());
                }
            }
            catch (Exception e)
            {
                global::System.Console.WriteLine(e.ToString());
                throw;
            }

        }

        static async Task<Personaje> ObtenPersonaje(int id)
        {
            try
            {
                Personaje personaje;
                HttpResponseMessage response = await client.GetAsync(string.Concat("character/", id.ToString()));
                if (response.IsSuccessStatusCode)
                {
                    personaje = await response.Content.ReadFromJsonAsync<Personaje>();
                    return personaje;
                }
                return null;
            }
            catch (Exception e)
            {
                await global::System.Console.Out.WriteLineAsync(e.ToString());
                throw;
            }
        }
    }
}