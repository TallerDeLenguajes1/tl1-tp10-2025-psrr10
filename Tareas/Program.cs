using System;
using System.Net.Http;
using System.Text.Json;
using Tarea;


HttpClient client = new HttpClient();

string url = "https://jsonplaceholder.typicode.com/todos/";

//Envui solicitud GET y verifico que sea exitosa
HttpResponseMessage respuesta = await client.GetAsync(url);
respuesta.EnsureSuccessStatusCode();

//Leo y deserializo la respuesta
string contenidoJson = await respuesta.Content.ReadAsStringAsync();
var tareasDeserializadas = JsonSerializer.Deserialize<List<Tareas>>(contenidoJson);
List<Tareas> listTareas = tareasDeserializadas!;

//muestro todas las tareas
Console.WriteLine("------Todas las tareas------");
foreach (var T in listTareas)
{
    Console.WriteLine("Titulo:" + T.title + " - " + "Completado:" + T.completed);
}
Console.WriteLine("\n");

//muestro todas las tareas pendientes
Console.WriteLine("------Tareas Pendientes------");
foreach (var T in listTareas)
{
    if (!T.completed)
    {
        Console.WriteLine("Titulo:" + T.title + " - " + "Completado:" + T.completed);
    }
}
Console.WriteLine("\n");