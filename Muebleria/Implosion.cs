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
    public partial class Implosion : Form
    {
        informatica_industrial_dbEntities testcontext = new informatica_industrial_dbEntities();
        public Implosion()
        {
            InitializeComponent();
            completarProductos();
            completarUM();
        }

        private void btnImplosionar_Click(object sender, EventArgs e)
        {
            lbprodfinales.Items.Clear();
            if (!String.IsNullOrEmpty(tbCantidad.Text))
            {
                implosionar();
            }
            else
                MessageBox.Show("Complete los datos para continuar");
                      
        }

        private void cbProductosBuscados_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCantidades.Enabled = true;
            tbCantidad.Clear();
            lbprodfinales.Items.Clear();
        }

        public void completarProductos()
        {
            var query = from tradu in testcontext.traduccion
                        from prod in testcontext.producto
                        where tradu.idDescriptionT.Equals(prod.idDescriptionP)
                        && tradu.idLanguageT == LogIn.IdIdioma && (prod.idTipo==2 || prod.idTipo == 4) //2 es buy y 4 es bruto
                        select tradu.Traduccion_str;

            cbProductosBuscados.DataSource = query.ToList();
        }

        public void completarUM()
        {
            var query = from trad in testcontext.traduccion
                        from um in testcontext.unidad_medida
                        where trad.idDescriptionT.Equals(um.idDescriptionUM)
                        && trad.idLanguageT == LogIn.IdIdioma
                        select trad.Traduccion_str;
            cbUM.DataSource = query.ToList();
        }
        private void implosionar()  
        {
            string prodBuscado = cbProductosBuscados.SelectedItem.ToString();
            int cantIngresada = Convert.ToInt32(tbCantidad.Text);

            var subquery = from pc in testcontext.padre_componente
                           from prod in testcontext.producto
                           from trad in testcontext.traduccion
                           where pc.idHijo == prod.idProducto &&
                               prod.idDescriptionP == trad.idDescriptionT &&
                                trad.idLanguageT == LogIn.IdIdioma &&
                           trad.Traduccion_str == prodBuscado &&
                           pc.Cantidad <= cantIngresada
                           select pc.idPadre;

            var query = from t in testcontext.traduccion
                        from p in testcontext.producto
                        from n in subquery
                        where t.idDescriptionT == p.idDescriptionP &&
                        t.idLanguageT == LogIn.IdIdioma &&
                            n == p.idProducto
                        select t.Traduccion_str;

            if (query.ToList().Count > 0)
            {
                foreach (string item in query)
                    lbprodfinales.Items.Add(item);
            }

            else
                MessageBox.Show("no anduvo");
        }
    }
    
}
