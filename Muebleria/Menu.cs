﻿using System;
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
            this.Close();
            this.Hide();
            Composicion composicion = new Composicion();
            composicion.ShowDialog();
        }
        
        private void btnExplosionar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Explosion explosion = new Explosion();
            explosion.ShowDialog();
        }

        private void btnImplosionar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Implosion implosion = new Implosion();
            implosion.ShowDialog();
        }

        private void btnGrarRemito_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Nuevo_Remito nuevo_remito = new Nuevo_Remito();
            nuevo_remito.ShowDialog();
        }

        private void btnFabricarArticulo_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            FabricarProductos fc = new FabricarProductos();
            fc.ShowDialog();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            ArticulosEnStock aes = new ArticulosEnStock();
            aes.ShowDialog();
        }

        private void btnMovimiento_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            DetalleMovimiento dm = new DetalleMovimiento();
            dm.ShowDialog();
        }

        private void btnMRP_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            MRP mrp = new MRP();
            mrp.ShowDialog();
        }
    }
}
