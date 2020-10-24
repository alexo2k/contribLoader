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
    public partial class DatosEmpleados : Form
    {
        List<Employee> listaEmpleados;
        BindingSource dtBinding;

        public DatosEmpleados()
        {
            InitializeComponent();
            listaEmpleados = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtApMaterno.Text == "" && txtApPaterno.Text == "" && txtNombre.Text == "")
            {
                MessageBox.Show("Debes introducir un criterio de búsqueda.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                try
                {
                    using (var unitOfWork = new UnitOfWork(new ContributionContext()))
                    {
                        if (txtApPaterno.Text != "") {
                            listaEmpleados = unitOfWork.Employees.SearchEmployees(emp => emp.LastName.Contains(txtApPaterno.Text.Trim()));
                        }
                        else if (txtApMaterno.Text != "") {
                            listaEmpleados = unitOfWork.Employees.SearchEmployees(emp => emp.MaidenName.Contains(txtApMaterno.Text.Trim()));
                        }
                        else if(txtNombre.Text != "") {
                            listaEmpleados = unitOfWork.Employees.SearchEmployees(emp => emp.Name.Contains(txtNombre.Text.Trim()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error. ERR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (listaEmpleados != null)
                {
                    try
                    {
                        var auxLista = listaEmpleados.Select(emp => new { emp.EmployeeCode, emp.LastName, emp.MaidenName, emp.Name, emp.RFC, emp.CURP, emp.DependencyEntry }).ToList();

                        if (listaEmpleados.Count > 0)
                        {
                            DataTable dtEmployeesData = ContribHelpers.ToDataTable(auxLista);
                            dtEmployeesData.Columns["EmployeeCode"].ColumnName = "Numero de Empleado";
                            dtEmployeesData.Columns["LastName"].ColumnName = "Apellido Paterno";
                            dtEmployeesData.Columns["MaidenName"].ColumnName = "Apellido Materno";
                            dtEmployeesData.Columns["Name"].ColumnName = "Nombre";
                            dtEmployeesData.Columns["DependencyEntry"].ColumnName = "Fecha de Ingreso";

                            dtBinding = new BindingSource();
                            dtBinding.DataSource = dtEmployeesData;
                            dtDatosEmpleados.DataSource = dtBinding;
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron empleados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Ocurrió un error. ERR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else {
                    MessageBox.Show("No hay información asociada al empleado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DatosEmpleados_Load(object sender, EventArgs e)
        {
        }

        private void dtDatosEmpleados_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void txtApPaterno_TextChanged(object sender, EventArgs e)
        {
            if (txtApPaterno.Text != "")
            {
                txtApMaterno.Enabled = false;
                txtNombre.Enabled = false;
            }
            else {
                txtApMaterno.Enabled = true;
                txtNombre.Enabled = true;
            }
        }

        private void txtApMaterno_TextChanged(object sender, EventArgs e)
        {
            if (txtApMaterno.Text != "")
            {
                txtApPaterno.Enabled = false;
                txtNombre.Enabled = false;
            }
            else {
                txtApPaterno.Enabled = true;
                txtNombre.Enabled = true;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                txtApPaterno.Enabled = false;
                txtApMaterno.Enabled = false;
            }
            else {
                txtApPaterno.Enabled = true;
                txtApMaterno.Enabled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }

            if (char.IsLower(e.KeyChar)) {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txtApMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txtApPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtDatosEmpleados.DataSource = null;
            txtApMaterno.Text = "";
            txtApPaterno.Text = "";
            txtNombre.Text = "";
        }
    }
}
