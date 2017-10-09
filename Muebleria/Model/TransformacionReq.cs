using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class TransformacionReq
    {
        private Dictionary<int, int> diccionario = new Dictionary<int, int>();

        private int cantMesaTubular = 30;
        private const int idMesaTubular = 10056456;
        private int cantMesaRedonda = 40;
        private const int idMesaRedonda = 10056457;
        private int cantEscritorio2x1 = 30;
        private const int idEscritorio2x1 = 10056458;
        private int cantEscritorio1x30 = 30;
        private const int idEscritorio1x30 = 10056459;
        private int cantEscritorioExec = 15;
        private const int idEscritorioExec = 10056460;

        private List<requerimientos> Requerimientos;

        public TransformacionReq()
        {
            diccionario.Add(idMesaTubular, cantMesaTubular);
            diccionario.Add(idMesaRedonda, cantMesaRedonda);
            diccionario.Add(idEscritorio2x1, cantEscritorio2x1);
            diccionario.Add(idEscritorio1x30, cantEscritorio1x30);
            diccionario.Add(idEscritorioExec, cantEscritorioExec);

            requerimientos R = new requerimientos();
            Requerimientos = R.getRequerimientosSumados();
            deltaMenosStock();
        }

        private void deltaMenosStock()
        {
            stock S = new stock();
            float cantidad;
            foreach (requerimientos r in Requerimientos)
            {
                cantidad = S.getStockProducto(r.idProducto);
                if (cantidad > 0)
                {
                    if (r.Delta - cantidad < 0)
                    {
                        S.actualizarStock(r.idProducto, cantidad - r.Delta);
                        r.Delta = 0;
                    }
                    else
                    {
                        S.actualizarStock(r.idProducto, 0);
                        r.Delta -= Convert.ToInt32(cantidad);
                    }
                }
            }
        }

        public void elaborarPMP() 
        {
            Fecha fecha = new Fecha();
            int semana = fecha.convertir(DateTime.Now);
            semana += 3; //periodo de freeze??

            foreach(requerimientos row in Requerimientos)
            {
                distribuirProduccion(row.idProducto, row.Delta, semana);
            }

        }


        private void distribuirProduccion(int idProducto, int delta, int semana) //f() recursiva
        {
            pmp PMP = new pmp();
            int capMax;
            diccionario.TryGetValue(idProducto, out capMax);
            int cantidad = PMP.getCantidad(idProducto, semana);
            int cantDisp = capMax - cantidad;

            if (cantDisp > 0)
            {
                if (delta <= cantDisp)
                {
                    PMP.insertOrUpdate(delta, idProducto, semana);
                    return;
                }
                else
                {
                    PMP.insertOrUpdate(cantDisp, idProducto, semana);
                    distribuirProduccion(idProducto, delta - cantDisp, semana + 1);
                }
            }
        }

    }
}
