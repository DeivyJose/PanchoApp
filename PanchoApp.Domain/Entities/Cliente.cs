namespace PanchoApp.Domain.Entities;

public class Cliente
{
    public int Id {get; set;}

    public string Nombre {get; set;} = string.Empty;

    public string Telefono {get; set;} = string.Empty;

    public string? Correo {get; set;}

    public string? Direccion {get; set;}

    public DateTime FechaRegistro {get; set;} = DateTime.Now;

    public bool Activo {get; set;} = true;

    public string? Observaciones {get; set;}

   public List<Mascota> Mascotas { get; set; } = new();
    
}