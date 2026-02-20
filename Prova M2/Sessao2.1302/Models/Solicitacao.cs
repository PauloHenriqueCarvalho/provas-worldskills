using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2._1302.Models
{
    public class Solicitacao
    {
        public int Id { get; set; }
        public DateTime Validade { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int ClienteId { get; set; }
        public string Descricao { get; set; }
        public int Cashback { get; set; }

    }
}
