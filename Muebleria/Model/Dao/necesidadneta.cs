using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    public partial class necesidadneta
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public necesidadneta(int idProd, int semana, int cant)
        {
            idProductoHijo = idProd;
            Semana = semana;
            Cant = cant;
        }

        public necesidadneta()
        {

        }
        public void InsertOrUpdateNecesidadNeta()
        {
            var query = from nn in db.necesidadneta
                        where this.idProductoHijo == nn.idProductoHijo && this.Semana == nn.Semana
                        select nn;

            if (query.Count() > 0)
                query.ToList()[0].Cant = this.Cant;
            else
                db.necesidadneta.Add(this);

            try
            {
                db.SaveChanges();
            }
            catch (Exception E)
            {

            }
        }

        public List<necesidadneta> getAll()
        {
            var query = from nn in db.necesidadneta
                        select nn;
            if (query.Count() > 0)
                return query.ToList();
            else
                return new List<necesidadneta>();
        }

        public int getDiferenciaCantidad(int prod, int semana)
        {
            var query = from nb in db.necesidadneta
                        where nb.idProductoHijo == prod && nb.Semana == semana
                        select nb.Cant;
            if (query.Count() > 0)
                return query.ToList()[0];
            else
                return 0;

        }
    }
}
