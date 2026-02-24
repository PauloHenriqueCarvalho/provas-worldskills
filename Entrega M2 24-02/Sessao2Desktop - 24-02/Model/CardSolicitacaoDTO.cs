using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2Desktop2.Model
{
    public class CardSolicitacaoDTO
    {
        public string NomeTipo { get; set; }
        public string Descricao { get; set; }
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataCricao { get; set; }
        public string Status { get; set; }
        public List<Produtos> Produtos { get; set; }
    }
}
