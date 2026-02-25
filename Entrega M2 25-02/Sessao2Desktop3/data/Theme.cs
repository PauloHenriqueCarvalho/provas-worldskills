using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sessao2Desktop3.data
{
    public static class Theme
    {
        public static void Apply(Control c)
        {
            if (c is Form f)
            {
                f.BackColor = ColorTranslator.FromHtml("#FAFAFC");
                f.StartPosition = FormStartPosition.CenterScreen;

            }

            if (c is Button b)
            {
                b.BackColor = ColorTranslator.FromHtml("#FA2408");
                b.ForeColor = Color.White;
            }

            foreach (Control i in c.Controls)
            {
                Apply(i);
            }

        }
    }
}
