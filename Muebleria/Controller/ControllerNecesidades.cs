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
        private void generarNB()
        {
            pmp PMP = new pmp();
            List<pmp> listaPMP = PMP.getPMP();

            foreach (pmp item in listaPMP)
                explosion.Explotar(item.idProductoPadre, item.idProductoPadre, item.Semana);
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
                nb.cargarNecesidadBruta();
            }
            
            
        }
    }
}
