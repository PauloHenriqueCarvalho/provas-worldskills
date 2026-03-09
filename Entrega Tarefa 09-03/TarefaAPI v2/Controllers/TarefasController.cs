using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefaAPI_v2.DTOs;
using TarefaAPI_v2.Models;

namespace TarefaAPI_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        protected readonly AppDbContext context;

        public TarefasController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTarefa([FromBody] CreateTarefaDTO dto)
        {
            context.Tarefas.Add(new Tarefa
            {
                BoardId = dto.BoardId,
                ColunaId = dto.ColunaId,
                DataVencimento = dto.Vencimento,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                UsuarioCriadorId = dto.UsuarioCriadorId
            });

            await context.SaveChangesAsync();
            return Created();
        }


        [HttpPut("tranferir-tarefas/{idOrigem}/{idDestino}")]
        public async Task<IActionResult> PutTransferirTarefas(int idOrigem, int idDestino)
        {
            var t = await context.Tarefas.Where(x => x.BoardId == idOrigem).ToListAsync();

            var c = await context.Colunas.FirstOrDefaultAsync(x => x.BoardId == idDestino && x.Ordem == 1);
            if (c == null)
            {
                context.Colunas.Add(new Coluna
                {
                    BoardId = idOrigem,
                    Ordem = 1,
                    Nome = "Backlog",
                    Cor = "#fff"
                });
                await context.SaveChangesAsync();
            }



            foreach (var i in t)
            {
                i.BoardId = idDestino;
                i.ColunaId = 1;
            }

            await context.SaveChangesAsync();
            return Ok();


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefas(int id)
        {
            var t = await context.Tarefas.Where(x => x.BoardId == id).ToListAsync();
            return Ok(t);

        }



    }
}
