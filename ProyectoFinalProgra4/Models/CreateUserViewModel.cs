using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

public class CreateUserViewModel
{
    [Required, MaxLength(50)]
    public string Nombre { get; set; }
    [Required, MaxLength(50)]
    public string PrimerApellido { get; set; }
    [Required, MaxLength(50)]
    public string SegundoApellido { get; set; }
    [Required, EmailAddress]
    public string Correo { get; set; }
    [Required, MaxLength(20)]
    public string Usuario { get; set; }

    public string Estado { get; set; } = "Activo";
    [Required]
    public int TipoUsuario { get; set; }
}
