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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_implosionar = new System.Windows.Forms.Button();
            this.cbProductosBuscados = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbprodfinales = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_implosionar);
            this.groupBox1.Controls.Add(this.cbProductosBuscados);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbprodfinales);
            this.groupBox1.Location = new System.Drawing.Point(509, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(957, 523);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btn_implosionar
            // 
            this.btn_implosionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_implosionar.Location = new System.Drawing.Point(670, 423);
            this.btn_implosionar.Margin = new System.Windows.Forms.Padding(7);
            this.btn_implosionar.Name = "btn_implosionar";
            this.btn_implosionar.Size = new System.Drawing.Size(261, 51);
            this.btn_implosionar.TabIndex = 12;
            this.btn_implosionar.Text = "Implosion";
            this.btn_implosionar.UseVisualStyleBackColor = true;
            this.btn_implosionar.Click += new System.EventHandler(this.btn_implosionar_Click);
            // 
            // cbProductosBuscados
            // 
            this.cbProductosBuscados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductosBuscados.FormattingEnabled = true;
            this.cbProductosBuscados.Location = new System.Drawing.Point(243, 25);
            this.cbProductosBuscados.Margin = new System.Windows.Forms.Padding(7);
            this.cbProductosBuscados.Name = "cbProductosBuscados";
            this.cbProductosBuscados.Size = new System.Drawing.Size(688, 37);
            this.cbProductosBuscados.TabIndex = 11;
            this.cbProductosBuscados.SelectedIndexChanged += new System.EventHandler(this.cbProductosBuscados_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Producto buscado";
            // 
            // lbprodfinales
            // 
            this.lbprodfinales.FormattingEnabled = true;
            this.lbprodfinales.ItemHeight = 29;
            this.lbprodfinales.Location = new System.Drawing.Point(15, 86);
            this.lbprodfinales.Margin = new System.Windows.Forms.Padding(7);
            this.lbprodfinales.Name = "lbprodfinales";
            this.lbprodfinales.Size = new System.Drawing.Size(916, 323);
            this.lbprodfinales.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Location = new System.Drawing.Point(12, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 374);
            this.panel1.TabIndex = 10;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // Implosion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 583);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "Implosion";
            this.Text = "Implosion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Implosion_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_implosionar;
        private System.Windows.Forms.ComboBox cbProductosBuscados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbprodfinales;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}