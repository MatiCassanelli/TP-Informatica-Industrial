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
            this.SuspendLayout();
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(201, 76);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(259, 96);
            this.btnCargar.TabIndex = 0;
            this.btnCargar.Text = "Cargar Productos";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnExplosionar
            // 
            this.btnExplosionar.Location = new System.Drawing.Point(201, 236);
            this.btnExplosionar.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnExplosionar.Name = "btnExplosionar";
            this.btnExplosionar.Size = new System.Drawing.Size(259, 96);
            this.btnExplosionar.TabIndex = 1;
            this.btnExplosionar.Text = "Explosionar";
            this.btnExplosionar.UseVisualStyleBackColor = true;
            this.btnExplosionar.Click += new System.EventHandler(this.btnExplosionar_Click);
            // 
            // btnImplosionar
            // 
            this.btnImplosionar.Location = new System.Drawing.Point(201, 395);
            this.btnImplosionar.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnImplosionar.Name = "btnImplosionar";
            this.btnImplosionar.Size = new System.Drawing.Size(259, 96);
            this.btnImplosionar.TabIndex = 2;
            this.btnImplosionar.Text = "Implosionar";
            this.btnImplosionar.UseVisualStyleBackColor = true;
            this.btnImplosionar.Click += new System.EventHandler(this.btnImplosionar_Click);
            // 
            // btnFabricarArticulo
            // 
            this.btnFabricarArticulo.Location = new System.Drawing.Point(201, 558);
            this.btnFabricarArticulo.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnFabricarArticulo.Name = "btnFabricarArticulo";
            this.btnFabricarArticulo.Size = new System.Drawing.Size(259, 96);
            this.btnFabricarArticulo.TabIndex = 3;
            this.btnFabricarArticulo.Text = "Fabricar Artículo";
            this.btnFabricarArticulo.UseVisualStyleBackColor = true;
            this.btnFabricarArticulo.Click += new System.EventHandler(this.btnFabricarArticulo_Click);
            // 
            // btnGrarRemito
            // 
            this.btnGrarRemito.Location = new System.Drawing.Point(201, 712);
            this.btnGrarRemito.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnGrarRemito.Name = "btnGrarRemito";
            this.btnGrarRemito.Size = new System.Drawing.Size(259, 96);
            this.btnGrarRemito.TabIndex = 4;
            this.btnGrarRemito.Text = "Generar Remito";
            this.btnGrarRemito.UseVisualStyleBackColor = true;
            this.btnGrarRemito.Click += new System.EventHandler(this.btnGrarRemito_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 899);
            this.Controls.Add(this.btnGrarRemito);
            this.Controls.Add(this.btnFabricarArticulo);
            this.Controls.Add(this.btnImplosionar);
            this.Controls.Add(this.btnExplosionar);
            this.Controls.Add(this.btnCargar);
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
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
    }
}