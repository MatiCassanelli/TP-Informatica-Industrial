﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class ControllerMRP
    {
        ConsultasVarias cc = new ConsultasVarias();
        public List<requerimientos> formatearLista(List<requerimientos> lista)
        {
            List<requerimientos> aux = lista;
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 1; j < aux.Count && i != j; j++)
                {
                    if (lista[i].idProducto == aux[j].idProducto)
                        if (lista[i].Cliente == aux[j].Cliente)
                            if (lista[i].Semana == aux[j].Semana)
                            {
                                lista[i].Delta += aux[j].Delta;
                                lista.Remove(lista[j]);
                                j = i;
                            }
                }
            }
            return lista;
        }

        public string getNombreProducto(int id)
        {
            return cc.getNombreProd(id);
        }

        public void cargarRequerimiento(System.Windows.Forms.DataGridViewRow row)
        {
            //requerimientos req = new requerimientos((int)row.Cells["Producto"].Value, (int)row.Cells["SemanaRequerida"].Value, (string)row.Cells["Cliente"].Value, (int)row.Cells["Delta"].Value);
            requerimientos req = new requerimientos(cc.getIDProd(row.Cells["Producto"].Value.ToString()), (int)row.Cells["SemanaRequerida"].Value, (string)row.Cells["Cliente"].Value, (int)row.Cells["Delta"].Value);
            req.cargarRequerimiento();
        }
    }
}
