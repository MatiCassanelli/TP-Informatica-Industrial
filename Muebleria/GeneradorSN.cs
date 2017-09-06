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
            List<int> aux = new List<int>();
            for (int i = 0; i < par.Count(); i++)
            {
                aux.Add(int.Parse(par[i].ToString()));
            }

            int x = 0, y = 0;
            for (int i = 1; i < aux.Count; i+=2)
            {
                x += aux[i];
            }
            for (int i = 0; i < aux.Count; i+=2)
            {
                if (y > 9)
                    y += (2 * aux[i] - 9);
                else
                    y += (2 * aux[i]);
            }
            int z = x + y;

            int t = z % 10;

            int d = 10 - t;
            

        }

    }
}
