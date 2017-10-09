﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    public partial class necesidadbruta
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        public necesidadbruta(int idProd, int semana, int cant)
        {
            idProductoHijo = idProd;
            Semana = semana;
            Cant = cant;
        }
        public necesidadbruta()
        {

        }

        public void cargarNecesidadBruta()
        {
            var query = from nb in db.necesidadbruta
                        where this.idProductoHijo == nb.idProductoHijo && this.Semana == nb.Semana
                        select nb;

            if (query.Count() > 0)
                query.ToList()[0].Cant+=this.Cant;
            else
                db.necesidadbruta.Add(this);

            db.SaveChanges();

        }
    }
}