namespace SntsepomexContributionLoader
{
    partial class PagoParcial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagoParcial));
            this.txtNumEmpleado = new System.Windows.Forms.TextBox();
            this.txtRfcEmpleado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_BuscarEmpleado = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.txtMontoPagar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumEmpleado
            // 
            this.txtNumEmpleado.Location = new System.Drawing.Point(158, 37);
            this.txtNumEmpleado.MaxLength = 8;
            this.txtNumEmpleado.Name = "txtNumEmpleado";
            this.txtNumEmpleado.Size = new System.Drawing.Size(138, 20);
            this.txtNumEmpleado.TabIndex = 0;
            // 
            // txtRfcEmpleado
            // 
            this.txtRfcEmpleado.Location = new System.Drawing.Point(424, 37);
            this.txtRfcEmpleado.MaxLength = 13;
            this.txtRfcEmpleado.Name = "txtRfcEmpleado";
            this.txtRfcEmpleado.Size = new System.Drawing.Size(127, 20);
            this.txtRfcEmpleado.TabIndex = 1;
            this.txtRfcEmpleado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRfcEmpleado_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero de empleado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "RFC empleado:";
            // 
            // btn_BuscarEmpleado
            // 
            this.btn_BuscarEmpleado.Location = new System.Drawing.Point(601, 30);
            this.btn_BuscarEmpleado.Name = "btn_BuscarEmpleado";
            this.btn_BuscarEmpleado.Size = new System.Drawing.Size(132, 33);
            this.btn_BuscarEmpleado.TabIndex = 4;
            this.btn_BuscarEmpleado.Text = "Buscar";
            this.btn_BuscarEmpleado.UseVisualStyleBackColor = true;
            this.btn_BuscarEmpleado.Click += new System.EventHandler(this.btn_BuscarEmpleado_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre del empleado:";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Location = new System.Drawing.Point(155, 18);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.ReadOnly = true;
            this.txtNombreCompleto.Size = new System.Drawing.Size(459, 20);
            this.txtNombreCompleto.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnRegistrarPago);
            this.panel1.Controls.Add(this.txtMontoPagar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNombreCompleto);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(44, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 137);
            this.panel1.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(468, 71);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.Enabled = false;
            this.btnRegistrarPago.Location = new System.Drawing.Point(333, 72);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(116, 23);
            this.btnRegistrarPago.TabIndex = 9;
            this.btnRegistrarPago.Text = "Registrar Pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = true;
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // txtMontoPagar
            // 
            this.txtMontoPagar.Enabled = false;
            this.txtMontoPagar.Location = new System.Drawing.Point(158, 74);
            this.txtMontoPagar.Name = "txtMontoPagar";
            this.txtMontoPagar.Size = new System.Drawing.Size(148, 20);
            this.txtMontoPagar.TabIndex = 8;
            this.txtMontoPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoPagar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoPagar_KeyPress);
            this.txtMontoPagar.Leave += new System.EventHandler(this.txtMontoPagar_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Monto a pagar:";
            // 
            // PagoParcial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 251);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_BuscarEmpleado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRfcEmpleado);
            this.Controls.Add(this.txtNumEmpleado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PagoParcial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro de pago parcial";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumEmpleado;
        private System.Windows.Forms.TextBox txtRfcEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_BuscarEmpleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.TextBox txtMontoPagar;
        private System.Windows.Forms.Label label4;
    }
}