using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2Desktop3.Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string Login { get; set; }
        public string SenhaHash { get; set; }
        public bool cliente { get; set; }
    }
}
