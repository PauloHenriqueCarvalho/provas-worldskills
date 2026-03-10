using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefaAPI_v2.DTOs;
using TarefaAPI_v2.Models;

namespace TarefaAPI_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColunasController : ControllerBase
    {
        protected readonly AppDbContext context;

        public ColunasController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateColunas([FromBody] CreateColunaDTO dto)
        {
            var b = await context.Colunas.FirstOrDefaultAsync(x => x.Nome == dto.Nome && x.BoardId == dto.BoardId);
            if (b != null)
                return BadRequest("Ja existe uma coluna com esse nome no board.");

            var cont = await context.Colunas.Where(x => x.BoardId == dto.BoardId).ToListAsync();

            context.Colunas.Add(new Coluna
            {
                Nome = dto.Nome,
                BoardId = dto.BoardId,
                Cor = "#fff",
                Ordem = cont.Count + 1

            });
            await context.SaveChangesAsync();
            var r = await context.Colunas.FirstOrDefaultAsync(x => x.Nome == dto.Nome && x.BoardId == dto.BoardId);
            return Ok(r);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColunasTarefas(int id)
        {
            var colunas = await context.Colunas
                .Include(x => x.Tarefas)
                .Where(x => x.BoardId == id).ToListAsync();
            return Ok(colunas);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var d = await context.Colunas.FirstOrDefaultAsync(x => x.Id == id);
            context.Colunas.Remove(d);
            await context.SaveChangesAsync();
            return Ok();
        }

        public class ColunaOrdemDTO
        {
            public int Id { get; set; }
            public int Ordem { get; set; }
        }

        [HttpPut("Ordenar")]
        public async Task<IActionResult> OrdenarColunas([FromBody] List<ColunaOrdemDTO> dto)
        {
            foreach (var colunaOrdem in dto)
            {
                var c = await context.Colunas.FindAsync(colunaOrdem.Id);
                if (c != null)
                {
                    c.Ordem = colunaOrdem.Ordem;
                }
            }
            await context.SaveChangesAsync();
            return Ok();


        }
    }
}
