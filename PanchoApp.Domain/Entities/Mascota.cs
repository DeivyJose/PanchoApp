namespace PanchoApp.Domain.Entities;

public class Mascota
{
    public int Id {get; set;}
    public string Nombre {get; set;} = string.Empty;
    public DateTime? FechaNacimiento {get; set;}
    public string Sexo {get; set;} = string.Empty;
    public string? Color {get; set;}
    public decimal? Peso {get; set;}
    public string? FotoRuta {get; set;}
    public string? NivelAgresividad {get; set;}
    public bool Esterilizado {get; set;}
    public string? Microchip {get; set;}
    public string? TipoAlimentacion {get; set;}
    public string? Alergias {get; set;}
    public string? Enfermedades {get; set;}
    public string? MedicamentosActuales {get; set;}
    public string? Observaciones {get; set;}
    public bool Activa {get; set;} = true;
    public int ClienteID {get; set;}
    public Cliente? Cliente {get; set;}
    public int EspecieId {get; set;}
    public Especie? Especie {get; set;}
    public int? RazaId {get; set;}
    public Raza? Raza {get; set;}
    
}