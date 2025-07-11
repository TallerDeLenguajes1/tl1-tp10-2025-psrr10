namespace MiWebApi.Models;

public class League
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string type { get; set; } = string.Empty;
    public string logo { get; set; } = string.Empty;
}

public class Country
{
    public string name { get; set; } = string.Empty;
    public string code { get; set; } = string.Empty;
    public string flag { get; set; } = string.Empty;
}

public class Response
{
    public League league { get; set; } = new League();
    public Country country { get; set; } = new Country();
}

public class Root
{
    public string get { get; set; } = string.Empty;
    public object[] parameters { get; set; } = Array.Empty<object>();
    public object[] errors { get; set; } = Array.Empty<object>();
    public int results { get; set; }
    public List<Response> response { get; set; } = new();
}
