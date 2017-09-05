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
    public partial class Nuevo_Detalle_Remito : Form
    {
        public Nuevo_Detalle_Remito()
        {
            InitializeComponent();
        }

        private void Nuevo_Detalle_Remito_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Close();
            Menu menu = new Menu();
            menu.ShowDialog();
        }
    }
}
