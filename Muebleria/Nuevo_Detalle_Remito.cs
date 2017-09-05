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
            SetLabel2();
            CargarCombo();
        }

        private void CargarCombo()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            //Consulta para traer la lista de los ID de los productos de tipo "finales"
            var subquery = from p in db.producto
                           where p.idTipo == 1
                           select p.idDescriptionP;

            //Consulta para traer los nombres de los productos
            var query = from t in db.traduccion
                        from p in subquery
                        where t.idDescriptionT == p &&
                        t.idLanguageT == LogIn.IdIdioma
                        select t.Traduccion_str;

            cbProductosFinales.DataSource = query.ToList();
        }

        private void SetLabel2()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            var query = from r in db.remito
                        orderby r.idRemito descending
                        select r.idRemito;
            lblRemito.Text = query.ToList()[0].ToString();
        }

        private void Nuevo_Detalle_Remito_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Close();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i <  tbCantidad.Text.Length; i++)
            {
                if (tbCantidad.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 49 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        //Cargar detalle en DataGrid
        private void btnCargarProducto_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbCantidad.Text))
            {
                MessageBox.Show("Indique la cantidad deseada");
                return;
            }

            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductosFinales.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;

            int id = queryP.ToList()[0];
            string nombre = cbProductosFinales.Text.ToString();
            int cantidad = Convert.ToInt32(tbCantidad.Text.ToString());

            DataGridDetalles.Rows.Add(id, nombre, cantidad);
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            DataGridDetalles.Rows.Remove(DataGridDetalles.CurrentRow);
        }

        private void btnFinalizarDetalle_Click(object sender, EventArgs e)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            if(DataGridDetalles.RowCount > 0)
            {
                foreach(DataGridViewRow row in DataGridDetalles.Rows)
                {
                    remito_detalle NuevoRD = new remito_detalle()
                    {
                        idRemito = Convert.ToInt32(lblRemito.Text),
                        idProducto = Convert.ToInt32(row.Cells[0].AccessibilityObject.Value),
                        Cantidad = Convert.ToInt32(row.Cells[2].AccessibilityObject.Value)
                    };
                    try
                    {
                        db.remito_detalle.Add(NuevoRD);
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Error en la carga del detalle");
                    }
                }
            }
            else
            {
                MessageBox.Show("Cargue algún detalle antes de Finalizar");
                return;
            }

            this.Hide();
            this.Close();
            Menu menu = new Menu();
            menu.ShowDialog();
        }
    }
}
