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
    public partial class ArticulosEnStock : Form
    {
        public ArticulosEnStock()
        {
            InitializeComponent();
            cargarCombo();
        }

        private void cargarCombo()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            var subquery = from p in db.producto
                           //where p.idTipo == 1 || p.idTipo == 3
                           select p.idDescriptionP;

            var query = from t in db.traduccion
                        from p in subquery
                        where t.idDescriptionT == p &&
                        t.idLanguageT == LogIn.IdIdioma
                        select t.Traduccion_str;

            cbProductos.DataSource = query.ToList();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            traerStock(cbProductos.SelectedItem.ToString());
        }

        private int convertirEnID(string prod)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == prod &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;

            return queryP.ToList()[0];
        }

        private void traerStock(string prod)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            int idSeleccionado = convertirEnID(prod);

            var query = from s in db.stock
                        from p in db.producto
                        from a in db.almacen
                        where s.idProducto == p.idProducto && p.idProducto == idSeleccionado && s.idAlmacen==a.idAlmacen && a.Real==1
                        select new { prod = prod, cant = s.Cantidad, almacen = a.Nombre };
            if (query.Count() > 0)
                dataGridView1.DataSource = query.ToList();
            else
                MessageBox.Show("El producto seleccionado no se encuentra en stock");
        }

        private void ArticulosEnStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }
    }
}
