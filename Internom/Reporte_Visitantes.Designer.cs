﻿namespace Internom
{
    partial class Reporte_Visitantes
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reporte_Visitantes));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtfecha1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.visitantesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitantesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(118, 140);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(642, 235);
            this.dataGridView1.TabIndex = 1;
                        // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.RoyalBlue;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(-1, 433);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(74, 22);
            this.button6.TabIndex = 12;
            this.button6.Text = "Regresar";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(143, 86);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 13;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txtfecha1
            // 
            this.txtfecha1.Enabled = false;
            this.txtfecha1.Location = new System.Drawing.Point(349, 86);
            this.txtfecha1.Name = "txtfecha1";
            this.txtfecha1.Size = new System.Drawing.Size(100, 20);
            this.txtfecha1.TabIndex = 15;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(388, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Consulta Visitantes Dia: ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(524, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 31);
            this.button1.TabIndex = 18;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // visitantesBindingSource
            // 
            this.visitantesBindingSource.DataMember = "visitantes";
            // 
            // Reporte_Visitantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(901, 453);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtfecha1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "Reporte_Visitantes";
            this.Text = "Reporte_Visitantes";
            this.Load += new System.EventHandler(this.Reporte_Visitantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitantesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtfecha1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
       // private internomDataSet internomDataSet;
        private System.Windows.Forms.BindingSource visitantesBindingSource;
    }
}