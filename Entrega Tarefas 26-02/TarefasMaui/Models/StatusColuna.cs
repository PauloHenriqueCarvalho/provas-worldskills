using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasMaui.Models
{
    public class StatusColuna
    {
        public Status Status { get; set; }
        public List<Tarefa> Tarefas { get; set; }
    }
}
