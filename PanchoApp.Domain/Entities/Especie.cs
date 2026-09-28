namespace PanchoApp.Domain.Entities;

public class Especie
{
    public int Id {get; set;}

    public string Nombre {get; set;} = string.Empty;

    public string? Descripcion {get; set;}

    public bool Activa {get; set;} = true;

    public List<Raza> Razas {get; set;} = new();

    public List<Mascota> Mascotas {get; set;} = new();

}