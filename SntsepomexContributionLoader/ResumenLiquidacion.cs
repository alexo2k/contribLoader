using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SntsepomexContributionLoader.Persistence;
using SntsepomexContributionLoader.Models;
using Microsoft.Reporting.WinForms;

namespace SntsepomexContributionLoader
{
    public partial class ResumenLiquidacion : Form
    {

        Employee searchEmployee;
        Contribution aportacionFinal;
        Contribution aportacionInicial;
        public double totalDepositos;
        public double totalRetiros;
        public double totalIntereses;
        public double numeroPeriodos;
        public double granTotal;
        public ResumenLiquidacion()
        {
            InitializeComponent();
            searchEmployee = new Employee();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            totalDepositos = 0;
            totalRetiros = 0;
            totalIntereses = 0;
            numeroPeriodos = 0;
            granTotal = 0;

            try
            {
                using (var unitOfWork = new UnitOfWork(new ContributionContext()))
                {
                    string auxRfcEmp = txtRFCEmpleado.Text;
                    string auxNumEmp = txtNumEmpleado.Text;

                    if (auxRfcEmp == "" && auxNumEmp == "")
                    {
                        MessageBox.Show("Es necesario introducir el RFC o número de empleado.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (auxNumEmp != "")
                        {
                            searchEmployee = unitOfWork.Employees.GetEmployeeWithContribs(emp => emp.EmployeeCode == auxNumEmp);
                        }
                        else if (auxRfcEmp != "")
                        {
                            searchEmployee = unitOfWork.Employees.GetEmployeeWithContribs(emp => emp.RFC == auxRfcEmp);
                        }

                        if (searchEmployee != null)
                        {
                            aportacionFinal = unitOfWork.Contributions.GetLastContribution(con => con.EmployeeId == searchEmployee.EmployeeId);
                        }

                        if (aportacionFinal != null)
                        {

                            aportacionInicial = unitOfWork.Contributions.SingleOrDefault(con => con.EmployeeId == searchEmployee.EmployeeId);

                            txtSaldoFinal.Text = String.Format("{0:C}", aportacionFinal.ContributionAccumulated);
                            txtNumEmpleado.Text = searchEmployee.EmployeeCode;
                            txtRFCEmpleado.Text = searchEmployee.RFC;
                            txtApPaterno.Text = searchEmployee.LastName;
                            txtApMaterno.Text = searchEmployee.MaidenName;
                            txtNombreEmp.Text = searchEmployee.Name;
                            txtAdscripcion.Text = searchEmployee.WorkPlace.WorkplaceDescription;

                            totalDepositos = unitOfWork.Contributions.GetTotal(searchEmployee.EmployeeId, 1);
                            totalRetiros = unitOfWork.Contributions.GetTotal(searchEmployee.EmployeeId, 2) + unitOfWork.Contributions.GetTotal(searchEmployee.EmployeeId, 5); 
                            totalIntereses = unitOfWork.Contributions.GetTotal(searchEmployee.EmployeeId, 3);
                            numeroPeriodos = unitOfWork.Contributions.TotalOfPeriods(searchEmployee.EmployeeId);
                            granTotal = unitOfWork.Contributions.GetBigTotal(searchEmployee.EmployeeId);

                            txtAportaciones.Text = String.Format("{0:C}", totalDepositos + totalRetiros);
                            txtIntereses.Text = String.Format("{0:C}", totalIntereses);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el empleado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ocurrió un error. ERR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.cleanForm();
        }

        private void cleanForm() {
            txtSaldoFinal.Text = "";
            txtNumEmpleado.Text = "";
            txtRFCEmpleado.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtNombreEmp.Text = "";
            txtAdscripcion.Text = "";
            txtRFCEmpleado.Enabled = true;
            txtNumEmpleado.Enabled = true;
            reportViewer1.Clear();
            txtAportaciones.Text = "";
            txtIntereses.Text = "";
        }

        private void ResumenLiquidacion_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                LocalReport localReport = reportViewer1.LocalReport;
                localReport.ReportPath = "EstadoDeCuenta.rdlc";

                /* nuevo codigo para ordenar*/
                //List<Contribution> contribOrderedList = searchEmployee.Contributions.ToList();
                //contribOrderedList.Sort((p, q) => p.Year.CompareTo(q.Year));

                //DataTable testDT = ContribHelpers.ToDataTable<Contribution>(contribOrderedList);
                /* termina nuevo codigo*/

                /* original */
                DataTable testDT = ContribHelpers.ToDataTable<Contribution>(searchEmployee.Contributions.ToList());
                /*Termina original*/

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ContributionDataSet", testDT));
                ReportParameter[] paramsRep = new ReportParameter[11];
                paramsRep[0] = new ReportParameter("NumEmpleado", txtNumEmpleado.Text);
                paramsRep[1] = new ReportParameter("RfcEmpleado", txtRFCEmpleado.Text);
                paramsRep[2] = new ReportParameter("NombreEmpleado", txtApPaterno.Text + " " + txtApMaterno.Text + " " + txtNombreEmp.Text);
                paramsRep[3] = new ReportParameter("MesInicial", aportacionInicial.ContributionDate.ToString("MM/yy"));
                paramsRep[4] = new ReportParameter("MesFinal", aportacionFinal.ContributionDate.ToString("MM/yy"));
                paramsRep[5] = new ReportParameter("TotalDepositos", totalDepositos.ToString());
                paramsRep[6] = new ReportParameter("TotalRetiros", (totalRetiros * -1).ToString());
                paramsRep[7] = new ReportParameter("TotalIntereses", totalIntereses.ToString());
                paramsRep[8] = new ReportParameter("SaldoPromedio", (granTotal / numeroPeriodos).ToString());
                paramsRep[9] = new ReportParameter("SaldoFinal", aportacionFinal.ContributionAccumulated.ToString());
                paramsRep[10] = new ReportParameter("FechaReporte", dtDocumento.Value.ToString());
                reportViewer1.LocalReport.SetParameters(paramsRep);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex) {
                MessageBox.Show("Ha ocurrido un error al generar el reporte. ERR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRFCEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }  
        }

        private void txtNumEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void txtRFCEmpleado_TextChanged(object sender, EventArgs e)
        {
            if (txtRFCEmpleado.Text.Length > 0)
            {
                txtNumEmpleado.Enabled = false;
            }
            else {
                txtNumEmpleado.Enabled = true;
            }
            
        }

        private void txtNumEmpleado_TextChanged(object sender, EventArgs e)
        {
            if (txtNumEmpleado.Text.Length > 0)
            {
                txtRFCEmpleado.Enabled = false;
            }
            else {
                txtRFCEmpleado.Enabled = true;
            }
        }
    }
}
