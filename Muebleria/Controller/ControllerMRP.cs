using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class ControllerMRP
    {
        internal List<requerimientos> formatearLista(List<requerimientos> lista)
        {
            List<requerimientos> aux = lista;
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 1; j < aux.Count && i!=j; j++)
                {
                    if (lista[i].idProducto == aux[j].idProducto)
                        if (lista[i].Cliente == aux[j].Cliente)
                            if (lista[i].Semana == aux[j].Semana)
                                lista[i].Delta += aux[j].Delta;
                }
            }
            return lista;
        }
    }
}
