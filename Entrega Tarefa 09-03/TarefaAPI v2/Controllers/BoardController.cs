using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefaAPI_v2.DTOs;
using TarefaAPI_v2.Models;

namespace TarefaAPI_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {

        protected readonly AppDbContext context;

        public BoardController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard([FromBody] CreateBoardDTO dto)
        {

            var u = await context.Boards.FirstOrDefaultAsync(x => x.Nome == dto.Nome && x.UsuarioCriadorId == dto.IdUsuario);
            if (u != null)
                return BadRequest("Já existe um board com esse nome.");

            context.Boards.Add(new Board
            {
                Nome = dto.Nome,
                UsuarioCriadorId = dto.IdUsuario,
            });

            await context.SaveChangesAsync();
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoard(int id)
        {
            var r = await context.Boards
                .Include(x => x.Usuarios)
                .Where(x => x.UsuarioCriadorId == id || x.Usuarios.Any(c => c.Id == id)).ToListAsync();
            return Ok(r);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            var r = await context.Boards.FirstOrDefaultAsync(x => x.UsuarioCriadorId == id);
            context.Boards.Remove(r);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNome(int id, [FromBody] CreateBoardDTO dto)
        {
            var r = await context.Boards.FirstOrDefaultAsync(x => x.UsuarioCriadorId == id);
            r.Nome = dto.Nome;
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
