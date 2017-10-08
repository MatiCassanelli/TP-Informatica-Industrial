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
        public requerimientos(string cliente, int idProd, int cdelta, int csemana)
        {
            idProducto = idProd;
            Semana = csemana;
            Cliente = cliente;
            Delta = cdelta;
            Cant = 0;
        }
        public requerimientos()
        {

        }

        public void cargarRequerimiento()
        {
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
                foreach (requerimientos item in query)
                {
                    lista.Add(item);
                }
            }
            return lista;

            //List<requerimientos> lista = new List<requerimientos>();
            //var query = from req in db.requerimientos
            //            where req.Delta > 0
            //            group req by req.idProducto & req.Semana into g
            //            select new { idProducto = idProducto, semana = Semana, cant = g.Sum(req => req.Cant) };
            //if (query.Count() > 0)
            //{
            //    foreach (var item in query)
            //    {
            //        lista.Add(item);
            //    }
            //}
            //return lista;
        }
        
    }
}
