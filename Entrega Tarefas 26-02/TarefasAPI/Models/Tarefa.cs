using System;
using System.Collections.Generic;

namespace TarefasAPI.Models;

public partial class Tarefa
{
    public int Id { get; set; }

    public int UsuarioRemetente { get; set; }

    public int? Status { get; set; }

    public int UsuarioDestinatario { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public DateTime? DataVencimento { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual Status? StatusNavigation { get; set; }

    public virtual Usuario UsuarioDestinatarioNavigation { get; set; } = null!;

    public virtual Usuario UsuarioRemetenteNavigation { get; set; } = null!;
}
