using AutoMapper;
using Inventario_Net6.DTOs;
using Inventario_Net6.DTOs.Usuario;
using Inventario_Net6.Entidades;
using Inventario_Net6.Helpers;
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

        //GET: api/usuarios/todosPaginacion
        [HttpGet("todosPaginacion")]
        public async Task<ActionResult<List<UsuarioDTO>>> Todos([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.Usuarios.Include(x => x.Rol).AsQueryable();

            await HttpContext.InsertarParametrosPaginacionCabeceraAsync(queryable);

            //traer el paginado
            var usuarios = await queryable.Paginar(paginacionDTO).ToListAsync();

            return usuarios.Select(x => new UsuarioDTO
            {
                IdUsuario = x.IdUsuario,
                IdRol= x.IdRol, 
                NombreRol= x.Rol.Nombre,    
                Correo= x.Correo,   
                Estado= x.Estado   
            }).ToList();
        }

        //GET : api/usuarios/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioEditarDTO>> Get(int id)
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

            return mapper.Map<UsuarioEditarDTO>(usuario);

        }

        //POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult> Crear([FromBody] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            if (usuarioCreacionDTO.IdRol > 0)
            {

                var usuario = mapper.Map<Usuario>(usuarioCreacionDTO);

                //Agregar el estado actico
                usuario.Estado = true;

                context.Add(usuario);

                await context.SaveChangesAsync();

                return NoContent();


            }

            return BadRequest("El campo IdRol es menor a cero.");
        }


        //PUT : api/usuarios/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            //usuario.IdRol = usuarioCreacionDTO.IdRol;
            //usuario.Correo = usuarioCreacionDTO.Correo;

            usuario = mapper.Map(usuarioCreacionDTO, usuario);


            await context.SaveChangesAsync();

            return NoContent();


        }


        //PUT: api/usuarios/desactivar
        [HttpPut("desactivar/{id:int}")]
        public async Task<ActionResult> Desactivar(int id)
        {
            var usuario = context.Usuarios.FirstOrDefault(x => x.IdUsuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Estado = false;

            await context.SaveChangesAsync();

            return NoContent();
        }

        //PUT: api/usuarios/activar
        [HttpPut("activar/{id:int}")]
        public async Task<ActionResult> Activar(int id)
        {
            var usuario = context.Usuarios.FirstOrDefault(x => x.IdUsuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Estado = true;

            await context.SaveChangesAsync();

            return NoContent();
        }










    }
}
