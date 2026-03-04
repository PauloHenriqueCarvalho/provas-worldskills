using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasAPI_v2.Models;

namespace TarefasAPI_v2.Controllers
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

        public class CreateTarefaDTO
        {
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public int BoardId { get; set; }
            public int ColunaId { get; set; }
            public DateTime Vencimento { get; set; }
            public int UsuarioCriador { get; set; }
            public int UsuarioDestino { get; set; }
        }

        [HttpGet("board/{id}")]
        public async Task<IActionResult> GetTasksBoard(int id)
        {
            var t = await context.Tarefas.Where(x => x.BoardId == id).ToListAsync();
            if (!t.Any()) return NotFound("Nenhuma tarefa encontrada!");
            return Ok(t);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTarefa([FromBody] CreateTarefaDTO dto)
        {

            var tarefa = new Tarefa
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                DataVencimento = dto.Vencimento,
                BoardId = dto.BoardId,
                ColunaId = dto.ColunaId,
                UsuarioCriadorId = dto.UsuarioCriador,

            };

            var u = await context.Usuarios.FindAsync(dto.UsuarioDestino);
            tarefa.Usuarios.Add(u);
            await context.Tarefas.AddAsync(tarefa);
            await context.SaveChangesAsync();
            return Ok();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var t = await context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            if (t == null) return NotFound("Tarefa não encontrada!");
            context.Tarefas.Remove(t);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
