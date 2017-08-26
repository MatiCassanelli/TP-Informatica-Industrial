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

            lbComponentes.DataSource = ConsultarRecursivo(cbProductos.SelectedItem.ToString());
        }

        List<string> hijos = new List<string>();

        int cantRequerida;
        public int CantRequerida
        {
            get
            {
                return cantRequerida;
            }

            set
            {
                cantRequerida = Convert.ToInt32(tbCantidad.Text);
            }
        }

        private List<string> ConsultarRecursivo(string padre)
        {            
            //Obtener los id de los productos hijos del padre seleccionado en el cbProducto
            var query = from ph in db.padre_componente
                        from t in db.traduccion
                        from p in db.producto
                        where p.idProducto == ph.idPadre &&
                        p.idDescriptionP == t.idDescriptionT &&
                        t.Traduccion_str == padre &&
                        t.idLanguageT == LogIn.IdIdioma
                        select new { id_Hijo = ph.idHijo, cant = ph.Cantidad * CantRequerida };

            //Obtener las descripciones de las unidades de medida de la cantidad de aplicacion
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
                         sq.id == p.Unidad_id_Aplication &&
                         t.idLanguageT == LogIn.IdIdioma
                         select t.Traduccion_str + "  x" + n.cant.ToString() + " " + sq.t;
            //select new { Componente = t.Traduccion_str, Cantidad = n.cant };
            List<string> resultadoquery = new List<string>();
            if(query2 != null)
            {
                resultadoquery = query2.ToList();
                foreach (string item in resultadoquery)
                {
                    hijos.AddRange(ConsultarRecursivo(item));
                    hijos.Add(item);
                }
            }              
            
            return hijos;
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
