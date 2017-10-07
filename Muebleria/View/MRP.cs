﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muebleria
{
    public partial class MRP : Form
    {
        ControllerMRP controller= new ControllerMRP();
        private List<requerimientos> lista = new List<requerimientos>();
        public MRP()
        {
            InitializeComponent();
            Fecha fecha = new Fecha();
            label1.Text = fecha.convertir(DateTime.Now).ToString();
        }

        private void cargarDataGrid(List<requerimientos> lista)
        {
            //dataGridView1.DataSource = lista;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (requerimientos req in lista)
                dataGridView1.Rows.Add(controller.getNombreProducto(req.idProducto), req.Semana, req.Cant, req.Cliente, req.Delta);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            View.CargaVGM carga = new View.CargaVGM(lista);
            carga.ShowDialog();
            controller.formatearLista(lista);
            cargarDataGrid(lista);
        }

        private void MRP_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }
        
        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                controller.cargarRequerimiento(row);
            }
            MessageBox.Show("Reporte Generado con Exito!");
            this.Close();
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }
}
}
