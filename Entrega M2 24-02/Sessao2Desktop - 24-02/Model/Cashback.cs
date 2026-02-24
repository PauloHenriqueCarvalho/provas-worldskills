using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sessao2Desktop2.Data;

namespace Sessao2Desktop2.Model
{
    public class Cashback
    {
        public double valor { get; set; }
        public int Id { get; set; }
        public int Solicitacaoid { get; set; }


        public void RemoverTodoCashback(List<CardSolicitacaoDTO> solicitacoes)
        {
            foreach (var item in solicitacoes)
            {

                new PadraoDAO().RemoverTodoCashback(item.Id);
            }
        }

        public void AdicionarCashback(int idSolicitacao, double valor)
        {
            new PadraoDAO().Adicionarcashback(idSolicitacao, valor);
        }
        public double GetCashback()
        {
            return new PadraoDAO().Getcashback();
        }

    }
}
