namespace Muebleria
{
    partial class Nuevo_Remito
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblIdRemito = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNombreCliente = new System.Windows.Forms.TextBox();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.btnGenerarRemito = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remito:";
            // 
            // lblIdRemito
            // 
            this.lblIdRemito.AutoSize = true;
            this.lblIdRemito.Location = new System.Drawing.Point(210, 26);
            this.lblIdRemito.Name = "lblIdRemito";
            this.lblIdRemito.Size = new System.Drawing.Size(35, 13);
            this.lblIdRemito.TabIndex = 1;
            this.lblIdRemito.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre del Cliente: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dirección de Destino:";
            // 
            // tbNombreCliente
            // 
            this.tbNombreCliente.Location = new System.Drawing.Point(196, 77);
            this.tbNombreCliente.Name = "tbNombreCliente";
            this.tbNombreCliente.Size = new System.Drawing.Size(166, 20);
            this.tbNombreCliente.TabIndex = 4;
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(196, 117);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(166, 20);
            this.tbDireccion.TabIndex = 5;
            // 
            // btnGenerarRemito
            // 
            this.btnGenerarRemito.Location = new System.Drawing.Point(287, 188);
            this.btnGenerarRemito.Name = "btnGenerarRemito";
            this.btnGenerarRemito.Size = new System.Drawing.Size(75, 23);
            this.btnGenerarRemito.TabIndex = 6;
            this.btnGenerarRemito.Text = "Generar";
            this.btnGenerarRemito.UseVisualStyleBackColor = true;
            this.btnGenerarRemito.Click += new System.EventHandler(this.btnGenerarRemito_Click);
            // 
            // Nuevo_Remito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 250);
            this.Controls.Add(this.btnGenerarRemito);
            this.Controls.Add(this.tbDireccion);
            this.Controls.Add(this.tbNombreCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIdRemito);
            this.Controls.Add(this.label1);
            this.Name = "Nuevo_Remito";
            this.Text = "Nuevo Remito";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIdRemito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNombreCliente;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.Button btnGenerarRemito;
    }
}