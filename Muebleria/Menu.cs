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
    public partial class Menu : Form
    {
        int codigoidioma;

        public Menu()
        {
            InitializeComponent();
            Codigoidioma = LogIn.IdIdioma;
        }

        public Menu(int idioma)
        {
            InitializeComponent();
            Codigoidioma = idioma;
        }

        public int Codigoidioma
        {
            get
            {
                return codigoidioma;
            }

            set
            {
                codigoidioma = value;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Composicion composicion = new Composicion();
            this.Close();
            this.Hide();
            composicion.ShowDialog();
            
        }
        
        private void btnExplosionar_Click(object sender, EventArgs e)
        {
            Explosion explosion = new Explosion();
            this.Hide();
            explosion.ShowDialog();
            this.Close();
        }

        private void btnImplosionar_Click(object sender, EventArgs e)
        {
            Implosion implosion = new Implosion();
            this.Hide();
            implosion.ShowDialog();
            this.Close();
        }
    }
}
