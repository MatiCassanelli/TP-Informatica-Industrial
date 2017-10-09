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
        private int idPadre;
        private string hijo;
        private int idHijo;
        private int cantidad;
        private string um;
        private string sustituto;
        private int idSust;
        private int semana;

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

        public string Sustituto
        {
            get
            {
                return sustituto;
            }

            set
            {
                sustituto = value;
            }
        }

        public int IdPadre
        {
            get
            {
                return idPadre;
            }

            set
            {
                idPadre = value;
            }
        }

        public int IdHijo
        {
            get
            {
                return idHijo;
            }

            set
            {
                idHijo = value;
            }
        }

        public int IdSust
        {
            get
            {
                return idSust;
            }

            set
            {
                idSust = value;
            }
        }

        public int Semana
        {
            get
            {
                return semana;
            }

            set
            {
                semana = value;
            }
        }

        public PadreHijo(string cpadre, string chijo, int ccant, string cum)
        {
            padre = cpadre;
            hijo = chijo;
            cantidad = ccant;
            um = cum;
        }

        public PadreHijo(string cpadre, string chijo, string chijo2)
        {
            padre = cpadre;
            hijo = chijo;
            sustituto = chijo2;
        }

        public PadreHijo(int cpadre, int chijo, int chijo2)
        {
            idPadre = cpadre;
            idHijo = chijo;
            idSust = chijo2;
        }
        PadreHijo()
        {

        }
        public PadreHijo(string cpadre, string chijo, int ccant, string cum, int semana)
        {
            padre = cpadre;
            hijo = chijo;
            cantidad = ccant;
            um = cum;
            Semana = semana;
        }

        public bool esPadre(string Prod)
        {
            informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
            ConsultasVarias cv = new ConsultasVarias();
            int idProd = cv.getIDProd(Prod);
            var query = from pcp in db.padre_componente_publicado
                        where pcp.idPadreP == idProd
                        select pcp.idPadreP;
            if (query.Count() > 0)
                return true;
            else
                return false;

        }
    }
}
