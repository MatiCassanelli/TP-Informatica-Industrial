using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class ConsultasDetalleMovimiento
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();

        public void InsertarMovimiento(movimiento mov)
        {
            db.movimiento.Add(mov);
            db.SaveChanges();
        }

        public int getIDRazon(string razon)
        {
            var query = from r in db.razon
                        from t in db.traduccion
                        where r.idDescripcion == t.idDescriptionT && t.Traduccion_str == razon
                        select r.idRazon;
            return query.ToList()[0];
        }

        public int getIDProd(string prod)
        {
            var query = from p in db.producto
                        from t in db.traduccion
                        where p.idDescriptionP == t.idDescriptionT && t.Traduccion_str == prod
                        select p.idProducto;
            return query.ToList()[0];
        }

        public int getIDSucursal(string suc)
        {
            var query = from s in db.sucursal
                        where s.Nombre == suc
                        select s.idSucursal;
            return query.ToList()[0];
        }

        public int getIDAlmacen(string suc)
        {
            var query = from s in db.almacen
                        where s.Nombre == suc
                        select s.idSucursal;
            return query.ToList()[0];
        }

        public int getIDUnidadMedidad(string um)
        {
            var query = from p in db.unidad_medida
                        from t in db.traduccion
                        where p.idDescriptionUM == t.idDescriptionT && t.Traduccion_str == um
                        select p.idUnidad_Medida;
            return query.ToList()[0];
        }

        //public int getIDUbicacion(string suc)
        //{
        //    var query = from s in db.ubicacion
        //                where s.
        //                select s.idSucursal;
        //    return query.ToList()[0];
        //}
    }
}
