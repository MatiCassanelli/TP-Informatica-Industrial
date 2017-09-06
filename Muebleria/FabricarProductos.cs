﻿using System;
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

            var query = db.stock.SqlQuery("select * from stock where idProducto = " + idProd + ";");
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
                stock s = new stock()
                {
                    idProducto = idProd,
                    Cantidad = float.Parse(tbCantidad.Text),
                    unidad_medida = UMU[0],
                    last_upd = DateTime.Now,
                    user_upd = LogIn.IdUsuario
                };
                db.stock.Add(s);
            }
            db.SaveChanges();
            generarMovimiento(idProd, UMU[0], Convert.ToInt32(tbCantidad.Text));

            for (int i = 0; i < Convert.ToInt32(tbCantidad.Text); i++)
            {
                crearArticulo(idProd);
                Thread.Sleep(2);
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
            int sn = gsn.generarSN();

            articulo a = new articulo()
            {
                numero_serie = sn,
                idProducto = idProd,
                fecha_fabricacion = DateTime.Now,
                fecha_caducidad = DateTime.Now,
                estado = "Fabricado",
                ubicacion = "En deposito",
                last_upd = DateTime.Now,
                user_upd = LogIn.IdUsuario
            };
            db.articulo.Add(a);
            db.SaveChanges();
            mostrarCodigoDeBarra(a);
        }

        private void mostrarCodigoDeBarra(articulo a)
        {
            CodigoDeBarras cdb = new CodigoDeBarras();
            MessageBox.Show(cdb.generarCodigoDeBarras(a.numero_serie));
        }

        private void generarMovimiento(int idProd, int um, int cant)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            movimiento mov = new movimiento()
            {
                ubicacion_origen = "Fabrica",
                ubicacion_destino = "Deposito",
                idProducto = idProd,
                fecha_movimiento = DateTime.Now,
                cantidad = cant,
                unidad_medida = um,
                idRazon=1                
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
    }
}
