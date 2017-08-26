using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class PadreHijo
    {
        private string padre;
        private string hijo;
        private int cantidad;
        private string um;

        public string Padre
        {
            get
            {
                return padre;
            }

            set
            {
                padre = value;
            }
        }

        public string Hijo
        {
            get
            {
                return hijo;
            }

            set
            {
                hijo = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public string Um
        {
            get
            {
                return um;
            }

            set
            {
                um = value;
            }
        }
        public PadreHijo(string cpadre, string chijo, int ccant, string cum)
        {
            padre = cpadre;
            hijo = chijo;
            cantidad = ccant;
            um = cum;
        }
        PadreHijo()
        {

        }
    }
}
