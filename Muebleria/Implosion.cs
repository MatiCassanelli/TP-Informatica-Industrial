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
        }
        
        private void cbProductosBuscados_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbprodfinales.Items.Clear();
            implosionar();
        }

        public void completarProductos()
        {
            var query = from tradu in testcontext.traduccion
                        from prod in testcontext.producto
                        where tradu.idDescriptionT.Equals(prod.idDescriptionP)
                        && tradu.idLanguageT == LogIn.IdIdioma 
                        && (prod.idTipo==2 || prod.idTipo == 3 || prod.idTipo == 4) //2 es buy y 4 es bruto
                        select tradu.Traduccion_str;

            cbProductosBuscados.DataSource = query.ToList();
        }
        
        private void implosionar()  
        {            
            string prodBuscado = cbProductosBuscados.SelectedItem.ToString();
            var queryhijo = from pc in testcontext.padre_componente_temporal
                            from prod in testcontext.producto
                            from trad in testcontext.traduccion
                            where pc.idHijo == prod.idProducto &&
                                prod.idDescriptionP == trad.idDescriptionT &&
                                 trad.idLanguageT == LogIn.IdIdioma &&
                            trad.Traduccion_str == prodBuscado 
                            select pc.idPadre;

            var final = from t in testcontext.traduccion
                        from p in testcontext.producto
                        from n in queryhijo
                        where t.idDescriptionT == p.idDescriptionP &&
                        t.idLanguageT == LogIn.IdIdioma &&
                            n == p.idProducto
                        select t.Traduccion_str;

            if (final.ToList().Count > 0)
            {
                foreach (string item in final)
                    lbprodfinales.Items.Add(item);
            }

            else
                MessageBox.Show("No existe ningun producto que se pueda fabricar con los productos seleccionados");
        }

        private void Implosion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            //this.Close();
            menu.ShowDialog();
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back))
                return;

            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
    }
    
}
