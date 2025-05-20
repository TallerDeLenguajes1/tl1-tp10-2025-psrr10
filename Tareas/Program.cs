using System;
using System.Net.Http;
using System.Text.Json;
using Tarea;

//creo una instancia httpClient
HttpClient client = new HttpClient();

//url
string url = "https://jsonplaceholder.typicode.com/todos/";

//Envio solicitud get y verifico que sea exitosa 
HttpResponseMessage respuesta = await client.GetAsync(url);
respuesta.EnsureSuccessStatusCode();

//Leo y deserializo la respuesta
string contenidoJson = await respuesta.Content.ReadAsStringAsync();
string Json = contenidoJson;
var tareasDeserializadas = JsonSerializer.Deserialize<List<Tareas>>(Json);
List<Tareas> listTareas = tareasDeserializadas!;

//Mostrar informacion
foreach(var T in listTareas)
{
    Console.WriteLine("Titulo:" + T.title +" - " + "Completado:" + T.completed +"\n");
}

