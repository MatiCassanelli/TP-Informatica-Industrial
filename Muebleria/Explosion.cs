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
    public partial class Explosion : Form
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public Explosion()
        {
            InitializeComponent();
            LlenarCombos();
        }

        private void LlenarCombos()
        {
            //Consulta para traer la lista de los nombres de los productos de "intermedio buy", "intermedio make" y "bruto"
            var subquery = from p in db.producto
                           where p.idTipo == 1 || p.idTipo == 3
                           select p.idDescriptionP;

            var query = from t in db.traduccion
                        from p in subquery
                        where t.idDescriptionT == p &&
                        t.idLanguageT == LogIn.IdIdioma
                        select t.Traduccion_str;

            cbProductos.DataSource = query.ToList();
        }

        private void ActualizarListBox()
        {
            lbComponentes.Items.Clear();
            ConsultarRecursivo(cbProductos.SelectedItem.ToString(), cbProductos.SelectedItem.ToString());
        }

        private List<PadreHijo> consultarPadre(string padre)
        {
            List<padre_componente_publicado> relleno = ObtenerComponentes(padre);
            List<padre_componente_publicado> aux = new List<padre_componente_publicado>();
            foreach (padre_componente_publicado fila in relleno)
            {
                padre_componente_publicado pcp = new padre_componente_publicado()
                {
                    idPadreP = fila.idPadreP,
                    idHijoP = fila.idHijoP,
                    Cantidad = fila.Cantidad,
                    U_medida_default = fila.U_medida_default,
                    U_medida_usada = fila.U_medida_usada
                };
                aux.Add(fila);
            }

            //Obtener las descripciones de las unidades de medidas
            var subquery = from um in db.unidad_medida
                           from t in db.traduccion
                           where um.idDescriptionUM == t.idDescriptionT &&
                           t.idLanguageT == LogIn.IdIdioma
                           select new { id = um.idUnidad_Medida, t = t.Traduccion_str };

            //Obtener las descripciones de los productos seleccionados en la consulta anterior
            List<PadreHijo> lista = new List<PadreHijo>();

            foreach (padre_componente_publicado pcp in aux)
            {
                var query2 = from sq in subquery
                             from t in db.traduccion
                             from p in db.producto
                             where p.idProducto == pcp.idHijoP &&
                             p.idDescriptionP == t.idDescriptionT &&
                             sq.id == pcp.U_medida_usada &&
                             t.idLanguageT == LogIn.IdIdioma
                             //select t.Traduccion_str + "  x" + n.cant.ToString() + " " + sq.t;
                             select new { nombre = t.Traduccion_str, cant = pcp.Cantidad.ToString(), um = sq.t };

                foreach (var item in query2)
                {
                    lista.Add(new PadreHijo(padre, item.nombre, Convert.ToInt32(item.cant), item.um));
                }
            }            
            return lista;
        }

        private List<string> buscarSustitutos(string padre, string hijo)
        {
            List<producto_sustituto> relleno = ObtenerSustitutos(padre, hijo);
            List<producto_sustituto> aux = new List<producto_sustituto>();
            foreach(producto_sustituto item in relleno)
            {
                producto_sustituto ps = new producto_sustituto()
                {
                    idPadre = item.idPadre,
                    idHijo = item.idHijo
                };
                aux.Add(item);
            }
            List<string> lista = new List<string>();
            foreach(producto_sustituto item in aux)
            {
                var queryFinal = from t in db.traduccion
                                 from p in db.producto
                                 where item.sustituto == p.idProducto &&
                                 p.idDescriptionP == t.idDescriptionT &&
                                 t.idLanguageT == LogIn.IdIdioma
                                 select t.Traduccion_str;
                foreach (string ps in queryFinal)
                    lista.Add(ps);
            }           
            return lista;
        }

        private List<padre_componente_publicado> ObtenerComponentes(string prod)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            Fecha f = new Fecha();
            int fecha = f.convertir(monthCalendar1.SelectionRange.Start);
            //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == prod &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();

            //var blogs = db.producto.SqlQuery("SELECT * FROM producto").ToList();
            //var relleno = db.padre_componente_publicado.SqlQuery("SELECT * FROM `padre-componente-publicado` pcp WHERE pcp.idPadreP = " + P[0].ToString() + " and pcp.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion FROM `padre-componente-publicado` pcp2 WHERE pcp2.idPadreP = " + P[0].ToString() + ")");
            var componentes = db.padre_componente_publicado.SqlQuery("SELECT pcp.* FROM `padre-componente-publicado` pcp INNER JOIN(SELECT distinct pcp2.idPadreP, pcp2.fecha_aplicacion FROM `padre-componente-publicado` pcp2 WHERE pcp2.idPadreP = " + P[0].ToString()+ " and pcp2.fecha_aplicacion = " + traerFechas(prod) + ") as t on pcp.idPadreP = t.idPadreP WHERE pcp.fecha_aplicacion = t.fecha_aplicacion and pcp.version >= all(SELECT distinct pcp4.version FROM `padre-componente-publicado` pcp4 WHERE pcp4.idPadreP = " + P[0].ToString() + " and pcp4.fecha_aplicacion = " + traerFechas(prod).ToString() + ");");
            return componentes.ToList<padre_componente_publicado>();
        }

        private List<producto_sustituto> ObtenerSustitutos(string padre, string hijo)
        {
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == padre &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();

            var queryC = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == hijo &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> C = queryC.ToList();
            Fecha f = new Fecha();
            int fecha = f.convertir(monthCalendar1.SelectionRange.Start);
            //Obtener id de los productos sustitutos
            var plista = P[0];
            var hlista = C[0];
            //var queryS = from ps in db.producto_sustituto
            //             where ps.idPadre == plista &&
            //             ps.idHijo == hlista //&
            //             //ps.activado == 1
            //             select ps.sustituto;

            var sust = db.producto_sustituto.SqlQuery("SELECT pcp.* FROM `producto-sustituto` pcp INNER JOIN (SELECT distinct pcp2.idPadre, pcp2.fecha_aplicacion FROM `producto-sustituto` pcp2 WHERE pcp2.idPadre = " + P[0].ToString() + " and pcp2.idHijo = " + C[0].ToString() + " and pcp2.fecha_aplicacion = " + traerFechas(padre).ToString() + ") as t on pcp.idPadre = t.idPadre WHERE pcp.fecha_aplicacion = t.fecha_aplicacion and pcp.version >= all(SELECT distinct pcp4.version FROM `producto-sustituto` pcp4 WHERE pcp4.idPadre = " + P[0].ToString() + " and pcp4.idHijo = " + C[0].ToString() + " and pcp4.fecha_aplicacion = " + traerFechas(padre).ToString() + ");");

            //var sust = db.producto_sustituto.SqlQuery("SELECT pcp.* FROM `producto-sustituto` pcp INNER JOIN(SELECT distinct pcp2.idPadre, pcp2.fecha_aplicacion FROM `producto-sustituto` pcp2 WHERE pcp2.idPadre = " + P[0].ToString() + " and pcp2.idHijo = " + C[0].ToString() + " and pcp2.activado = 1 and pcp2.fecha_aplicacion <= " + traerFechas(padre).ToString() + ") as t on pcp.idPadre = t.idPadre WHERE pcp.fecha_aplicacion = t.fecha_aplicacion and pcp.activado = 1 and pcp.version >= all(SELECT distinct pcp4.version FROM `producto-sustituto` pcp4 WHERE pcp4.idPadre = " + P[0].ToString() + " and pcp4.idHijo = " + C[0].ToString() + " and pcp4.activado = 1 and pcp4.fecha_aplicacion <= " + traerFechas(padre).ToString() + "); ");
            return sust.ToList<producto_sustituto>();
        }

        private void ConsultarRecursivo(string padre, string prodfinal)
        {
            List<PadreHijo> aux = consultarPadre(padre);
            if (aux.Count > 0)
            {
                foreach (PadreHijo item in aux)
                {
                    string tabs = "";
                    string sustitutos = "";
                    if (prodfinal != item.Padre)
                        tabs += '\t';
                    UM_valor umv = consultarUM(item.Hijo);
                    List<string> SustitutosList = buscarSustitutos(item.Padre, item.Hijo);
                    if (SustitutosList.Count > 0)
                    {
                        for (int i = 0; i < SustitutosList.Count; i++)
                        {
                            if (i >= 1)
                                sustitutos += ", " + SustitutosList[i];
                            else
                                sustitutos += SustitutosList[i];
                        }
                        lbComponentes.Items.Add(tabs + item.Hijo + " x " + umv.Conversion + ' ' + umv.Um + '(' + sustitutos + ')');
                    }
                    else
                        lbComponentes.Items.Add(tabs + item.Hijo + " x " + umv.Conversion + ' ' + umv.Um);

                    ConsultarRecursivo(item.Hijo, prodfinal);
                }
            }
        }

        
        private UM_valor consultarUM(string prod)
        {
            if (!String.IsNullOrEmpty(tbCantidad.Text))
            {
                float cant = int.Parse(tbCantidad.Text);

                //Obtener el id del producto seleccionado en el combo
                var queryC = from p in db.producto
                             from t in db.traduccion
                             where p.idDescriptionP == t.idDescriptionT &&
                             t.Traduccion_str == prod &&
                             t.idLanguageT == LogIn.IdIdioma
                             select p.idProducto;
                List<int> C = queryC.ToList();


                //Obtener el id de la unidad de medida de Compra del producto
                var pppp = C[0];
                var queryUMD = from pUMD in db.producto
                               where pUMD.idProducto == pppp
                               select pUMD.Unidad_id_Purchase;
                List<int> UMD = queryUMD.ToList();

                //Obtener el id de la unidad de medida cargada por el usuario en la tabla pc publicada
                var queryUMU = from c in queryC
                               from p in db.padre_componente_publicado
                               where c == p.idHijoP
                               select p.U_medida_usada;
                List <int> UMU = queryUMU.ToList();


                //Conversión de unidad para guardar en tabla
                float coeficiente = 1;
                int auxD = UMD[0];
                int auxU = UMU[0];

                var cantpc = from pc in db.padre_componente_publicado
                             from c in C
                             where pc.idHijoP == c
                             select pc.Cantidad;
                float cantidadPC = cantpc.ToList()[0];

                cant = (cantidadPC / coeficiente) * cant;

                if (UMD[0] != UMU[0])
                {
                    try
                    {
                        var query = from conv in db.conversion
                                    where conv.U_medida_default == auxD &&
                                    conv.U_medida == auxU
                                    select conv.Coeficiente;
                        coeficiente = query.ToList()[0];

                        var desc = from t in db.traduccion
                                   from um in db.unidad_medida
                                   where t.idDescriptionT == um.idDescriptionUM && um.idUnidad_Medida==auxD && t.idLanguageT==LogIn.IdIdioma
                                   select t.Traduccion_str;
                        return new UM_valor(desc.ToList()[0], cant);
                    }
                    catch
                    {
                        var desc = from t in db.traduccion
                                   from um in db.unidad_medida
                                   where t.idDescriptionT == um.idDescriptionUM && um.idUnidad_Medida == auxU
                                   select t.Traduccion_str;
                        return new UM_valor(desc.ToList()[0], cant);
                    }
                }
                var d = from t in db.traduccion
                           from um in db.unidad_medida
                           where t.idDescriptionT == um.idDescriptionUM && um.idUnidad_Medida == auxD && t.idLanguageT == LogIn.IdIdioma
                           select t.Traduccion_str;
                return new UM_valor(d.ToList()[0], cant);
            }
            return new UM_valor();            
        }

        private int traerFechas(string prod)
        {
            DateTime fechacalendario = monthCalendar1.SelectionRange.Start;
            Fecha f = new Fecha();
            int fecha = f.convertir(fechacalendario);
            //var subquery = db.padre_componente_publicado.SqlQuery("select distinct `padre-componente-publicado`.fecha_aplicacion from `padre-componente-publicado` order by fecha_aplicacion desc");
            var QueryidPadre = from p in db.producto
                               from t in db.traduccion
                               where p.idDescriptionP == t.idDescriptionT &&
                               t.Traduccion_str == prod &&
                               t.idLanguageT == LogIn.IdIdioma
                               select p.idProducto;

            var subquery = from pc in db.padre_componente_publicado
                           from qinp in QueryidPadre
                           where pc.idPadreP == qinp
                           orderby pc.fecha_aplicacion descending
                           select pc.fecha_aplicacion;
            List<int> fechasconsulta = subquery.ToList();

            int fechaAplicacion = 1;
            for (int i = 0; i < fechasconsulta.Count; i++)
            {
                if (fecha >= fechasconsulta[i])
                {
                    fechaAplicacion = fechasconsulta[i];
                    i = fechasconsulta.Count;
                }
            }
            return fechaAplicacion;
        }

        private void Explosion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.ShowDialog();
        }

        private void btnExplosionar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbCantidad.Text))
            {
                ActualizarListBox();
            }
            else
                MessageBox.Show("Complete los datos para continuar");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbComponentes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
