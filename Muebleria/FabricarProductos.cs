using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muebleria
{
    public partial class FabricarProductos : Form
    {
    //    informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public FabricarProductos()
        {
            InitializeComponent();

            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            var subquery = from p in db.producto
                           where p.idTipo == 1 || p.idTipo == 3
                           select p.idDescriptionP;

            var query = from t in db.traduccion
                        from p in subquery
                        where t.idDescriptionT == p &&
                        t.idLanguageT == LogIn.IdIdioma
                        select t.Traduccion_str;
            cbProductos.DataSource = query.ToList();

            query = from um in db.unidad_medida
                    from t in db.traduccion
                    where t.idDescriptionT == um.idDescriptionUM &&
                    t.idLanguageT == LogIn.IdIdioma
                    select t.Traduccion_str;
            cbUM.DataSource = query.ToList();

            query = from s in db.sucursal
                    where s.Real==1
                    select s.Nombre;
            cbSucursalOrigen.DataSource = query.ToList();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            var queryUMU = from uMU in db.unidad_medida
                           from t in db.traduccion
                           where uMU.idDescriptionUM == t.idDescriptionT &&
                           t.Traduccion_str == cbUM.SelectedItem.ToString() &&
                           t.idLanguageT == LogIn.IdIdioma
                           select uMU.idUnidad_Medida;
            List<int> UMU = queryUMU.ToList();

            int idProd = convertirEnID(cbProductos.SelectedItem.ToString());

            var query = from s in db.stock
                        from a in db.almacen
                        where s.idProducto == idProd && a.idAlmacen==s.idAlmacen && a.Real==1
                        select s;
            if (query.Count() > 0)
            {
                float stock = obtenerStock(idProd);
                foreach (var item in query)
                {
                    item.Cantidad = stock + float.Parse(tbCantidad.Text);
                }
            }
            else
            {
                ConsultasVarias cc = new ConsultasVarias();                
                int almacen = cc.getIDAlmacen(cbAlmacenOrigen.SelectedItem.ToString());
                stock s = new stock()
                {
                    idProducto = idProd,
                    Cantidad = float.Parse(tbCantidad.Text),
                    unidad_medida = UMU[0],
                    last_upd = DateTime.Now,
                    idAlmacen=almacen,    //almacen 2 es el deposito
                    user_upd = LogIn.IdUsuario
                    
                };
                db.stock.Add(s);
            }
            db.SaveChanges();
            generarMovimiento(idProd, UMU[0], Convert.ToInt32(tbCantidad.Text));

            for (int i = 0; i < Convert.ToInt32(tbCantidad.Text); i++)
            {
                crearArticulo(idProd);
                Thread.Sleep(10);
            }
            MessageBox.Show("Articulos creados con exito");
            //try
            //{
            //    crearArticulo(idProd);
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show("No anduvo: " + exp.Message);
            //}

        }

        private void crearArticulo(int idProd)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            GeneradorSN gsn = new GeneradorSN();
            double sn = gsn.generarSNcompleto(idProd);

            ConsultasVarias cc = new ConsultasVarias();
            int almacen = cc.getIDAlmacen(cbAlmacenOrigen.SelectedItem.ToString());
            articulo a = new articulo()
            {
                numero_serie = sn,
                idProducto = idProd,
                fecha_fabricacion = DateTime.Now,
                fecha_caducidad = DateTime.Now,
                estado = "Fabricado",
                ubicacion = almacen,
                last_upd = DateTime.Now,
                user_upd = LogIn.IdUsuario
            };
            db.articulo.Add(a);
            try
            {
                db.SaveChanges();
            }
            catch (Exception exp)
            {
                MessageBox.Show("No anduvo: " + exp.Message);
            }
            //db.SaveChanges();
            //mostrarCodigoDeBarra(a);
        }

        private void mostrarCodigoDeBarra(articulo a)
        {
            CodigoDeBarras cdb = new CodigoDeBarras();
            String codigo = cdb.generarCodigoDeBarras(a.numero_serie);
            MostrarCodigoBarras mcb = new MostrarCodigoBarras();
            mcb.imprimir(codigo);
            mcb.ShowDialog();
            //MessageBox.Show(codigo);
        }

        private void generarMovimiento(int idProd, int um, int cant)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            ConsultasVarias cc = new ConsultasVarias();
            int sucursal = cc.getIDSucursal(cbSucursalOrigen.SelectedItem.ToString());
            movimiento mov = new movimiento()
            {
                S_origen = sucursal,
                S_destino = sucursal,
                idProducto = idProd,
                fechaMovimiento = DateTime.Now,
                cantidad = cant,
                u_medida = um,
                idRazon=4   //4 es el fabricar!!               
            };
            db.movimiento.Add(mov);
            db.SaveChanges();
        }


        private float obtenerStock(int prod)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            var stock = from s in db.stock
                        where s.idProducto == prod
                        select s.Cantidad;

            return stock.ToList()[0];
        }

        private int convertirEnID(string prod)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == prod &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;

            return queryP.ToList()[0];
        }

        private void FabricarProductos_Load(object sender, EventArgs e)
        {

        }

        private void FabricarProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        
        private void cbSucursalOrigen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ControllerDetalleMovimiento controller = new ControllerDetalleMovimiento();
            cbAlmacenOrigen.DataSource = controller.CargarAlmacen(cbSucursalOrigen.SelectedItem.ToString());
        }

        private void cbAlmacenOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControllerDetalleMovimiento controller = new ControllerDetalleMovimiento();
            cbUbicacionOrigen.DataSource = controller.CargarUbicacion(cbAlmacenOrigen.SelectedItem.ToString());
        }
    }
}
