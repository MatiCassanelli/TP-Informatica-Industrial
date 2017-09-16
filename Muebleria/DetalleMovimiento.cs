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
    public partial class DetalleMovimiento : Form
    {
        ControllerDetalleMovimiento controller = new ControllerDetalleMovimiento();
        string guiones;
        public DetalleMovimiento()
        {
            InitializeComponent();
            guiones = maskedTextBox1.Text;
            cbRazon.Items.Add("sad");
            cbProductos.Items.Add("");
            cbProductos.DataSource = controller.CargarProductos();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel4.Enabled = true;
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            gbProductos.Enabled = false;
            if (maskedTextBox1.Text == guiones)
                gbProductos.Enabled = true;
        }
    }
}
