﻿using System;
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
            int CantRequerida = Convert.ToInt32(tbCantidad.Text);
            //Obtener los id de los productos hijos del padre seleccionado en el cbProducto
            var query = from ph in db.padre_componente_publicado
                        from t in db.traduccion
                        from p in db.producto
                        where p.idProducto == ph.idPadreP &&
                        p.idDescriptionP == t.idDescriptionT &&
                        t.Traduccion_str == padre &&
                        t.idLanguageT == LogIn.IdIdioma
                        select new { id_Hijo = ph.idHijoP, cant = ph.Cantidad, UMU = ph.U_medida_usada };

            //Obtener las descripciones de las unidades de medidas
            var subquery = from um in db.unidad_medida
                           from t in db.traduccion
                           where um.idDescriptionUM == t.idDescriptionT &&
                           t.idLanguageT == LogIn.IdIdioma
                           select new { id = um.idUnidad_Medida, t = t.Traduccion_str };

            //Obtener las descripciones de los productos seleccionados en la consulta anterior
            var query2 = from n in query
                         from sq in subquery
                         from t in db.traduccion
                         from p in db.producto
                         where p.idProducto == n.id_Hijo &&
                         p.idDescriptionP == t.idDescriptionT &&
                         sq.id == n.UMU &&
                         t.idLanguageT == LogIn.IdIdioma
                         //select t.Traduccion_str + "  x" + n.cant.ToString() + " " + sq.t;
                         select new { nombre = t.Traduccion_str, cant = n.cant.ToString(), um = sq.t };

            List<PadreHijo> lista = new List<PadreHijo>();

            foreach (var item in query2)
            {
                lista.Add(new PadreHijo(padre, item.nombre, Convert.ToInt32(item.cant), item.um));
            }
            return lista;
        }

        List<PadreHijo> hijos = new List<PadreHijo>();

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
                    UM_valor umv = consultarUM(item.Padre);
                    List<string> SustitutosList = buscarSustitutos(item.Padre, item.Hijo);
                    if(SustitutosList.Count>0)
                    {
                        foreach (string sust in SustitutosList)
                        {
                            if (SustitutosList.Count > 1)
                                sustitutos += sust + ", ";
                            else
                                sustitutos = sust;
                        }
                        lbComponentes.Items.Add(tabs + item.Hijo + " x " + /*umv.Conversion + ' ' + umv.Um +*/ '('+sustitutos+')');
                    }
                    else
                        lbComponentes.Items.Add(tabs + item.Hijo + " x " /*+ umv.Conversion + ' ' + umv.Um */);

                    ConsultarRecursivo(item.Hijo, prodfinal);
                }
            }

        }

        private List<string> buscarSustitutos(string padre, string hijo)
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

            //Obtener id de los productos sustitutos
            var plista = P[0];
            var hlista = C[0];
            var queryS = from ps in db.producto_sustituto
                         where ps.idPadre == plista &&
                         ps.idHijo == hlista &&
                         ps.activado == 1
                         select ps.sustituto;

            var queryFinal = from s in queryS
                             from t in db.traduccion
                             from p in db.producto
                             where s == p.idProducto &&
                             p.idDescriptionP == t.idDescriptionT &&
                             t.idLanguageT == LogIn.IdIdioma
                             select t.Traduccion_str;

            return queryFinal.ToList();
        }
        private UM_valor consultarUM(string prod)
        {
            if (!String.IsNullOrEmpty(tbCantidad.Text))
            {
                float cant = int.Parse(tbCantidad.Text);
                tbCantidad.Clear();

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
                               where c == p.idPadreP
                               select p.U_medida_usada;
                               //from pc in db.padre_componente_publicado
                               //from p in db.producto
                               //from t in db.traduccion
                               //where p.idProducto==pc.idPadreP && uMU.idUnidad_Medida == pc.U_medida_usada && 
                               // p.idDescriptionP==t.idDescriptionT && t.Traduccion_str==prod
                               //select pc.U_medida_usada;
                List < int > UMU = queryUMU.ToList();


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
                        cant /= coeficiente;

                        var desc = from t in db.traduccion
                                   from um in db.unidad_medida
                                   where t.idDescriptionT == um.idDescriptionUM && um.idUnidad_Medida==auxD
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
                        //int aux = UMD[0];
                        //var query = from um in db.unidad_medida
                        //            from t in db.traduccion
                        //            where um.idDescriptionUM == t.idDescriptionT &&
                        //            um.idUnidad_Medida == aux &&
                        //            t.idLanguageT == LogIn.IdIdioma
                        //            select t.Traduccion_str;

                        //MessageBox.Show("Unidad de medida inválida para este producto. Intente con: " + query.ToList()[0].ToString());
                        //return;
                    }
                }                
            }
            return new UM_valor();
        }

        private void Explosion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            //this.Close();
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
    }
}
