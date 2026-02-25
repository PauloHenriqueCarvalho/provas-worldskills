using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2Desktop3.Model
{
    public class CardSolicitacaoDTO
    {
        public int Id { get; set; }
        public string NomeTipo { get; set; }
        public string Descricao { get; set; }
        public int tipoId { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
