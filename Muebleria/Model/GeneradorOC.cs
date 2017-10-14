using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria.Model
{
    class GeneradorOC
    {
        List<necesidadneta> listaNN = new List<necesidadneta>();
        necesidadneta necesidadNeta = new necesidadneta();
        proveedorproducto proveedorProducto = new proveedorproducto();
        ordencompra ordenCompra = new ordencompra();
        List<ordencompra> ListaordenCompra = new List<ordencompra>();
        public GeneradorOC()
        {
            listaNN = necesidadNeta.getAll();
            realizarPedido();
            generarTXT();
        }
        public void realizarPedido()
        {
            foreach(necesidadneta nn in listaNN)
            {
                string idProducto = nn.idProductoHijo.ToString();
                int cantProveedores = proveedorProducto.getCantProveedores(idProducto);
                if (cantProveedores == 1)    //1 solo proveedor
                {
                    string nombreProveedor = proveedorProducto.getProveedores(nn.idProductoHijo.ToString())[0].nombreProveedor.ToString();
                    ordencompra oc = new ordencompra(this.generarNroOC(), nn.idProductoHijo, nn.Semana, nn.Cant, nombreProveedor);
                    ListaordenCompra.Add(oc);
                }
                else if(cantProveedores == 2)      //2 proveedores
                {
                    List<proveedorproducto> listaPP = new List<proveedorproducto>();
                    listaPP = proveedorProducto.getProveedores(nn.idProductoHijo.ToString());
                    if(nn.Cant <= listaPP[0].capProductiva*0.7)
                    {
                        ordencompra oc = new ordencompra(this.generarNroOC(), nn.idProductoHijo, nn.Semana, nn.Cant, 
                            listaPP[0].nombreProveedor);
                        ListaordenCompra.Add(oc);
                    }
                    else
                    {
                        int capProductiva0 = Convert.ToInt32(listaPP[0].capProductiva * 0.7);
                        int capProductiva1 = Convert.ToInt32(listaPP[1].capProductiva * 0.3);

                        if (nn.Cant <= capProductiva0 + capProductiva1)
                        {
                            ordencompra oc = new ordencompra(this.generarNroOC(), nn.idProductoHijo, nn.Semana, 
                                capProductiva0, listaPP[0].nombreProveedor);
                            ListaordenCompra.Add(oc);

                            int cantidadRestante = nn.Cant - capProductiva0;

                            ordencompra oc2 = new ordencompra(this.generarNroOC(), nn.idProductoHijo, nn.Semana, 
                                cantidadRestante, listaPP[1].nombreProveedor);
                            ListaordenCompra.Add(oc2);
                        }
                        else
                        {
                            int capProductiva02 = Convert.ToInt32(listaPP[0].capProductiva * 0.3);
                            int capProductiva12 = Convert.ToInt32(listaPP[0].capProductiva * 0.7);
                            if(nn.Cant <= capProductiva0 + capProductiva1 + capProductiva02)
                            {
                                int cantidadRestante = nn.Cant - (capProductiva0 + capProductiva1);

                                ordencompra oc = new ordencompra(this.generarNroOC(), nn.idProductoHijo, nn.Semana, 
                                    capProductiva0 + cantidadRestante, listaPP[0].nombreProveedor);
                                ListaordenCompra.Add(oc);

                                ordencompra oc2 = new ordencompra(this.generarNroOC(), nn.idProductoHijo, nn.Semana, 
                                    capProductiva1, listaPP[1].nombreProveedor);
                                ListaordenCompra.Add(oc2);
                            }
                            else
                            {
                                int cantidadRestante = nn.Cant - (capProductiva0 + capProductiva1 + capProductiva02);

                                ordencompra oc = new ordencompra(this.generarNroOC(), nn.idProductoHijo, nn.Semana, 
                                    capProductiva0 + capProductiva02, listaPP[0].nombreProveedor);
                                ListaordenCompra.Add(oc);

                                ordencompra oc2 = new ordencompra(this.generarNroOC(), nn.idProductoHijo, nn.Semana, 
                                    capProductiva1 + cantidadRestante, listaPP[1].nombreProveedor);
                                ListaordenCompra.Add(oc2);
                            }
                        }
                    }
                }
            }
        }

        private string generarNroOC ()
        {
            int i = ListaordenCompra.Count();
            if (i > 0)
            {
                return ListaordenCompra[0].NroOrdenCompra;
            }
            else
                return "OC" + ordenCompra.getNextId().ToString();
        }

        public void generarTXT()
        {
            ordenCompra.insertarOC(ListaordenCompra);

            string path = @"D:\Mati\Facu\4° Año\2° Semestre\Informatica Industrial\Ordenes de Compra\" + ListaordenCompra[0].NroOrdenCompra+".txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(ListaordenCompra[0].NroOrdenCompra + "\n");
                    
                    foreach (ordencompra oc in ListaordenCompra)
                    {
                        sw.WriteLine(oc.idProductoHijo.ToString() + "\t Proveedor: " + oc.Proveedor + 
                            "\t Semana: " + oc.Semana.ToString() + "\t Cantidad: " + oc.Cant.ToString());
                    }
                
                }
            }

        }

    }
}
