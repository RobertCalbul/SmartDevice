﻿namespace SmartDeviceProject1.interfaz
{
    partial class TakeData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakeData));
            this.panelCodServicio = new System.Windows.Forms.Panel();
            this.tCodServ = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panelNodata = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pSave = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelReadActual = new System.Windows.Forms.Panel();
            this.tReadActual = new System.Windows.Forms.TextBox();
            this.panelDateHour = new System.Windows.Forms.Panel();
            this.tDateHour = new System.Windows.Forms.TextBox();
            this.panelCorrdenada = new System.Windows.Forms.Panel();
            this.tCoordenate = new System.Windows.Forms.TextBox();
            this.back = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelCodServicio.SuspendLayout();
            this.panelNodata.SuspendLayout();
            this.pSave.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelReadActual.SuspendLayout();
            this.panelDateHour.SuspendLayout();
            this.panelCorrdenada.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCodServicio
            // 
            this.panelCodServicio.BackColor = System.Drawing.Color.Transparent;
            this.panelCodServicio.Controls.Add(this.tCodServ);
            this.panelCodServicio.Location = new System.Drawing.Point(125, 87);
            this.panelCodServicio.Name = "panelCodServicio";
            this.panelCodServicio.Size = new System.Drawing.Size(120, 20);
            // 
            // tCodServ
            // 
            this.tCodServ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tCodServ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tCodServ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(19)))), ((int)(((byte)(61)))));
            this.tCodServ.Location = new System.Drawing.Point(0, 0);
            this.tCodServ.Name = "tCodServ";
            this.tCodServ.Size = new System.Drawing.Size(120, 21);
            this.tCodServ.TabIndex = 0;
            this.tCodServ.TextChanged += new System.EventHandler(this.tCodServ_TextChanged);
            this.tCodServ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tCodServ_KeyPress);
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(125, 105);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(100, 100);
            this.listBox1.TabIndex = 1;
            this.listBox1.Visible = false;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // panelNodata
            // 
            this.panelNodata.BackColor = System.Drawing.Color.Gray;
            this.panelNodata.Controls.Add(this.label6);
            this.panelNodata.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNodata.Location = new System.Drawing.Point(0, 260);
            this.panelNodata.Name = "panelNodata";
            this.panelNodata.Size = new System.Drawing.Size(240, 20);
            this.panelNodata.Click += new System.EventHandler(this.panel6_Click_1);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 20);
            this.label6.Text = "NO SE OUEDE TOMAR LECTURA";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pSave
            // 
            this.pSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.pSave.Controls.Add(this.label5);
            this.pSave.Location = new System.Drawing.Point(0, 185);
            this.pSave.Name = "pSave";
            this.pSave.Size = new System.Drawing.Size(120, 20);
            this.pSave.Click += new System.EventHandler(this.pSave_Click);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.Text = "GUARDAR .";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(129)))), ((int)(((byte)(128)))));
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(0, 160);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 20);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.Text = "COORDENADAS .";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(128)))), ((int)(((byte)(113)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(0, 135);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(120, 20);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.Text = "FECHA Y HORA .";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(99)))), ((int)(((byte)(74)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 20);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.Text = "LECTURA ACTUAL .";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(19)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 20);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.Text = "CODIGO SERVICIO .";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelReadActual
            // 
            this.panelReadActual.BackColor = System.Drawing.Color.Transparent;
            this.panelReadActual.Controls.Add(this.tReadActual);
            this.panelReadActual.Location = new System.Drawing.Point(125, 112);
            this.panelReadActual.Name = "panelReadActual";
            this.panelReadActual.Size = new System.Drawing.Size(120, 20);
            // 
            // tReadActual
            // 
            this.tReadActual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tReadActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tReadActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(99)))), ((int)(((byte)(74)))));
            this.tReadActual.Location = new System.Drawing.Point(0, 0);
            this.tReadActual.Name = "tReadActual";
            this.tReadActual.Size = new System.Drawing.Size(120, 21);
            this.tReadActual.TabIndex = 0;
            this.tReadActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tReadActual_KeyPress);
            // 
            // panelDateHour
            // 
            this.panelDateHour.BackColor = System.Drawing.Color.Transparent;
            this.panelDateHour.Controls.Add(this.tDateHour);
            this.panelDateHour.Location = new System.Drawing.Point(125, 135);
            this.panelDateHour.Name = "panelDateHour";
            this.panelDateHour.Size = new System.Drawing.Size(120, 20);
            // 
            // tDateHour
            // 
            this.tDateHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tDateHour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tDateHour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(128)))), ((int)(((byte)(113)))));
            this.tDateHour.Location = new System.Drawing.Point(0, 0);
            this.tDateHour.Name = "tDateHour";
            this.tDateHour.Size = new System.Drawing.Size(120, 21);
            this.tDateHour.TabIndex = 0;
            // 
            // panelCorrdenada
            // 
            this.panelCorrdenada.BackColor = System.Drawing.Color.Transparent;
            this.panelCorrdenada.Controls.Add(this.tCoordenate);
            this.panelCorrdenada.Location = new System.Drawing.Point(125, 160);
            this.panelCorrdenada.Name = "panelCorrdenada";
            this.panelCorrdenada.Size = new System.Drawing.Size(120, 20);
            // 
            // tCoordenate
            // 
            this.tCoordenate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tCoordenate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tCoordenate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(129)))), ((int)(((byte)(128)))));
            this.tCoordenate.Location = new System.Drawing.Point(0, 0);
            this.tCoordenate.Multiline = true;
            this.tCoordenate.Name = "tCoordenate";
            this.tCoordenate.Size = new System.Drawing.Size(120, 20);
            this.tCoordenate.TabIndex = 0;
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(0, 25);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(40, 40);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(81, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // TakeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.panelCodServicio);
            this.Controls.Add(this.panelReadActual);
            this.Controls.Add(this.panelDateHour);
            this.Controls.Add(this.panelCorrdenada);
            this.Controls.Add(this.panelNodata);
            this.Controls.Add(this.pSave);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TakeData";
            this.Size = new System.Drawing.Size(240, 280);
            this.panelCodServicio.ResumeLayout(false);
            this.panelNodata.ResumeLayout(false);
            this.pSave.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelReadActual.ResumeLayout(false);
            this.panelDateHour.ResumeLayout(false);
            this.panelCorrdenada.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCodServicio;
        private System.Windows.Forms.Panel panelNodata;
        private System.Windows.Forms.Panel pSave;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelReadActual;
        private System.Windows.Forms.TextBox tCodServ;
        private System.Windows.Forms.TextBox tReadActual;
        private System.Windows.Forms.TextBox tDateHour;
        private System.Windows.Forms.TextBox tCoordenate;
        private System.Windows.Forms.Panel panelDateHour;        
        private System.Windows.Forms.Panel panelCorrdenada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;

    }
}
