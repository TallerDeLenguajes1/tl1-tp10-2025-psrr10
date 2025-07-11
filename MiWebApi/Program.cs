using System.Net.Http;
using System.Text.Json;
using MiWebApi.Models;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("🔄 Consultando la API-Football...");

        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("x-apisports-key", "1b72d0d8630bb00875bb5c57b2084f68");

        HttpResponseMessage res = await client.GetAsync("https://v3.football.api-sports.io/leagues");
        res.EnsureSuccessStatusCode();

        string json = await res.Content.ReadAsStringAsync();

        Root? datos = JsonSerializer.Deserialize<Root>(json);

        Console.WriteLine("\n📋 Ligas disponibles:");
        foreach (var item in datos!.response.Take(10)) // Muestra solo 10 ligas
        {
            Console.WriteLine($"🏆 {item.league.name} | 🌍 {item.country.name}");
        }

        // Guardar en archivo
        string jsonGuardado = JsonSerializer.Serialize(datos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("ligas.json", jsonGuardado);

        Console.WriteLine("\n✅ Datos guardados en el archivo ligas.json");
    }
}
