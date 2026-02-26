using System;
using System.Collections.Generic;

namespace TarefasAPI.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime? DataCadastro { get; set; }

    public virtual ICollection<Tarefa> TarefaUsuarioDestinatarioNavigations { get; set; } = new List<Tarefa>();

    public virtual ICollection<Tarefa> TarefaUsuarioRemetenteNavigations { get; set; } = new List<Tarefa>();
}
