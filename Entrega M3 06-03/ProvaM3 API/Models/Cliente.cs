using System;
using System.Collections.Generic;

namespace ProvaM3_API.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public DateOnly DataNascimento { get; set; }

    public string Cpf { get; set; } = null!;

    public int? ResponsavelId { get; set; }

    public virtual ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

    public virtual ICollection<DoseProduto> DoseProdutos { get; set; } = new List<DoseProduto>();

    public virtual Pessoa IdNavigation { get; set; } = null!;

    public virtual ICollection<Cliente> InverseResponsavel { get; set; } = new List<Cliente>();

    public virtual Cliente? Responsavel { get; set; }
}
