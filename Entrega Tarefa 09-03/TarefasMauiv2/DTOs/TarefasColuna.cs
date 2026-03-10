using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasMauiv2.Models;

namespace TarefasMauiv2.DTOs
{
    public class TarefasColuna
    {
        public Coluna Coluna { get; set; }
        public List<Tarefa> Tarefas { get; set; }
    }
}
