using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class ControllerCargaVGM
    {
        ConsultasDetalleMovimiento consulta = new ConsultasDetalleMovimiento();
        ControllerMRP controllerMRP = new ControllerMRP();

        public requerimientos crearRequerimiento(string cliente, string prod, int cant, int semana)
        {
            requerimientos req = new requerimientos(cliente, consulta.getIDProd(prod), cant, semana);
            //controllerMRP.traerReqCreado(req);
            return req;

        }
    }
}
