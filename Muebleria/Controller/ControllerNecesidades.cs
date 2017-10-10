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
        List<PadreHijo> listaExplosionada = new List<PadreHijo>();
        List<necesidadbruta> listaNB = new List<necesidadbruta>();
        List<necesidadbruta> listaNN = new List<necesidadbruta>();
        List<necesidadneta> necesidadesNetas = new List<necesidadneta>();

        private void generarNB()
        {
            pmp PMP = new pmp();
            List<pmp> listaPMP = PMP.getPMP();

            foreach (pmp item in listaPMP) 
                explosion.Explotar(item.idProductoPadre, item.idProductoPadre, item.Semana, item.Cant);
        }

        private List<PadreHijo> getProdExplotados()
        {
            generarNB();
            listaExplosionada = explosion.getListaExplosionada();
            return listaExplosionada;
        }

        public void cargarNecesidadBruta()
        {
            List<PadreHijo> lista = getProdExplotados();
            foreach (PadreHijo item in lista)
            {
                necesidadbruta nb = new necesidadbruta(cv.getIDProd(item.Hijo), item.Semana, item.Cantidad);
                if(!item.esPadre(item.Hijo))
                    listaNB.Add(nb);
                nb.cargarNecesidadBruta();
            }  
        }

        private void NBmenosStock()
        {
            stock S = new stock();
            float cantidad;
            foreach (PadreHijo ph in listaExplosionada)
            {
                listaNN.Add(new necesidadbruta(cv.getIDProd(ph.Hijo), ph.Semana, ph.Cantidad));
            }
            
            foreach (necesidadbruta nb in listaNN)
            {
                cantidad = S.getStockProducto(nb.idProductoHijo);
                if (cantidad > 0)
                {
                    if (nb.Cant - cantidad < 0)
                    {
                        S.actualizarStock(nb.idProductoHijo, cantidad - nb.Cant);
                        nb.Cant = 0;
                    }
                    else
                    {
                        S.actualizarStock(nb.idProductoHijo, 0);
                        nb.Cant -= Convert.ToInt32(cantidad);
                    }
                }
            }
        }

        public void generarNN()
        {
            NBmenosStock();
            foreach(necesidadbruta nn in listaNN)
            {
                necesidadneta NN = new necesidadneta(nn.idProductoHijo, nn.Semana, nn.Cant);
                necesidadesNetas.Add(NN);
                NN.InsertOrUpdateNecesidadNeta();
            }
        }

        public List<necesidadneta> getNecesidadesNetas()
        {
            return necesidadesNetas;
        }
    }
}
