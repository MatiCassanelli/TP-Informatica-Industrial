using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class ControllerNecesidades
    {
        ConsultasVarias cv = new ConsultasVarias();

        ExplosionClass explosion = new ExplosionClass();

        List<PadreHijo> listaExplosionada = new List<PadreHijo>();
        List<PadreHijo> listaPadres = new List<PadreHijo>();
        List<necesidadbruta> listaNB = new List<necesidadbruta>();
        List<necesidadbruta> listaNN = new List<necesidadbruta>();
        List<necesidadbruta> listaDiferencias = new List<necesidadbruta>();
        List<necesidadbruta> listaNBviejas = new List<necesidadbruta>();
        List<necesidadneta> listaNNviejas = new List<necesidadneta>();
        List<necesidadneta> necesidadesNetas = new List<necesidadneta>();

        public ControllerNecesidades()
        {
            necesidadbruta nb = new necesidadbruta();   
            listaNBviejas = nb.getAll();
            necesidadneta nn = new necesidadneta();
            listaNNviejas = nn.getAll();
        }

        public void cargarNecesidadBruta()  //1
        {
            getProdExplotados();
            foreach (PadreHijo item in listaExplosionada)
            {
                necesidadbruta nb = new necesidadbruta();
                nb = new necesidadbruta(cv.getIDProd(item.Hijo), item.Semana,
                    (item.Cantidad - nb.getCantidad(cv.getIDProd(item.Hijo), item.Semana)));
                listaNB.Add(nb);

                nb.cargarNecesidadBruta();

                if (item.esPadre(item.Hijo))
                    listaPadres.Add(item);
                //if (!item.esPadre(item.Hijo))
                //    nb.cargarNecesidadBruta();
                //else
                //{
                //    necesidadneta nn = new necesidadneta();     //lo de necesidad neta me hace RUIDO
                //    item.Cantidad -= nn.getDiferenciaCantidad(cv.getIDProd(item.Hijo), item.Semana);    //con los valores q siempre cargo, da 18 xq hace 30-12. No deberia hacer 30-12, sino q deberia hacer 27-12 para q de lo q tiene q dar. o sino, 5 de la semana q viene - 3 q ya produje
                //    listaPadres.Add(item);                                                              //tiene en cuenta las 5 mesa tubulares producidas, pero no las 3 tp q ya produje. siempre me termina haciendo 40 del req total - 5 mt hechas. 
                //}
            }
        }
        private void getProdExplotados() //2
        {
            generarNB();
            listaExplosionada = explosion.getListaExplosionada();
        }

        private void generarNB()    //3
        {
            pmp PMP = new pmp();
            List<pmp> listaPMP = PMP.getPMP();

            foreach (pmp item in listaPMP) 
                explosion.Explotar(item.idProductoPadre, item.idProductoPadre, item.Semana, item.Cant);
        }

        public void generarNN() //4
        {
            NBmenosStock(); //hacer metodo para detectar cambios en el stock - comparar listaNN con NB de la bd --> si hay cambios, calcular delta y restar a la nn 
            restarListas();

            TransformacionReq tr = new TransformacionReq();
            necesidadbruta nb = new necesidadbruta();
            List <necesidadbruta> NBnuevas = nb.getAll();
            necesidadneta nn = new necesidadneta();
            List<necesidadneta> NNviejas = nn.getAll();

            for (int i = 0; i < listaNB.Count(); i++)
            {
                int idPadre = devolveridPadre(NBnuevas[i].idProductoHijo, NBnuevas[i].Semana);
                int capXcant = devolverCantidadNecesaria(NBnuevas[i].idProductoHijo, NBnuevas[i].Semana) * tr.getCapacidad(idPadre);
                if (NBnuevas[i].Cant == capXcant)
                {
                    int aux = capXcant - getCantidadNBVieja(NBnuevas[i].idProductoHijo) - getDiferencia(NBnuevas[i].idProductoHijo) + getCantidadNNVieja(NBnuevas[i].idProductoHijo);
                    nn = new necesidadneta(NBnuevas[i].idProductoHijo, NBnuevas[i].Semana, aux);
                    necesidadesNetas.Add(nn);
                    nn.InsertOrUpdateNecesidadNeta();
                }
                else
                {
                    nn = new necesidadneta(NBnuevas[i].idProductoHijo, NBnuevas[i].Semana, NBnuevas[i].Cant - getDiferencia(NBnuevas[i].idProductoHijo)); //- listaDiferencias[i].Cant);
                    necesidadesNetas.Add(nn);
                    nn.InsertOrUpdateNecesidadNeta();
                }
            }
            


            //foreach (necesidadbruta nn in listaNN)      //traerme la tabla de NB de la bd
            //{
            //    necesidadneta NN = new necesidadneta(nn.idProductoHijo, nn.Semana, nn.Cant);
            //    necesidadesNetas.Add(NN);
            //    NN.InsertOrUpdateNecesidadNeta();
            //}
            //NBmenosStock deberia ir aca
        }
        private int getCantidadNBVieja(int idproducto)
        {
            var query = listaNBviejas.Where(x => x.idProductoHijo == idproducto);
            if (query.Count() > 0)
                return query.ToList()[0].Cant;
            else
                return 0;
        }
        private int getCantidadNNVieja(int idproducto)
        {
            var query = listaNNviejas.Where(x => x.idProductoHijo == idproducto);
            if (query.Count() > 0)
                return query.ToList()[0].Cant;
            else
                return 0;
        }
        private int getDiferencia(int idproducto)
        {
            return listaDiferencias.Where(x => x.idProductoHijo == idproducto).ToList()[0].Cant;
        }
        private void restarListas()
        {
            int aux;
            necesidadbruta nb = new necesidadbruta();
            List<necesidadbruta> NBnuevas = nb.getAll();
            for (int i = 0; i < listaNN.Count(); i++)
            {
                if (listaNB[i].Cant - listaNN[i].Cant <= 0)
                    aux = 0;
                else
                    aux = listaNB[i].Cant - listaNN[i].Cant;
                necesidadbruta nn = new necesidadbruta(listaNN[i].idProductoHijo, listaNN[i].Semana, aux);
                listaDiferencias.Add(nn);
            }
        }
        private int devolverCantidadNecesaria (int idproductoHijo, int semana)
        {
            string nombreProducto = cv.getNombreProd(idproductoHijo);
            var query = from le in listaExplosionada
                        where le.Hijo == nombreProducto &&
                        le.Semana == semana
                        select le.Padre;

            int idPadre = cv.getIDProd(query.ToList()[0]);
            return cv.getCantidadPadreComponente(idPadre, idproductoHijo);
        }

        private int devolveridPadre(int idproductoHijo, int semana)
        {
            string nombreProducto = cv.getNombreProd(idproductoHijo);
            var query = from le in listaExplosionada
                        where le.Hijo == nombreProducto &&
                        le.Semana == semana
                        select le.Padre;

            PadreHijo ph = listaPadres.Find(x => x.Hijo == query.ToList()[0]);
            if (ph != null)
            {
                return devolveridPadre(cv.getIDProd(ph.Hijo), semana);
            }
            else
                return cv.getIDProd(query.ToList()[0]);
        }

        private int devolverCantidadVieja (int idproducto, int semana)
        {
            var query = from NBv in listaNBviejas
                        where NBv.idProductoHijo == idproducto &&
                        NBv.Semana == semana
                        select NBv.Cant;
            if (query.Count() > 0)
                return query.ToList()[0];
            else
                return 0;
        }

        private void NBmenosStock() //5
        {
            stock S = new stock();
            float cantidad;
            limpiarLista();
            foreach (PadreHijo ph in listaExplosionada)
            {
                listaNN.Add(new necesidadbruta(cv.getIDProd(ph.Hijo), ph.Semana, ph.Cantidad));
            }

            foreach (necesidadneta nb in listaNNviejas)
            {
                cantidad = S.getStockProducto(nb.idProductoHijo);
                if (cantidad > 0)
                {
                    if (nb.Cant - cantidad < 0)
                    {
                        S.actualizarStock(nb.idProductoHijo, cantidad - nb.Cant);
                        nb.Cant = 0;
                    }
                    else
                    {
                        S.actualizarStock(nb.idProductoHijo, 0);
                        nb.Cant -= Convert.ToInt32(cantidad);
                    }
                }
            }
        }

        private void limpiarLista() //6
        {
            foreach (PadreHijo ph in explotarParaNN())
            {
                for (int i = 0; i < listaExplosionada.Count; i++)
                {
                    if (ph.Padre == listaExplosionada[i].Padre && ph.Hijo == listaExplosionada[i].Hijo &&
                        ph.Semana == listaExplosionada[i].Semana)
                        listaExplosionada[i].Cantidad = ph.Cantidad;
                }
            }
        }

        private List<PadreHijo> explotarParaNN()    //7
        {
            restarStockPadres();
            ExplosionClass exp = new ExplosionClass();
            //List<PadreHijo> asd = new List<PadreHijo>();
            foreach (PadreHijo ph in listaPadres)//listaExplosionada)
                exp.Explotar(cv.getIDProd(ph.Hijo), cv.getIDProd(ph.Hijo), ph.Semana, ph.Cantidad);

            return exp.getListaExplosionada();
        }

        private void restarStockPadres()    //8
        {
            stock S = new stock();
            foreach (PadreHijo ph in listaPadres )// listaExplosionada)
            {
                //if (ph.esPadre(ph.Hijo))//&&es ultima semana
                //{
                    float cantidad = S.getStockProducto(cv.getIDProd(ph.Hijo));
                    if (cantidad > 0)
                    {
                        if (ph.Cantidad - cantidad < 0)
                        {
                            S.actualizarStock(cv.getIDProd(ph.Hijo), cantidad - ph.Cantidad);
                            ph.Cantidad = 0;
                        }
                        else
                        {
                            S.actualizarStock(cv.getIDProd(ph.Hijo), 0);
                            ph.Cantidad -= Convert.ToInt32(cantidad);
                        }
                    }
                //}
            }
        }

        public List<PadreHijo> getListaPadres()
        {
            return listaPadres;
        }
    }
}
