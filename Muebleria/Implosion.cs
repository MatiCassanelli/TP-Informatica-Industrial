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
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public Implosion()
        {
            InitializeComponent();
            completarProductos();
        }
        
        public void completarProductos()
        {
            //var query = from tradu in db.traduccion
            //            from prod in db.producto
            //            where tradu.idDescriptionT.Equals(prod.idDescriptionP)
            //            && tradu.idLanguageT == LogIn.IdIdioma 
            //            && (prod.idTipo==2 || prod.idTipo == 3 || prod.idTipo == 4) //2 es buy y 4 es bruto
            //            select tradu.Traduccion_str;
            DateTime fecha = monthCalendar1.SelectionRange.Start;

            var querypc = from pcp in db.padre_componente_publicado
                          where pcp.fecha_aplicacion <= fecha
                          select new { padre = pcp.idPadreP, hijo1 = pcp.idHijoP, hijo2 = pcp.idHijoP };
            var queryps = from ps in db.producto_sustituto
                          //where ps.fecha_aplicacion <= fecha
                          select new { padre = ps.idPadre, hijo1 = ps.idHijo, hijo2 = ps.sustituto };

            var union = querypc.Union(queryps);

            var query = from aux in union
                        from p in db.producto
                        from t in db.traduccion
                        where t.idDescriptionT.Equals(p.idDescriptionP) && t.idLanguageT == LogIn.IdIdioma
                            && aux.hijo2==p.idProducto
                        select t.Traduccion_str;

            cbProductosBuscados.DataSource = query.ToList();
        }
        
        private void implosionar()  
        {            
            string prodBuscado = cbProductosBuscados.SelectedItem.ToString();

            DateTime fecha = monthCalendar1.SelectionRange.Start;

            var querypc = from pcp in db.padre_componente_publicado
                          where pcp.fecha_aplicacion <= fecha
                          select new { padre = pcp.idPadreP, hijo1 = pcp.idHijoP, hijo2 = pcp.idHijoP };
            var queryps = from ps in db.producto_sustituto
                              //where ps.fecha_aplicacion <= fecha
                          select new { padre = ps.idPadre, hijo1 = ps.idHijo, hijo2 = ps.sustituto };

            var union = querypc.Union(queryps);

            var queryhijo = from aux in union
                            from prod in db.producto
                            from trad in db.traduccion
                            where aux.hijo2 == prod.idProducto &&
                                prod.idDescriptionP == trad.idDescriptionT &&
                                trad.idLanguageT == LogIn.IdIdioma &&
                                trad.Traduccion_str == prodBuscado
                            select aux.padre;

            var final = from t in db.traduccion
                        from p in db.producto
                        from n in queryhijo
                        where t.idDescriptionT == p.idDescriptionP &&
                        t.idLanguageT == LogIn.IdIdioma && n == p.idProducto
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
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            completarProductos();
        }

        private void btn_implosionar_Click(object sender, EventArgs e)
        {
            lbprodfinales.Items.Clear();
            implosionar();
        }

        private void cbProductosBuscados_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbprodfinales.Items.Clear();
        }
    }
    
}
