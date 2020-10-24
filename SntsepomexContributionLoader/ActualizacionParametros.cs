using SntsepomexContributionLoader.Models;
using SntsepomexContributionLoader.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SntsepomexContributionLoader
{
    public partial class ActualizacionParametros : Form
    {

        List<Interest> listaIntereses;
        Interest selectedInterest;
        public ActualizacionParametros()
        {
            InitializeComponent();
        }

        private void ActualizacionParametros_Load(object sender, EventArgs e)
        {

            listaIntereses = null;
            selectedInterest = null;

            try
            {
                using (UnitOfWork unitOfwork = new UnitOfWork(new ContributionContext())) {
                    listaIntereses = (unitOfwork.Interests.GetAll()).ToList();
                }

                if (listaIntereses.Count > 0)
                {
                    cmbAnioInt.DataSource = listaIntereses;
                    cmbAnioInt.ValueMember = "InterestId";
                    cmbAnioInt.DisplayMember = "Year";
                    cmbAnioInt.SelectedItem = 1;

                    selectedInterest = (Interest)cmbAnioInt.SelectedItem;
                    txtIntPerc.Text = selectedInterest.Percentage.ToString();
                }
                else {
                    MessageBox.Show("No hay registros para mostrar. Consulta al administrador", "Sin registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception ex) {
                MessageBox.Show("Ocurrio un error al recuperar el listado desde la BD. ERR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbAnioInt_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedInterest = (Interest)cmbAnioInt.SelectedItem;
            txtIntPerc.Text = selectedInterest.Percentage.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnCancelar.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            txtIntPerc.Enabled = true;
        }

        private void txtIntPerc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
            { 
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Enabled = false;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            txtIntPerc.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new ContributionContext())) {
                    selectedInterest = (Interest)cmbAnioInt.SelectedItem;
                    Interest bufferInterest = unitOfWork.Interests.SingleOrDefault(inte => inte.InterestId == selectedInterest.InterestId);
                    bufferInterest.Percentage = Double.Parse(txtIntPerc.Text);    

                    unitOfWork.Complete();
                    MessageBox.Show("Modificacion realizada con éxito.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    listaIntereses = unitOfWork.Interests.GetAll().ToList();
                }

            }
            catch (Exception ex) {
                MessageBox.Show("Ocurrió un error. ERR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                btnCancelar.Enabled = false;
                btnModificar.Enabled = true;
                btnGuardar.Enabled = false;
                txtIntPerc.Enabled = false;
            }
        }

    }
}
