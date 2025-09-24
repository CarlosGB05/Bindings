using System;

namespace Bindings.Models;

public class Boligrafo
{
    public string Codigo { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    
    public DateTime Fecha { set; get; } = DateTime.Now;

    public override string ToString()
    {
        return "Codigo: "+Codigo+", Color: "+Color;;
    }
}