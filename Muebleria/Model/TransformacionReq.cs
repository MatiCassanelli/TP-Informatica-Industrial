using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria.Model
{
    class TransformacionReq
    {
        private int cantMesaTubular = 30;
        private int cantMesaRedonda = 40;
        private int cantMesa2x1 = 30;
        private int cantMesa1x30 = 30;
        private int cantMesaExec = 15;

        private List<requerimientos> Requerimientos;

        public TransformacionReq()
        {
            requerimientos R = new requerimientos();
            Requerimientos = R.getRequerimientosCargados();
        }

        void deltaMenosStock()
        {
            stock S = new stock();
            float cantidad;
            foreach (requerimientos r in Requerimientos)
            {
                if(S.getStockProducto(r.idProducto)>0)
                {
                    cantidad = S.getStockProducto(r.idProducto);
                    if (r.Delta - cantidad < 0)
                    {
                        S.actualizarStock(r.idProducto, cantidad - r.Delta);
                        r.Delta = 0;
                    }
                    else
                    {
                        S.actualizarStock(r.idProducto, cantidad - r.Delta);
                        r.Delta = r.Delta - Convert.ToInt32(cantidad);
                    }
                }
            }
        }
    }
}
