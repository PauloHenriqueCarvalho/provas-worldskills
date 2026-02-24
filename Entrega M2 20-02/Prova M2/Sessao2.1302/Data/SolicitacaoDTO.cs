using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sessao2._1302.Services.PadraoDAO;


namespace Sessao2._1302.Data
{
    public class SolicitacaoDTO
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
        public string TipoNome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public List<ProdutoSolicitacaoDTO> listaProduto { get; set; }
        public int diasPraVencer { get; set; }
    }
}
