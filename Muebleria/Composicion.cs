﻿using System;
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
        int EstadoPublicacion = 1;      //1=No hay cambios || 0=Hay cambios, se puede publicar
        List<producto_sustituto> ListaPS = new List<producto_sustituto>();

        public Composicion()
        {
            InitializeComponent();
            LlenarCombos();
            CargarListaPS();
        }

        private void CargarListaPS()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            //HACER CONSULTA QUE TRAIGA LOS SUSTITUTOS CARGADOS EN EL LISTBOX DE CARGADOS

            var query = from ps in db.producto_sustituto
                        select ps;

            //foreach (producto_sustituto tupla in query)
            //{

            //}
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


                //Conversión de unidad para guardar en tabla
                //float coeficiente = 1;
                //int auxD = UMD[0];
                //int auxU = UMU[0];
                //if (UMD[0] != UMU[0])
                //{
                //    try
                //    {
                //        var query = from conv in db.conversion
                //                    where conv.U_medida_default == auxD &&
                //                    conv.U_medida == auxU
                //                    select conv.Coeficiente;
                //        coeficiente = query.ToList()[0];
                //    }
                //    catch
                //    {
                //        int aux = UMD[0];
                //        var query = from um in db.unidad_medida
                //                    from t in db.traduccion
                //                    where um.idDescriptionUM == t.idDescriptionT &&
                //                    um.idUnidad_Medida == aux &&
                //                    t.idLanguageT == LogIn.IdIdioma
                //                    select t.Traduccion_str;

                //        MessageBox.Show("Unidad de medida inválida para este producto. Intente con: " + query.ToList()[0].ToString());
                //        return;
                //    }

                //}

                //cant = cant / coeficiente;
                //Agregar nueva fila a la tabla "Padre-Componente"

                padre_componente_temporal nuevoPC = new padre_componente_temporal()
                {
                    idPadre = P[0],
                    idHijo = C[0],
                    Cantidad = cant,                     //cant AHORA no incluye la cantidad modificada por el coeficiente de la tabla conversion
                    U_medida_default = UMD[0],
                    U_medida_usada = UMU[0],
                    //Last_Upd = DateTime.Now,
                    //User_Upd = LogIn.IdUsuario                        
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
                Actualizar_ListBox_Cargadas();
                lblProdSeleccionado.Visible = false;
                lbSustitutos.Items.Clear();

            }
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelComponentes.Enabled = true;
            Actualizar_tabla_temporal();
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

            if (e.KeyChar >= 49 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void Composicion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
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

        //MODIFICAR
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

            //if (ListaPS.Contains(NuevoPS) == true)
            //    MessageBox.Show("El componente ya ha sido agregado");
            //else
            //    ListaPS.Add(NuevoPS);
            /* TENGO Q MANEJAR TODO CON UNA LISTA INTERNA DEL PROGRAMA
            
            //Obtener tupla indicada de la tabla producto_sustituto
            var auxp = P[0];
            var auxc = C[0];
            var auxs = S[0];
            var sustituto = from ps in db.producto_sustituto
                            where ps.idPadre == auxp &&
                            ps.idHijo == auxc &&
                            ps.sustituto == auxs
                            select ps;
            
            
            if(sustituto.Count() > 0)
            {
                foreach (var Item in sustituto)
                    Item.activado = 1;

                db.SaveChanges();
            }
            else
            {
                producto_sustituto nuevoPS = new producto_sustituto()
                {
                    idPadre = P[0],
                    idHijo = C[0],
                    sustituto = S[0],
                    activado = 1
                };
                try
                {
                    db.producto_sustituto.Add(nuevoPS);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("El componente ya ha sido agregado");
                    return;
                }
            }
            */
            Actualizar_ListBox_Sustitutos();
        }

        //MODIFICAR
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

            producto_sustituto NuevoPS = new producto_sustituto()
            {
                idPadre = P[0],
                idHijo = C[0],
                user_upd = LogIn.IdUsuario
            };

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

        //MODIFICAR
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

            //producto_sustituto NuevoPS = new producto_sustituto()
            //{
            //    idPadre = P[0],
            //    idHijo = C[0],
            //    sustituto = S[0],
            //    user_upd = LogIn.IdUsuario
            //};

            producto_sustituto sust = ListaPS.Find(
                delegate (producto_sustituto ps)
                {
                    return ps.idPadre == P[0] && ps.idHijo == C[0] && ps.sustituto == S[0];
                }
            );

            ListaPS.Remove(sust);
            /*
            //Obtener tupla indicada de la tabla producto_sustituto
            var auxp = P[0];
            var auxc = C[0];
            var auxs = S[0];
            var sustituto = from ps in db.producto_sustituto
                            where ps.idPadre == auxp &&
                            ps.idHijo == auxc &&
                            ps.sustituto == auxs
                            select ps;

            foreach (var Item in sustituto)
                Item.activado = 0;

            db.SaveChanges();
            */

            Actualizar_ListBox_Sustitutos();

        }

        //MODIFICAR --> debe publicar la lista de productos-sustitutos
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
            else if (query.Count() <= 0)
            {
                MessageBox.Show("Cargue algún componente antes de publicar");
                return;
            }
            else if (lblFechaAplicacion.Text == monthCalendar1.SelectionRange.Start.ToShortDateString())
            {
                MessageBox.Show("En esta fecha ya se ha realizado una publicación de este producto. Seleccione otra");
                //EstadoPublicacion = 1;
                return;
            }

            if (MessageBox.Show("¿Esta seguro que desea realizar la publicación? Una vez publicada no podrá realizar modificaciones para la misma fecha de aplicación.", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;


            //MODIFICADOOOOOOOOOOOOOO
            int aplicacion = 1;//monthCalendar1.SelectionRange.Start.Date;
            DateTime upd = DateTime.Now;

            List<padre_componente_publicado> PCP = new List<padre_componente_publicado>();

            foreach (var fila in query)
            {
                padre_componente_publicado NuevoPCP = new padre_componente_publicado()
                {
                    idPadreP = fila.idPadre,
                    idHijoP = fila.idHijo,
                    Cantidad = fila.Cantidad,
                    U_medida_default = fila.U_medida_default,
                    U_medida_usada = fila.U_medida_usada,
                    fecha_aplicacion = aplicacion,
                    last_upd = upd,
                    user_upd = LogIn.IdUsuario
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
                MessageBox.Show("El producto ya ha sido publicado");
                //return;
            }

            Publicar_Sustitutos();

            EstadoPublicacion = 1;
            Actualizar_tabla_temporal();
        }

        private void Publicar_Sustitutos()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            List<producto_sustituto> PCP = new List<producto_sustituto>();
            foreach(producto_sustituto ps in ListaPS)
            {
                producto_sustituto NuevoPS = new producto_sustituto()
                {
                    idPadre = ps.idPadre,
                    idHijo = ps.idHijo,
                    sustituto = ps.sustituto,
                    last_upd = DateTime.Now,
                    user_upd = ps.user_upd,
                    fecha_aplicacion = 1    //PONER LA F() CONVERTIR
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
                MessageBox.Show("No se agregaron los productos sustitutos");
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

            //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();

            //var blogs = db.producto.SqlQuery("SELECT * FROM producto").ToList();
            var relleno = db.padre_componente_publicado.SqlQuery("SELECT * FROM `padre-componente-publicado` pcp WHERE pcp.idPadreP = " + P[0].ToString() + " and pcp.fecha_aplicacion >= all(SELECT distinct fecha_aplicacion FROM `padre-componente-publicado` pcp2 WHERE pcp2.idPadreP = " + P[0].ToString() + ")");
            List<padre_componente_temporal> ListaPCT = new List<padre_componente_temporal>();

            

            foreach (var fila in relleno)
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
                //MessageBox.Show("No hay datos en la tabla padre componente-publicada");
                lblFechaAplicacion.Visible = false;
                return;
            }
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
        }
    }
}
