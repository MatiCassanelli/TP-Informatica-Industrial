using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    public partial class requerimientos
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public requerimientos(int idProd, int csemana, string cliente,  int cdelta)
        {
            idProducto = idProd;
            Semana = csemana;
            Cant = 0;
            Cliente = cliente;
            Delta = cdelta;
        }
        public requerimientos()
        {

        }

        public void cargarRequerimiento()
        {
            Fecha f = new Fecha();
            var query = from req in db.requerimientos
                        where this.idProducto == req.idProducto && this.Semana == req.Semana && this.Cliente == req.Cliente
                        select req;

            if (query.Count() > 0)
                query.ToList()[0].Delta += this.Delta;
            else
                db.requerimientos.Add(this);

            db.SaveChanges();
        }

        public List<requerimientos> getRequerimientosCargados()
        {
            List<requerimientos> lista = new List<requerimientos>();
            var query = from req in db.requerimientos
                        where req.Delta>0
                        select req;
            if(query.Count()>0)
            {
                lista = query.ToList();
            }
            return lista;          
        }

        public List<requerimientos> getRequerimientosSumados()
        {
            List<requerimientos> lista = new List<requerimientos>();
            var query = db.requerimientos.SqlQuery("SELECT idProducto, Semana, Cant, Cliente, SUM(Delta) as Delta FROM requerimientos WHERE Delta>0 GROUP BY idProducto, Semana;");
            if(query.Count()>0)
            {
                lista = query.ToList();
            }
            return lista;
        }

        public void actualizarDelta_Cant()
        {
            var query = from Req in db.requerimientos
                        where Req.Delta > 0
                        select Req;

            foreach(requerimientos r in query)
            {
                r.Cant += r.Delta;
                r.Delta = 0;
            }
            db.SaveChanges();
        }

    }
}
