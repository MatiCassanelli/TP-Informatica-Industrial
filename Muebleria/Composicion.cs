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

namespace Muebleria
{
    public partial class Composicion : Form
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        int EstadoPublicacion = 1;
        public Composicion()
        {
            InitializeComponent();
            LlenarCombos();
        }

        private string CortarCadena (string c)
        {
            String[] substrings = c.Split(new string[] { "  x" }, StringSplitOptions.None);
            return substrings[0];
        }

        private void Actualizar_ListBox_Cargadas()
        {
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
            lblProdSeleccionado.Visible = false;

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

        private void btnCargar_Click(object sender, EventArgs e)
        {
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

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
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

            }
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelComponentes.Enabled = true;
            Actualizar_ListBox_Cargadas();
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

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Composicion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.ShowDialog();
        }

        private void lbCargadas_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            Actualizar_ListBox_Sustitutos();
        }

        private void Actualizar_ListBox_Sustitutos()
        {
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

            //Obtener id de los productos sustitutos
            var padre = P[0];
            var hijo = C[0];
            var queryS = from ps in db.producto_sustituto
                         where ps.idPadre == padre &&
                         ps.idHijo == hijo &&
                         ps.activado == 1
                         select ps.sustituto;

            var queryFinal = from s in queryS
                             from t in db.traduccion
                             from p in db.producto
                             where s == p.idProducto &&
                             p.idDescriptionP == t.idDescriptionT &&
                             t.idLanguageT == LogIn.IdIdioma
                             select t.Traduccion_str;


            foreach (string item in queryFinal)
            {
                lbSustitutos.Items.Add(item);
            }
        }

        private void btnEliminar_Sustituto_Click(object sender, EventArgs e)
        {
            if(lbSustitutos.SelectedItem == null)
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

            Actualizar_ListBox_Sustitutos();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(monthCalendar1.SelectionRange.Start.ToShortDateString());
            EstadoPublicacion = 1;

            var query = from pct in db.padre_componente_temporal
                        select pct;
            DateTime aplicacion = monthCalendar1.SelectionRange.Start.Date;
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
                foreach(padre_componente_publicado item in PCP)
                {
                    db.padre_componente_publicado.Add(item);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("El producto ya ha sido publicado");
                return;
            }

            Actuaizar_tabla_temporal();

        }

        private void Actuaizar_tabla_temporal()
        {
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

            //TRAER DE PUBLICADA A TEMPORAL LOS UTLIMOS DATOS
            //Actualizar_ListBox_Cargadas();
            lbSustitutos.Items.Clear();
        }

        private void cbProductos_Click(object sender, EventArgs e)
        {
            if(EstadoPublicacion == 0)
                MessageBox.Show("Publique los cambios antes de seleccionar otro producto, de lo contrario los cambios se perderán");            
        }
    }
}
