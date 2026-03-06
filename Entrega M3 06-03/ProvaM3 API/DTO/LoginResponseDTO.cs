using ProvaM3_API.Models;

namespace ProvaM3_API.DTO
{
    public class LoginResponseDTO
    {
        public string CPF { get; set; }
        public string Perfil { get; set; }
        public string Nome { get; set; }
        public int Id { get; set; }
        public List<Pessoa>? Idosos { get; set; }
    }
}
