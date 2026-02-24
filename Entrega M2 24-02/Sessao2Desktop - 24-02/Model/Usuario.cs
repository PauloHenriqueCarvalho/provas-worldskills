using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2Desktop2.Model
{
    public class Usuario
    {
        public string Login { get; set; }
        public string SenhaHash { get; set; }
        public int Id { get; set; }
        public bool cliente { get; set; }
    }
}
