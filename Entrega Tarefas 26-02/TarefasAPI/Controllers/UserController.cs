using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasAPI.Models;

namespace TarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }


        public class LoginDTO
        {
            public string Login { get; set; }
            public string Senha { get; set; }
        }
        public class CreateUserDTO
        {
            public string Nome { get; set; }
            public string Login { get; set; }
            public string Senha { get; set; }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var u = await _context.Usuarios.FirstOrDefaultAsync(x => x.Login == dto.Login && x.Senha == dto.Senha);
            if (u != null)
            {
                return Ok(u);
            }
            else
            {
                return Unauthorized("Esse usuario não existe!");
            }



        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO dto)
        {

            var existe = await _context.Usuarios.AnyAsync(x => x.Login == dto.Login);
            if (existe)
                return BadRequest("Já existe um usuario com esse login!");

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Login = dto.Login,
                Senha = dto.Senha,
            };
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Created("", usuario);

        }
        public class UsersResponseDTO
        {
            public string Nome { get; set; }
            public int Id { get; set; }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario([FromBody] CreateUserDTO dto, int id)
        {
            var u = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (u == null)
                return BadRequest("Usuario não encontrado!");
            u.Login = dto.Login;
            u.Nome = dto.Nome;
            u.Senha = dto.Senha;
            await _context.SaveChangesAsync();
            return Ok(u);
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var usuario = await _context.Usuarios.Select(u => new UsersResponseDTO
            {
                Id = u.Id,
                Nome = u.Nome
            }).ToListAsync();

            return Ok(usuario);
        }

    }
}
