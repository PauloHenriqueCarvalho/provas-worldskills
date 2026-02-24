using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2._1302.Models
{
    public class DetalhesProdutosDTO
    {
        public string Nome { get; set; }
        public DateTime Validade { get; set; }
        public int Quantidade { get; set; }
        public double preco { get; set; }
        public int desconto { get; set; }
        public string fornecedor { get; set; }
        public double subtotal { get; set; }
    }
}
