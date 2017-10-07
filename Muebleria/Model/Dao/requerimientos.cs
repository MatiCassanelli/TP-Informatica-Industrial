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

        public void cargarRequerimiento()
        {
            db.requerimientos.Add(this);
            try
            {
                db.SaveChanges();
            }
            catch(Exception e)
            {

            }
            
        }

        public List<requerimientos> getRequerimientosCargados(int semana)
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
        }
        
    }
}
