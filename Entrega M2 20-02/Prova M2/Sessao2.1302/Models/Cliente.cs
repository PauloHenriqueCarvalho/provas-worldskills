using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2._1302.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public DateTime DataNasciment { get; set; }
        public string CPF { get; set; }
        public int Responsavelid { get; set; }

    }
}
