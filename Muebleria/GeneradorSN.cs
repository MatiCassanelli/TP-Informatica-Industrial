using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class GeneradorSN
    {
        private int serialNumber;

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
        
        public void digitoValidador(int sn)
        {
            string par = sn.ToString();
            string aux= "";
            for (int i = 1; i < par.Count(); i+=2)
            {
                aux+= par[i];
            }
        }

    }
}
