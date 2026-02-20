using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2._1302.Models
{
    public class Cashback
    {
        public int Id { get; set; }
        public int SolicitacaoId { get; set; }
        public double Valor { get; set; }
    }
}
