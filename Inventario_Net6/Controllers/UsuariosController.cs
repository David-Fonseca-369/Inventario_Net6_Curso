using AutoMapper;
using Inventario_Net6.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario_Net6.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UsuariosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        //GET : api/usuarios/todos
        [HttpGet("todos")]
        public async Task<ActionResult<List<UsuarioDTO>>> Todos()
        {
            var usuarios = await context.Usuarios.Include(x => x.Rol).ToListAsync();

            return usuarios.Select(x => new UsuarioDTO
            {
                IdUsuario = x.IdUsuario,
                IdRol = x.IdRol,
                NombreRol = x.Rol.Nombre,
                Correo = x.Correo,  
                Estado = x.Estado
            }).ToList();
        }

        //GET : api/usuarios/{id}
        [HttpGet("{id:int}")]
        public  async Task<ActionResult<UsuarioEditarDTO>> Get(int id)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            //return new UsuarioEditarDTO
            //{
            //    IdUsuario = usuario.IdUsuario,
            //    IdRol = usuario.IdRol,
            //    Correo = usuario.Correo
            //};

            return  mapper.Map<UsuarioEditarDTO>(usuario);

        }






    }
}
