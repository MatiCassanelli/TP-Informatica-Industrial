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
        public void InsertOrUpdateNecesidadNeta()
        {
            var query = from nn in db.necesidadneta
                        where this.idProductoHijo == nn.idProductoHijo && this.Semana == nn.Semana
                        select nn;

            if (query.Count() > 0)
                query.ToList()[0].Cant += this.Cant;
            else
                db.necesidadneta.Add(this);

            db.SaveChanges();
        }

    }
}
