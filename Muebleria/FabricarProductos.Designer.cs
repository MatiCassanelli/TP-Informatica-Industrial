namespace Muebleria
{
    partial class FabricarProductos
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
            this.cbProductos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelCantidades = new System.Windows.Forms.Panel();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbUM = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbUbicacionOrigen = new System.Windows.Forms.ComboBox();
            this.cbAlmacenOrigen = new System.Windows.Forms.ComboBox();
            this.cbSucursalOrigen = new System.Windows.Forms.ComboBox();
            this.panelCantidades.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbProductos
            // 
            this.cbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductos.FormattingEnabled = true;
            this.cbProductos.Location = new System.Drawing.Point(273, 49);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(747, 39);
            this.cbProductos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Producto a Fabricar";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(594, 465);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(248, 55);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(239, 465);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(248, 55);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panelCantidades
            // 
            this.panelCantidades.Controls.Add(this.tbCantidad);
            this.panelCantidades.Controls.Add(this.label3);
            this.panelCantidades.Controls.Add(this.label4);
            this.panelCantidades.Controls.Add(this.cbUM);
            this.panelCantidades.Location = new System.Drawing.Point(18, 160);
            this.panelCantidades.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panelCantidades.Name = "panelCantidades";
            this.panelCantidades.Size = new System.Drawing.Size(1040, 110);
            this.panelCantidades.TabIndex = 24;
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(160, 33);
            this.tbCantidad.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(220, 38);
            this.tbCantidad.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 32);
            this.label3.TabIndex = 22;
            this.label3.Text = "Unidad de Medida";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 32);
            this.label4.TabIndex = 21;
            this.label4.Text = "Cantidad";
            // 
            // cbUM
            // 
            this.cbUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUM.FormattingEnabled = true;
            this.cbUM.Location = new System.Drawing.Point(670, 31);
            this.cbUM.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cbUM.Name = "cbUM";
            this.cbUM.Size = new System.Drawing.Size(350, 39);
            this.cbUM.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbProductos);
            this.groupBox1.Location = new System.Drawing.Point(18, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Size = new System.Drawing.Size(1040, 128);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbUbicacionOrigen);
            this.groupBox3.Controls.Add(this.cbAlmacenOrigen);
            this.groupBox3.Controls.Add(this.cbSucursalOrigen);
            this.groupBox3.Location = new System.Drawing.Point(18, 279);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(803, 148);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ubicacion Almacenado";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // cbUbicacionOrigen
            // 
            this.cbUbicacionOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUbicacionOrigen.FormattingEnabled = true;
            this.cbUbicacionOrigen.Location = new System.Drawing.Point(552, 55);
            this.cbUbicacionOrigen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbUbicacionOrigen.Name = "cbUbicacionOrigen";
            this.cbUbicacionOrigen.Size = new System.Drawing.Size(228, 39);
            this.cbUbicacionOrigen.TabIndex = 4;
            // 
            // cbAlmacenOrigen
            // 
            this.cbAlmacenOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlmacenOrigen.FormattingEnabled = true;
            this.cbAlmacenOrigen.Location = new System.Drawing.Point(277, 55);
            this.cbAlmacenOrigen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAlmacenOrigen.Name = "cbAlmacenOrigen";
            this.cbAlmacenOrigen.Size = new System.Drawing.Size(228, 39);
            this.cbAlmacenOrigen.TabIndex = 3;
            this.cbAlmacenOrigen.SelectedIndexChanged += new System.EventHandler(this.cbAlmacenOrigen_SelectedIndexChanged);
            // 
            // cbSucursalOrigen
            // 
            this.cbSucursalOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSucursalOrigen.FormattingEnabled = true;
            this.cbSucursalOrigen.Location = new System.Drawing.Point(16, 55);
            this.cbSucursalOrigen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSucursalOrigen.Name = "cbSucursalOrigen";
            this.cbSucursalOrigen.Size = new System.Drawing.Size(228, 39);
            this.cbSucursalOrigen.TabIndex = 2;
            this.cbSucursalOrigen.SelectedIndexChanged += new System.EventHandler(this.cbSucursalOrigen_SelectedIndexChanged_1);
            // 
            // FabricarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 590);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panelCantidades);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAceptar);
            this.Name = "FabricarProductos";
            this.Text = "FabricarProductos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FabricarProductos_FormClosed);
            this.Load += new System.EventHandler(this.FabricarProductos_Load);
            this.panelCantidades.ResumeLayout(false);
            this.panelCantidades.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelCantidades;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbUM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbUbicacionOrigen;
        private System.Windows.Forms.ComboBox cbAlmacenOrigen;
        private System.Windows.Forms.ComboBox cbSucursalOrigen;
    }
}