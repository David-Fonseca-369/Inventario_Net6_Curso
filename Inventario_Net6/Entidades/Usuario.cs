using System.ComponentModel.DataAnnotations;

namespace Inventario_Net6.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "El campo rol es requerido.")]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "El campo email es requerido.")]
        [EmailAddress]
        [MaxLength(60)]
        public string Correo { get; set; }
        public bool Estado { get; set; }

        //Referencias
        public Rol Rol { get; set; }
    }
}
