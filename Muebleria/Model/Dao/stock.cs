using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    public partial class stock
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

        public stock()
        {

        }

        public float getStockProducto (int idProducto)
        {
            var query = from s in db.stock
                        where s.idProducto == idProducto &&
                        s.idAlmacen == 1
                        select s.Cantidad;

            List<float> lista = new List<float>();
            if (query.Count() > 0)
            {
                foreach (float item in query)
                {
                    lista.Add(item);
                }
            }
            return lista[0];
        }

        public void actualizarStock (int idProducto, float cant)
        {
            var query = from s in db.stock
                        where s.idProducto == idProducto &&
                        s.idAlmacen == 1
                        select s;

            foreach (stock item in query)
                item.Cantidad = cant;

            db.SaveChanges();
        }
    }
}
