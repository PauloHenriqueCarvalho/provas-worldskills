using System;
using System.Collections.Generic;

namespace Prova3_Mobile_MAUI.Models;

public partial class DoseProduto
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int ProdutoId { get; set; }

    public DateTime DataHoraDose { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Produto Produto { get; set; } = null!;
}
