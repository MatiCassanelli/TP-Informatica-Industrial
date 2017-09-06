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
            //completarProductos();
        }
        
        public void completarProductos()
        {
            //var query = from tradu in db.traduccion
            //            from prod in db.producto
            //            where tradu.idDescriptionT.Equals(prod.idDescriptionP)
            //            && tradu.idLanguageT == LogIn.IdIdioma 
            //            && (prod.idTipo==2 || prod.idTipo == 3 || prod.idTipo == 4) //2 es buy y 4 es bruto
            //            select tradu.Traduccion_str;
            DateTime fechacalendario = monthCalendar1.SelectionRange.Start;
            Fecha f = new Fecha();
            int fecha = f.convertir(fechacalendario);
            //var querypc = from pcp in db.padre_componente_publicado
            //              where pcp.fecha_aplicacion <= fecha
            //              select new { padre = pcp.idPadreP, hijo1 = pcp.idHijoP, hijo2 = pcp.idHijoP };

            var subquerypc = from pcp in db.padre_componente_publicado
                          where pcp.fecha_aplicacion <= fecha
                          select pcp;

            var last_updpc = from sb in subquerypc
                           orderby sb.fecha_aplicacion descending
                           select sb.fecha_aplicacion;
            var auxLUpc = last_updpc.ToList()[0];

            var last_vpc = from sb in subquerypc
                           where sb.fecha_aplicacion == auxLUpc
                             orderby sb.version descending
                             select sb.version;
            var auxLVpc = last_vpc.ToList()[0];

            var querypc = from pcp in db.padre_componente_publicado
                          where pcp.fecha_aplicacion == auxLUpc &&
                          pcp.version == auxLVpc
                          select new { padre = pcp.idPadreP, hijo1 = pcp.idHijoP, hijo2 = pcp.idHijoP };



            //var queryps = from ps in db.producto_sustituto
            //              where ps.fecha_aplicacion <= fecha
            //              select new { padre = ps.idPadre, hijo1 = ps.idHijo, hijo2 = ps.sustituto };

            var subqueryps = from ps in db.producto_sustituto
                          where ps.fecha_aplicacion <= fecha
                          select ps;

            var last_updps = from sb in subqueryps
                           orderby sb.fecha_aplicacion descending
                           select sb.fecha_aplicacion;
            var auxLUps = last_updps.ToList()[0];

            var last_vps = from sb in subqueryps
                         orderby sb.version descending
                         select sb.version;
            var auxLVps = last_vps.ToList()[0];

            var queryps = from ps in db.producto_sustituto
                          where ps.fecha_aplicacion == auxLUps &&
                          ps.version == auxLVps
                          select new { padre = ps.idPadre, hijo1 = ps.idHijo, hijo2 = ps.sustituto };


            var union = querypc.Union(queryps);

            var query = from u in union
                        from p in db.producto
                        from t in db.traduccion
                        where t.idDescriptionT.Equals(p.idDescriptionP) && 
                        t.idLanguageT == LogIn.IdIdioma &&
                        u.hijo2==p.idProducto
                        select t.Traduccion_str;

            cbProductosBuscados.DataSource = query.ToList();
        }
        
        private void implosionar()  
        {            
            string prodBuscado = cbProductosBuscados.SelectedItem.ToString();

            DateTime fechacalendario = monthCalendar1.SelectionRange.Start;
            Fecha f = new Fecha();
            int fecha = f.convertir(fechacalendario);

            var querypc = from pcp in db.padre_componente_publicado
                          where pcp.fecha_aplicacion <= fecha
                          select new { padre = pcp.idPadreP, hijo1 = pcp.idHijoP, hijo2 = pcp.idHijoP };
            var queryps = from ps in db.producto_sustituto
                          where ps.fecha_aplicacion >= fecha && ps.activado==1
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
