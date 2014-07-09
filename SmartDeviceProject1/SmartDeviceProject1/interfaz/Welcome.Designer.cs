namespace SmartDeviceProject1.interfaz
{
    partial class Welcome
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.Icon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Icon
            // 
            this.Icon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Icon.Image = ((System.Drawing.Image)(resources.GetObject("Icon.Image")));
            this.Icon.Location = new System.Drawing.Point(68, 91);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(111, 81);
            this.Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(19)))), ((int)(((byte)(61)))));
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 20);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(99)))), ((int)(((byte)(74)))));
            this.panel2.Location = new System.Drawing.Point(0, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 20);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(128)))), ((int)(((byte)(113)))));
            this.panel3.Location = new System.Drawing.Point(0, 126);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 20);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(129)))), ((int)(((byte)(128)))));
            this.panel4.Location = new System.Drawing.Point(0, 151);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 20);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.panel5.Location = new System.Drawing.Point(0, 176);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 20);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gray;
            this.panel6.Location = new System.Drawing.Point(0, 223);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(20, 20);
            this.panel6.Click += new System.EventHandler(this.panel6_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Icon);
            this.Name = "Welcome";
            this.Size = new System.Drawing.Size(240, 280);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Icon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;

    }
}
