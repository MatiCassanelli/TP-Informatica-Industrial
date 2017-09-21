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
            foreach (string item in controller.CargarRazon())
                cbRazon.Items.Add(item);

            cbProductos.Items.Add("");
            foreach(string item in controller.CargarProductos())
            {
                cbProductos.Items.Add(item);
            }

            foreach(string item in controller.CargarUM())
            {
                cbUM.Items.Add(item);
            }
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

        private void cbRazon_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelOculto.Enabled = true;
            razon r = controller.getRazonCompleta(cbRazon.SelectedItem.ToString());
            completarCombosConRazon(r);
        }

        private void completarCombosConRazon(razon r)
        {
            //cbSucursalOrigen.Items.Add(controller.CargarSucursal());
            if (r.idRazon != 3)
            {
                cbSucursalOrigen.DataSource = controller.CargarSucursal(Convert.ToInt32(r.S_origen));
                cbSucursalDestino.DataSource = controller.CargarSucursal(Convert.ToInt32(r.S_destino));
                cbAlmacenOrigen.DataSource = controller.CargarAlmacen(Convert.ToInt32(r.S_origen), Convert.ToInt32(r.A_origen));
                cbAlmacenDestino.DataSource = controller.CargarAlmacen(Convert.ToInt32(r.S_destino), Convert.ToInt32(r.A_destino));
                cbUbicacionOrigen.DataSource = controller.CargarUbicacion(Convert.ToInt32(r.A_origen), Convert.ToInt32(r.U_origen));
                cbUbicacionDestino.DataSource = controller.CargarUbicacion(Convert.ToInt32(r.A_destino), Convert.ToInt32(r.U_destino));
            }
            else
            {
                cbSucursalOrigen.DataSource = controller.CargarSucursal();
                cbSucursalDestino.DataSource = controller.CargarSucursal();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //crear una variable para cada parametro inicializada en null. preguntar si ese objeto de la interfaz es distinto a null, si es asi, hacer variable=objeto

            string almacenOrigen = null, almacenDestino = null, um = null;
            int cant = 1, ubicacionOrigen = 0, ubicacionDestino = 0;
            double sn = 0;
            if (!String.IsNullOrEmpty(cbAlmacenOrigen.SelectedItem.ToString()))
                almacenOrigen = cbAlmacenOrigen.SelectedItem.ToString();
            if (!String.IsNullOrEmpty(cbAlmacenDestino.SelectedItem.ToString()))
                almacenDestino = cbAlmacenDestino.SelectedItem.ToString();
            if (cbUbicacionOrigen.SelectedItem != null)
                ubicacionOrigen = Convert.ToInt32(cbUbicacionOrigen.SelectedItem.ToString());
            if (cbUbicacionDestino.SelectedItem != null)
                ubicacionDestino = Convert.ToInt32(cbUbicacionDestino.SelectedItem.ToString());
            if (tbCantidad.Text != null)
                cant = int.Parse(tbCantidad.Text);
            if (cbUM.SelectedItem != null)
                um = cbUM.SelectedItem.ToString();
            if (maskedTextBox1.Text != guiones)
                sn = double.Parse(maskedTextBox1.Text);

            controller.crearMovimiento(cbRazon.SelectedItem.ToString(), cbProductos.SelectedItem.ToString(), cbSucursalOrigen.ToString()
, cbSucursalDestino.ToString(), almacenOrigen, almacenDestino, ubicacionOrigen, ubicacionDestino, sn, cant, um);

        }

        private void cbSucursalOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAlmacenOrigen.DataSource = controller.CargarAlmacen(cbSucursalOrigen.SelectedItem.ToString());
        }

        private void cbAlmacenDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbUbicacionDestino.DataSource = controller.CargarUbicacion(cbAlmacenDestino.SelectedItem.ToString());
        }

        private void cbSucursalDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAlmacenDestino.DataSource = controller.CargarAlmacen(cbSucursalDestino.SelectedItem.ToString());
        }

        private void cbAlmacenOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbUbicacionOrigen.DataSource = controller.CargarUbicacion(cbAlmacenOrigen.SelectedItem.ToString());
        }

        private void btnCargarDesdeTxt_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                string path = openFileDialog1.FileName;
                ControllerDetalleMovimiento controller = new ControllerDetalleMovimiento();
                string Mensaje = controller.crearMovimientoTXT(path);
                sr.Close();
                MessageBox.Show(Mensaje);
            }

        }
    }
}



   