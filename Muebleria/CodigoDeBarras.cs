﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class CodigoDeBarras
    {
        public CodigoDeBarras()
        {

        }

        public string generarCodigoDeBarras(long sn)
        {
            string cdb = "*" + sn.ToString() + "*";
            return cdb;
        }

    }
}
