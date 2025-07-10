using System;
namespace Usuarios;

public class Address
{
    public string street { get; set; } = string.Empty;
    public string suite { get; set; } = string.Empty;
    public string city { get; set; } = string.Empty;
    public string zipcode { get; set; } = string.Empty;
    public Geo geo { get; set; } 
}

public class Company
{
    public string name { get; set; } = string.Empty;
    public string catchPhrase { get; set; } = string.Empty;
    public string bs { get; set; } = string.Empty;
}

public class Geo
{
    public string lat { get; set; } = string.Empty;
    public string lng { get; set; } = string.Empty;
}

public class Root
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string username { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public Address address { get; set; } 
    public string phone { get; set; } = string.Empty;
    public string website { get; set; } = string.Empty;
    public Company company { get; set; } 
}