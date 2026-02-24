using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2Desktop2.Model
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int TipoId { get; set; }
        public string Descricao { get; set; }
        public DateTime Validade { get; set; }
        public int Estoque { get; set; }
        public int FornecedorId { get; set; }
        public int Quantidade { get; set; }


    }
}
