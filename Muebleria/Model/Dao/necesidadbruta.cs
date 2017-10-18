using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    public partial class necesidadbruta
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public necesidadbruta(int idProd, int semana, int cant)
        {
            idProductoHijo = idProd;
            Semana = semana;
            Cant = cant;
        }
        public necesidadbruta()
        {

        }

        public void cargarNecesidadBruta()
        {
            var query = from nb in db.necesidadbruta
                        where this.idProductoHijo == nb.idProductoHijo && this.Semana == nb.Semana
                        select nb;

            if (query.Count() > 0)
                query.ToList()[0].Cant += this.Cant;
            else
                db.necesidadbruta.Add(this);

            db.SaveChanges();
        }

        public int getCantidad(int prod, int semana)
        {
            var query = from nb in db.necesidadbruta
                        where nb.idProductoHijo == prod && nb.Semana == semana
                        select nb.Cant;
            if (query.Count() > 0)
                return query.ToList()[0];
            else
                return 0;
            
        }

        public List<necesidadbruta> getAll()
        {
            var query = from nb in db.necesidadbruta
                        select nb;

            if (query.Count() > 0)
                return query.ToList();
            else
                return new List<necesidadbruta>();
        }
    }
}
