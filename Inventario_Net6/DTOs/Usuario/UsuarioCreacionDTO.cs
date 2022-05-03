using System.ComponentModel.DataAnnotations;

namespace Inventario_Net6.DTOs.Usuario
{
    public class UsuarioCreacionDTO
    {
        [Required(ErrorMessage ="El campo Rol es requerido.")]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "El campo Correo es requerido")]
        [EmailAddress (ErrorMessage = "La dirección de correo no es valida.")]
        [MaxLength(60)]
        public string Correo { get; set; }

    }
}
