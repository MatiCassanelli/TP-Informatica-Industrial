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
    public partial class Nuevo_Detalle_Remito : Form
    {
        //int cerrado = 0;
        public Nuevo_Detalle_Remito()
        {
            InitializeComponent();
            SetLabel2();
        }

        private void SetLabel2()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            var query = from r in db.remito
                        orderby r.idRemito descending
                        select r.idRemito;
            lblRemito.Text = query.ToList()[0].ToString();
        }

        //Cargar detalle en DataGrid
        private void btnCargarProducto_Click(object sender, EventArgs e)
        {
            string mascara = maskedTextBox1.Text;
            string recorte = "";
            if (mascara.Length == 14)    //14 para contar los ** y 12 digitos
                recorte = mascara.Substring(1, 12);  //TENGO Sacar del 1 al 13
            else
            {
                maskedTextBox1.Clear();
                return;
            }

            if (DataGridDetalles.RowCount > 0)
            {
                foreach (DataGridViewRow row in DataGridDetalles.Rows)
                {
                    String strFila = row.Cells[0].AccessibilityObject.Value.ToString();
                    if(recorte == strFila)
                    {
                        MessageBox.Show("El artículo ya ha sido agregado");
                        return;
                    }
                }
            }

            double nroserie = double.Parse(recorte);
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            var query = from a in db.articulo
                        from t in db.traduccion
                        from p in db.producto
                        where a.numero_serie == nroserie &&
                        a.estado == "Fabricado" &&
                        a.idProducto == p.idProducto &&
                        p.idDescriptionP == t.idDescriptionT &&
                        t.idLanguageT == LogIn.IdIdioma
                        select new { nro = a.numero_serie, prod = a.idProducto, desc = t.Traduccion_str };

            if (query.ToList().Count == 0)
                MessageBox.Show("El artículo no se encuentra en stock");

            foreach(var item in query)
            {
                DataGridDetalles.Rows.Add(item.nro, item.prod, item.desc);
            }
        }
        //private void btnCargarProducto_Click(object sender, EventArgs e)
        //{
        //    informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            //    //Obtener el id del producto Padre que coincide con el nombre seleccionado en el combo
            //    var queryP = from p in db.producto
            //                 from t in db.traduccion
            //                 where p.idDescriptionP == t.idDescriptionT &&
            //                 t.Traduccion_str == cbProductosFinales.SelectedItem.ToString() &&
            //                 t.idLanguageT == LogIn.IdIdioma
            //                 select p.idProducto;

            //    int id = queryP.ToList()[0];
            //    int cantidad = Convert.ToInt32(tbCantidad.Text.ToString());

            //    var query = from s in db.stock
            //                where s.idProducto == id
            //                select s.Cantidad;

            //    if (query.Count() > 0)
            //    {
            //        if (float.Parse(tbCantidad.Text) <= query.ToList()[0])
            //        {
            //            string nombre = cbProductosFinales.Text.ToString();
            //            DataGridDetalles.Rows.Add(id, nombre, cantidad);
            //        }
            //        else
            //            MessageBox.Show("Stock Insuficiente. Sólo se dispone de: " + query.ToList()[0].ToString());
            //    }
            //    else
            //        MessageBox.Show("No se dispone ese producto");

            //}

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            DataGridDetalles.Rows.Remove(DataGridDetalles.CurrentRow);
        }

        private void btnFinalizarDetalle_Click(object sender, EventArgs e)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            if(DataGridDetalles.RowCount > 0)
            {
                foreach(DataGridViewRow row in DataGridDetalles.Rows)
                {
                    remito_detalle NuevoRD = new remito_detalle()
                    {
                        idRemito = Convert.ToInt32(lblRemito.Text),
                        idArticulo = double.Parse(row.Cells[0].AccessibilityObject.Value),
                        idProducto = Convert.ToInt32(row.Cells[1].AccessibilityObject.Value),
                    };
                    try
                    {
                        db.remito_detalle.Add(NuevoRD);
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Error en la carga del detalle");
                    }
                }
            }
            else
            {
                MessageBox.Show("Cargue algún detalle antes de Finalizar");
                return;
            }

            ActualizarStock();
            ActualizarEstado();

            //cerrado = 1;
            this.Hide();
            this.Close();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void ActualizarEstado()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            if (DataGridDetalles.RowCount > 0)
            {
                foreach (DataGridViewRow row in DataGridDetalles.Rows)
                {
                    int nroserie = Convert.ToInt32(row.Cells[0].AccessibilityObject.Value);
                    var query = from a in db.articulo
                                where a.numero_serie == nroserie
                                select a;

                    foreach (var item in query)
                    {
                        item.estado = "Remito";
                    }
                    db.SaveChanges();
                }
            }
        }

        private void ActualizarStock()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            if (DataGridDetalles.RowCount > 0)
            {
                foreach (DataGridViewRow row in DataGridDetalles.Rows)
                {
                    int nroserie = Convert.ToInt32(row.Cells[1].AccessibilityObject.Value);

                    var subquery = from a in db.articulo
                                   where a.numero_serie == nroserie
                                   select a.idProducto;
                    int idprod = subquery.ToList()[0];

                    var query = from s in db.stock
                                where s.idProducto == idprod &&
                                s.idAlmacen == 1                    //TENGO q poner el almacen por defecto
                                select s;

                    //float cantIngresada = float.Parse(row.Cells[2].AccessibilityObject.Value);
                    foreach (var item in query)
                    {
                        item.Cantidad = item.Cantidad - 1;
                    }
                    db.SaveChanges();

                    //remito_detalle NuevoRD = new remito_detalle()
                    //{
                    //    idRemito = Convert.ToInt32(lblRemito.Text),
                    //    idProducto = Convert.ToInt32(row.Cells[0].AccessibilityObject.Value),
                    //    Cantidad = Convert.ToInt32(row.Cells[2].AccessibilityObject.Value)
                    //};
                    //try
                    //{
                    //    db.remito_detalle.Add(NuevoRD);
                    //    db.SaveChanges();
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("Error en la carga del detalle");
                    //}
                }
            }
        }
        private void Nuevo_Detalle_Remito_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.ShowDialog();
            //if (e.CloseReason == CloseReason.UserClosing && cerrado == 0)
            //{
            //    MessageBox.Show("Debe finalizar la operación");
            //    e.Cancel = true;
            //    //DialogResult result = MessageBox.Show("¿Quiere eliminar el remito generado?", "Alerta", MessageBoxButtons.YesNo);
            //    //if (result == DialogResult.Yes)
            //    //{
            //    //    Environment.Exit(0);
            //    //    informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

            //    //    int nroRemito = Convert.ToInt32(lblRemito.Text);
            //    //    var query = from r in db.remito
            //    //                where r.idRemito == nroRemito
            //    //                select r;

            //    //    if(query.Count() > 0)
            //    //    {
            //    //        foreach(var item in query)
            //    //        {
            //    //            db.remito.Remove(item);
            //    //            db.SaveChanges();
            //    //        }
            //    //    }
            //}
            //    else
            //    {
            //        e.Cancel = true;
            //    }
        }
        }
    }

