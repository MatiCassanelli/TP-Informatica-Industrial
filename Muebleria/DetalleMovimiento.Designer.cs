namespace Muebleria
{
    partial class DetalleMovimiento
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbRazon = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbUbicacionDestino = new System.Windows.Forms.ComboBox();
            this.cbAlmacenDestino = new System.Windows.Forms.ComboBox();
            this.cbSucursalDestino = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCargarDesdeTxt = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbUbicacionOrigen = new System.Windows.Forms.ComboBox();
            this.cbAlmacenOrigen = new System.Windows.Forms.ComboBox();
            this.cbSucursalOrigen = new System.Windows.Forms.ComboBox();
            this.panelSN = new System.Windows.Forms.Panel();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbProductos = new System.Windows.Forms.GroupBox();
            this.panelCantidades = new System.Windows.Forms.Panel();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbUM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProductos = new System.Windows.Forms.ComboBox();
            this.panelOculto = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelSN.SuspendLayout();
            this.gbProductos.SuspendLayout();
            this.panelCantidades.SuspendLayout();
            this.panelOculto.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbRazon);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(29, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 100);
            this.panel1.TabIndex = 25;
            // 
            // cbRazon
            // 
            this.cbRazon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRazon.FormattingEnabled = true;
            this.cbRazon.Location = new System.Drawing.Point(106, 31);
            this.cbRazon.Name = "cbRazon";
            this.cbRazon.Size = new System.Drawing.Size(248, 39);
            this.cbRazon.TabIndex = 27;
            this.cbRazon.SelectedIndexChanged += new System.EventHandler(this.cbRazon_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1250, 510);
            this.panel3.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 32);
            this.label2.TabIndex = 26;
            this.label2.Text = "Razón";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbUbicacionDestino);
            this.groupBox4.Controls.Add(this.cbAlmacenDestino);
            this.groupBox4.Controls.Add(this.cbSucursalDestino);
            this.groupBox4.Location = new System.Drawing.Point(12, 446);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(803, 148);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ubicacion Destino";
            // 
            // cbUbicacionDestino
            // 
            this.cbUbicacionDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUbicacionDestino.FormattingEnabled = true;
            this.cbUbicacionDestino.Location = new System.Drawing.Point(552, 55);
            this.cbUbicacionDestino.Name = "cbUbicacionDestino";
            this.cbUbicacionDestino.Size = new System.Drawing.Size(229, 39);
            this.cbUbicacionDestino.TabIndex = 4;
            // 
            // cbAlmacenDestino
            // 
            this.cbAlmacenDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlmacenDestino.FormattingEnabled = true;
            this.cbAlmacenDestino.Location = new System.Drawing.Point(278, 55);
            this.cbAlmacenDestino.Name = "cbAlmacenDestino";
            this.cbAlmacenDestino.Size = new System.Drawing.Size(229, 39);
            this.cbAlmacenDestino.TabIndex = 3;
            this.cbAlmacenDestino.SelectedIndexChanged += new System.EventHandler(this.cbAlmacenDestino_SelectedIndexChanged);
            // 
            // cbSucursalDestino
            // 
            this.cbSucursalDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSucursalDestino.FormattingEnabled = true;
            this.cbSucursalDestino.Location = new System.Drawing.Point(16, 55);
            this.cbSucursalDestino.Name = "cbSucursalDestino";
            this.cbSucursalDestino.Size = new System.Drawing.Size(229, 39);
            this.cbSucursalDestino.TabIndex = 2;
            this.cbSucursalDestino.SelectedIndexChanged += new System.EventHandler(this.cbSucursalDestino_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnAceptar);
            this.groupBox2.Controls.Add(this.btnCargarDesdeTxt);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1461, 364);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1202, 237);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(248, 55);
            this.btnCancelar.TabIndex = 39;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(938, 237);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(248, 55);
            this.btnAceptar.TabIndex = 38;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCargarDesdeTxt
            // 
            this.btnCargarDesdeTxt.Location = new System.Drawing.Point(938, 143);
            this.btnCargarDesdeTxt.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCargarDesdeTxt.Name = "btnCargarDesdeTxt";
            this.btnCargarDesdeTxt.Size = new System.Drawing.Size(512, 55);
            this.btnCargarDesdeTxt.TabIndex = 37;
            this.btnCargarDesdeTxt.Text = "Cargar desde TXT";
            this.btnCargarDesdeTxt.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbUbicacionOrigen);
            this.groupBox3.Controls.Add(this.cbAlmacenOrigen);
            this.groupBox3.Controls.Add(this.cbSucursalOrigen);
            this.groupBox3.Location = new System.Drawing.Point(0, 37);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(803, 148);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ubicacion Origen";
            // 
            // cbUbicacionOrigen
            // 
            this.cbUbicacionOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUbicacionOrigen.FormattingEnabled = true;
            this.cbUbicacionOrigen.Location = new System.Drawing.Point(552, 55);
            this.cbUbicacionOrigen.Name = "cbUbicacionOrigen";
            this.cbUbicacionOrigen.Size = new System.Drawing.Size(229, 39);
            this.cbUbicacionOrigen.TabIndex = 4;
            // 
            // cbAlmacenOrigen
            // 
            this.cbAlmacenOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlmacenOrigen.FormattingEnabled = true;
            this.cbAlmacenOrigen.Location = new System.Drawing.Point(278, 55);
            this.cbAlmacenOrigen.Name = "cbAlmacenOrigen";
            this.cbAlmacenOrigen.Size = new System.Drawing.Size(229, 39);
            this.cbAlmacenOrigen.TabIndex = 3;
            this.cbAlmacenOrigen.SelectedIndexChanged += new System.EventHandler(this.cbAlmacenOrigen_SelectedIndexChanged);
            // 
            // cbSucursalOrigen
            // 
            this.cbSucursalOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSucursalOrigen.FormattingEnabled = true;
            this.cbSucursalOrigen.Location = new System.Drawing.Point(16, 55);
            this.cbSucursalOrigen.Name = "cbSucursalOrigen";
            this.cbSucursalOrigen.Size = new System.Drawing.Size(229, 39);
            this.cbSucursalOrigen.TabIndex = 2;
            this.cbSucursalOrigen.SelectedIndexChanged += new System.EventHandler(this.cbSucursalOrigen_SelectedIndexChanged);
            // 
            // panelSN
            // 
            this.panelSN.Controls.Add(this.maskedTextBox1);
            this.panelSN.Controls.Add(this.label5);
            this.panelSN.Location = new System.Drawing.Point(19, 29);
            this.panelSN.Name = "panelSN";
            this.panelSN.Size = new System.Drawing.Size(509, 100);
            this.panelSN.TabIndex = 34;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(261, 30);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBox1.Mask = "*000000000000*";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(220, 38);
            this.maskedTextBox1.TabIndex = 29;
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 32);
            this.label5.TabIndex = 28;
            this.label5.Text = "Codigo de Barras";
            // 
            // gbProductos
            // 
            this.gbProductos.Controls.Add(this.panelCantidades);
            this.gbProductos.Controls.Add(this.label1);
            this.gbProductos.Controls.Add(this.cbProductos);
            this.gbProductos.Location = new System.Drawing.Point(17, 117);
            this.gbProductos.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbProductos.Name = "gbProductos";
            this.gbProductos.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbProductos.Size = new System.Drawing.Size(1456, 128);
            this.gbProductos.TabIndex = 33;
            this.gbProductos.TabStop = false;
            // 
            // panelCantidades
            // 
            this.panelCantidades.Controls.Add(this.tbCantidad);
            this.panelCantidades.Controls.Add(this.label3);
            this.panelCantidades.Controls.Add(this.label4);
            this.panelCantidades.Controls.Add(this.cbUM);
            this.panelCantidades.Location = new System.Drawing.Point(547, 4);
            this.panelCantidades.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panelCantidades.Name = "panelCantidades";
            this.panelCantidades.Size = new System.Drawing.Size(893, 110);
            this.panelCantidades.TabIndex = 25;
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(160, 33);
            this.tbCantidad.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(174, 38);
            this.tbCantidad.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 36);
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
            this.cbUM.Location = new System.Drawing.Point(612, 29);
            this.cbUM.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cbUM.Name = "cbUM";
            this.cbUM.Size = new System.Drawing.Size(265, 39);
            this.cbUM.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Producto";
            // 
            // cbProductos
            // 
            this.cbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductos.FormattingEnabled = true;
            this.cbProductos.Location = new System.Drawing.Point(145, 45);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(391, 39);
            this.cbProductos.TabIndex = 0;
            this.cbProductos.SelectedIndexChanged += new System.EventHandler(this.cbProductos_SelectedIndexChanged);
            // 
            // panelOculto
            // 
            this.panelOculto.Controls.Add(this.panelSN);
            this.panelOculto.Controls.Add(this.groupBox4);
            this.panelOculto.Controls.Add(this.gbProductos);
            this.panelOculto.Controls.Add(this.groupBox2);
            this.panelOculto.Enabled = false;
            this.panelOculto.Location = new System.Drawing.Point(12, 102);
            this.panelOculto.Name = "panelOculto";
            this.panelOculto.Size = new System.Drawing.Size(1498, 625);
            this.panelOculto.TabIndex = 36;
            // 
            // DetalleMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelOculto);
            this.Name = "DetalleMovimiento";
            this.Text = "DetalleMovimiento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DetalleMovimiento_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panelSN.ResumeLayout(false);
            this.panelSN.PerformLayout();
            this.gbProductos.ResumeLayout(false);
            this.gbProductos.PerformLayout();
            this.panelCantidades.ResumeLayout(false);
            this.panelCantidades.PerformLayout();
            this.panelOculto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbRazon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbUbicacionDestino;
        private System.Windows.Forms.ComboBox cbAlmacenDestino;
        private System.Windows.Forms.ComboBox cbSucursalDestino;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbUbicacionOrigen;
        private System.Windows.Forms.ComboBox cbAlmacenOrigen;
        private System.Windows.Forms.ComboBox cbSucursalOrigen;
        private System.Windows.Forms.Panel panelSN;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbProductos;
        private System.Windows.Forms.Panel panelCantidades;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbUM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProductos;
        private System.Windows.Forms.Panel panelOculto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCargarDesdeTxt;
    }
}