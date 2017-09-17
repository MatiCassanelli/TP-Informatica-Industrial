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

        private double generarProximoSN()
        {
            List<Double> sn7digitos = new List<Double>();
            double ultimoSN = 1000000;
            var query = from a in db.articulo
                        orderby a.numero_serie descending
                        select a.numero_serie;
            if (query.Count() > 0)
            {
                for (int i = 0; i < query.Count(); i++)
                {
                    string aux = query.ToList()[i].ToString().Substring(4, 7);
                    sn7digitos.Add(double.Parse(aux));
                }
                ultimoSN = sn7digitos.Max();
                ultimoSN++;
            }
            return ultimoSN;
        }

        public double generarSNcompleto(int prod)
        {
            double sn = generarProximoSN();
            var query = from p in db.producto
                        where prod == p.idProducto
                        select p.Codigo_abreviado;

            int codAbreviado = Convert.ToInt32(query.ToList()[0]);
            if (codAbreviado < 10)
                codAbreviado *= 1000;
            else if (codAbreviado < 100)
                codAbreviado *= 100;
            else if (codAbreviado < 1000)
                codAbreviado *= 10;

            string rejunte = codAbreviado.ToString()+sn.ToString()+ digitoValidador(sn);
            double a = double.Parse(rejunte);
            return a;

        }
        
        private int digitoValidador(double sn)
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
            if (d == 10)
                d = 0;
            return d;        
        }

    }
}
