using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefaAPI_v2.DTOs;
using TarefaAPI_v2.Models;

namespace TarefaAPI_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        protected readonly AppDbContext context;

        public UsuarioController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var u = await context.Usuarios

                .FirstOrDefaultAsync(x => x.Login == dto.Login && x.SenhaHash == dto.Senha);
            if (u == null)
                return NotFound("Login ou senha incorreto!");

            return Ok(u);

        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CreateUsuarioDTO dto)
        {
            var u = await context.Usuarios
                .Include(x => x.Boards)
                .Include(x => x.Tarefas)
                .FirstOrDefaultAsync(x => x.Login == dto.Login);
            if (u != null)
                return NotFound("Já existe usuario com esse login!");


            context.Usuarios.Add(new Usuario
            {
                Login = dto.Login,
                Nome = dto.Nome,
                SenhaHash = dto.Senha,
            });
            await context.SaveChangesAsync();
            return Created();

        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var u = await context.Usuarios.ToListAsync();
            return Ok(u);
        }


    }
}
