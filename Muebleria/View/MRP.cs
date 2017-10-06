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
    public partial class MRP : Form
    {
        ControllerMRP controller= new ControllerMRP();
        public MRP()
        {
            InitializeComponent();
            Fecha fecha = new Fecha();
            label1.Text = fecha.convertir(DateTime.Now).ToString();

            cargarDataGrid();
        }

        private void cargarDataGrid()
        {
            dataGridView1.DataSource = controller.getRequerimientos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            View.CargaVGM carga = new View.CargaVGM();
            carga.ShowDialog();
        }

        private void MRP_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }
    }
}
