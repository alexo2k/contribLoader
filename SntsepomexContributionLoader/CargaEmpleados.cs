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
    public partial class CargaEmpleados : Form
    {
        public CargaEmpleados()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtRfcEmp_TextChanged(object sender, EventArgs e)
        {

        }

        private void CargaEmpleados_Load(object sender, EventArgs e)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ContributionContext()))
                {

                    var workPlacesList = unitOfWork.Workplaces.GetWorkplacesByOrder();
                    var workPositionList = unitOfWork.WorkPositions.GetPositionOrdered();

                    if (workPositionList.Count() > 0)
                    {
                        cmbWorkPosition.DataSource = workPositionList;
                        cmbWorkPosition.ValueMember = "WorkPositionId";
                        cmbWorkPosition.DisplayMember = "WorkPositionDescription";
                        cmbWorkPosition.SelectedItem = 1;
                    }

                    if (workPlacesList.Count() > 0)
                    {
                        cmbWorkPlace.DataSource = workPlacesList;
                        cmbWorkPlace.ValueMember = "WorkplaceId";
                        cmbWorkPlace.DisplayMember = "WorkplaceDescription";
                        cmbWorkPlace.SelectedItem = 1;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ocurrió un error al recuperar datos desde la BD. ERR: " + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancelEmp_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSaveEmp_Click(object sender, EventArgs e)
        {

            if (cmbWorkPlace.Items.Count != 0 && cmbWorkPosition.Items.Count != 0)
            {

                Workplace auxSelectedWorkPlace = (Workplace)(cmbWorkPlace.SelectedItem);
                WorkPosition auxSelectedWorkPosition = (WorkPosition)(cmbWorkPosition.SelectedItem);

                if (txtClaveEmp.Text != "" && txtCurpEmp.Text != "" && txtLastNameEmp.Text != "" && txtNameEmp.Text != "")
                {
                    Employee newRecord = new Employee
                    {
                        EmployeeCode = txtClaveEmp.Text,
                        LastName = txtLastNameEmp.Text,
                        MaidenName = txtMaidenNameEmp.Text,
                        Name = txtNameEmp.Text,
                        RFC = txtRfcEmp.Text,
                        CURP = txtCurpEmp.Text,
                        WorkPlace = null,
                        WorkPosition = null,
                        GovernmentEntry = dtpGobierno.Value,
                        DependencyEntry = dtpDependencia.Value
                    };

                    using (UnitOfWork unitOfWork = new UnitOfWork(new ContributionContext()))
                    {

                        newRecord.WorkPlace = unitOfWork.Workplaces.SingleOrDefault(wpl => wpl.WorkplaceId == auxSelectedWorkPlace.WorkplaceId);
                        newRecord.WorkPosition = unitOfWork.WorkPositions.SingleOrDefault(wps => wps.WorkPositionId == auxSelectedWorkPosition.WorkPositionId);

                        var auxEmployee = unitOfWork.Employees.SingleOrDefault(a => a.EmployeeCode == newRecord.EmployeeCode);

                        if (auxEmployee == null)
                        {
                            try
                            {
                                unitOfWork.Employees.Add(newRecord);
                                unitOfWork.Complete();

                                MessageBox.Show("El registro fue guardado con éxito. Se almacenó el empleado con número: " + newRecord.EmployeeCode, "Almacenado con éxito.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                btnClearEmp.PerformClick();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ocurrió un error al guardar el registro: " + ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                        else
                        {
                            MessageBox.Show("Ya existe un empleado con esa clave: " + auxEmployee.LastName + " " + auxEmployee.Name + ". RFC: " + auxEmployee.RFC, "Registro duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La información no está completa, por favor valida que los datos esten completos.", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else {
                MessageBox.Show("Los datos no han sido completados.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnClearEmp_Click(object sender, EventArgs e)
        {
            txtClaveEmp.Text = "";
            txtCurpEmp.Text = "";
            txtLastNameEmp.Text = "";
            txtMaidenNameEmp.Text = "";
            txtNameEmp.Text = "";
            txtRfcEmp.Text = "";
        }

        private void txtLastNameEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void txtMaidenNameEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNameEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRfcEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCurpEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtClaveEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}
