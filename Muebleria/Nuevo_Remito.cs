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
    public partial class Nuevo_Remito : Form
    {
        public Nuevo_Remito()
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

            int nroRemito = 1;
            if (query.Count() > 0)
                nroRemito = query.ToList()[0] + 1;
            lblIdRemito.Text = nroRemito.ToString();
        }

        private void btnGenerarRemito_Click(object sender, EventArgs e)
        {
            InsertarRemito();

            this.Close();
            this.Hide();
            Nuevo_Detalle_Remito nuevo_detalle_remito = new Nuevo_Detalle_Remito();
            nuevo_detalle_remito.ShowDialog();
        }

        private void InsertarRemito()
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            remito NuevoRemito = new remito()
            {
                Cliente = tbNombreCliente.Text,
                Destino = tbDireccion.Text
            };
            try
            {
                db.remito.Add(NuevoRemito);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("No se pudo generar el remito");
            }
        }
    }
}
