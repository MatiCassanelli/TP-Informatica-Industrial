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
    }
}
