using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class CodigoDeBarras
    {
        private int serialNumber;
        private int codigoVerificador;

        public CodigoDeBarras()
        {

        }

        public string generarCodigoDeBarras(int sn)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            var subquery = from a in db.articulo
                           where a.numero_serie == sn
                           select a.producto;

            var query = from p in db.producto
                        from s in subquery
                        where s.idProducto == p.idProducto
                        select p.Codigo_abreviado;

            int cr = Convert.ToInt32(query.ToList()[0]);
            if (cr < 10)
                cr *= 1000;
            else if (cr < 100)
                cr *= 100;
            else if (cr<1000)
                cr *= 10;

            GeneradorSN gsn = new GeneradorSN();
            int cv=gsn.digitoValidador(sn);

            string cdb = "*" + cr + sn + cv + "*";
            return cdb;
        }

    }
}
