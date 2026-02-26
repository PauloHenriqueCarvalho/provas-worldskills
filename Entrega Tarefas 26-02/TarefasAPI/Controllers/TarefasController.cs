using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasAPI.Models;

namespace TarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        protected readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefasUsuario(int id)
        {
            var t = await _context.Tarefas.Where(x => x.UsuarioDestinatario == id)
                .Select(x => new
                {
                    x.Id,
                    x.Titulo,
                    x.Descricao,
                    x.DataVencimento,
                    x.DataCadastro,
                    Status = new
                    {
                        x.StatusNavigation.Id,
                        x.StatusNavigation.Nome,
                        x.StatusNavigation.Cor
                    },
                    Destinatario = new
                    {
                        x.UsuarioDestinatarioNavigation.Id,
                        x.UsuarioDestinatarioNavigation.Nome
                    },
                    Remetente = new
                    {
                        x.UsuarioRemetenteNavigation.Id,
                        x.UsuarioRemetenteNavigation.Nome
                    }


                })
                .ToListAsync();
            return Ok(t);
        }

        [HttpGet("Enviadas/{id}")]
        public async Task<IActionResult> GetTarefasEnviadasUsuario(int id)
        {
            var t = await _context.Tarefas.Where(x => x.UsuarioRemetente == id)
                .Select(x => new
                {
                    x.Id,
                    x.Titulo,
                    x.Descricao,
                    x.DataVencimento,
                    x.DataCadastro,
                    Status = new
                    {
                        x.StatusNavigation.Id,
                        x.StatusNavigation.Nome,
                        x.StatusNavigation.Cor
                    },
                    Destinatario = new
                    {
                        x.UsuarioDestinatarioNavigation.Id,
                        x.UsuarioDestinatarioNavigation.Nome
                    },
                    Remetente = new
                    {
                        x.UsuarioRemetenteNavigation.Id,
                        x.UsuarioRemetenteNavigation.Nome,
                        x.StatusNavigation.Cor
                    }


                })
                .ToListAsync();
            return Ok(t);
        }

        public class CreateTarefasDTO
        {
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public int UsuarioRemetente { get; set; }
            public int UsuarioDestinatario { get; set; }
            public DateTime DataVencimento { get; set; }
            public int Status { get; set; }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarefa([FromBody] CreateTarefasDTO dto, int id)
        {
            var t = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

            if (t == null)
                return BadRequest("Tarefa não encontrada!");

            t.Titulo = dto.Titulo;
            t.Status = dto.Status;
            t.UsuarioDestinatario = dto.UsuarioDestinatario;
            t.DataVencimento = dto.DataVencimento;
            t.Descricao = dto.Descricao;
            t.UsuarioRemetente = dto.UsuarioRemetente;
            await _context.SaveChangesAsync();
            return Ok(t);

        }


        [HttpPost]
        public async Task<IActionResult> CreateTarefa([FromBody] CreateTarefasDTO dto)
        {
            var t = new Tarefa
            {
                DataVencimento = dto.DataVencimento,
                Descricao = dto.Descricao,
                Status = dto.Status,
                Titulo = dto.Titulo,
                UsuarioDestinatario = dto.UsuarioDestinatario,
                UsuarioRemetente = dto.UsuarioRemetente,
            };

            _context.Tarefas.Add(t);
            await _context.SaveChangesAsync();
            return Created("Tarefa criada", t);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            var t = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            _context.Tarefas.Remove(t);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
