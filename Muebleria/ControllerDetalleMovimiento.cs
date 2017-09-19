using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class ControllerDetalleMovimiento
    {
        CargarCombos cc = new CargarCombos();
        ConsultasDetalleMovimiento cdm = new ConsultasDetalleMovimiento();
        public List<string> CargarProductos()
        {
            return cc.CargarProductos();
        }

        public List<string> CargarProductos(int indice)
        {
            return cc.CargarProductos(indice);
        }

        public List<string> CargarUM()
        {
            return cc.CargarUM();
        }

        //venta de un articulo determinado a un cliente
        public void crearMovimiento(string razon, double sn, string prod, int cant, string um, string sucorigen, string sucdestino,
            string almorigen, string almdestino, int uborigen, int ubdestino)
        {
            movimiento mov = new movimiento()
            {
                idRazon = cdm.getIDRazon(razon),
                idArticulo=sn,
                idProducto = cdm.getIDProd(prod),
                cantidad = cant,
                u_medida = cdm.getIDUnidadMedidad(um),
                S_origen=cdm.getIDSucursal(sucorigen),
                S_destino=cdm.getIDSucursal(sucdestino),
                A_origen=cdm.getIDAlmacen(almorigen),
                A_destino=cdm.getIDAlmacen(almdestino),
                U_origen=cdm.getIDUbicacion(uborigen),
                U_destino=cdm.getIDUbicacion(ubdestino)                
            };
            cdm.InsertarMovimiento(mov);
            cdm.actualizarStock(mov);
            cdm.actualizarArticulo(mov);
        }
        
    }
}
