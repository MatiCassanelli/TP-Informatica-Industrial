﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class ControllerNecesidades
    {
        ExplosionClass explosion = new ExplosionClass();
        ConsultasVarias cv = new ConsultasVarias();
        List<PadreHijo> listaExplosionada = new List<PadreHijo>();
        List<PadreHijo> listaPadres = new List<PadreHijo>();
        List<necesidadbruta> listaNB = new List<necesidadbruta>();
        List<necesidadbruta> listaNN = new List<necesidadbruta>();
        List<necesidadneta> necesidadesNetas = new List<necesidadneta>();

        private void generarNB()
        {
            pmp PMP = new pmp();
            List<pmp> listaPMP = PMP.getPMP();

            foreach (pmp item in listaPMP) 
                explosion.Explotar(item.idProductoPadre, item.idProductoPadre, item.Semana, item.Cant);
        }

        private List<PadreHijo> getProdExplotados()
        {
            generarNB();
            listaExplosionada = explosion.getListaExplosionada();
            return listaExplosionada;
        }
        
        public void cargarNecesidadBruta()
        {
            List<PadreHijo> lista = getProdExplotados();
            foreach (PadreHijo item in lista)
            {
                necesidadbruta nb = new necesidadbruta();
                nb = new necesidadbruta(cv.getIDProd(item.Hijo), item.Semana, (item.Cantidad - nb.getDiferenciaCantidad(cv.getIDProd(item.Hijo),item.Semana)));

                listaNB.Add(nb);
                if (!item.esPadre(item.Hijo))
                    nb.cargarNecesidadBruta();
                else
                {
                    necesidadneta nn = new necesidadneta();
                    item.Cantidad -= nn.getDiferenciaCantidad(cv.getIDProd(item.Hijo), item.Semana);    //con los valores q siempre cargo, da 18 xq hace 30-12. No deberia hacer 30-12, sino q deberia hacer 27-12 para q de lo q tiene q dar. o sino, 5 de la semana q viene - 3 q ya produje
                    listaPadres.Add(item);                                                              //tiene en cuenta las 5 mesa tubulares producidas, pero no las 3 tp q ya produje. siempre me termina haciendo 40 del req total - 5 mt hechas. 
                }
            }
        }
        public void generarNN()
        {
            NBmenosStock();
            foreach (necesidadbruta nn in listaNN)
            {
                necesidadneta NN = new necesidadneta(nn.idProductoHijo, nn.Semana, nn.Cant);
                necesidadesNetas.Add(NN);
                NN.InsertOrUpdateNecesidadNeta();
            }
        }

        private void restarStockPadres()
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

        private List<PadreHijo> explotarParaNN()
        {
            restarStockPadres();
            ExplosionClass exp = new ExplosionClass();
            //List<PadreHijo> asd = new List<PadreHijo>();
            foreach (PadreHijo ph in listaPadres)//listaExplosionada)
                exp.Explotar(cv.getIDProd(ph.Hijo), cv.getIDProd(ph.Hijo), ph.Semana, ph.Cantidad);

            return exp.getListaExplosionada();
        }
        
        private void limpiarLista()
        {
            foreach(PadreHijo ph in explotarParaNN())
            {
                for (int i = 0; i < listaExplosionada.Count; i++)
                {
                    if (ph.Padre == listaExplosionada[i].Padre && ph.Hijo == listaExplosionada[i].Hijo && ph.Semana == listaExplosionada[i].Semana)
                        listaExplosionada[i].Cantidad = ph.Cantidad;
                }
            }
        }

        private void NBmenosStock()
        {
            stock S = new stock();
            float cantidad;
            limpiarLista();
            List<PadreHijo> asd = listaExplosionada;
            foreach (PadreHijo ph in asd)
            {
                listaNN.Add(new necesidadbruta(cv.getIDProd(ph.Hijo), ph.Semana, ph.Cantidad));
            }
            
            foreach (necesidadbruta nb in listaNN)
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



        public List<necesidadneta> getNecesidadesNetas()
        {
            return necesidadesNetas;
        }
    }
}
