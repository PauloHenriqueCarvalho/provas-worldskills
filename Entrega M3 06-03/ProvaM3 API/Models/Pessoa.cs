using System;
using System.Collections.Generic;

namespace ProvaM3_API.Models;

public partial class Pessoa
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Telefone { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();

    public virtual Fornecedor? Fornecedor { get; set; }

    public virtual Profissional? Profissional { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
