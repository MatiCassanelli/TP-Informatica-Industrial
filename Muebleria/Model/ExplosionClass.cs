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
        public void ConsultarRecursivo(string padre, string prodfinal, int semanaBuscada)
        {
            List<PadreHijo> aux = consultarPadre(padre,semanaBuscada);
            if (aux.Count > 0)
            {
                foreach (PadreHijo item in aux)
                {
                    //UM_valor umv = consultarUM(item.Hijo);
                    ConsultarRecursivo(item.Hijo, prodfinal, semanaBuscada);
                    lista.Add(item);
                }
            }
        }
        public List<PadreHijo> getListaExplosionada()
        {
            return lista;
        }

        private List<PadreHijo> consultarPadre(string padre, int semanaBuscada)
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
                    lista.Add(new PadreHijo(padre, item.nombre, Convert.ToInt32(item.cant), item.um));
                }
            }
            return lista;
        }

        private List<padre_componente_publicado> ObtenerComponentes(string prod, int semana)
        {
            var queryP = from p in db.producto
                         from t in db.traduccion
                         where p.idDescriptionP == t.idDescriptionT &&
                         t.Traduccion_str == prod &&
                         t.idLanguageT == LogIn.IdIdioma
                         select p.idProducto;
            List<int> P = queryP.ToList();

            var componentes = db.padre_componente_publicado.SqlQuery("SELECT pcp.* FROM `padre-componente-publicado` pcp INNER JOIN(SELECT distinct pcp2.idPadreP, pcp2.fecha_aplicacion FROM `padre-componente-publicado` pcp2 WHERE pcp2.idPadreP = " + P[0].ToString() + " and pcp2.fecha_aplicacion = " + traerFechas(prod,semana) + ") as t on pcp.idPadreP = t.idPadreP WHERE pcp.fecha_aplicacion = t.fecha_aplicacion and pcp.version >= all(SELECT distinct pcp4.version FROM `padre-componente-publicado` pcp4 WHERE pcp4.idPadreP = " + P[0].ToString() + " and pcp4.fecha_aplicacion = " + traerFechas(prod,semana).ToString() + ");");
            return componentes.ToList<padre_componente_publicado>();
        }
        
        private int traerFechas(string prod, int semana)
        {
            int fecha = semana;
            //var subquery = db.padre_componente_publicado.SqlQuery("select distinct `padre-componente-publicado`.fecha_aplicacion from `padre-componente-publicado` order by fecha_aplicacion desc");
            var QueryidPadre = from p in db.producto
                               from t in db.traduccion
                               where p.idDescriptionP == t.idDescriptionT &&
                               t.Traduccion_str == prod &&
                               t.idLanguageT == LogIn.IdIdioma
                               select p.idProducto;

            var subquery = from pc in db.padre_componente_publicado
                           from qinp in QueryidPadre
                           where pc.idPadreP == qinp
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
