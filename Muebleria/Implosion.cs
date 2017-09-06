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
        //informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        List<int> componentes = new List<int>();
        public Implosion()
        {
            InitializeComponent();
            //completarProductos();
        }
        
        public void completarProductos()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            //var query = from tradu in db.traduccion
            //            from prod in db.producto
            //            where tradu.idDescriptionT.Equals(prod.idDescriptionP)
            //            && tradu.idLanguageT == LogIn.IdIdioma 
            //            && (prod.idTipo==2 || prod.idTipo == 3 || prod.idTipo == 4) //2 es buy y 4 es bruto
            //            select tradu.Traduccion_str;
            DateTime fechacalendario = monthCalendar1.SelectionRange.Start;
            Fecha f = new Fecha();
            int fecha = f.convertir(fechacalendario);

            try
            {
                List<int> relleno = new List<int>();
                
                //Padre-componente-publicado
                var comp = from pcp in db.padre_componente_publicado
                           where pcp.fecha_aplicacion <= fecha
                           select pcp.idPadreP;

                var padUnicos = comp.Distinct();


                //var subquerypc = from pcp in db.padre_componente_publicado
                //                 from pu in padUnicos
                //                 where pcp.fecha_aplicacion <= fecha &&
                //                 pcp.idPadreP == pu
                //                 select pcp;

                //var last_updpc = from sb in subquerypc
                //                 orderby sb.fecha_aplicacion descending
                //                 select sb.fecha_aplicacion;
                //var auxLUpc = last_updpc.ToList()[0];

                //var last_vpc = from sb in subquerypc
                //               where sb.fecha_aplicacion == auxLUpc
                //               orderby sb.version descending
                //               select sb.version;
                //var auxLVpc = last_vpc.ToList()[0];

                //var querypc = from pcp in db.padre_componente_publicado
                //              from pu in padUnicos
                //              where pcp.fecha_aplicacion == auxLUpc &&
                //              pcp.version == auxLVpc &&
                //              pcp.idPadreP == pu
                //              select new { padre = pcp.idPadreP, hijo1 = pcp.idHijoP, hijo2 = pcp.idHijoP };

                //foreach (var fila in querypc)
                //    relleno.Add(fila.hijo2);

                foreach (int item in padUnicos)
                {
                    informatica_industrial_dbEntities db2 = new informatica_industrial_dbEntities();
                    var subquerypc = from pcp in db2.padre_componente_publicado
                                     where pcp.fecha_aplicacion <= fecha &&
                                     pcp.idPadreP == item
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

                    var querypc = from pcp in db2.padre_componente_publicado
                                  where pcp.fecha_aplicacion == auxLUpc &&
                                  pcp.version == auxLVpc &&
                                  pcp.idPadreP == item
                                  select new { padre = pcp.idPadreP, hijo1 = pcp.idHijoP, hijo2 = pcp.idHijoP };

                    foreach (var fila in querypc)
                        relleno.Add(fila.hijo2);
                }


                //Producto-Sustituto
                var sust = from pcp in db.producto_sustituto
                           where pcp.fecha_aplicacion <= fecha
                           select pcp.idPadre;

                padUnicos = comp.Distinct();


                foreach(int item in padUnicos)
                {
                    informatica_industrial_dbEntities db2 = new informatica_industrial_dbEntities();
                    var subqueryps = from ps in db2.producto_sustituto
                                     where ps.fecha_aplicacion <= fecha &&
                                     ps.idPadre == item
                                     select ps;

                    var last_updps = from sb in subqueryps
                                     orderby sb.fecha_aplicacion descending
                                     select sb.fecha_aplicacion;
                    var auxLUps = last_updps.ToList()[0];

                    var last_vps = from sb in subqueryps
                                   orderby sb.version descending
                                   select sb.version;
                    var auxLVps = last_vps.ToList()[0];

                    var queryps = from ps in db2.producto_sustituto
                                  where ps.fecha_aplicacion == auxLUps &&
                                  ps.version == auxLVps &&
                                  ps.idPadre == item
                                  select new { padre = ps.idPadre, hijo1 = ps.idHijo, hijo2 = ps.sustituto };

                    foreach(var fila in queryps)
                    {
                        relleno.Add(fila.hijo2);
                    }
                }

                //Union y Consulta final
                //var union = querypc.Union(queryps);
                var union = relleno.Distinct();
                var tablaAUX = from t in db.traduccion
                             from p in db.producto
                             where p.idDescriptionP == t.idDescriptionT &&
                             t.idLanguageT == LogIn.IdIdioma
                             select new { id = p.idProducto, trad = t.Traduccion_str };
                var final = from a in tablaAUX
                           from u in union
                           where a.id == u
                           select a.trad;

                //var query = from u in asdasd                              //VER QUE ES ESTE ERROR!!!!!!!!!
                //            from p in db.producto
                //            from t in db.traduccion
                //            where t.idDescriptionT == p.idDescriptionP &&
                //            t.idLanguageT == LogIn.IdIdioma &&
                //            u.idProducto == p.idProducto
                //            select t.Traduccion_str;

                var mostrar = final.Distinct();
                componentes = union.ToList();
                cbProductosBuscados.DataSource = mostrar.ToList();
            }
            catch
            {
                MessageBox.Show("No existe registro de cómo está formado el producto en esa fecha");
            }
        }

        //private void implosionar()  
        //{            
        //    string prodBuscado = cbProductosBuscados.SelectedItem.ToString();

        //    DateTime fechacalendario = monthCalendar1.SelectionRange.Start;
        //    Fecha f = new Fecha();
        //    int fecha = f.convertir(fechacalendario);

        //    var querypc = from pcp in db.padre_componente_publicado
        //                  where pcp.fecha_aplicacion <= fecha
        //                  select new { padre = pcp.idPadreP, hijo1 = pcp.idHijoP, hijo2 = pcp.idHijoP };
        //    var queryps = from ps in db.producto_sustituto
        //                  where ps.fecha_aplicacion >= fecha && ps.activado==1
        //                  select new { padre = ps.idPadre, hijo1 = ps.idHijo, hijo2 = ps.sustituto };

        //    var union = querypc.Union(queryps);

        //    var queryhijo = from aux in union
        //                    from prod in db.producto
        //                    from trad in db.traduccion
        //                    where aux.hijo2 == prod.idProducto &&
        //                        prod.idDescriptionP == trad.idDescriptionT &&
        //                        trad.idLanguageT == LogIn.IdIdioma &&
        //                        trad.Traduccion_str == prodBuscado
        //                    select aux.padre;

        //    var final = from t in db.traduccion
        //                from p in db.producto
        //                from n in queryhijo
        //                where t.idDescriptionT == p.idDescriptionP &&
        //                t.idLanguageT == LogIn.IdIdioma && n == p.idProducto
        //                select t.Traduccion_str;

        //    if (final.ToList().Count > 0)
        //    {
        //        foreach (string item in final)
        //            lbprodfinales.Items.Add(item);
        //    }

        //    else
        //        MessageBox.Show("No existe ningun producto que se pueda fabricar con los productos seleccionados");
        //}

        private void implosionar()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            DateTime fechacalendario = monthCalendar1.SelectionRange.Start;
            Fecha f = new Fecha();
            int fecha = f.convertir(fechacalendario);

            var query1 = from t in db.traduccion
                         from p in db.producto
                         where t.idDescriptionT == p.idDescriptionP &&
                         t.Traduccion_str == cbProductosBuscados.Text.ToString()
                         select p.idProducto;


            //var query1 = from c in compAux
            //             from t in db.traduccion
            //             from p in db.producto
            //             where p.idDescriptionP == t.idDescriptionT &&
            //             t.Traduccion_str == c
            //             select p.idProducto;

            var query2 = from q in query1
                         from pcp in db.padre_componente_publicado
                         where q == pcp.idHijoP
                         select pcp.idPadreP;

            var query3 = from q in query1
                         from ps in db.producto_sustituto
                         where q == ps.sustituto
                         select ps.idPadre;

            var query4 = query2.Concat(query3).Distinct();

            //var query5 = from q in query4
            //             from t in db.traduccion
            //             from p in db.producto
            //             where q == p.idProducto &&
            //             p.idDescriptionP == t.idDescriptionT
            //             select t.Traduccion_str;

            var tablaAUX = from t in db.traduccion
                           from p in db.producto
                           where p.idDescriptionP == t.idDescriptionT &&
                           t.idLanguageT == LogIn.IdIdioma
                           select new { id = p.idProducto, trad = t.Traduccion_str };
            var final = from a in tablaAUX
                        from u in query4
                        where a.id == u
                        select a.trad;

            if (final.ToList().Count > 0)
            {
                foreach (string item in final)
                    lbprodfinales.Items.Add(item);
            }
            else
                MessageBox.Show("No existe ningun producto que se pueda fabricar con los productos seleccionados");

            ////Padre-componente-publicado
            //var subquerypc = from pcp in db.padre_componente_publicado
            //                 where pcp.fecha_aplicacion <= fecha
            //                 select pcp;

            //var last_updpc = from sb in subquerypc
            //                 orderby sb.fecha_aplicacion descending
            //                 select sb.fecha_aplicacion;
            //var auxLUpc = last_updpc.ToList()[0];

            //var last_vpc = from sb in subquerypc
            //               where sb.fecha_aplicacion == auxLUpc
            //               orderby sb.version descending
            //               select sb.version;
            //var auxLVpc = last_vpc.ToList()[0];

            //var querypc = from pcp in db.padre_componente_publicado
            //              where pcp.fecha_aplicacion == auxLUpc &&
            //              pcp.version == auxLVpc
            //              select new { padre = pcp.idPadreP, hijo1 = pcp.idHijoP, hijo2 = pcp.idHijoP };


            ////Producto-Sustituto
            //var subqueryps = from ps in db.producto_sustituto
            //                 where ps.fecha_aplicacion <= fecha
            //                 select ps;

            //var last_updps = from sb in subqueryps
            //                 orderby sb.fecha_aplicacion descending
            //                 select sb.fecha_aplicacion;
            //var auxLUps = last_updps.ToList()[0];

            //var last_vps = from sb in subqueryps
            //               orderby sb.version descending
            //               select sb.version;
            //var auxLVps = last_vps.ToList()[0];

            //var queryps = from ps in db.producto_sustituto
            //              where ps.fecha_aplicacion == auxLUps &&
            //              ps.version == auxLVps
            //              select new { padre = ps.idPadre, hijo1 = ps.idHijo, hijo2 = ps.sustituto };

            ////Union y Consulta final
            //var union = querypc.Union(queryps);

            ////Traer ID del componente o producto sustituto seleccionado en el combobox
            //var queryP = from p in db.producto
            //             from t in db.traduccion
            //             where p.idDescriptionP == t.idDescriptionT &&
            //             t.Traduccion_str == cbProductosBuscados.SelectedItem.ToString() &&
            //             t.idLanguageT == LogIn.IdIdioma
            //             select p.idProducto;
            //List<int> P = queryP.ToList();

            //var auxP = P[0];
            //var padres = from u in union
            //             where u.hijo2 == auxP
            //             select u.padre;

            //var query = from pa in padres
            //            from p in db.producto
            //            from t in db.traduccion
            //            where t.idDescriptionT.Equals(p.idDescriptionP) &&
            //            t.idLanguageT == LogIn.IdIdioma &&
            //            pa == p.idProducto
            //            select t.Traduccion_str;
            //var mostrar = query.Distinct();

            //if (mostrar.ToList().Count > 0)
            //{
            //    foreach (string item in mostrar)
            //        lbprodfinales.Items.Add(item);
            //}
            //else
            //    MessageBox.Show("No existe ningun producto que se pueda fabricar con los productos seleccionados");
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
