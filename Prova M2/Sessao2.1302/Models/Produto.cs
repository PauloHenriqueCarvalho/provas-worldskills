using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2._1302.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public double Valor { get; set; }
        public int Tipoid { get; set; }
        public int FornecedorID { get; set; }
        public string Descricao { get; set; }
        public DateTime Validade { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int Estoque { get; set; }
        public int qtdAdicionada { get; set; }
    }
}
