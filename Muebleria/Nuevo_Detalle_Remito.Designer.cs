namespace Muebleria
{
    partial class Nuevo_Detalle_Remito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRemito = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.cbProductosFinales = new System.Windows.Forms.ComboBox();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCargarProducto = new System.Windows.Forms.Button();
            this.DataGridDetalles = new System.Windows.Forms.DataGridView();
            this.CProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnFinalizarDetalle = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRemito
            // 
            this.lblRemito.AutoSize = true;
            this.lblRemito.Location = new System.Drawing.Point(270, 20);
            this.lblRemito.Name = "lblRemito";
            this.lblRemito.Size = new System.Drawing.Size(35, 13);
            this.lblRemito.TabIndex = 3;
            this.lblRemito.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Remito:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Producto";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(37, 74);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(49, 13);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Cantidad";
            // 
            // cbProductosFinales
            // 
            this.cbProductosFinales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductosFinales.FormattingEnabled = true;
            this.cbProductosFinales.Location = new System.Drawing.Point(122, 23);
            this.cbProductosFinales.Name = "cbProductosFinales";
            this.cbProductosFinales.Size = new System.Drawing.Size(254, 21);
            this.cbProductosFinales.TabIndex = 6;
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(122, 71);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(254, 20);
            this.tbCantidad.TabIndex = 7;
            this.tbCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantidad_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCargarProducto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbCantidad);
            this.panel1.Controls.Add(this.Label3);
            this.panel1.Controls.Add(this.cbProductosFinales);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 125);
            this.panel1.TabIndex = 8;
            // 
            // btnCargarProducto
            // 
            this.btnCargarProducto.Location = new System.Drawing.Point(417, 99);
            this.btnCargarProducto.Name = "btnCargarProducto";
            this.btnCargarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnCargarProducto.TabIndex = 8;
            this.btnCargarProducto.Text = "Cargar";
            this.btnCargarProducto.UseVisualStyleBackColor = true;
            this.btnCargarProducto.Click += new System.EventHandler(this.btnCargarProducto_Click);
            // 
            // DataGridDetalles
            // 
            this.DataGridDetalles.AllowUserToAddRows = false;
            this.DataGridDetalles.AllowUserToDeleteRows = false;
            this.DataGridDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CProducto,
            this.NProducto,
            this.Cant});
            this.DataGridDetalles.Location = new System.Drawing.Point(12, 176);
            this.DataGridDetalles.Name = "DataGridDetalles";
            this.DataGridDetalles.ReadOnly = true;
            this.DataGridDetalles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DataGridDetalles.Size = new System.Drawing.Size(396, 162);
            this.DataGridDetalles.TabIndex = 0;
            // 
            // CProducto
            // 
            this.CProducto.HeaderText = "Código";
            this.CProducto.Name = "CProducto";
            this.CProducto.ReadOnly = true;
            // 
            // NProducto
            // 
            this.NProducto.HeaderText = "Producto";
            this.NProducto.Name = "NProducto";
            this.NProducto.ReadOnly = true;
            // 
            // Cant
            // 
            this.Cant.HeaderText = "Cantidad";
            this.Cant.Name = "Cant";
            this.Cant.ReadOnly = true;
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.Location = new System.Drawing.Point(429, 315);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarProducto.TabIndex = 9;
            this.btnEliminarProducto.Text = "Eliminar";
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnFinalizarDetalle
            // 
            this.btnFinalizarDetalle.Location = new System.Drawing.Point(429, 361);
            this.btnFinalizarDetalle.Name = "btnFinalizarDetalle";
            this.btnFinalizarDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizarDetalle.TabIndex = 10;
            this.btnFinalizarDetalle.Text = "Finalizar";
            this.btnFinalizarDetalle.UseVisualStyleBackColor = true;
            this.btnFinalizarDetalle.Click += new System.EventHandler(this.btnFinalizarDetalle_Click);
            // 
            // Nuevo_Detalle_Remito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 398);
            this.Controls.Add(this.btnFinalizarDetalle);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.DataGridDetalles);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblRemito);
            this.Controls.Add(this.label1);
            this.Name = "Nuevo_Detalle_Remito";
            this.Text = "Nuevo_Detalle_Remito";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Nuevo_Detalle_Remito_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRemito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.ComboBox cbProductosFinales;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCargarProducto;
        private System.Windows.Forms.DataGridView DataGridDetalles;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnFinalizarDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cant;
    }
}