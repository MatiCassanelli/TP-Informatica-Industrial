using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class ControllerNecesidades
    {
        ExplosionClass explosion = new ExplosionClass();
        ConsultasVarias cv = new ConsultasVarias();
        List<necesidadbruta> listaNB = new List<necesidadbruta>();
        private void generarNB()
        {
            pmp PMP = new pmp();
            List<pmp> listaPMP = PMP.getPMP();

            foreach (pmp item in listaPMP)  //ver xq creo q lo hace mas veces de la q deberia
                explosion.Explotar(item.idProductoPadre, item.idProductoPadre, item.Semana, item.Cant);
        }

        private List<PadreHijo> getProdExplotados()
        {
            generarNB();
            List<PadreHijo> asd = explosion.getListaExplosionada();
            return asd;
        }

        public void cargarNecesidadBruta()
        {
            List<PadreHijo> lista = getProdExplotados();
            foreach (PadreHijo item in lista)
            {
                necesidadbruta nb = new necesidadbruta(cv.getIDProd(item.Hijo), item.Semana, item.Cantidad);
                listaNB.Add(nb);
                nb.cargarNecesidadBruta();
            }  
        }

        public void NBmenosStock()
        {
            stock S = new stock();
            float cantidad;
            foreach (necesidadbruta r in listaNB)
            {
                cantidad = S.getStockProducto(r.idProductoHijo);
                if (cantidad > 0)
                {
                    if (r.Cant - cantidad < 0)
                    {
                        S.actualizarStock(r.idProductoHijo, cantidad - r.Cant);
                        r.Cant = 0;
                    }
                    else
                    {
                        S.actualizarStock(r.idProductoHijo, 0);
                        r.Cant -= Convert.ToInt32(cantidad);
                    }
                }
            }
        }
    }
}
