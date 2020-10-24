namespace SntsepomexContributionLoader
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.btnCargaInicial = new System.Windows.Forms.Button();
            this.btnActualizacionQ = new System.Windows.Forms.Button();
            this.btnCargaManual = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnParametros = new System.Windows.Forms.Button();
            this.btn_ResumenLiquidacion = new System.Windows.Forms.Button();
            this.btnPagoParcialForm = new System.Windows.Forms.Button();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.btn_reporteSaldos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCargaInicial
            // 
            this.btnCargaInicial.Location = new System.Drawing.Point(222, 217);
            this.btnCargaInicial.Name = "btnCargaInicial";
            this.btnCargaInicial.Size = new System.Drawing.Size(222, 56);
            this.btnCargaInicial.TabIndex = 0;
            this.btnCargaInicial.Text = "Carga múltiple";
            this.btnCargaInicial.UseVisualStyleBackColor = true;
            this.btnCargaInicial.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnActualizacionQ
            // 
            this.btnActualizacionQ.Location = new System.Drawing.Point(222, 63);
            this.btnActualizacionQ.Name = "btnActualizacionQ";
            this.btnActualizacionQ.Size = new System.Drawing.Size(222, 56);
            this.btnActualizacionQ.TabIndex = 1;
            this.btnActualizacionQ.Text = "Actualización quincenal";
            this.btnActualizacionQ.UseVisualStyleBackColor = true;
            this.btnActualizacionQ.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCargaManual
            // 
            this.btnCargaManual.Location = new System.Drawing.Point(222, 294);
            this.btnCargaManual.Name = "btnCargaManual";
            this.btnCargaManual.Size = new System.Drawing.Size(222, 56);
            this.btnCargaManual.TabIndex = 2;
            this.btnCargaManual.Text = "Carga manual de empleados";
            this.btnCargaManual.UseVisualStyleBackColor = true;
            this.btnCargaManual.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(474, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sistema de administración de aportaciones";
            // 
            // btnParametros
            // 
            this.btnParametros.Location = new System.Drawing.Point(222, 448);
            this.btnParametros.Name = "btnParametros";
            this.btnParametros.Size = new System.Drawing.Size(222, 56);
            this.btnParametros.TabIndex = 4;
            this.btnParametros.Text = "Modificación de parámetros";
            this.btnParametros.UseVisualStyleBackColor = true;
            this.btnParametros.Click += new System.EventHandler(this.btnParametros_Click);
            // 
            // btn_ResumenLiquidacion
            // 
            this.btn_ResumenLiquidacion.Location = new System.Drawing.Point(222, 371);
            this.btn_ResumenLiquidacion.Name = "btn_ResumenLiquidacion";
            this.btn_ResumenLiquidacion.Size = new System.Drawing.Size(222, 56);
            this.btn_ResumenLiquidacion.TabIndex = 5;
            this.btn_ResumenLiquidacion.Text = "Generar estado de cuenta";
            this.btn_ResumenLiquidacion.UseVisualStyleBackColor = true;
            this.btn_ResumenLiquidacion.Click += new System.EventHandler(this.btn_ResumenLiquidacion_Click);
            // 
            // btnPagoParcialForm
            // 
            this.btnPagoParcialForm.Location = new System.Drawing.Point(222, 525);
            this.btnPagoParcialForm.Name = "btnPagoParcialForm";
            this.btnPagoParcialForm.Size = new System.Drawing.Size(222, 56);
            this.btnPagoParcialForm.TabIndex = 6;
            this.btnPagoParcialForm.Text = "Registrar pago parcial";
            this.btnPagoParcialForm.UseVisualStyleBackColor = true;
            this.btnPagoParcialForm.Click += new System.EventHandler(this.btnPagoParcialForm_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Location = new System.Drawing.Point(222, 140);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(222, 56);
            this.btnBusqueda.TabIndex = 7;
            this.btnBusqueda.Text = "Busqueda de empleados";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btn_reporteSaldos
            // 
            this.btn_reporteSaldos.Location = new System.Drawing.Point(222, 600);
            this.btn_reporteSaldos.Name = "btn_reporteSaldos";
            this.btn_reporteSaldos.Size = new System.Drawing.Size(222, 56);
            this.btn_reporteSaldos.TabIndex = 8;
            this.btn_reporteSaldos.Text = "Generar reporte de saldos";
            this.btn_reporteSaldos.UseVisualStyleBackColor = true;
            this.btn_reporteSaldos.Click += new System.EventHandler(this.btn_reporteSaldos_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 684);
            this.Controls.Add(this.btn_reporteSaldos);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnPagoParcialForm);
            this.Controls.Add(this.btn_ResumenLiquidacion);
            this.Controls.Add(this.btnParametros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCargaManual);
            this.Controls.Add(this.btnActualizacionQ);
            this.Controls.Add(this.btnCargaInicial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sindicato Nacional SEPOMEX";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCargaInicial;
        private System.Windows.Forms.Button btnActualizacionQ;
        private System.Windows.Forms.Button btnCargaManual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnParametros;
        private System.Windows.Forms.Button btn_ResumenLiquidacion;
        private System.Windows.Forms.Button btnPagoParcialForm;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Button btn_reporteSaldos;
    }
}

