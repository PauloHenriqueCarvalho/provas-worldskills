using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProvaM3_API.DTO;
using ProvaM3_API.Models;

namespace ProvaM3_API.Controllers
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


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var u = await context.Usuarios.FirstOrDefaultAsync(x => x.Login == dto.CPF && x.SenhaHash == dto.Senha);
            if (u == null)
                return NotFound("Login ou senha invalido!");

            var pessoa = await context.Pessoas.FirstOrDefaultAsync(x => x.Id == u.Id);

            var r = new LoginResponseDTO();
            r.CPF = dto.CPF;
            r.Nome = pessoa.Nome;
            r.Id = u.Id;
            r.Perfil = u.Perfil;

            if (u.Perfil != "Idoso")
            {
                var idososRelacionados = await context.Pessoas
                    .Include(x => x.Cliente)
                    .Include(x => x.Usuario)
                    .Where(x => x.Cliente.ResponsavelId == u.Id && x.Usuario.Perfil == "Idoso").ToListAsync();
                r.Idosos = idososRelacionados;
            }

            return Ok(r);

        }

    }
}
