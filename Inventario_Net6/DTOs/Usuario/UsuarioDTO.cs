namespace Inventario_Net6.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }

    }
}
