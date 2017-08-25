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

namespace Muebleria
{
    public partial class Composicion : Form
    {
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

        private void Actualizar_ListBox()
        {
            lbCargadas.Items.Clear();

            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            //Obtener los id de los productos hijos del padre seleccionado en el cbProducto
            var query = from ph in db.padre_componente
                        from t in db.traduccion
                        from p in db.producto
                        where p.idProducto == ph.idPadre &&
                        p.idDescriptionP == t.idDescriptionT &&
                        t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                        t.idLanguageT == LogIn.IdIdioma
                        select new { id_Hijo = ph.idHijo, cant = ph.Cantidad };

            //Obtener las descripciones de las unidades de medida de la cantidad de aplicacion
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
                         sq.id == p.Unidad_id_Aplication &&
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

            subquery = from p in db.producto
                       where p.idTipo == 2 || p.idTipo == 3 || p.idTipo == 4
                       select p.idDescriptionP;

            query = from t in db.traduccion
                    from p in subquery
                    where t.idDescriptionT == p &&
                    t.idLanguageT == LogIn.IdIdioma
                    select t.Traduccion_str;

            cbComponentes.DataSource = query.ToList();

            //Consulta para traer la lista de los nombres de las unidades de medida
            query = from um in db.unidad_medida from t in db.traduccion
                    where t.idDescriptionT == um.idDescriptionUM &&
                    t.idLanguageT == LogIn.IdIdioma
                    select t.Traduccion_str;

            cbUM.DataSource = query.ToList();
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelComponentes.Enabled = true;
            Actualizar_ListBox();
        }
        private void cbComponentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCantidades.Enabled = true;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbCantidad.Text) || String.IsNullOrEmpty(cbUM.Text))
                MessageBox.Show("Complete los datos para continuar");
            else
            {
                float cant = int.Parse(tbCantidad.Text);
                tbCantidad.Clear();
                informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

                //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
                var queryP = from p in db.producto from t in db.traduccion  
                             where p.idDescriptionP == t.idDescriptionT && 
                             t.Traduccion_str == cbProductos.SelectedItem.ToString() &&
                             t.idLanguageT == LogIn.IdIdioma
                             select p.idProducto;
                List<int> P = queryP.ToList();


                //Obtener el id del producto Componente que coincide con el nombre seleccionado en el combo
                var queryC = from p in db.producto from t in db.traduccion
                             where p.idDescriptionP == t.idDescriptionT &&
                             t.Traduccion_str == cbComponentes.SelectedItem.ToString() &&
                             t.idLanguageT == LogIn.IdIdioma
                             select p.idProducto;
                List<int> C = queryC.ToList();
                

                //Obtener el id de la unidad de medida de aplicacion del producto
                var pppp = C[0];        //Los casteos tienen que estar fuera de la consulta LINQ
                var queryUMD = from pUMD in db.producto   
                               where pUMD.idProducto == pppp
                               select pUMD.Unidad_id_Aplication;
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
                float coeficiente = 1;
                int auxD = UMD[0];
                int auxU = UMU[0];
                if (UMD[0] != UMU[0])
                {
                    try
                    {
                        var query = from conv in db.conversion
                                    where conv.U_medida_default == auxD &&
                                    conv.U_medida == auxU
                                    select conv.Coeficiente;
                        coeficiente = query.ToList()[0];
                    }
                    catch
                    {
                        int aux = UMD[0];
                        var query = from um in db.unidad_medida
                                    from t in db.traduccion
                                    where um.idDescriptionUM == t.idDescriptionT &&
                                    um.idUnidad_Medida == aux &&
                                    t.idLanguageT == LogIn.IdIdioma
                                    select t.Traduccion_str;

                        MessageBox.Show("Unidad de medida inválida para este producto. Intente con: " + query.ToList()[0].ToString());
                        return;
                    }

                }


                //Agregar nueva fila a la tabla "Padre-Componente"
                cant = cant / coeficiente;
                padre_componente nuevoPC = new padre_componente()
                {
                    idPadre = P[0],
                    idHijo = C[0],
                    Cantidad = cant,                     //cant incluye la cantidad modificada por el coeficiente de la tabla conversion
                    U_medida_default = UMD[0],
                    U_medida_used = UMU[0],
                    Last_Upd = DateTime.Now,
                    User_Upd = LogIn.IdUsuario                        //FALTA PONER EL ID DE USUARIO QUE SE TOMA CUANDO INICIA SESIÓN
                };

                //Intenta realizar un UPDATE en la tabla padre-componente
                try
                {
                    db.padre_componente.Add(nuevoPC);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("El componente ya ha sido agregado");
                    return;
                }

                Actualizar_ListBox();

            }
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

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lbCargadas.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un elemento para borrar");
                return;
            }
            else
            {
                informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

                //producto seleccionado en el lbcargadas
                var aux = CortarCadena(lbCargadas.SelectedItem.ToString());
                var query = from pc in db.padre_componente
                            from t in db.traduccion
                            from p in db.producto
                            where pc.idHijo == p.idProducto &&
                            p.idDescriptionP == t.idDescriptionT &&
                            t.Traduccion_str == aux &&
                            t.idLanguageT == LogIn.IdIdioma
                            select pc;
                List<padre_componente> lPC = query.ToList();

                //Intenta hacer un delete en la tabla padre-componente
                try
                {
                    db.padre_componente.Remove(lPC[0]);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("El componente ya ha sido eliminado");
                }
                Actualizar_ListBox();

            }
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

    }
}
