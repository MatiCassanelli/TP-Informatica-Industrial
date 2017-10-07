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

        public requerimientos crearRequerimiento(string prod, int semana,string cliente, int cant)
        {
            requerimientos req = new requerimientos(consulta.getIDProd(prod), semana, cliente, cant);
            //controllerMRP.traerReqCreado(req);
            return req;

        }
    }
}
