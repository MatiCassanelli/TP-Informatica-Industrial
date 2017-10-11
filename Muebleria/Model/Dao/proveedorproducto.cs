using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    public partial class proveedorproducto
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public int getCantProveedores(string codigoProducto)
        {
            var query = from pp in db.proveedorproducto
                        where pp.codigoProducto == codigoProducto
                        select pp;

            return query.Count();
        }

        public List<proveedorproducto> getProveedores(string codigoProducto)
        {
            var query = from pp in db.proveedorproducto
                        where pp.codigoProducto == codigoProducto
                        orderby pp.precio ascending
                        select pp;
            return query.ToList();
        }

    }
}
