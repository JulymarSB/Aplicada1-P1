using System.ComponentModel.DataAnnotations;

namespace Services.Models;

public class Autores
{
    [Key]
    public int IdAutor {get; set;}

    [Required(ErrorMessage ="El nombre del autor es obligatorio")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage ="La nacionalidad es obligatorio")]
    public string Nacionalidad { get; set; } = string.Empty;

    
    public DateTime FechaNacimiento { get; set; } = DateTime.MinValue;

    [Range(1, int.MaxValue, ErrorMessage="El sueldo debe ser mayor a cero")]
    public decimal Sueldo { get; set; }
}