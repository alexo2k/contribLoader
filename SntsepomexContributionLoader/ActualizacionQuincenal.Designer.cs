namespace SntsepomexContributionLoader
{
    partial class ActualizacionQuincenal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizacionQuincenal));
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFornight = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAnioQuincena = new System.Windows.Forms.ComboBox();
            this.cmbNumQuincena = new System.Windows.Forms.ComboBox();
            this.radNumero = new System.Windows.Forms.RadioButton();
            this.radRFC = new System.Windows.Forms.RadioButton();
            this.btnLastFortnight = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(371, 30);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(144, 32);
            this.btnSeleccionar.TabIndex = 0;
            this.btnSeleccionar.Text = "Seleccionar Archivo";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(63, 37);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(302, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnCargar
            // 
            this.btnCargar.Enabled = false;
            this.btnCargar.Location = new System.Drawing.Point(73, 266);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(148, 33);
            this.btnCargar.TabIndex = 2;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(367, 266);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(148, 33);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLastFortnight);
            this.groupBox1.Controls.Add(this.dtpFornight);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbAnioQuincena);
            this.groupBox1.Controls.Add(this.cmbNumQuincena);
            this.groupBox1.Location = new System.Drawing.Point(101, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 130);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion de la quincena";
            // 
            // dtpFornight
            // 
            this.dtpFornight.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFornight.Location = new System.Drawing.Point(211, 84);
            this.dtpFornight.Name = "dtpFornight";
            this.dtpFornight.Size = new System.Drawing.Size(94, 20);
            this.dtpFornight.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de la quincena";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Año de la quincena";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero de quincena";
            // 
            // cmbAnioQuincena
            // 
            this.cmbAnioQuincena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnioQuincena.FormattingEnabled = true;
            this.cmbAnioQuincena.Location = new System.Drawing.Point(211, 51);
            this.cmbAnioQuincena.Name = "cmbAnioQuincena";
            this.cmbAnioQuincena.Size = new System.Drawing.Size(93, 21);
            this.cmbAnioQuincena.TabIndex = 1;
            // 
            // cmbNumQuincena
            // 
            this.cmbNumQuincena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumQuincena.FormattingEnabled = true;
            this.cmbNumQuincena.Location = new System.Drawing.Point(210, 19);
            this.cmbNumQuincena.MaxDropDownItems = 5;
            this.cmbNumQuincena.Name = "cmbNumQuincena";
            this.cmbNumQuincena.Size = new System.Drawing.Size(94, 21);
            this.cmbNumQuincena.TabIndex = 0;
            // 
            // radNumero
            // 
            this.radNumero.AutoSize = true;
            this.radNumero.Checked = true;
            this.radNumero.Location = new System.Drawing.Point(130, 78);
            this.radNumero.Name = "radNumero";
            this.radNumero.Size = new System.Drawing.Size(164, 17);
            this.radNumero.TabIndex = 5;
            this.radNumero.TabStop = true;
            this.radNumero.Text = "Cargar por Numero Empleado";
            this.radNumero.UseVisualStyleBackColor = true;
            // 
            // radRFC
            // 
            this.radRFC.AutoSize = true;
            this.radRFC.Location = new System.Drawing.Point(317, 78);
            this.radRFC.Name = "radRFC";
            this.radRFC.Size = new System.Drawing.Size(98, 17);
            this.radRFC.TabIndex = 6;
            this.radRFC.TabStop = true;
            this.radRFC.Text = "Cargar por RFC";
            this.radRFC.UseVisualStyleBackColor = true;
            // 
            // btnLastFortnight
            // 
            this.btnLastFortnight.Location = new System.Drawing.Point(323, 49);
            this.btnLastFortnight.Name = "btnLastFortnight";
            this.btnLastFortnight.Size = new System.Drawing.Size(40, 23);
            this.btnLastFortnight.TabIndex = 7;
            this.btnLastFortnight.Text = "?";
            this.btnLastFortnight.UseVisualStyleBackColor = true;
            this.btnLastFortnight.Click += new System.EventHandler(this.btnLastFortnight_Click);
            // 
            // ActualizacionQuincenal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(585, 323);
            this.Controls.Add(this.radRFC);
            this.Controls.Add(this.radNumero);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnSeleccionar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActualizacionQuincenal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizacion quincenal";
            this.Load += new System.EventHandler(this.ActualizacionQuincenal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAnioQuincena;
        private System.Windows.Forms.ComboBox cmbNumQuincena;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFornight;
        private System.Windows.Forms.RadioButton radNumero;
        private System.Windows.Forms.RadioButton radRFC;
        private System.Windows.Forms.Button btnLastFortnight;
    }
}