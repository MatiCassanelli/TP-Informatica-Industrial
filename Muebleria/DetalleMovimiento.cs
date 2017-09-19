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
            foreach(string item in controller.CargarProductos())
            {
                cbProductos.Items.Add(item);
            }
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

        private void DetalleMovimiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProductos.SelectedIndex != 0)
                maskedTextBox1.Enabled = false;
            else
                maskedTextBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.crearMovimiento(cbRazon.SelectedItem.ToString(), double.Parse(maskedTextBox1.ToString()), cbProductos.SelectedItem.ToString(),
                Convert.ToInt32(tbCantidad.Text), cbUM.SelectedItem.ToString(), cbSucursalOrigen.ToString(), cbSucursalDestino.ToString(),
                cbAlmacenOrigen.SelectedItem.ToString(), cbAlmacenDestino.SelectedItem.ToString(), Convert.ToInt32(cbUbicacionOrigen.SelectedItem.ToString()), Convert.ToInt32(cbUbicacionDestino.SelectedItem.ToString()));
            //controller.crearMovimiento(cbProductos.SelectedItem.ToString(), Convert.ToInt32(tbCantidad), cbUM.SelectedItem.ToString(), cbRazon.SelectedItem.ToString());
        }
    }
}
