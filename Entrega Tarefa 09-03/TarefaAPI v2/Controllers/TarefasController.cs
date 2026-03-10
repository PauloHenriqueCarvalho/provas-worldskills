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
            var t = new Tarefa
            {
                BoardId = dto.BoardId,
                ColunaId = dto.ColunaId,
                DataVencimento = dto.Vencimento,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                UsuarioCriadorId = dto.UsuarioCriadorId,

            };
            var u = await context.Usuarios.FindAsync(dto.UsuarioDestinoId);
            t.Usuarios.Add(u);
            context.Tarefas.Add(t);

            await context.SaveChangesAsync();
            return Created();
        }

        [HttpPut("mover/{idTarefa}/{idDestino}")]
        public async Task<IActionResult> MoverTarefa(int idTarefa, int idDestino)
        {
            var t = await context.Tarefas.Where(x => x.Id == idTarefa).FirstOrDefaultAsync();
            t.ColunaId = idDestino;
            await context.SaveChangesAsync();
            return Ok();

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
                    BoardId = idDestino,
                    Ordem = 1,
                    Nome = "Backlog",
                    Cor = "#fff"
                });
                await context.SaveChangesAsync();
            }
            c = await context.Colunas.FirstOrDefaultAsync(x => x.BoardId == idDestino && x.Ordem == 1);


            foreach (var i in t)
            {
                i.BoardId = idDestino;
                i.ColunaId = c.Id;
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
