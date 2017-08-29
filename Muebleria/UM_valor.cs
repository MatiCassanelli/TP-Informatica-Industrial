using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class UM_valor
    {
        string um;
        float conversion;
        
        public float Conversion
        {
            get
            {
                return conversion;
            }

            set
            {
                conversion = value;
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

        public UM_valor(string cum, float cconv)
        {
            Um = cum;
            Conversion = cconv;
        }

        public UM_valor()
        {

        }
    }
}
