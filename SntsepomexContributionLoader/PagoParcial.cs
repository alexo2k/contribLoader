using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SntsepomexContributionLoader.Models;
using SntsepomexContributionLoader.Persistence;

namespace SntsepomexContributionLoader
{

    public partial class PagoParcial : Form
    {

        Employee empleadoActual;
        public PagoParcial()
        {
            InitializeComponent();
            empleadoActual = null;
            txtMontoPagar.Enabled = false;
            btnRegistrarPago.Enabled = false;
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            txtMontoPagar.Enabled = false;
            btnRegistrarPago.Enabled = false;
            txtNumEmpleado.Enabled = false;
            txtRfcEmpleado.Enabled = false;
            btn_BuscarEmpleado.Enabled = false;

            try
            {
                if (empleadoActual != null)
                {
                    using (var unitOfWork = new UnitOfWork(new ContributionContext()))
                    {

                        Employee empleadoPagoParcial = unitOfWork.Employees.SingleOrDefault(emp => emp.EmployeeId == empleadoActual.EmployeeId);
                        Contribution prevContrib = unitOfWork.Contributions.GetLastContribution(con => con.EmployeeId == empleadoActual.EmployeeId);

                        if (prevContrib != null)
                        {

                            Contribution contribucionPagoParcial = new Contribution
                            {
                                FortnightNumber = null,
                                Year = DateTime.Now.ToString("yyyy"),
                                ContributionDate = DateTime.Now,
                                ContributionBalance = -1.00 * Double.Parse(txtMontoPagar.Text, System.Globalization.NumberStyles.Currency),
                                ContributionAccumulated = 0,
                                ContribType = 5
                            };

                            contribucionPagoParcial.Employee = empleadoPagoParcial;

                            contribucionPagoParcial.ContributionAccumulated = prevContrib.ContributionAccumulated + contribucionPagoParcial.ContributionBalance;

                            try
                            {
                                unitOfWork.Contributions.Add(contribucionPagoParcial);
                                unitOfWork.Complete();
                                MessageBox.Show(String.Format("Se ha registrado el pago parcial de {0} por la cantidad {1} con éxito.", txtNombreCompleto.Text, txtMontoPagar.Text, "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk));

                                txtNumEmpleado.Text = string.Empty;
                                txtRfcEmpleado.Text = string.Empty;
                                txtMontoPagar.Text = string.Empty;
                                txtNumEmpleado.Enabled = true;
                                txtRfcEmpleado.Enabled = true;
                                btn_BuscarEmpleado.Enabled = true;
                                txtNombreCompleto.Text = string.Empty;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ocurrió un problema al registrar el pago parcial. ERR:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ha ocurrido un error. ERR: " + ex.Message + " INN:" + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMontoPagar_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txtMontoPagar.Text, out value))
            {
                txtMontoPagar.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            }
            else {
                txtMontoPagar.Text = string.Empty;
            }
        }

        private void txtMontoPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btn_BuscarEmpleado_Click(object sender, EventArgs e)
        {
            txtMontoPagar.Enabled = false;
            btnRegistrarPago.Enabled = false;
            empleadoActual = null;

            try
            {
                using (var unitofWork = new UnitOfWork(new ContributionContext()))
                {
                    string auxRfcEmp = txtRfcEmpleado.Text;
                    string auxNumEmp = txtNumEmpleado.Text;

                    if (auxRfcEmp == "" && auxNumEmp == "")
                    {
                        MessageBox.Show("Introduce el número del empleado o el RFC del empleado", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (auxNumEmp != "")
                        {
                            empleadoActual = unitofWork.Employees.SingleOrDefault(emp => emp.EmployeeCode == auxNumEmp);
                        }
                        else
                        {
                            empleadoActual = unitofWork.Employees.SingleOrDefault(emp => emp.RFC == auxRfcEmp);
                        }

                        if (empleadoActual != null)
                        {
                            txtNombreCompleto.Text = String.Format("{0} {1} {2}", empleadoActual.LastName, empleadoActual.MaidenName, empleadoActual.Name);
                            txtMontoPagar.Enabled = true;
                            btnRegistrarPago.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró al empleado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ocurrio un error. ERR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                empleadoActual = null;
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtRfcEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }

            if (char.IsLower(e.KeyChar)) {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
    }
}
