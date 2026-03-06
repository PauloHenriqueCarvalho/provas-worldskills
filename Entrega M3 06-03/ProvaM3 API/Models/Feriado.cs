using System;
using System.Collections.Generic;

namespace ProvaM3_API.Models;

public partial class Feriado
{
    public int Id { get; set; }

    public DateOnly DataFeriado { get; set; }
}
