﻿namespace Muebleria
{
    partial class Composicion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCargarSustituto = new System.Windows.Forms.Button();
            this.cbProductosSustitutos = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblProdSeleccionado = new System.Windows.Forms.Label();
            this.btnEliminar_Sustituto = new System.Windows.Forms.Button();
            this.lbSustitutos = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.lbCargadas = new System.Windows.Forms.ListBox();
            this.panelComponentes = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbComponentes = new System.Windows.Forms.ComboBox();
            this.panelCantidades = new System.Windows.Forms.Panel();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUM = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFechaAplicacion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbProductos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelComponentes.SuspendLayout();
            this.panelCantidades.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 665);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.monthCalendar1);
            this.groupBox4.Controls.Add(this.btnPublicar);
            this.groupBox4.Location = new System.Drawing.Point(133, 450);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(579, 207);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Seleccione la fecha de publicación:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.monthCalendar1.Location = new System.Drawing.Point(188, 35);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // btnPublicar
            // 
            this.btnPublicar.Location = new System.Drawing.Point(461, 174);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(112, 23);
            this.btnPublicar.TabIndex = 22;
            this.btnPublicar.Text = "Publicar";
            this.btnPublicar.UseVisualStyleBackColor = true;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCargarSustituto);
            this.groupBox3.Controls.Add(this.cbProductosSustitutos);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblProdSeleccionado);
            this.groupBox3.Controls.Add(this.btnEliminar_Sustituto);
            this.groupBox3.Controls.Add(this.lbSustitutos);
            this.groupBox3.Location = new System.Drawing.Point(8, 255);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(834, 189);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sustitutos";
            // 
            // btnCargarSustituto
            // 
            this.btnCargarSustituto.Location = new System.Drawing.Point(303, 107);
            this.btnCargarSustituto.Name = "btnCargarSustituto";
            this.btnCargarSustituto.Size = new System.Drawing.Size(93, 23);
            this.btnCargarSustituto.TabIndex = 25;
            this.btnCargarSustituto.Text = "Cargar Sustituto";
            this.btnCargarSustituto.UseVisualStyleBackColor = true;
            this.btnCargarSustituto.Click += new System.EventHandler(this.btnCargarSustituto_Click);
            // 
            // cbProductosSustitutos
            // 
            this.cbProductosSustitutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductosSustitutos.FormattingEnabled = true;
            this.cbProductosSustitutos.Location = new System.Drawing.Point(188, 68);
            this.cbProductosSustitutos.Name = "cbProductosSustitutos";
            this.cbProductosSustitutos.Size = new System.Drawing.Size(208, 21);
            this.cbProductosSustitutos.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Seleccione un producto sustituto:";
            // 
            // lblProdSeleccionado
            // 
            this.lblProdSeleccionado.AutoSize = true;
            this.lblProdSeleccionado.Location = new System.Drawing.Point(15, 37);
            this.lblProdSeleccionado.Name = "lblProdSeleccionado";
            this.lblProdSeleccionado.Size = new System.Drawing.Size(35, 13);
            this.lblProdSeleccionado.TabIndex = 6;
            this.lblProdSeleccionado.Text = "label8";
            this.lblProdSeleccionado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnEliminar_Sustituto
            // 
            this.btnEliminar_Sustituto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar_Sustituto.Location = new System.Drawing.Point(716, 160);
            this.btnEliminar_Sustituto.Name = "btnEliminar_Sustituto";
            this.btnEliminar_Sustituto.Size = new System.Drawing.Size(112, 23);
            this.btnEliminar_Sustituto.TabIndex = 4;
            this.btnEliminar_Sustituto.Text = "Eliminar";
            this.btnEliminar_Sustituto.UseVisualStyleBackColor = true;
            this.btnEliminar_Sustituto.Click += new System.EventHandler(this.btnEliminar_Sustituto_Click);
            // 
            // lbSustitutos
            // 
            this.lbSustitutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbSustitutos.FormattingEnabled = true;
            this.lbSustitutos.Location = new System.Drawing.Point(431, 19);
            this.lbSustitutos.Name = "lbSustitutos";
            this.lbSustitutos.Size = new System.Drawing.Size(397, 130);
            this.lbSustitutos.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Eliminar);
            this.groupBox2.Controls.Add(this.lbCargadas);
            this.groupBox2.Controls.Add(this.panelComponentes);
            this.groupBox2.Location = new System.Drawing.Point(8, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(834, 176);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Componentes";
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Eliminar.Location = new System.Drawing.Point(716, 147);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(112, 23);
            this.btn_Eliminar.TabIndex = 4;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // lbCargadas
            // 
            this.lbCargadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCargadas.FormattingEnabled = true;
            this.lbCargadas.Location = new System.Drawing.Point(431, 19);
            this.lbCargadas.Name = "lbCargadas";
            this.lbCargadas.Size = new System.Drawing.Size(397, 117);
            this.lbCargadas.TabIndex = 0;
            this.lbCargadas.SelectedIndexChanged += new System.EventHandler(this.lbCargadas_SelectedIndexChanged);
            // 
            // panelComponentes
            // 
            this.panelComponentes.Controls.Add(this.label4);
            this.panelComponentes.Controls.Add(this.cbComponentes);
            this.panelComponentes.Controls.Add(this.panelCantidades);
            this.panelComponentes.Enabled = false;
            this.panelComponentes.Location = new System.Drawing.Point(6, 13);
            this.panelComponentes.Name = "panelComponentes";
            this.panelComponentes.Size = new System.Drawing.Size(409, 143);
            this.panelComponentes.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Componentes";
            // 
            // cbComponentes
            // 
            this.cbComponentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComponentes.FormattingEnabled = true;
            this.cbComponentes.Location = new System.Drawing.Point(86, 6);
            this.cbComponentes.Name = "cbComponentes";
            this.cbComponentes.Size = new System.Drawing.Size(304, 21);
            this.cbComponentes.TabIndex = 14;
            this.cbComponentes.SelectedIndexChanged += new System.EventHandler(this.cbComponentes_SelectedIndexChanged);
            // 
            // panelCantidades
            // 
            this.panelCantidades.Controls.Add(this.tbCantidad);
            this.panelCantidades.Controls.Add(this.btnCargar);
            this.panelCantidades.Controls.Add(this.label2);
            this.panelCantidades.Controls.Add(this.label1);
            this.panelCantidades.Controls.Add(this.cbUM);
            this.panelCantidades.Enabled = false;
            this.panelCantidades.Location = new System.Drawing.Point(5, 41);
            this.panelCantidades.Name = "panelCantidades";
            this.panelCantidades.Size = new System.Drawing.Size(395, 91);
            this.panelCantidades.TabIndex = 21;
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(60, 14);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(85, 20);
            this.tbCantidad.TabIndex = 23;
            this.tbCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantidad_KeyPress_1);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(292, 59);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(93, 23);
            this.btnCargar.TabIndex = 20;
            this.btnCargar.Text = "Cargar Producto";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Unidad de Medida";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Cantidad";
            // 
            // cbUM
            // 
            this.cbUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUM.FormattingEnabled = true;
            this.cbUM.Location = new System.Drawing.Point(251, 13);
            this.cbUM.Name = "cbUM";
            this.cbUM.Size = new System.Drawing.Size(134, 21);
            this.cbUM.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFechaAplicacion);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbProductos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(819, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblFechaAplicacion
            // 
            this.lblFechaAplicacion.AutoSize = true;
            this.lblFechaAplicacion.Location = new System.Drawing.Point(544, 22);
            this.lblFechaAplicacion.Name = "lblFechaAplicacion";
            this.lblFechaAplicacion.Size = new System.Drawing.Size(35, 13);
            this.lblFechaAplicacion.TabIndex = 25;
            this.lblFechaAplicacion.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(428, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Semana de Aplicación: ";
            // 
            // cbProductos
            // 
            this.cbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductos.FormattingEnabled = true;
            this.cbProductos.Location = new System.Drawing.Point(86, 19);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(304, 21);
            this.cbProductos.TabIndex = 0;
            this.cbProductos.Tag = "";
            this.cbProductos.SelectedIndexChanged += new System.EventHandler(this.cbProductos_SelectedIndexChanged);
            this.cbProductos.Click += new System.EventHandler(this.cbProductos_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Productos";
            // 
            // Composicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 685);
            this.Controls.Add(this.panel1);
            this.Name = "Composicion";
            this.Text = "Composición de los Productos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Composicion_FormClosed);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelComponentes.ResumeLayout(false);
            this.panelComponentes.PerformLayout();
            this.panelCantidades.ResumeLayout(false);
            this.panelCantidades.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbProductos;
        private System.Windows.Forms.Panel panelComponentes;
        private System.Windows.Forms.ComboBox cbComponentes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbCargadas;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Panel panelCantidades;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEliminar_Sustituto;
        private System.Windows.Forms.ListBox lbSustitutos;
        private System.Windows.Forms.ComboBox cbProductosSustitutos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblProdSeleccionado;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCargarSustituto;
        private System.Windows.Forms.Label lblFechaAplicacion;
        private System.Windows.Forms.Label label7;
    }
}

