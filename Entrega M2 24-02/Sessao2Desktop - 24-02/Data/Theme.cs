using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sessao2Desktop2.Data
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
                b.BackColor = ColorTranslator.FromHtml("#FA2804");
                b.ForeColor = Color.White;
            }

            foreach (Control item in c.Controls)
            {
                Apply(item);
            }

        }

    }
}
