using System;
using System.Collections.Generic;

namespace Prova3_Mobile_MAUI.Models;

public partial class Servico
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public decimal? PrecoBase { get; set; }

    public virtual ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();
}
