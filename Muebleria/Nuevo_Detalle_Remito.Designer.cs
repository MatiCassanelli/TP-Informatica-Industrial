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
            this.panel1 = new System.Windows.Forms.Panel();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCargarProducto = new System.Windows.Forms.Button();
            this.DataGridDetalles = new System.Windows.Forms.DataGridView();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnFinalizarDetalle = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRemito
            // 
            this.lblRemito.AutoSize = true;
            this.lblRemito.Location = new System.Drawing.Point(224, 9);
            this.lblRemito.Name = "lblRemito";
            this.lblRemito.Size = new System.Drawing.Size(35, 13);
            this.lblRemito.TabIndex = 3;
            this.lblRemito.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Remito:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.maskedTextBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCargarProducto);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 78);
            this.panel1.TabIndex = 8;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(186, 15);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox1.Mask = "*000000000000*";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(85, 20);
            this.maskedTextBox1.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Ingrese Codigo de Barras";
            // 
            // btnCargarProducto
            // 
            this.btnCargarProducto.Location = new System.Drawing.Point(334, 44);
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
            this.Column1,
            this.CProducto,
            this.NProducto});
            this.DataGridDetalles.Location = new System.Drawing.Point(12, 129);
            this.DataGridDetalles.Name = "DataGridDetalles";
            this.DataGridDetalles.ReadOnly = true;
            this.DataGridDetalles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DataGridDetalles.Size = new System.Drawing.Size(324, 162);
            this.DataGridDetalles.TabIndex = 0;
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.Location = new System.Drawing.Point(346, 268);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarProducto.TabIndex = 9;
            this.btnEliminarProducto.Text = "Eliminar";
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnFinalizarDetalle
            // 
            this.btnFinalizarDetalle.Location = new System.Drawing.Point(346, 308);
            this.btnFinalizarDetalle.Name = "btnFinalizarDetalle";
            this.btnFinalizarDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizarDetalle.TabIndex = 10;
            this.btnFinalizarDetalle.Text = "Finalizar";
            this.btnFinalizarDetalle.UseVisualStyleBackColor = true;
            this.btnFinalizarDetalle.Click += new System.EventHandler(this.btnFinalizarDetalle_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "NroSerie";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
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
            // Nuevo_Detalle_Remito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 342);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCargarProducto;
        private System.Windows.Forms.DataGridView DataGridDetalles;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnFinalizarDetalle;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NProducto;
    }
}