namespace Internom
{
    partial class PrincipalAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalAdmin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horariosEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.credencialesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaCredencialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generadorCodigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flotillaVehicularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatoInvUnidadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultasToolStripMenuItem,
            this.empleadosToolStripMenuItem,
            this.horariosEmpleadosToolStripMenuItem,
            this.credencialesToolStripMenuItem1,
            this.flotillaVehicularToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            this.consultasToolStripMenuItem.Click += new System.EventHandler(this.consultasToolStripMenuItem_Click);
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroEmpleadoToolStripMenuItem,
            this.catalogoEmpleadoToolStripMenuItem});
            this.empleadosToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.empleadosToolStripMenuItem.Text = "Empleados";
            // 
            // registroEmpleadoToolStripMenuItem
            // 
            this.registroEmpleadoToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.registroEmpleadoToolStripMenuItem.Name = "registroEmpleadoToolStripMenuItem";
            this.registroEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.registroEmpleadoToolStripMenuItem.Text = "Registro Empleado";
            this.registroEmpleadoToolStripMenuItem.Click += new System.EventHandler(this.registroEmpleadoToolStripMenuItem_Click);
            // 
            // catalogoEmpleadoToolStripMenuItem
            // 
            this.catalogoEmpleadoToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.catalogoEmpleadoToolStripMenuItem.Name = "catalogoEmpleadoToolStripMenuItem";
            this.catalogoEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.catalogoEmpleadoToolStripMenuItem.Text = "Catalogo Empleados";
            this.catalogoEmpleadoToolStripMenuItem.Click += new System.EventHandler(this.catalogoEmpleadoToolStripMenuItem_Click);
            // 
            // horariosEmpleadosToolStripMenuItem
            // 
            this.horariosEmpleadosToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.horariosEmpleadosToolStripMenuItem.Name = "horariosEmpleadosToolStripMenuItem";
            this.horariosEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.horariosEmpleadosToolStripMenuItem.Text = "Horarios_Empleados";
            this.horariosEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.horariosEmpleadosToolStripMenuItem_Click);
            // 
            // credencialesToolStripMenuItem1
            // 
            this.credencialesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaCredencialToolStripMenuItem,
            this.generadorCodigosToolStripMenuItem});
            this.credencialesToolStripMenuItem1.ForeColor = System.Drawing.Color.Navy;
            this.credencialesToolStripMenuItem1.Name = "credencialesToolStripMenuItem1";
            this.credencialesToolStripMenuItem1.Size = new System.Drawing.Size(86, 20);
            this.credencialesToolStripMenuItem1.Text = "Credenciales";
            this.credencialesToolStripMenuItem1.Click += new System.EventHandler(this.credencialesToolStripMenuItem1_Click);
            // 
            // nuevaCredencialToolStripMenuItem
            // 
            this.nuevaCredencialToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.nuevaCredencialToolStripMenuItem.Name = "nuevaCredencialToolStripMenuItem";
            this.nuevaCredencialToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.nuevaCredencialToolStripMenuItem.Text = "Nueva Credencial";
            this.nuevaCredencialToolStripMenuItem.Click += new System.EventHandler(this.nuevaCredencialToolStripMenuItem_Click);
            // 
            // generadorCodigosToolStripMenuItem
            // 
            this.generadorCodigosToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.generadorCodigosToolStripMenuItem.Name = "generadorCodigosToolStripMenuItem";
            this.generadorCodigosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.generadorCodigosToolStripMenuItem.Text = "Generador Codigos";
            this.generadorCodigosToolStripMenuItem.Click += new System.EventHandler(this.generadorCodigosToolStripMenuItem_Click);
            // 
            // flotillaVehicularToolStripMenuItem
            // 
            this.flotillaVehicularToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroVehiculoToolStripMenuItem,
            this.formatoInvUnidadToolStripMenuItem1});
            this.flotillaVehicularToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.flotillaVehicularToolStripMenuItem.Name = "flotillaVehicularToolStripMenuItem";
            this.flotillaVehicularToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.flotillaVehicularToolStripMenuItem.Text = "Flotilla Vehicular";
            // 
            // registroVehiculoToolStripMenuItem
            // 
            this.registroVehiculoToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.registroVehiculoToolStripMenuItem.Name = "registroVehiculoToolStripMenuItem";
            this.registroVehiculoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.registroVehiculoToolStripMenuItem.Text = "Registro Vehiculo";
            this.registroVehiculoToolStripMenuItem.Click += new System.EventHandler(this.registroVehiculoToolStripMenuItem_Click);
            // 
            // formatoInvUnidadToolStripMenuItem1
            // 
            this.formatoInvUnidadToolStripMenuItem1.ForeColor = System.Drawing.Color.Navy;
            this.formatoInvUnidadToolStripMenuItem1.Name = "formatoInvUnidadToolStripMenuItem1";
            this.formatoInvUnidadToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.formatoInvUnidadToolStripMenuItem1.Text = "Rendimiento";
            this.formatoInvUnidadToolStripMenuItem1.Click += new System.EventHandler(this.formatoInvUnidadToolStripMenuItem1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 90);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // PrincipalAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(901, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PrincipalAdmin";
            this.Text = "PrincipalAdmin";
            this.Load += new System.EventHandler(this.PrincipalAdmin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horariosEmpleadosToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem credencialesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nuevaCredencialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generadorCodigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flotillaVehicularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatoInvUnidadToolStripMenuItem1;
    }
}