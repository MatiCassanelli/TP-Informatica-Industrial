using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class GeneradorSN
    {

        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public GeneradorSN()
        {

        }

        public int generarSN()
        {
            int ultimoSN = 1000000;
            var query = from a in db.articulo
                        orderby a.numero_serie descending
                        select a.numero_serie;
            if (query.Count() > 0)
            {
                ultimoSN = query.ToList()[0];
                ultimoSN++;
            }
            return ultimoSN;


        }

    }
}
