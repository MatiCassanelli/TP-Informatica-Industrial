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
        public Explosion()
        {
            InitializeComponent();
            LlenarCombos();
        }

        private void LlenarCombos()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            
            //Consulta para traer la lista de los nombres de los productos de "intermedio by", "intermedio make" y "bruto"
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

        private void cbComponentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarListBox();
        }

        private void ActualizarListBox()
        {
            lbComponentes.Items.Clear();

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
            List<string> q2 = query2.ToList();

            foreach (string item in q2)
            {
                lbComponentes.Items.Add(item);
            }
        }
    }
}
