namespace OperaciónOrbita
{
    partial class FrmPanelControl
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
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.dgvMisiones = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnIniciarMision = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(13, 9);
            this.lblBienvenida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(173, 37);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Bienvenido";
            this.lblBienvenida.UseWaitCursor = true;
            // 
            // dgvMisiones
            // 
            this.dgvMisiones.AllowUserToAddRows = false;
            this.dgvMisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisiones.Location = new System.Drawing.Point(2, 49);
            this.dgvMisiones.MultiSelect = false;
            this.dgvMisiones.Name = "dgvMisiones";
            this.dgvMisiones.ReadOnly = true;
            this.dgvMisiones.RowHeadersWidth = 51;
            this.dgvMisiones.RowTemplate.Height = 24;
            this.dgvMisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMisiones.Size = new System.Drawing.Size(1077, 336);
            this.dgvMisiones.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(906, 392);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(160, 45);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnIniciarMision
            // 
            this.btnIniciarMision.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnIniciarMision.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarMision.Location = new System.Drawing.Point(738, 392);
            this.btnIniciarMision.Margin = new System.Windows.Forms.Padding(4);
            this.btnIniciarMision.Name = "btnIniciarMision";
            this.btnIniciarMision.Size = new System.Drawing.Size(160, 45);
            this.btnIniciarMision.TabIndex = 5;
            this.btnIniciarMision.Text = "Iniciar Misión";
            this.btnIniciarMision.UseVisualStyleBackColor = false;
            this.btnIniciarMision.Click += new System.EventHandler(this.btnIniciarMision_Click);
            // 
            // FrmPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 450);
            this.Controls.Add(this.btnIniciarMision);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvMisiones);
            this.Controls.Add(this.lblBienvenida);
            this.Name = "FrmPanelControl";
            this.Text = "Panel de Control de Misiones";
            this.Load += new System.EventHandler(this.FrmPanelControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.DataGridView dgvMisiones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnIniciarMision;
    }
}