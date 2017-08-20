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
        informatica_industrial_dbEntities testcontext = new informatica_industrial_dbEntities();
        public Implosion()
        {
            InitializeComponent();
            completarProductos();
            completarUM();
        }

        private void btnImplosionar_Click(object sender, EventArgs e)
        {
            lbprodfinales.Items.Clear();
            if (!String.IsNullOrEmpty(tbCantidad.Text))
            {
                implosionar();
            }
            else
                MessageBox.Show("Complete los datos para continuar");
                      
        }

        private void cbProductosBuscados_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCantidades.Enabled = true;
            tbCantidad.Clear();
            lbprodfinales.Items.Clear();
        }

        public void completarProductos()
        {
            var query = from tradu in testcontext.traduccion
                        from prod in testcontext.producto
                        where tradu.idDescriptionT.Equals(prod.idDescriptionP)
                        && tradu.idLanguageT == LogIn.IdIdioma 
                        //&& (prod.idTipo==2 || prod.idTipo == 3 || prod.idTipo == 4) //2 es buy y 4 es bruto
                        select tradu.Traduccion_str;

            cbProductosBuscados.DataSource = query.ToList();
        }

        public void completarUM()
        {
            var query = from trad in testcontext.traduccion
                        from um in testcontext.unidad_medida
                        where trad.idDescriptionT.Equals(um.idDescriptionUM)
                        && trad.idLanguageT == LogIn.IdIdioma
                        select trad.Traduccion_str;
            cbUM.DataSource = query.ToList();
        }
        private void implosionar()  
        {
            float cant = float.Parse(tbCantidad.Text);
            //Obtener el id del producto Componente que coincide con el nombre seleccionado en el combo
            var queryC = from p in testcontext.producto
                         from t in testcontext.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == cbProductosBuscados.SelectedItem.ToString() &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> C = queryC.ToList();

            //Obtener el id de la unidad de medida de aplicacion del producto
            var pppp = C[0];        //Los casteos tienen que estar fuera de la consulta LINQ
            var queryUMD = from pUMD in testcontext.producto
                           where pUMD.idProducto == pppp
                           select pUMD.Unidad_id_Aplication;
            List<int> UMD = queryUMD.ToList();


            //Obtener el id de la unidad de medida usada por el usuario
            var queryUMU = from uMU in testcontext.unidad_medida
                           from t in testcontext.traduccion
                           where uMU.idDescriptionUM == t.idDescriptionT &&
                           t.Traduccion_str == cbUM.SelectedItem.ToString() &&
                           t.idLanguageT == LogIn.IdIdioma
                           select uMU.idUnidad_Medida;
            List<int> UMU = queryUMU.ToList();

            //Conversión de unidad
            float coeficiente = 1;
            int auxD = UMD[0];
            int auxU = UMU[0];
            if (UMD[0] != UMU[0])
            {
                try
                {
                    var query = from conv in testcontext.conversion
                                where conv.U_medida_default == auxD &&
                                conv.U_medida == auxU
                                select conv.Coeficiente;
                    coeficiente = query.ToList()[0];
                }
                catch
                {
                    int aux = UMD[0];
                    var query = from um in testcontext.unidad_medida
                                from t in testcontext.traduccion
                                where um.idDescriptionUM == t.idDescriptionT &&
                                um.idUnidad_Medida == aux &&
                                t.idLanguageT == LogIn.IdIdioma
                                select t.Traduccion_str;

                    MessageBox.Show("Unidad de medida inválida para este producto. Intente con: " + query.ToList()[0].ToString());
                    return;
                }
            }
            cant/=coeficiente;

            string prodBuscado = cbProductosBuscados.SelectedItem.ToString();
            var queryhijo = from pc in testcontext.padre_componente
                            from prod in testcontext.producto
                            from trad in testcontext.traduccion
                            where pc.idHijo == prod.idProducto &&
                                prod.idDescriptionP == trad.idDescriptionT &&
                                 trad.idLanguageT == LogIn.IdIdioma &&
                            trad.Traduccion_str == prodBuscado &&
                            pc.Cantidad <= cant
                            select pc.idPadre;

            var final = from t in testcontext.traduccion
                        from p in testcontext.producto
                        from n in queryhijo
                        where t.idDescriptionT == p.idDescriptionP &&
                        t.idLanguageT == LogIn.IdIdioma &&
                            n == p.idProducto
                        select t.Traduccion_str;

            if (final.ToList().Count > 0)
            {
                foreach (string item in final)
                    lbprodfinales.Items.Add(item);
            }

            else
                MessageBox.Show("No existe ningun producto que se pueda fabricar con los productos seleccionados");
        }

        private void Implosion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            //this.Close();
            menu.ShowDialog();
        }
       
    }
    
}
