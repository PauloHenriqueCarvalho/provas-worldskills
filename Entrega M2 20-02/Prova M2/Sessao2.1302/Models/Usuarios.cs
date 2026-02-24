using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2._1302.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string SenhaHash { get; set; }
        public double CashbackUsuario { get; set; }

        public bool cliente { get; set; }

    }
}
