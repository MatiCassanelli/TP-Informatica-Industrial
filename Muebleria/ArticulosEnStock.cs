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
    public partial class ArticulosEnStock : Form
    {
        public ArticulosEnStock()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string mascara = maskedTextBox1.Text;
            string recorte = "";
            if (mascara.Length == 14)    //14 para contar los ** y 12 digitos
                recorte = mascara.Substring(5, 7);
            else
            {
                maskedTextBox1.Clear();
                return;
            }
            buscarProd(Convert.ToInt32(recorte));
        }

        private void buscarProd(int sn)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            var subquery = from a in db.articulo
                           where a.numero_serie == sn
                           select new { prod = a.idProducto, ubicacion = a.ubicacion };

            var query = from aux in subquery
                        from s in db.stock
                        where s.idProducto == aux.prod
                        select new { idProd = aux.prod, cant = s.Cantidad, ubicacion = aux.ubicacion };

            var final = from aux in query
                        from p in db.producto
                        from t in db.traduccion
                        where p.idProducto == aux.idProd && p.idDescriptionP == t.idDescriptionT && t.idLanguageT == LogIn.IdIdioma
                        select new { prod = t.Traduccion_str, cant = aux.cant, ubicacion = aux.ubicacion };

            dataGridView1.DataSource = final.ToList();
        }

        private void ArticulosEnStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }
    }
}
