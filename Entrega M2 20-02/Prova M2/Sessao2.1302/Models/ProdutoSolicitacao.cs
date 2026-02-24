using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2._1302.Models
{
    public class ProdutoSolicitacao
    {
        public int Id { get; set; }
        public int SolicitacaoId { get; set; }
        public int produtoID { get; set; }
        public int Quantidade { get; set; }
        public int EstoqueAtual { get; set; }
        public int Desconto { get; set; }
    }
}
