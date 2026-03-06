using System;
using System.Collections.Generic;

namespace ProvaM3_API.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public int FornecedorId { get; set; }

    public virtual ICollection<AtendimentoProduto> AtendimentoProdutos { get; set; } = new List<AtendimentoProduto>();

    public virtual ICollection<DoseProduto> DoseProdutos { get; set; } = new List<DoseProduto>();

    public virtual Fornecedor Fornecedor { get; set; } = null!;
}
