using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class CargarCombos
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public List<string> CargarProductos()
        {            
            var query = from t in db.traduccion
                        from p in db.producto
                        where t.idDescriptionT == p.idDescriptionP &&
                        t.idLanguageT == LogIn.IdIdioma
                        select t.Traduccion_str;

            return query.ToList();
        }

        public List<string> CargarProductos(int tipo)
        {
            var subquery = from p in db.producto
                           where p.idTipo == tipo
                           select p.idDescriptionP;

            var query = from t in db.traduccion
                        from p in subquery
                        where t.idDescriptionT == p &&
                        t.idLanguageT == LogIn.IdIdioma
                        select t.Traduccion_str;

            return query.ToList();
        }

        public List<string> CargarUM()
        {
            var query = from um in db.unidad_medida
                    from t in db.traduccion
                    where t.idDescriptionT == um.idDescriptionUM &&
                    t.idLanguageT == LogIn.IdIdioma
                    select t.Traduccion_str;

            return query.ToList();
        }

        public List<string> CargarSucursal(int? id)
        {
            if (id != null)
            {
                var query = from s in db.sucursal
                            where s.idSucursal == id
                            select s.Nombre;
            return query.ToList();
            }
            else
            {
                var query = from s in db.sucursal
                            select s.Nombre;
                return query.ToList();
            }

        }

        public List<string> CargarAlmacen(int idScucursal, int ?id)
        {
            if (id != null)
            {
                var query = from a in db.almacen
                            where a.idSucursal == idScucursal && a.idAlmacen == id
                            select a.Nombre;
                return query.ToList();
            }
            else
            {
                var query = from a in db.almacen
                            where a.idSucursal == idScucursal
                            select a.Nombre;
                return query.ToList();
            }
        }

        public List<string> CargarUbicacion(int idAlmacen, int ?id)
        {
            List<string> Final = new List<string>();
            if (id != null)
            {
                var query = from u in db.ubicacion
                            where u.idAlmacen == idAlmacen && u.idUbicacion==id
                            select u.idUbicacion;
                foreach (var item in query)
                {
                    Final.Add(item.ToString());
                }
            }
            else
            {
                var query = from u in db.ubicacion
                            where u.idAlmacen == idAlmacen
                            select u.idUbicacion;
                foreach (var item in query)
                {
                    Final.Add(item.ToString());
                }
            }         
            return Final;
        }

        public List<string> CargarRazon()
        {
            var query = from r in db.razon
                        from t in db.traduccion
                        where r.idDescripcion == t.idDescriptionT && t.idLanguageT==LogIn.IdIdioma
                        select t.Traduccion_str;

            return query.ToList();
        }
    }
}
