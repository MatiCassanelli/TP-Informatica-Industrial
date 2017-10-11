using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    public partial class ordencompra
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public ordencompra()
        {

        }
        public ordencompra(string nroOrdenCompra, int idProducto, int semana, int cant, string proveedor)
        {
            this.NroOrdenCompra = nroOrdenCompra;
            this.idProductoHijo = idProducto;
            this.Semana = semana;
            this.Cant = cant;
            this.Proveedor = proveedor;
            this.user_upd = LogIn.IdUsuario;
            this.last_upd = DateTime.Now;
        }

        public int getNextId()
        {
            var query = from oc in db.ordencompra
                        orderby oc.idOrdenCompra descending
                        select oc.NroOrdenCompra;

            if (query.Count() > 0)
            {
                string oc = query.ToList()[0];
                oc = oc.Substring(2);                                    //PROBAR SI ESTO SACA "OC"
                int nro = Convert.ToInt32(oc);
                nro++;
                return nro;
            }
            else
                return 0;
        }

        public void insertarOC (List<ordencompra> listaOC)
        {
            foreach(ordencompra oc in listaOC)
            {
                db.ordencompra.Add(oc);
            }
            db.SaveChanges();
        }
    }
}
