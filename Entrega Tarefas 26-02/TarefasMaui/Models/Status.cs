using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasMaui.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;
        public string Cor { get; set; } = null!;

        public DateTime? DataCadastro { get; set; }
    }
}
