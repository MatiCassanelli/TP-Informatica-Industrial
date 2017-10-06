using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class ControllerMRP
    {
        private List<requerimientos> listReq = new List<requerimientos>();

        public void traerReqCreado(requerimientos req)
        {
            listReq.Add(req);
        }

        public List<requerimientos> getRequerimientos()
        {
            return listReq;
        }
    }
}
