using System;
using System.Net.Http;
using System.Text.Json;
using Usuarios;


//URL de la api
string url = "https://jsonplaceholder.typicode.com/users";

//Creo cliente http
HttpClient cliente = new HttpClient();

//Solicitud GET
HttpResponseMessage response = await cliente.GetAsync(url);
response.EnsureSuccessStatusCode();

//Leo el JSON
string contenidoJson = await response.Content.ReadAsStringAsync();

//Deserializo a lista de Root (representa un usuario)
List<Root>? usuarios = JsonSerializer.Deserialize<List<Root>>(contenidoJson);

//Muestro la informacion 
Console.WriteLine("------Usuarios------");
foreach (Root usu in usuarios!)
{
    Console.WriteLine($"Nombre: {usu.name}");
    Console.WriteLine($"Usuario: {usu.username}");
    Console.WriteLine($"Email: {usu.email}");
    Console.WriteLine("-----------------------------------");
}
