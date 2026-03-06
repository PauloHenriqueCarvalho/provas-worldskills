using System;
using System.Collections.Generic;

namespace ProvaM3_API.Models;

public partial class AtendimentoProduto
{
    public int Id { get; set; }

    public int AtendimentoId { get; set; }

    public int ProdutoId { get; set; }

    public int Quantidade { get; set; }

    public virtual Atendimento Atendimento { get; set; } = null!;

    public virtual Produto Produto { get; set; } = null!;
}
