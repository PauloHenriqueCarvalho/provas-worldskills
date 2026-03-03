using System;
using System.Collections.Generic;

namespace TarefasAPI.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime? DataCadastro { get; set; }

    public string? Cor { get; set; }

    public virtual ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
}
