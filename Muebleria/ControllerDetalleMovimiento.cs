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

        public void crearMovimiento(string prod, int cant, string um, string razon)
        {
            movimiento mov = new movimiento()
            {
                idProducto = cdm.getIDProd(prod),
                cantidad = cant,
                u_medida = cdm.getIDUnidadMedidad(um),
                idRazon = cdm.getIDRazon(razon)
            };
            cdm.InsertarMovimiento(mov);
        }
    }
}
