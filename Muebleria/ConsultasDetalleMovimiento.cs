﻿using System;
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

            try
            {
                origen.Cantidad -= mov.cantidad;
            }
            catch
            {
                origen = new stock()
                {
                    idProducto = mov.idProducto,
                    Cantidad = mov.cantidad,
                    unidad_medida = Convert.ToInt32(mov.u_medida),
                    idAlmacen = Convert.ToInt32(mov.A_origen),
                    user_upd = LogIn.IdUsuario,
                    last_upd = DateTime.Now
                };
                db.stock.Add(origen);
            }

            try
            {
                destino.Cantidad += mov.cantidad;
            }
            catch
            {
                destino = new stock()
                {
                    idProducto = mov.idProducto,
                    Cantidad = mov.cantidad,
                    unidad_medida = Convert.ToInt32(mov.u_medida),
                    idAlmacen = Convert.ToInt32(mov.A_destino),
                    user_upd = LogIn.IdUsuario,
                    last_upd = DateTime.Now
                };
                db.stock.Add(destino);
            }
            db.SaveChanges();
        }

        public void actualizarArticulo(movimiento mov)
        {
            articulo art = getArticulo(Convert.ToDouble(mov.idArticulo));
            art.estado = "asd";
            art.ubicacion = Convert.ToInt32(mov.A_destino);
            db.SaveChanges();
        }

        public articulo getArticulo(double sn)
        {
            var query = from a in db.articulo
                        where a.numero_serie == sn
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
    }
}
