using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

// Clase que representa la entidad Cliente en el dominio
public class Cliente {

    public int Id { get; set; }
    
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
    public string CorreoElectronico { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [Phone(ErrorMessage = "El número de teléfono no es válido")]
    public string Telefono { get; set; } = string.Empty;

}
