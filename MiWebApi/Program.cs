using System.Net.Http;
using System.Text.Json;
using Tarea;     
using Usuarios; 

class Program
{
    static async Task Main(string[] args)
    {
        string opcion;

        do
        {
            Console.WriteLine("\n----- MENÚ PRINCIPAL -----");
            Console.WriteLine("a) Ver tareas");
            Console.WriteLine("b) Ver usuarios");
            Console.WriteLine("c) Salir");
            Console.Write("Ingrese una opción: ");
            opcion = Console.ReadLine()!.ToLower();

            switch (opcion)
            {
                case "a":
                    await MostrarTareas();
                    break;
                case "b":
                    await MostrarUsuarios();
                    break;
                case "c":
                    Console.WriteLine("👋 Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("❌ Opción inválida. Intente nuevamente.");
                    break;
            }

        } while (opcion != "c");
    }

    // MOSTRAR TAREAS
    static async Task MostrarTareas()
    {
        Console.WriteLine("\n----- TAREAS -----");
        HttpClient client = new HttpClient();
        string url = "https://jsonplaceholder.typicode.com/todos";
        string json = await client.GetStringAsync(url);

        List<Tareas>? tareas = JsonSerializer.Deserialize<List<Tareas>>(json);

        foreach (var t in tareas!.Take(10)) // solo muestra 10 tareas
        {
            string estado = t.completed ? "✅ Completada" : "⏳ Pendiente";
            Console.WriteLine($"[{t.id}] {t.title} - {estado}");
        }
    }

    // MOSTRAR USUARIOS
    static async Task MostrarUsuarios()
    {
        Console.WriteLine("\n----- USUARIOS -----");
        HttpClient client = new HttpClient();
        string url = "https://jsonplaceholder.typicode.com/users";
        string json = await client.GetStringAsync(url);

        List<Root>? usuarios = JsonSerializer.Deserialize<List<Root>>(json);

        foreach (var u in usuarios!)
        {
            Console.WriteLine($"Nombre: {u.name} | Usuario: {u.username} | Email: {u.email}");
        }
    }
}
