using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muebleria.View
{
    public partial class CargaVGM : Form
    {
        CargarCombos cc = new CargarCombos();
        Fecha f = new Fecha();
        ControllerCargaVGM controllerCargaVGM = new ControllerCargaVGM();
        private List<requerimientos> lista;

        public List<requerimientos> Lista
        {
            get
            {
                return lista;
            }

            set
            {
                lista = value;
            }
        }

        public CargaVGM()
        {
            InitializeComponent();
            cbProductos.DataSource = cc.CargarProductos();
            cbCliente.Items.Add("Ventas Concretadas");
            cbCliente.Items.Add("Marketing");
            cbCliente.Items.Add("Decisión Gerencial");
        }

        public CargaVGM(List<requerimientos> asd)
        {
            InitializeComponent();
            cbProductos.DataSource = cc.CargarProductos();
            cbCliente.Items.Add("Ventas Concretadas");
            cbCliente.Items.Add("Marketing");
            cbCliente.Items.Add("Decisión Gerencial");
            Lista = asd;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (cbCliente.SelectedItem != null && cbProductos.SelectedItem != null && !String.IsNullOrEmpty(tbCantidad.Text))
            {
                Lista.Add(controllerCargaVGM.crearRequerimiento(cbProductos.SelectedItem.ToString(), f.convertir(monthCalendar1.SelectionRange.Start), cbCliente.SelectedItem.ToString(), int.Parse(tbCantidad.Text)));
                this.Close();
            }
            else
                MessageBox.Show("No anduvo");
                
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (DateTime.Now >= monthCalendar1.SelectionRange.Start)
            {
                MessageBox.Show("No se puede publicar una estructura para una fecha ya pasada");
                monthCalendar1.SetDate(DateTime.Now);
            }
            if ((f.convertir(DateTime.Now) + 2) >= f.convertir(monthCalendar1.SelectionRange.Start))
            {
                MessageBox.Show("No se permite realizar pedidos dentro del periodo de freeze");
                monthCalendar1.SetDate(DateTime.Now);
            }
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) //backspace
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tbCantidad.Clear();
            cbCliente.ResetText();
            cbProductos.ResetText();
        }
    }
}
