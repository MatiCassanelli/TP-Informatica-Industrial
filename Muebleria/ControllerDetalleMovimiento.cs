using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class ControllerDetalleMovimiento
    {
        CargarCombos cc = new CargarCombos();
        ConsultasDetalleMovimiento cdm = new ConsultasDetalleMovimiento();
        public List<string> CargarProductos()
        {
            return cc.CargarProductos();
        }

        public List<string> CargarProductos(int indice)
        {
            return cc.CargarProductos(indice);
        }

        public List<string> CargarProductos(double sn)
        {
            return cc.CargarProductos(sn);
        }

        public List<string> CargarUM()
        {
            return cc.CargarUM();
        }

        public List<string> CargarRazon()
        {
            return cc.CargarRazon();
        }

        public List<string> CargarSucursal(int ?id=null)
        {
            return cc.CargarSucursal(id);
        }

        public List<string> CargarAlmacen(int suc, int? id=null)
        {
            return cc.CargarAlmacen(suc, id);
        }

        public List<string> CargarAlmacen(string suc)
        {
            return cc.CargarAlmacen(Convert.ToInt32(cdm.getIDSucursal(suc)),null);
        }

        public List<string> CargarUbicacion(int alm, int ?id=null)
        {
            return cc.CargarUbicacion(alm, id);
        }

        public List<string> CargarUbicacion(string alm)
        {
            return cc.CargarUbicacion(cdm.getIDAlmacen(alm),null);
        }

        //venta de un articulo determinado a un cliente
        public void crearMovimiento(string razon, string prod, string sucorigen, string sucdestino,
            string almorigen = null, string almdestino = null, int? uborigen = null, int? ubdestino=null, double? sn=null, int cant=1, string unidadmedida=null)
        {
            Nullable<int> ubicacionOrigen=null, ubicacionDestino = null, almacenOrigen = null, almacenDestino = null, um = null;

            if (almorigen != null)
                almacenOrigen = cdm.getIDAlmacen(almorigen);
            if (almdestino != null)
                almacenDestino = cdm.getIDAlmacen(almdestino);
            if (uborigen != null)
                ubicacionOrigen = cdm.getIDUbicacion(uborigen);
            if (ubdestino != null)
                ubicacionDestino = cdm.getIDUbicacion(ubdestino);
            if (unidadmedida != null)
                um = cdm.getIDUnidadMedidad(unidadmedida);
            

            movimiento mov = new movimiento()
            {
                idRazon = cdm.getIDRazon(razon),
                idArticulo = sn,
                idProducto = cdm.getIDProd(prod),
                cantidad = cant,
                u_medida = um,
                S_origen = cdm.getIDSucursal(sucorigen),
                S_destino = cdm.getIDSucursal(sucdestino),
                A_origen = almacenOrigen,
                A_destino = almacenDestino,
                U_origen = ubicacionOrigen,
                U_destino = ubicacionDestino,
                fechaMovimiento=DateTime.Now             
            };
            cdm.InsertarMovimiento(mov);
            cdm.actualizarStock(mov);
            if (sn != null)
                cdm.actualizarArticulo(mov);
        }

        public razon getRazonCompleta(string razon)
        {
            return cdm.getRazonCompleta(cdm.getIDRazon(razon));

        }
        
        public string crearMovimientoTXT(string path)
        {
            Procesador_txt procesadorTxt = new Procesador_txt(path);
            ConsultasDetalleMovimiento consulta = new ConsultasDetalleMovimiento();
            string EstadoFinalizacion = "";

            if(procesadorTxt.getTxtCorrecto() == true)
            {
                if (consulta.existeIdHistorial(procesadorTxt.getNumero_archivo()) == false)
                {
                    for (int i = 0; i < procesadorTxt.getNumero_filas(); i++)
                    {
                        if (consulta.existeIdProducto(procesadorTxt.getProducto(i)) == true &&
                            consulta.existeSucursal(procesadorTxt.getProveedor()) == true)
                        {
                            //CREAR MOVIMIENTO Y AGREGARLOS A LA BD
                            movimiento mov = new movimiento()
                            {
                                idProducto = procesadorTxt.getProducto(i),
                                cantidad = procesadorTxt.getCantidad(i),
                                S_origen = procesadorTxt.getProveedor(),
                                S_destino = 1,
                                fechaMovimiento = DateTime.Parse(procesadorTxt.getFecha_arribo().ToString()),
                                idRazon = 3
                            };
                            //ACTUALIZACION DE STOCK


                        }
                    }


                    consulta.insertIdHistorial(procesadorTxt.getNumero_archivo());
                    EstadoFinalizacion = "La operacion se realizó correctamente!";
                }
                else
                    EstadoFinalizacion = "El archivo txt ya ha sido cargado";
            }
            else
                EstadoFinalizacion = "El archivo txt está corrupto";
            return EstadoFinalizacion;
        }
    }
}
