using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    public partial class necesidadbruta
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public necesidadbruta(int idProd, int semana, int cant)
        {
            idProductoHijo = idProd;
            Semana = semana;
            Cant = cant;
        }

        public void cargarNecesidadBruta()
        {
            db.necesidadbruta.Add(this);

            db.SaveChanges();

        }

        private bool existeNB(necesidadbruta nb)
        {
            var query = from NB in db.necesidadbruta
                        select NB;
            if (query.Contains(nb))
                return true;
            else
                return false;
        }
    }
}
