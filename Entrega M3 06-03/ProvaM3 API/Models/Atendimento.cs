using System;
using System.Collections.Generic;

namespace ProvaM3_API.Models;

public partial class Atendimento
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int ProfissionalId { get; set; }

    public int ServicoId { get; set; }

    public DateTime DataAgendada { get; set; }

    public int? Retorno { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<AtendimentoProduto> AtendimentoProdutos { get; set; } = new List<AtendimentoProduto>();

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Profissional Profissional { get; set; } = null!;

    public virtual Servico Servico { get; set; } = null!;
}
