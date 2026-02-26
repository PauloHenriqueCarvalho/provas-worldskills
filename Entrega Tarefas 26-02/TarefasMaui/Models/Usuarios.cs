using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasMaui.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string Login { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public DateTime? DataCadastro { get; set; }
    }
}
