using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class ExplosionClass
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        List<PadreHijo> lista = new List<PadreHijo>();
        ConsultasVarias cv = new ConsultasVarias();
        public void Explotar(int padre, int prodfinal, int semanaBuscada,int cantidad)
        {
            List<PadreHijo> aux = consultarPadre(padre,semanaBuscada);
            if (aux.Count > 0)
            {
                List<PadreHijo> padresSinFiltro = new List<PadreHijo>();
                foreach (PadreHijo item in aux)
                {
                    //UM_valor umv = consultarUM(item.Hijo);
                    Explotar(cv.getIDProd(item.Hijo), prodfinal, semanaBuscada, cantidad);
                    PadreHijo ph = new PadreHijo(cv.getNombreProd(padre), item.Hijo, (Convert.ToInt32(item.Cantidad) * cantidad), item.Um, semanaBuscada);
                    if (ph.esPadre(ph.Hijo) == false)
                        lista.Add(ph);
                }
                //lista = filtrarPadre(padresSinFiltro);
            }
        }

        //private List<PadreHijo> filtrarPadre(PadreHijo ph)
        //{
        //    for (int i = 0; i < padresSinFiltro.Count; i++)
        //    {
        //        if (padresSinFiltro[i].esPadre(padresSinFiltro[i].Hijo) == true)
        //        {
        //            padresSinFiltro.Remove(padresSinFiltro[i]);
        //        }
        //    }
        //    return padresSinFiltro;
        //}

        public List<PadreHijo> getListaExplosionada()
        {
            return lista;
        }

        private List<PadreHijo> consultarPadre(int padre, int semanaBuscada)
        {
            List<padre_componente_publicado> relleno = ObtenerComponentes(padre, semanaBuscada);
            List<padre_componente_publicado> aux = new List<padre_componente_publicado>();
            foreach (padre_componente_publicado fila in relleno)
            {
                padre_componente_publicado pcp = new padre_componente_publicado()
                {
                    idPadreP = fila.idPadreP,
                    idHijoP = fila.idHijoP,
                    Cantidad = fila.Cantidad,
                    U_medida_default = fila.U_medida_default,
                    U_medida_usada = fila.U_medida_usada
                };
                aux.Add(fila);
            }

            //Obtener las descripciones de las unidades de medidas
            var subquery = from um in db.unidad_medida
                           from t in db.traduccion
                           where um.idDescriptionUM == t.idDescriptionT &&
                           t.idLanguageT == LogIn.IdIdioma
                           select new { id = um.idUnidad_Medida, t = t.Traduccion_str };

            //Obtener las descripciones de los productos seleccionados en la consulta anterior
            List<PadreHijo> lista = new List<PadreHijo>();

            foreach (padre_componente_publicado pcp in aux)
            {
                var query2 = from sq in subquery
                             from t in db.traduccion
                             from p in db.producto
                             where p.idProducto == pcp.idHijoP &&
                             p.idDescriptionP == t.idDescriptionT &&
                             sq.id == pcp.U_medida_usada &&
                             t.idLanguageT == LogIn.IdIdioma
                             //select t.Traduccion_str + "  x" + n.cant.ToString() + " " + sq.t;
                             select new { nombre = t.Traduccion_str, cant = pcp.Cantidad.ToString(), um = sq.t };

                foreach (var item in query2)
                {
                    lista.Add(new PadreHijo(cv.getNombreProd(padre), item.nombre, Convert.ToInt32(item.cant), item.um, semanaBuscada));
                }
            }
            return lista;
        }

        private List<padre_componente_publicado> ObtenerComponentes(int prod, int semana)
        {
            var componentes = db.padre_componente_publicado.SqlQuery("SELECT pcp.* FROM `padre-componente-publicado` pcp INNER JOIN(SELECT distinct pcp2.idPadreP, pcp2.fecha_aplicacion FROM `padre-componente-publicado` pcp2 WHERE pcp2.idPadreP = " + prod + " and pcp2.fecha_aplicacion = " + traerFechas(prod,semana) + ") as t on pcp.idPadreP = t.idPadreP WHERE pcp.fecha_aplicacion = t.fecha_aplicacion and pcp.version >= all(SELECT distinct pcp4.version FROM `padre-componente-publicado` pcp4 WHERE pcp4.idPadreP = " + prod + " and pcp4.fecha_aplicacion = " + traerFechas(prod,semana).ToString() + ");");
            return componentes.ToList<padre_componente_publicado>();
        }
        
        private int traerFechas(int prod, int semana)
        {
            int fecha = semana;
            //var subquery = db.padre_componente_publicado.SqlQuery("select distinct `padre-componente-publicado`.fecha_aplicacion from `padre-componente-publicado` order by fecha_aplicacion desc");
            
            var subquery = from pc in db.padre_componente_publicado
                           where pc.idPadreP == prod
                           orderby pc.fecha_aplicacion descending
                           select pc.fecha_aplicacion;
            List<int> fechasconsulta = subquery.ToList();

            int fechaAplicacion = 1;
            for (int i = 0; i < fechasconsulta.Count; i++)
            {
                if (fecha >= fechasconsulta[i])
                {
                    fechaAplicacion = fechasconsulta[i];
                    i = fechasconsulta.Count;
                }
            }
            return fechaAplicacion;
        }
    }
}
