namespace SntsepomexContributionLoader
{
    partial class CargaEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargaEmpleados));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurpEmp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRfcEmp = new System.Windows.Forms.TextBox();
            this.txtNameEmp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaidenNameEmp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastNameEmp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClaveEmp = new System.Windows.Forms.TextBox();
            this.btnSaveEmp = new System.Windows.Forms.Button();
            this.btnClearEmp = new System.Windows.Forms.Button();
            this.btnCancelEmp = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpDependencia = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpGobierno = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbWorkPlace = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbWorkPosition = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCurpEmp);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtRfcEmp);
            this.groupBox1.Controls.Add(this.txtNameEmp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaidenNameEmp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLastNameEmp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtClaveEmp);
            this.groupBox1.Location = new System.Drawing.Point(53, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 203);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Empleado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(520, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "CURP";
            // 
            // txtCurpEmp
            // 
            this.txtCurpEmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCurpEmp.Location = new System.Drawing.Point(523, 122);
            this.txtCurpEmp.MaxLength = 18;
            this.txtCurpEmp.Name = "txtCurpEmp";
            this.txtCurpEmp.Size = new System.Drawing.Size(211, 20);
            this.txtCurpEmp.TabIndex = 10;
            this.txtCurpEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurpEmp_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "RFC";
            // 
            // txtRfcEmp
            // 
            this.txtRfcEmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRfcEmp.Location = new System.Drawing.Point(272, 122);
            this.txtRfcEmp.MaxLength = 13;
            this.txtRfcEmp.Name = "txtRfcEmp";
            this.txtRfcEmp.Size = new System.Drawing.Size(212, 20);
            this.txtRfcEmp.TabIndex = 8;
            this.txtRfcEmp.TextChanged += new System.EventHandler(this.txtRfcEmp_TextChanged);
            this.txtRfcEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRfcEmp_KeyPress);
            // 
            // txtNameEmp
            // 
            this.txtNameEmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNameEmp.Location = new System.Drawing.Point(21, 122);
            this.txtNameEmp.MaxLength = 60;
            this.txtNameEmp.Name = "txtNameEmp";
            this.txtNameEmp.Size = new System.Drawing.Size(212, 20);
            this.txtNameEmp.TabIndex = 7;
            this.txtNameEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNameEmp_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombre(s)";
            // 
            // txtMaidenNameEmp
            // 
            this.txtMaidenNameEmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaidenNameEmp.Location = new System.Drawing.Point(522, 51);
            this.txtMaidenNameEmp.MaxLength = 40;
            this.txtMaidenNameEmp.Name = "txtMaidenNameEmp";
            this.txtMaidenNameEmp.Size = new System.Drawing.Size(212, 20);
            this.txtMaidenNameEmp.TabIndex = 5;
            this.txtMaidenNameEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaidenNameEmp_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apellido Materno";
            // 
            // txtLastNameEmp
            // 
            this.txtLastNameEmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastNameEmp.Location = new System.Drawing.Point(272, 51);
            this.txtLastNameEmp.MaxLength = 40;
            this.txtLastNameEmp.Name = "txtLastNameEmp";
            this.txtLastNameEmp.Size = new System.Drawing.Size(212, 20);
            this.txtLastNameEmp.TabIndex = 3;
            this.txtLastNameEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLastNameEmp_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido Paterno";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número Empleado";
            // 
            // txtClaveEmp
            // 
            this.txtClaveEmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveEmp.Location = new System.Drawing.Point(21, 51);
            this.txtClaveEmp.MaxLength = 6;
            this.txtClaveEmp.Name = "txtClaveEmp";
            this.txtClaveEmp.Size = new System.Drawing.Size(212, 20);
            this.txtClaveEmp.TabIndex = 0;
            this.txtClaveEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClaveEmp_KeyPress);
            // 
            // btnSaveEmp
            // 
            this.btnSaveEmp.Location = new System.Drawing.Point(115, 435);
            this.btnSaveEmp.Name = "btnSaveEmp";
            this.btnSaveEmp.Size = new System.Drawing.Size(189, 47);
            this.btnSaveEmp.TabIndex = 2;
            this.btnSaveEmp.Text = "Guardar";
            this.btnSaveEmp.UseVisualStyleBackColor = true;
            this.btnSaveEmp.Click += new System.EventHandler(this.btnSaveEmp_Click);
            // 
            // btnClearEmp
            // 
            this.btnClearEmp.Location = new System.Drawing.Point(348, 435);
            this.btnClearEmp.Name = "btnClearEmp";
            this.btnClearEmp.Size = new System.Drawing.Size(189, 47);
            this.btnClearEmp.TabIndex = 3;
            this.btnClearEmp.Text = "Limpiar";
            this.btnClearEmp.UseVisualStyleBackColor = true;
            this.btnClearEmp.Click += new System.EventHandler(this.btnClearEmp_Click);
            // 
            // btnCancelEmp
            // 
            this.btnCancelEmp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelEmp.Location = new System.Drawing.Point(585, 435);
            this.btnCancelEmp.Name = "btnCancelEmp";
            this.btnCancelEmp.Size = new System.Drawing.Size(189, 47);
            this.btnCancelEmp.TabIndex = 4;
            this.btnCancelEmp.Text = "Cancelar";
            this.btnCancelEmp.UseVisualStyleBackColor = true;
            this.btnCancelEmp.Click += new System.EventHandler(this.btnCancelEmp_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpDependencia);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dtpGobierno);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbWorkPlace);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbWorkPosition);
            this.groupBox2.Location = new System.Drawing.Point(88, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(675, 187);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Laborales";
            // 
            // dtpDependencia
            // 
            this.dtpDependencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDependencia.Location = new System.Drawing.Point(502, 121);
            this.dtpDependencia.MaxDate = new System.DateTime(2018, 6, 18, 0, 0, 0, 0);
            this.dtpDependencia.Name = "dtpDependencia";
            this.dtpDependencia.Size = new System.Drawing.Size(124, 20);
            this.dtpDependencia.TabIndex = 7;
            this.dtpDependencia.Value = new System.DateTime(2018, 6, 18, 0, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(499, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Ingreso a la dependencia";
            // 
            // dtpGobierno
            // 
            this.dtpGobierno.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGobierno.Location = new System.Drawing.Point(502, 56);
            this.dtpGobierno.MaxDate = new System.DateTime(2018, 6, 18, 0, 0, 0, 0);
            this.dtpGobierno.Name = "dtpGobierno";
            this.dtpGobierno.Size = new System.Drawing.Size(124, 20);
            this.dtpGobierno.TabIndex = 5;
            this.dtpGobierno.Value = new System.DateTime(2018, 6, 18, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(499, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Ingreso al gobierno";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Centro de trabajo:";
            // 
            // cmbWorkPlace
            // 
            this.cmbWorkPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkPlace.FormattingEnabled = true;
            this.cmbWorkPlace.Location = new System.Drawing.Point(41, 121);
            this.cmbWorkPlace.Name = "cmbWorkPlace";
            this.cmbWorkPlace.Size = new System.Drawing.Size(397, 21);
            this.cmbWorkPlace.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Descripcion del puesto";
            // 
            // cmbWorkPosition
            // 
            this.cmbWorkPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkPosition.FormattingEnabled = true;
            this.cmbWorkPosition.Location = new System.Drawing.Point(41, 56);
            this.cmbWorkPosition.Name = "cmbWorkPosition";
            this.cmbWorkPosition.Size = new System.Drawing.Size(397, 21);
            this.cmbWorkPosition.TabIndex = 0;
            // 
            // CargaEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelEmp;
            this.ClientSize = new System.Drawing.Size(890, 512);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancelEmp);
            this.Controls.Add(this.btnClearEmp);
            this.Controls.Add(this.btnSaveEmp);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CargaEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Carga manual empleados";
            this.Load += new System.EventHandler(this.CargaEmpleados_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClaveEmp;
        private System.Windows.Forms.Button btnSaveEmp;
        private System.Windows.Forms.Button btnClearEmp;
        private System.Windows.Forms.Button btnCancelEmp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMaidenNameEmp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastNameEmp;
        private System.Windows.Forms.TextBox txtNameEmp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCurpEmp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRfcEmp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbWorkPlace;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbWorkPosition;
        private System.Windows.Forms.DateTimePicker dtpDependencia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpGobierno;
        private System.Windows.Forms.Label label9;
    }
}