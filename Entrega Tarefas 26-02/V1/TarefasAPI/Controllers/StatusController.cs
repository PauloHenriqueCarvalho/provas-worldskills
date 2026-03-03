using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasAPI.Models;

namespace TarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        protected readonly AppDbContext _context;

        public StatusController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatus()
        {
            var status = await _context.Statuses.ToListAsync();
            return Ok(status);
        }



        public class CreateStatusDTO
        {
            public string Nome { get; set; }
            public string Cor { get; set; }

        }

        [HttpPost]
        public async Task<IActionResult> CreateStatus([FromBody] CreateStatusDTO dto)
        {
            var existe = await _context.Statuses.AnyAsync(x => x.Nome == dto.Nome);
            if (existe)
                return BadRequest("Ja existe um status com esse nome!");



            var status = new Status { Nome = dto.Nome, Cor = dto.Cor };
            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();
            return Ok(status);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var u = await _context.Statuses.FirstOrDefaultAsync(x => x.Id == id);
            if (u == null)
                return NotFound("Esse Status não existe");

            var emUso = await _context.Tarefas.AnyAsync(t => t.Status == id);

            if (emUso)
                return Conflict("Não é possivel concluir, Status em uso.");

            _context.Statuses.Remove(u);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
