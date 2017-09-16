namespace Muebleria
{
    partial class Menu
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
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnExplosionar = new System.Windows.Forms.Button();
            this.btnImplosionar = new System.Windows.Forms.Button();
            this.btnFabricarArticulo = new System.Windows.Forms.Button();
            this.btnGrarRemito = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnMovimiento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(17, 31);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(296, 103);
            this.btnCargar.TabIndex = 0;
            this.btnCargar.Text = "Cargar Productos";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnExplosionar
            // 
            this.btnExplosionar.Location = new System.Drawing.Point(329, 31);
            this.btnExplosionar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnExplosionar.Name = "btnExplosionar";
            this.btnExplosionar.Size = new System.Drawing.Size(296, 103);
            this.btnExplosionar.TabIndex = 1;
            this.btnExplosionar.Text = "Explosionar";
            this.btnExplosionar.UseVisualStyleBackColor = true;
            this.btnExplosionar.Click += new System.EventHandler(this.btnExplosionar_Click);
            // 
            // btnImplosionar
            // 
            this.btnImplosionar.Location = new System.Drawing.Point(641, 31);
            this.btnImplosionar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnImplosionar.Name = "btnImplosionar";
            this.btnImplosionar.Size = new System.Drawing.Size(296, 103);
            this.btnImplosionar.TabIndex = 2;
            this.btnImplosionar.Text = "Implosionar";
            this.btnImplosionar.UseVisualStyleBackColor = true;
            this.btnImplosionar.Click += new System.EventHandler(this.btnImplosionar_Click);
            // 
            // btnFabricarArticulo
            // 
            this.btnFabricarArticulo.Location = new System.Drawing.Point(17, 178);
            this.btnFabricarArticulo.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnFabricarArticulo.Name = "btnFabricarArticulo";
            this.btnFabricarArticulo.Size = new System.Drawing.Size(296, 103);
            this.btnFabricarArticulo.TabIndex = 3;
            this.btnFabricarArticulo.Text = "Fabricar Artículo";
            this.btnFabricarArticulo.UseVisualStyleBackColor = true;
            this.btnFabricarArticulo.Click += new System.EventHandler(this.btnFabricarArticulo_Click);
            // 
            // btnGrarRemito
            // 
            this.btnGrarRemito.Location = new System.Drawing.Point(641, 178);
            this.btnGrarRemito.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnGrarRemito.Name = "btnGrarRemito";
            this.btnGrarRemito.Size = new System.Drawing.Size(296, 103);
            this.btnGrarRemito.TabIndex = 4;
            this.btnGrarRemito.Text = "Generar Remito";
            this.btnGrarRemito.UseVisualStyleBackColor = true;
            this.btnGrarRemito.Click += new System.EventHandler(this.btnGrarRemito_Click);
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(329, 178);
            this.btnStock.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(296, 103);
            this.btnStock.TabIndex = 5;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnMovimiento
            // 
            this.btnMovimiento.Location = new System.Drawing.Point(17, 316);
            this.btnMovimiento.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnMovimiento.Name = "btnMovimiento";
            this.btnMovimiento.Size = new System.Drawing.Size(296, 103);
            this.btnMovimiento.TabIndex = 6;
            this.btnMovimiento.Text = "Generar Movimiento";
            this.btnMovimiento.UseVisualStyleBackColor = true;
            this.btnMovimiento.Click += new System.EventHandler(this.btnMovimiento_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 496);
            this.Controls.Add(this.btnMovimiento);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnGrarRemito);
            this.Controls.Add(this.btnFabricarArticulo);
            this.Controls.Add(this.btnImplosionar);
            this.Controls.Add(this.btnExplosionar);
            this.Controls.Add(this.btnCargar);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnExplosionar;
        private System.Windows.Forms.Button btnImplosionar;
        private System.Windows.Forms.Button btnFabricarArticulo;
        private System.Windows.Forms.Button btnGrarRemito;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnMovimiento;
    }
}