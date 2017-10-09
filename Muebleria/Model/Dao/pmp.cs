using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    public partial class pmp
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public pmp()
        {

        }
        public pmp(int idProducto, int Semana, int cantidad)
        {
            this.idProductoPadre = idProducto;
            this.Semana = Semana;
            this.Cant = cantidad;
        }

        public int getCantidad(int idProducto, int Semana)
        {
            var query = from PMP in db.pmp
                        where PMP.idProductoPadre == idProducto &&
                        PMP.Semana == Semana
                        select PMP.Cant;
            if (query.Count() > 0)
                return query.ToList()[0];
            else
                return 0;
        }

        public List<pmp> getPMP()
        {
            var query = from PMP in db.pmp
                        select PMP;

            return query.ToList();
        }


        public void insertOrUpdate(int cant, int idProducto, int Semana)
        {
            var query = from PMP in db.pmp
                        where PMP.idProductoPadre == idProducto &&
                        PMP.Semana == Semana
                        select PMP;

            if (query.Count() > 0)
                query.ToList()[0].Cant += cant;

            else
                db.pmp.Add(new pmp(idProducto, Semana, cant));

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }

        }
    }
}
