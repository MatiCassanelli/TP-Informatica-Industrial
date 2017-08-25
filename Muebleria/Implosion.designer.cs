namespace Muebleria
{
    partial class Implosion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbprodfinales = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImplosionar = new System.Windows.Forms.Button();
            this.cbProductosBuscados = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 302);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbprodfinales);
            this.groupBox1.Location = new System.Drawing.Point(5, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 202);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // lbprodfinales
            // 
            this.lbprodfinales.FormattingEnabled = true;
            this.lbprodfinales.Location = new System.Drawing.Point(0, 3);
            this.lbprodfinales.Name = "lbprodfinales";
            this.lbprodfinales.Size = new System.Drawing.Size(395, 199);
            this.lbprodfinales.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnImplosionar);
            this.panel2.Controls.Add(this.cbProductosBuscados);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 83);
            this.panel2.TabIndex = 2;
            // 
            // btnImplosionar
            // 
            this.btnImplosionar.Location = new System.Drawing.Point(297, 52);
            this.btnImplosionar.Name = "btnImplosionar";
            this.btnImplosionar.Size = new System.Drawing.Size(95, 23);
            this.btnImplosionar.TabIndex = 24;
            this.btnImplosionar.Text = "Buscar Producto";
            this.btnImplosionar.UseVisualStyleBackColor = true;
            this.btnImplosionar.Click += new System.EventHandler(this.btnImplosionar_Click);
            // 
            // cbProductosBuscados
            // 
            this.cbProductosBuscados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductosBuscados.FormattingEnabled = true;
            this.cbProductosBuscados.Location = new System.Drawing.Point(103, 12);
            this.cbProductosBuscados.Name = "cbProductosBuscados";
            this.cbProductosBuscados.Size = new System.Drawing.Size(287, 21);
            this.cbProductosBuscados.TabIndex = 3;
            this.cbProductosBuscados.SelectedIndexChanged += new System.EventHandler(this.cbProductosBuscados_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Producto buscado";
            // 
            // Implosion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 314);
            this.Controls.Add(this.panel1);
            this.Name = "Implosion";
            this.Text = "Implosion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Implosion_FormClosed);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbProductosBuscados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbprodfinales;
        private System.Windows.Forms.Button btnImplosionar;
    }
}