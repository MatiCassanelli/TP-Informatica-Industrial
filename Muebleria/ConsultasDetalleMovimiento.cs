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

        public void actualizarStock(movimiento mov)
        {
            stock origen = getStock(mov.idProducto, Convert.ToInt32(mov.A_origen));
            stock destino = getStock(mov.idProducto, Convert.ToInt32(mov.A_destino));

            int real = 0;
            try
            {
                real = esReal(origen.idAlmacen);
            }
            catch
            {
                real = 0;
            }
            if (real == 1)  
            {   //quiere decir q estoy vendiendo
                if (origen.Cantidad - mov.cantidad >= 0)
                {
                    origen.Cantidad -= mov.cantidad;
                    destino.Cantidad += mov.cantidad;
                }
                else
                    throw new Exception("No se puede realizar el movimiento. Stock insuficiente");
            }

            else
            {   //estoy comprandole a un proveedor
                if (origen.idProducto != 0)
                    origen.Cantidad -= mov.cantidad;
                else
                {
                    origen = new stock()
                    {
                        idProducto = mov.idProducto,
                        Cantidad = 0,
                        unidad_medida = Convert.ToInt32(mov.u_medida),
                        idAlmacen = Convert.ToInt32(mov.A_origen),
                        user_upd = LogIn.IdUsuario,
                        last_upd = DateTime.Now
                    };
                origen.Cantidad -= mov.cantidad;
                db.stock.Add(origen);
                }
            }

                if (destino.idProducto != 0)
                    destino.Cantidad += mov.cantidad;
                else
                {
                    destino = new stock()
                    {
                        idProducto = mov.idProducto,
                        Cantidad = 0,
                        unidad_medida = Convert.ToInt32(mov.u_medida),
                        idAlmacen = Convert.ToInt32(mov.A_destino),
                        user_upd = LogIn.IdUsuario,
                        last_upd = DateTime.Now
                    };
                    destino.Cantidad += mov.cantidad;
                    db.stock.Add(destino);
                }
            
            try
            {
                db.SaveChanges();
            }
            catch (Exception exc)
            {

            }
        }

        public int esReal(int id)
        {
            var query = from s in db.sucursal
                        from a in db.almacen
                        where s.idSucursal == a.idSucursal && a.idAlmacen == id
                        select s.Real;
            return query.ToList()[0];
        }

        public void actualizarArticulo(movimiento mov)
        {
            articulo art = getArticulo(Convert.ToDouble(mov.idArticulo));
            art.estado = "Fuera de mi Planta";
            art.ubicacion = Convert.ToInt32(mov.A_destino);
            db.SaveChanges();
        }

        public articulo getArticulo(double sn)
        {
            var query = from a in db.articulo
                        where a.numero_serie == sn// && a.estado!= "Remito"
                        select a;
            return query.ToList()[0];
        }

        public stock getStock(int prod,int almacen)
        {
            var query = from s in db.stock
                        where s.idProducto == prod && s.idAlmacen==almacen
                        select s;
            try
            {
                return query.ToList()[0];
            }
            catch
            {
                return new stock();
            }
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
                        select s.idAlmacen;
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

        public int getIDUbicacion(int? id)
        {
            var query = from s in db.ubicacion
                        where s.idUbicacion==id
                        select s.idUbicacion;
            return query.ToList()[0];
        }

        public razon getRazonCompleta(int id)
        {
            var query = from r in db.razon
                        where r.idRazon == id
                        select r;

            return query.ToList()[0];
        }

        public bool existeIdHistorial(int id)
        {
            var query = from h in db.historial_txt
                        where h.idHistorial_txt == id
                        select h.idHistorial_txt;
            if (query.Count() > 0)
                return true;
            else
                return false;
        }

        public void insertIdHistorial(int id)
        {
            historial_txt historialTXT = new historial_txt() { idHistorial_txt = id };
            db.historial_txt.Add(historialTXT);
            db.SaveChanges();
        }

        public bool existeIdProducto(int id)
        {
            var query = from p in db.producto
                        where p.idProducto == id
                        select p.idProducto;
            if (query.Count() > 0)
                return true;
            else
                return false;
        }

        public bool existeSucursal(int id)
        {
            var query = from s in db.sucursal
                        where s.idSucursal == id
                        select s.idSucursal;
            if (query.Count() > 0)
                return true;
            else
                return false;
        }

        public void ActualizarStockTXT(int idProducto, int cant)
        {
            stock _stock = getStock(idProducto, 1);

            if (_stock.idProducto != 0)
                _stock.Cantidad += cant;
            else
            {
                _stock = new stock()
                {
                    idProducto = idProducto,
                    Cantidad = cant,
                    unidad_medida = 1,
                    idAlmacen = 1,
                    user_upd = LogIn.IdUsuario,
                    last_upd = DateTime.Now
                };
                db.stock.Add(_stock);
            }









            //_stock.Cantidad += cant;
            db.SaveChanges();
        }
    }
}
