namespace PanchoApp.Domain.Entities;

public class Raza
{
    public int Id {get; set;}
    public string Nombre {get; set;} = string.Empty;
    public string? Descripcion {get; set;}
    public bool Activa {get; set;} = true;
    public int EspecieId {get; set;}
    public Especie? Especie {get; set;}
    public List<Mascota> Mascotas {get; set;} = new();
    
}