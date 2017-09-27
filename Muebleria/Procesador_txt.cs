using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria
{
    class Procesador_txt
    {
        private string vectorTxt;
        private string vectorEncabezado;
        private string vectorCuerpo;
        private string vectorPie;
        private bool txtCorrecto;

        private List<int> proveedor = new List<int>() { 3, 6 };
        private List<int> fecha_arribo = new List<int>() { 16, 8 };
        private List<int> numero_archivo = new List<int>() { 24, 10 };

        private List<int> producto = new List<int>() { 16, 16 };
        private List<int> cantidad = new List<int>() { 32, 10 };
        private List<int> numero_archivo_cuerpo = new List<int>() { 0, 10 };


        private List<int> numero_filas = new List<int>() { 10, 3 };

        public Procesador_txt(string path)
        {
            //Cargar vectores con txt
            vectorTxt = System.IO.File.ReadAllText(path);
            vectorTxt = vectorTxt.Replace("\r\n", string.Empty);
            vectorEncabezado = vectorTxt.Substring(0, 49);
            vectorCuerpo = vectorTxt.Substring(49, vectorTxt.Count()-99);
            vectorPie = vectorTxt.Substring(vectorTxt.Count() - 50, 50);
            ComprobarCompletitud();
        }

        private void ComprobarCompletitud()
        {
            if (vectorCuerpo.Count() % 51 != 0)
                txtCorrecto = false;
            else
            {
                if (vectorTxt.Count() == 49 + vectorCuerpo.Count() + 50)        //FALTA PONER COMPROBACION DE NUMERO DE FILAS
                    if (getNumero_filas() == vectorCuerpo.Count() / 51)
                        txtCorrecto = true;
                    else
                        txtCorrecto = false;
                else
                    txtCorrecto = false;
            }
        }

        private int DevolverEncabezado(List<int> Atributo)
        {
            return int.Parse(vectorEncabezado.Substring(Atributo[0], Atributo[1]));
        }
        private int DevolverCuerpo(List<int> Atributo, int i)
        {
            return int.Parse(vectorCuerpo.Substring(Atributo[0] + 51 * i, Atributo[1]));
        }
        private int DevolverProducto(List<int> Atributo, int i)
        {
            string producto = vectorCuerpo.Substring(Atributo[0] + 51 * i, Atributo[1]);
            int recorte1 = int.Parse(producto.Substring(0, 8));
            int recorte2 = int.Parse(producto.Substring(8, 8));

            if (recorte1 != 0)
                return 0;
            else
                return recorte2;
            
        }

        private int DevolverPie(List<int> Atributo)
        {
            return int.Parse(vectorPie.Substring(Atributo[0], Atributo[1]));
        }

        public int getProveedor()
        {
            return DevolverEncabezado(proveedor);
        }
        public string getFecha_arribo()
        {
            string parche = DevolverEncabezado(fecha_arribo).ToString();
            parche = parche.Insert(4, "/");
            parche = parche.Insert(7, "/");

            return parche;
        }

        public int getNumero_archivo()
        {
            return DevolverEncabezado(numero_archivo);
        }

        public int getProducto(int i)
        {
            return DevolverProducto(producto,i);
        }

        public int getCantidad(int i)
        {
            return DevolverCuerpo(cantidad,i);
        }

        public int getNumeroArchivoCuerpo(int i)
        {
            return DevolverCuerpo(numero_archivo_cuerpo, i);
        }

        public int getNumero_filas()
        {
            return DevolverPie(numero_filas);
        }

        public bool getTxtCorrecto()
        {
            return txtCorrecto;
        }
    }
}
