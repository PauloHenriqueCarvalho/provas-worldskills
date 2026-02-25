using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2Desktop3.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Fornecedor { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int FornecedorId { get; set; }
        public int Tipoid { get; set; }
        public int Estoque { get; set; }
        public DateTime Validade { get; set; }
        public DateTime Cadastro { get; set; }


    }
}
