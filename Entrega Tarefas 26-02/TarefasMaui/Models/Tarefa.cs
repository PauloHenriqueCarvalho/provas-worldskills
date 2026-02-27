using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasMaui.Models
{
    public class Tarefa
    {
        public int Id { get; set; }


        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataVencimento { get; set; }

        public DateTime? DataCadastro { get; set; }

        public Status Status { get; set; }
        public Usuarios Destinatario { get; set; }
        public Usuarios Remetente { get; set; }

    }
}
