using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasAPI_v2.Models;

namespace TarefasAPI_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColunaController : ControllerBase
    {
        protected readonly AppDbContext context;

        public ColunaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet("board/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var l = await context.Colunas.Where(x => x.BoardId == id).ToListAsync();
            if (!l.Any()) return NotFound("Nenhuma coluna encontrada");
            return Ok(l);
        }

        public class CreateColunaDTO
        {
            public string Nome { get; set; }
            public string Cor { get; set; }
            public int Ordem { get; set; }
            public int BoardId { get; set; }
        }


        [HttpPost]
        public async Task<IActionResult> CreateColuna(CreateColunaDTO dto)
        {
            var c = new Coluna
            {
                BoardId = dto.BoardId,
                Cor = dto.Cor,
                Nome = dto.Nome,
                Ordem = dto.Ordem,
            };

            await context.Colunas.AddAsync(c);
            await context.SaveChangesAsync();
            return Ok();
        }
    }



}
