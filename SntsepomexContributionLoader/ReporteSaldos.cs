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
using SntsepomexContributionLoader.Repositories;
using System.IO;

namespace SntsepomexContributionLoader
{
    public partial class ReporteSaldos : Form
    {
        public ReporteSaldos()
        {
            InitializeComponent();
        }

        SaveFileDialog saveFileDialog;

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            List<ContributionExcelModel> listaEmpleados = new List<ContributionExcelModel>();

            try
            {
                using (var unitOfWork = new UnitOfWork(new ContributionContext()))
                {
                    Contribution currentContrib = unitOfWork.Contributions.GetLastContribution(con => con.ContribType == 1);
                    string currentYear = currentContrib.Year;
                    int currentFornight = currentContrib.FortnightNumber ?? default(int);

                    if (currentYear != null && currentFornight != 0)
                    {
                        listaEmpleados = unitOfWork.Contributions.GetExcelReport(currentYear, currentFornight).ToList();

                        using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, true))
                        {
                            sw.WriteLine("Id de Empleado," + "Apellido Paterno," + "Apellido Materno," + "Nombre," + "RFC," + "CURP," + "Numero Empleado," + "Aportacion Mensual," 
                                + "Acumulado," + "Fecha de Aportacion," + "Anio de aportacion," + "Numero Aportacion," + "Tipo de Aportacion");

                            foreach (var joinedElement in listaEmpleados)
                            {
                                sw.WriteLine(joinedElement.EmployeeId + "," + joinedElement.LastName + "," + joinedElement.MaidenName + "," + joinedElement.Name + "," + joinedElement.RFC + ","
                                    + joinedElement.CURP + "," + joinedElement.EmployeeCode + "," + joinedElement.ContribBalance + "," + joinedElement.ContribAccumulated + "," + joinedElement.ContribDate + ","
                                    + joinedElement.Year + "," + joinedElement.FornightNumber + "," + joinedElement.ContribType);
                            }
                        }
                        MessageBox.Show("Archivo creado con éxito", "Exportación lista", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ha ocurrido un error. ERR:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV File|.csv";
            saveFileDialog.Title = "Nombre del reporte excel";
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.ShowDialog();

            if(saveFileDialog.FileName != "") {
                txtRuta.Text = saveFileDialog.FileName;
                btnGenerar.Enabled = true;
            }

        }
    }
}
