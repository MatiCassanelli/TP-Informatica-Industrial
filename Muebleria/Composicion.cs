using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;

namespace Muebleria
{
    public partial class Composicion : Form
    {
        Fecha f = new Fecha();
        int EstadoPublicacion = 1;      //1=No hay cambios || 0=Hay cambios, se puede publicar
        List<producto_sustituto> ListaPS = new List<producto_sustituto>();

        public Composicion()
        {
            InitializeComponent();
            LlenarCombos();
            ListaPS.Clear();
            CargarListaPS();
        }

        private void CargarListaPS()
        {
            List<producto_sustituto> relleno = ObtenerSustitutosActivados();

            foreach (producto_sustituto tupla in relleno)
            {
                ListaPS.Add(tupla);
            }
        }

        private List<producto_sustituto> ObtenerSustitutosActivados()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();

            var relleno = db.producto_sustituto.SqlQuery(@"SELECT * FROM `producto-sustituto` ps INNER JOIN(SELECT distinct ps3.idPadre, ps3.fecha_aplicacion FROM `producto-sustituto` ps3"
                    + " WHERE ps3.idPadre = " + P[0].ToString() + " and ps3.activado = 1 and ps3.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion FROM `producto-sustituto` ps2 WHERE ps2.idPadre = " + P[0].ToString() + " and ps2.activado = 1)) as t on ps.idPadre = t.idPadre"
                    + " WHERE ps.fecha_aplicacion = t.fecha_aplicacion and ps.activado = 1 and ps.version >= all(SELECT distinct ps4.version FROM `producto-sustituto` ps4 WHERE ps4.idPadre = " + P[0].ToString() + " and ps4.activado = 1 and ps4.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion"
                    + " FROM `producto-sustituto` ps5 WHERE ps5.idPadre = " + P[0].ToString() + " and ps5.activado = 1)); ");


            return relleno.ToList<producto_sustituto>();
        }

        private List<producto_sustituto> ObtenerSustitutos()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();

            var relleno = db.producto_sustituto.SqlQuery(@"SELECT * FROM `producto-sustituto` ps INNER JOIN(SELECT distinct ps3.idPadre, ps3.fecha_aplicacion FROM `producto-sustituto` ps3"
                    + " WHERE ps3.idPadre = " + P[0].ToString() + " and ps3.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion FROM `producto-sustituto` ps2 WHERE ps2.idPadre = " + P[0].ToString() + ")) as t on ps.idPadre = t.idPadre"
                    + " WHERE ps.fecha_aplicacion = t.fecha_aplicacion and ps.version >= all(SELECT distinct ps4.version FROM `producto-sustituto` ps4 WHERE ps4.idPadre = " + P[0].ToString() + " and ps4.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion"
                    + " FROM `producto-sustituto` ps5 WHERE ps5.idPadre = " + P[0].ToString() + ")); ");


            return relleno.ToList<producto_sustituto>();
        }

        private string CortarCadena (string c)
        {
            String[] substrings = c.Split(new string[] { "  x" }, StringSplitOptions.None);
            return substrings[0];
        }

        private void Actualizar_ListBox_Cargadas()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            lbCargadas.Items.Clear();

            //Obtener los id de los productos hijos del padre seleccionado en el cbProducto
            var query = from ph in db.padre_componente_temporal
                        from t in db.traduccion
                        from p in db.producto
                        where p.idProducto == ph.idPadre &&
                        p.idDescriptionP == t.idDescriptionT &&
                        t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                        t.idLanguageT == LogIn.IdIdioma
                        select new { id_Hijo = ph.idHijo, cant = ph.Cantidad, UMU =ph.U_medida_usada};

            //Obtener las descripciones de las unidades de medidas
            var subquery = from um in db.unidad_medida
                           from t in db.traduccion
                           where um.idDescriptionUM == t.idDescriptionT &&
                           t.idLanguageT == LogIn.IdIdioma
                           select new { id=um.idUnidad_Medida, t=t.Traduccion_str };

            //Obtener las descripciones de los productos seleccionados en la consulta anterior
            var query2 = from n in query
                         from sq in subquery
                         from t in db.traduccion
                         from p in db.producto
                         where p.idProducto == n.id_Hijo &&
                         p.idDescriptionP == t.idDescriptionT &&
                         sq.id == n.UMU &&
                         t.idLanguageT == LogIn.IdIdioma
                         select t.Traduccion_str + "  x" + n.cant.ToString() + " " + sq.t;
                         //select new { Componente = t.Traduccion_str, Cantidad = n.cant };
            List<string> q2 = query2.ToList();    

            foreach (string item in q2)
            {
                lbCargadas.Items.Add(item);
            }
        }

        private void LlenarCombos()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            lblProdSeleccionado.Visible = false;
            lblFechaAplicacion.Visible = false;

            //Consulta para traer la lista de los nombres de los productos de tipo "finales" y "intermedio make"
            var subquery = from p in db.producto
                           where p.idTipo == 1 || p.idTipo == 3
                           select p.idDescriptionP;


            var query = from t in db.traduccion
                        from p in subquery
                        where t.idDescriptionT == p &&
                        t.idLanguageT == LogIn.IdIdioma
                        select t.Traduccion_str;

            cbProductos.DataSource = query.ToList();

            //Consulta para traer la lista de los nombres de los productos de tipo "intermedio buy", "intermedio make" y "bruto"
            subquery = from p in db.producto
                       where p.idTipo == 2 || p.idTipo == 3 || p.idTipo == 4
                       select p.idDescriptionP;

            query = from t in db.traduccion
                    from p in subquery
                    where t.idDescriptionT == p &&
                    t.idLanguageT == LogIn.IdIdioma
                    select t.Traduccion_str;

            cbComponentes.DataSource = query.ToList();
            cbProductosSustitutos.DataSource = query.ToList();

            //Consulta para traer la lista de los nombres de las unidades de medida
            query = from um in db.unidad_medida from t in db.traduccion
                    where t.idDescriptionT == um.idDescriptionUM &&
                    t.idLanguageT == LogIn.IdIdioma
                    select t.Traduccion_str;

            cbUM.DataSource = query.ToList();
        }

        //Carga tupla en tabla "Padre-componente-temporal"
        private void btnCargar_Click(object sender, EventArgs e)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            if (String.IsNullOrEmpty(tbCantidad.Text) || String.IsNullOrEmpty(cbUM.Text))
                MessageBox.Show("Complete los datos para continuar");
            else
            {
                EstadoPublicacion = 0;

                float cant = int.Parse(tbCantidad.Text);
                tbCantidad.Clear();

                //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
                var queryP = from p in db.producto
                             from t in db.traduccion
                             where p.idDescriptionP == t.idDescriptionT &&
                             t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                             t.idLanguageT == LogIn.IdIdioma
                             select p.idProducto;
                List<int> P = queryP.ToList();


                //Obtener el id del producto Componente que coincide con el nombre seleccionado en el combo
                var queryC = from p in db.producto
                             from t in db.traduccion
                             where p.idDescriptionP == t.idDescriptionT &&
                             t.Traduccion_str == cbComponentes.SelectedItem.ToString() &&
                             t.idLanguageT == LogIn.IdIdioma
                             select p.idProducto;
                List<int> C = queryC.ToList();


                //Obtener el id de la unidad de medida de Compra del producto
                var pppp = C[0];        //Los casteos tienen que estar fuera de la consulta LINQ
                var queryUMD = from pUMD in db.producto
                               where pUMD.idProducto == pppp
                               select pUMD.Unidad_id_Purchase;
                List<int> UMD = queryUMD.ToList();


                //Obtener el id de la unidad de medida usada por el usuario
                var queryUMU = from uMU in db.unidad_medida
                               from t in db.traduccion
                               where uMU.idDescriptionUM == t.idDescriptionT &&
                               t.Traduccion_str == cbUM.SelectedItem.ToString() &&
                               t.idLanguageT == LogIn.IdIdioma
                               select uMU.idUnidad_Medida;
                List<int> UMU = queryUMU.ToList();

                padre_componente_temporal nuevoPC = new padre_componente_temporal()
                {
                    idPadre = P[0],
                    idHijo = C[0],
                    Cantidad = cant,                    
                    U_medida_default = UMD[0],
                    U_medida_usada = UMU[0]                     
                };

                //Intenta realizar un UPDATE en la tabla padre-componente
                try
                {
                    db.padre_componente_temporal.Add(nuevoPC);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("El componente ya ha sido agregado");
                    return;
                }
                Actualizar_ListBox_Cargadas();

            }
        }

        //Elimina tupla en tabla "Padre-componente-temporal"
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            if (lbCargadas.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un elemento para borrar");
                return;
            }
            else
            {
                EstadoPublicacion = 0;

                //producto seleccionado en el lbcargadas
                var aux = CortarCadena(lbCargadas.SelectedItem.ToString());
                var query = from pc in db.padre_componente_temporal
                            from t in db.traduccion
                            from p in db.producto
                            where pc.idHijo == p.idProducto &&
                            p.idDescriptionP == t.idDescriptionT &&
                            t.Traduccion_str == aux &&
                            t.idLanguageT == LogIn.IdIdioma
                            select pc;
                List<padre_componente_temporal> lPC = query.ToList();

                //Intenta hacer un delete en la tabla padre-componente
                try
                {
                    db.padre_componente_temporal.Remove(lPC[0]);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("El componente ya ha sido eliminado");
                    return;
                }

                //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
                var queryP = from p in db.producto
                             from t in db.traduccion
                             where p.idDescriptionP == t.idDescriptionT &&
                             t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                             t.idLanguageT == LogIn.IdIdioma
                             select p.idProducto;
                List<int> P = queryP.ToList();


                //Obtener el id del producto Componente que coincide con el nombre seleccionado en el listBox cargadas
                var queryC = from p in db.producto
                             from t in db.traduccion
                             where p.idDescriptionP == t.idDescriptionT &&
                             t.Traduccion_str == aux &&
                             t.idLanguageT == LogIn.IdIdioma
                             select p.idProducto;
                List<int> C = queryC.ToList();

                List<producto_sustituto> sustitutos = ListaPS.FindAll(
                    delegate (producto_sustituto ps)
                    {
                        return ps.idPadre == P[0] && ps.idHijo == C[0];
                    }
                );

                foreach(producto_sustituto item in sustitutos)
                    ListaPS.Remove(item);



                Actualizar_ListBox_Cargadas();
                lblProdSeleccionado.Visible = false;
                lbSustitutos.Items.Clear();

            }
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelComponentes.Enabled = true;
            Actualizar_tabla_temporal();
            ListaPS.Clear();
            CargarListaPS();
        }

        private void cbComponentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCantidades.Enabled = true;
        }

        private void tbCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < tbCantidad.Text.Length; i++)
            {
                if (tbCantidad.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void Composicion_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void lbCargadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCargadas.SelectedItem == null)
                return;
            SetLabel8();
            Actualizar_ListBox_Sustitutos();
        }

        private void SetLabel8()
        {
            lblProdSeleccionado.Visible = true;
            string texto = CortarCadena(lbCargadas.SelectedItem.ToString());
            lblProdSeleccionado.Text = texto;
        }

        private void btnCargarSustituto_Click(object sender, EventArgs e)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            if (lblProdSeleccionado.Visible == false)
            {
                MessageBox.Show("Seleccione un componente de la lista para indicar sustituto");
                return;
            }

            //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();


            //Obtener el id del producto Componente que coincide con el nombre seleccionado en el listBox cargadas
            var aux = CortarCadena(lbCargadas.SelectedItem.ToString());
            var queryC = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == aux &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> C = queryC.ToList();


            //Obtener el id del producto Sustituto que coincide con el nombre seleccionado en el combo
            var queryS = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductosSustitutos.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> S = queryS.ToList();

            producto_sustituto NuevoPS = new producto_sustituto()
            {
                idPadre = P[0],
                idHijo = C[0],
                sustituto = S[0],
                user_upd = LogIn.IdUsuario
            };

            if(ListaPS.Exists(delegate (producto_sustituto ps)
            {return ps.idPadre == P[0] && ps.idHijo == C[0] && ps.sustituto == S[0];}) == true)
                MessageBox.Show("El componente ya ha sido agregado");
            else
                ListaPS.Add(NuevoPS);
            
            Actualizar_ListBox_Sustitutos();
        }

        private void Actualizar_ListBox_Sustitutos()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            lbSustitutos.Items.Clear();

            //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();


            //Obtener el id del producto Componente que coincide con el nombre seleccionado en el listBox cargadas
            var aux = CortarCadena(lbCargadas.SelectedItem.ToString());
            var queryC = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == aux &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> C = queryC.ToList();

            List<producto_sustituto> ListaSustitutos = new List<producto_sustituto>();

            ListaSustitutos = ListaPS.FindAll(
                delegate (producto_sustituto ps)
                {
                    return ps.idPadre == P[0] && ps.idHijo == C[0];
                }
            );

            List<string> ListaPSMostrar = new List<string>();
            foreach (producto_sustituto ps in ListaSustitutos)
            {
                var queryFinal = from t in db.traduccion
                                 from p in db.producto
                                 where ps.sustituto == p.idProducto &&
                                 p.idDescriptionP == t.idDescriptionT &&
                                 t.idLanguageT == LogIn.IdIdioma
                                 select t.Traduccion_str;
                ListaPSMostrar.Add(queryFinal.ToList()[0].ToString());
            }

            foreach (string item in ListaPSMostrar)
            {
                lbSustitutos.Items.Add(item);
            }

        }

        private void btnEliminar_Sustituto_Click(object sender, EventArgs e)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            if (lbSustitutos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto sustituto para eliminar");
                return;
            }
            //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();


            //Obtener el id del producto Componente que coincide con el nombre seleccionado en el listBox cargadas
            var aux = CortarCadena(lbCargadas.SelectedItem.ToString());
            var queryC = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == aux &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> C = queryC.ToList();

            //Obtener el id del producto Sustituto que coincide con el nombre seleccionado en el listBox sustitutos
            var queryS = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == lbSustitutos.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> S = queryS.ToList();
            
            producto_sustituto sust = ListaPS.Find(
                delegate (producto_sustituto ps)
                {
                    return ps.idPadre == P[0] && ps.idHijo == C[0] && ps.sustituto == S[0];
                }
            );

            ListaPS.Remove(sust);

            Actualizar_ListBox_Sustitutos();

        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            //Filas de padre-componente-temporal
            var query = from pct in db.padre_componente_temporal
                        select pct;

            if (EstadoPublicacion == 1)
            {
                MessageBox.Show("Realice algún cambio antes de publicar");
                return;
            }
            //else if (query.Count() <= 0)
            //{
            //    MessageBox.Show("Cargue algún componente antes de publicar");
            //    return;
            //}
            else
            {
                if (f.convertir(monthCalendar1.SelectionRange.Start).ToString() == f.convertir(DateTime.Now).ToString())
                {
                    MessageBox.Show("No se pueden realizar cambios en la estructura en la misma semana de su publicacion.");
                    return;
                }
            }

            try
            {
                Publicar_Componentes();
                Publicar_Sustitutos();
                MessageBox.Show("La publicación se realizó de manera exitosa");
            }
            catch
            {
                MessageBox.Show("No se pudo realizar la publicación");
            }


            EstadoPublicacion = 1;
            Actualizar_tabla_temporal();
        }

        private void Publicar_Componentes()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            int aplicacion = f.convertir(monthCalendar1.SelectionRange.Start);
            DateTime upd = DateTime.Now;
            List<padre_componente_publicado> PCP = new List<padre_componente_publicado>();
            Fecha semana = new Fecha();
            List<padre_componente_publicado> relleno = ObtenerComponentes();    //necesito los padre-componentes activados o desactivados
            int v = 0;
            if (relleno.Count > 0)
                if (semana.convertir(monthCalendar1.SelectionRange.Start) == relleno[0].fecha_aplicacion)
                    v = relleno[0].version + 1;

            Desactivar_ultima_version_PCP();

            //Filas de padre-componente-temporal
            var query = from pct in db.padre_componente_temporal
                        select pct;

            foreach (var fila in query)
            {
                padre_componente_publicado NuevoPCP = new padre_componente_publicado()
                {
                    version = v,
                    idPadreP = fila.idPadre,
                    idHijoP = fila.idHijo,
                    Cantidad = fila.Cantidad,
                    U_medida_default = fila.U_medida_default,
                    U_medida_usada = fila.U_medida_usada,
                    fecha_aplicacion = aplicacion,
                    last_upd = upd,
                    user_upd = LogIn.IdUsuario,
                    activado = 1
                };
                PCP.Add(NuevoPCP);
            }
            try
            {
                foreach (padre_componente_publicado item in PCP)
                {
                    db.padre_componente_publicado.Add(item);
                    db.SaveChanges();
                }
            }
            catch
            {

            }
        }

        private void Desactivar_ultima_version_PCP()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();

            var ListaPCPparaDesactivar = db.padre_componente_publicado.SqlQuery("SELECT * FROM `padre-componente-publicado` pcp INNER JOIN(SELECT distinct pcp2.idPadreP, pcp2.fecha_aplicacion FROM `padre-componente-publicado` pcp2 WHERE pcp2.idPadreP = " + P[0].ToString() + " and pcp2.activado = 1 and pcp2.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion "
                                                                    + "FROM `padre-componente-publicado` pcp3 WHERE pcp3.idPadreP = " + P[0].ToString() + " and pcp3.activado = 1)) as t on pcp.idPadreP = t.idPadreP WHERE pcp.fecha_aplicacion = t.fecha_aplicacion and pcp.activado = 1 and pcp.version >= all(SELECT distinct pcp4.version FROM `padre-componente-publicado` pcp4 "
                                                                    + "WHERE pcp4.idPadreP = " + P[0].ToString() + " and pcp4.activado = 1 and pcp4.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion FROM `padre-componente-publicado` pcp5 WHERE pcp5.idPadreP = " + P[0].ToString() + " and pcp5.activado = 1)); ");

            if (ListaPCPparaDesactivar.Count() > 0)
            {
                foreach (var Item in ListaPCPparaDesactivar)
                    Item.activado = 0;

                db.SaveChanges();
            }
        }

        private void Publicar_Sustitutos()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            Fecha semana = new Fecha();
            List<producto_sustituto> PCP = new List<producto_sustituto>();
            List<producto_sustituto> relleno = ObtenerSustitutos();     //trae ultima version activada o desactivada

            int v=0;
            if (relleno.Count > 0)
                if (semana.convertir(monthCalendar1.SelectionRange.Start) == relleno[0].fecha_aplicacion)
                    v = relleno[0].version + 1;

            Desactivar_ultima_version_PS();

            foreach (producto_sustituto ps in ListaPS)
            {
                producto_sustituto NuevoPS = new producto_sustituto()
                {
                    version = v,
                    idPadre = ps.idPadre,
                    idHijo = ps.idHijo,
                    sustituto = ps.sustituto,
                    last_upd = DateTime.Now,
                    user_upd = ps.user_upd,
                    fecha_aplicacion = semana.convertir(monthCalendar1.SelectionRange.Start),
                    activado = 1
                };
                PCP.Add(NuevoPS);
            }
            try
            {
                foreach (producto_sustituto item in PCP)
                {
                    db.producto_sustituto.Add(item);
                    db.SaveChanges();
                }
            }
            catch
            {
               
            }
        }

        private void Desactivar_ultima_version_PS()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();

            var ListaPSparaDesactivar = db.producto_sustituto.SqlQuery(@"SELECT * FROM `producto-sustituto` ps INNER JOIN(SELECT distinct ps3.idPadre, ps3.fecha_aplicacion FROM `producto-sustituto` ps3"
                    + " WHERE ps3.idPadre = " + P[0].ToString() + " and ps3.activado = 1 and ps3.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion FROM `producto-sustituto` ps2 WHERE ps2.idPadre = " + P[0].ToString() + " and ps2.activado = 1)) as t on ps.idPadre = t.idPadre"
                    + " WHERE ps.fecha_aplicacion = t.fecha_aplicacion and ps.activado = 1 and ps.version >= all(SELECT distinct ps4.version FROM `producto-sustituto` ps4 WHERE ps4.idPadre = " + P[0].ToString() + " and ps4.activado = 1 and ps4.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion"
                    + " FROM `producto-sustituto` ps5 WHERE ps5.idPadre = " + P[0].ToString() + " and ps5.activado = 1)); ");

            if (ListaPSparaDesactivar.Count() > 0)
            {
                foreach (var Item in ListaPSparaDesactivar)
                    Item.activado = 0;

                db.SaveChanges();
            }
        }

        private void Actualizar_tabla_temporal()
        {
            VaciarTablaTemporal();      //Vaciar tabla padre-componente-temporal

            RellenarTablaTemporal();    //Traer de padre-componente-publicado a temporal los ultimos datos publicados

            Actualizar_ListBox_Cargadas();
            lbSustitutos.Items.Clear();
            lblProdSeleccionado.Visible = false;
        }

        private void VaciarTablaTemporal()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            var query = from pct in db.padre_componente_temporal
                        select pct;

            List<padre_componente_temporal> PCT = new List<padre_componente_temporal>();

            foreach (padre_componente_temporal item in query)
            {
                PCT.Add(item);
            }

            try
            {
                foreach (padre_componente_temporal item in PCT)
                {
                    db.padre_componente_temporal.Remove(item);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("El componente ya ha sido eliminado");
                return;
            }
        }

        private void RellenarTablaTemporal()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            List<padre_componente_publicado> relleno = ObtenerComponentesActivos();        //necesito los padre-componentes activos
            List<padre_componente_temporal> ListaPCT = new List<padre_componente_temporal>();

            foreach (padre_componente_publicado fila in relleno)
            {
                padre_componente_temporal NuevoPCT = new padre_componente_temporal()
                {
                    idPadre = fila.idPadreP,
                    idHijo = fila.idHijoP,
                    Cantidad = fila.Cantidad,
                    U_medida_default = fila.U_medida_default,
                    U_medida_usada = fila.U_medida_usada
                };
                ListaPCT.Add(NuevoPCT);
            }

            try
            {
                foreach (padre_componente_temporal item in ListaPCT)
                {
                    db.padre_componente_temporal.Add(item);
                    db.SaveChanges();
                }
                lblFechaAplicacion.Visible = true;
                string texto = relleno.ToList()[0].fecha_aplicacion.ToString();
                lblFechaAplicacion.Text = texto;
            }
            catch
            {
                lblFechaAplicacion.Visible = false;
                return;
            }
        }

        private List<padre_componente_publicado> ObtenerComponentesActivos()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();

            var ListaPCPActivos = db.padre_componente_publicado.SqlQuery("SELECT * FROM `padre-componente-publicado` pcp INNER JOIN(SELECT distinct pcp2.idPadreP, pcp2.fecha_aplicacion FROM `padre-componente-publicado` pcp2 WHERE pcp2.idPadreP = " + P[0].ToString() + " and pcp2.activado = 1 and pcp2.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion "
                                                                    + "FROM `padre-componente-publicado` pcp3 WHERE pcp3.idPadreP = " + P[0].ToString() + " and pcp3.activado = 1)) as t on pcp.idPadreP = t.idPadreP WHERE pcp.fecha_aplicacion = t.fecha_aplicacion and pcp.activado = 1 and pcp.version >= all(SELECT distinct pcp4.version FROM `padre-componente-publicado` pcp4 "
                                                                    + "WHERE pcp4.idPadreP = " + P[0].ToString() + " and pcp4.activado = 1 and pcp4.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion FROM `padre-componente-publicado` pcp5 WHERE pcp5.idPadreP = " + P[0].ToString() + " and pcp5.activado = 1)); ");

            return ListaPCPActivos.ToList<padre_componente_publicado>();
        }

        private List<padre_componente_publicado> ObtenerComponentes()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();

           var componentes = db.padre_componente_publicado.SqlQuery("SELECT * FROM `padre-componente-publicado` pcp INNER JOIN(SELECT distinct pcp2.idPadreP, pcp2.fecha_aplicacion FROM `padre-componente-publicado` pcp2 WHERE pcp2.idPadreP = " + P[0].ToString() + " and pcp2.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion "
                                                                    + "FROM `padre-componente-publicado` pcp3 WHERE pcp3.idPadreP = " + P[0].ToString() + ")) as t on pcp.idPadreP = t.idPadreP WHERE pcp.fecha_aplicacion = t.fecha_aplicacion and pcp.version >= all(SELECT distinct pcp4.version FROM `padre-componente-publicado` pcp4 "
                                                                    + "WHERE pcp4.idPadreP = " + P[0].ToString() + " and pcp4.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion FROM `padre-componente-publicado` pcp5 WHERE pcp5.idPadreP = " + P[0].ToString() + ")); ");
            return componentes.ToList<padre_componente_publicado>();
        }

        private void cbProductos_Click(object sender, EventArgs e)
        {
            
            if(EstadoPublicacion == 0)
                if(MessageBox.Show("Publique los cambios antes de seleccionar otro producto, de lo contrario los cambios se perderán", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.Cancel)
                {
                    EstadoPublicacion = 1;
                    Actualizar_tabla_temporal();
                }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            EstadoPublicacion = 0;
            if (DateTime.Now > monthCalendar1.SelectionRange.Start)
            {
                MessageBox.Show("No se puede publicar una estructura para una fecha ya pasada");
                monthCalendar1.SetDate(DateTime.Now);
            }
        }
    }
}
