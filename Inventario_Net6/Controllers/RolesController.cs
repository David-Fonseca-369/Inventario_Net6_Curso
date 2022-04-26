using Inventario_Net6.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario_Net6.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext context;


        public RolesController(ApplicationDbContext context)
        {
            this.context = context; 
        }



        //GET: api/roles/todos
        [HttpGet("todos")]
        public async Task<ActionResult<List<Rol>>> Todos()
        {
             return await context.Roles.ToListAsync();            
        }
    }
}
