using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace SntsepomexContributionLoader
{
    public partial class LoginForm : Form
    {

        string usuarioActual;
        string passAdmin;
        public LoginForm()
        {

            InitializeComponent();

            try
            {
                cmbUsuario.Items.Add("Administrador");
                cmbUsuario.Items.Add("Usuario");
                txtPass.Enabled = false;
                btnAceptar.Enabled = false;
                passAdmin = ConfigurationManager.AppSettings["sysadminkey"];
            }
            catch (Exception ex) {
                MessageBox.Show("Ocurrió un error al inicializar la aplicación. ERR: " + ex.Message, "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void cmbUsuario_Leave(object sender, EventArgs e)
        {
            
        }

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedIndex == 0)
            {
                txtPass.Enabled = true;
                btnAceptar.Enabled = false;
                usuarioActual = "Administrador";
            }
            else {
                txtPass.Enabled = false;
                btnAceptar.Enabled = true;
                usuarioActual = "Usuario";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarioActual == "Administrador")
                {
                    if (StringCipher.Decrypt(passAdmin, "inefable").Equals(txtPass.Text.Trim()))
                    {
                        Principal formPrincipal = new Principal(this.usuarioActual);
                        formPrincipal.ShowDialog();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("La contraseña no es correcta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (usuarioActual == "Usuario")
                {
                    Principal formPrincipal = new Principal(this.usuarioActual);
                    formPrincipal.ShowDialog();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("No se reconoce el usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ocurrió un error. ERR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text.Length > 0) {
                btnAceptar.Enabled = true;
            }
        }
    }
}
