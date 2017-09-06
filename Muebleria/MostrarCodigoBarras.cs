using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muebleria
{
    public partial class MostrarCodigoBarras : Form
    {
        public MostrarCodigoBarras()
        {
            InitializeComponent();
            //imprimir();
        }

        public void imprimir(string ccod)
        {
            lblCodigo.Text = ccod;
            textBox1.Text = ccod;
        }
    }
}
