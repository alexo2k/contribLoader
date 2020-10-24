using SntsepomexContributionLoader.Models;
using SntsepomexContributionLoader.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using SntsepomexContributionLoader;
using static SntsepomexContributionLoader.ContribHelpers;
using System.Configuration;

namespace SntsepomexContributionLoader
{
    public partial class ActualizacionQuincenal : Form
    {

        string fortnightFile = "";
        int addedRecords = 0;
        int rejectedRecords = 0;
        string directorioLog = "";

        public double calculateInterest(double saldoAcumulado, double porcentajeInteres) {
            double cetePorDia = (double)1 / (double)365;

            double interesNormalizado = porcentajeInteres / 100;
            double auxCalculo = interesNormalizado * cetePorDia * 28 * saldoAcumulado;
            return Math.Round(auxCalculo,2);
        }

        public ActualizacionQuincenal()
        {
            InitializeComponent();
            this.directorioLog = ConfigurationManager.AppSettings["rutaLog"];
        }

        private void ActualizacionQuincenal_Load(object sender, EventArgs e)
        {
            List<String> fortnightList = new List<string>();
            List<String> yearList = new List<string>();

            for (int x = 1; x <= 28; x++) {
                fortnightList.Add(x.ToString());
            }

            for (int x = 2004; x <= 2030; x++) {
                yearList.Add(x.ToString());
            }

            cmbNumQuincena.DataSource = fortnightList;
            cmbAnioQuincena.DataSource = yearList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivoExcelDialog = new OpenFileDialog();
            archivoExcelDialog.Filter = "Archivos Excel|*.xls;*xlsx";
            archivoExcelDialog.Title = "Selecciona Archivo Excel";

            if (archivoExcelDialog.ShowDialog() == DialogResult.OK) {
                fortnightFile = archivoExcelDialog.FileName;
                btnCargar.Enabled = true;
                txtFilePath.Text = fortnightFile;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            addedRecords = 0;
            rejectedRecords = 0;

            if (fortnightFile != "")
            {
                btnCancelar.Enabled = false;
                btnCargar.Enabled = false;

                string logFileName = this.directorioLog  + "\\logActQuin" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

                if (!File.Exists(logFileName))
                {
                    File.Create(logFileName).Close();
                }

                List<Contribution> contribList = new List<Contribution>();

                Excel.Application appExcel = new Excel.Application();
                Excel.Workbook libroExcel = appExcel.Workbooks.Open(fortnightFile, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Worksheet hojaExcel = (Excel.Worksheet)libroExcel.Worksheets[1];
                Excel.Range rangoExcel = hojaExcel.UsedRange;

                int rows = rangoExcel.Rows.Count;
                int columns = rangoExcel.Columns.Count;

                for (int x = 1; x <= rows; x++) {

                    try
                    {
                        string rowValue = hojaExcel.Cells[x, 1].Text.Trim();

                        if (rowValue == "#N/A")
                        {
                            using (StreamWriter sw = new StreamWriter(logFileName, true))
                            {
                                sw.WriteLine("No se pudo agregar la información de " + hojaExcel.Cells[x, 2].Text.Trim() + " que se encuentra en la fila número " + x);
                            }
                        }
                        else
                        {

                            Contribution newContribution = new Contribution
                            {

                                Employee = new Employee
                                {
                                    EmployeeCode = radNumero.Checked ? hojaExcel.Cells[x, 1].Text.Trim() : null,
                                    RFC = radRFC.Checked ? hojaExcel.Cells[x, 1].Text.Trim() : null
                                },
                                FortnightNumber = Int32.Parse(cmbNumQuincena.SelectedValue.ToString()),
                                Year = cmbAnioQuincena.SelectedValue.ToString(),
                                ContributionDate = dtpFornight.Value,
                                ContributionBalance = Double.Parse(hojaExcel.Cells[x, 3].Text.Trim())
                            };    

                            contribList.Add(newContribution);
                        }
                    }
                    catch (Exception ex) {
                        using (StreamWriter sw = new StreamWriter(logFileName, true)) {
                            sw.WriteLine("Ocurrio un error con el registro encontrado en la linea: " + x + ", no se pudo actualizar la informacion. ERR: " + ex.Message );
                        }
                    }
                }

                if (contribList.Count > 0)
                {

                    Interest interestPercentaje = null;

                    using (var unitOfWork = new UnitOfWork(new ContributionContext())) {
                        interestPercentaje = unitOfWork.Interests.SingleOrDefault(i => i.Year == cmbAnioQuincena.SelectedValue.ToString());
                    }

                    foreach (Contribution contribRecord in contribList) {

                        // Tipos de aportación 0 -> no es valido, 1 -> deposito, 2 -> retiro, 3 -> intereses, 4 -> finalizado

                        using (var unitOfWork = new UnitOfWork(new ContributionContext())) {

                            Employee auxEmployee = null;

                            try
                            {
                                if (radNumero.Checked)
                                {
                                    auxEmployee = unitOfWork.Employees.SingleOrDefault(emp => emp.EmployeeCode == contribRecord.Employee.EmployeeCode);
                                }
                                else
                                {
                                    auxEmployee = unitOfWork.Employees.SingleOrDefault(emp => emp.RFC == contribRecord.Employee.RFC);
                                }


                                if (auxEmployee != null)
                                {

                                    contribRecord.Employee = auxEmployee;
                                    Contribution previousContrib = null;
                                    Contribution auxContribution = unitOfWork.Contributions.SingleOrDefault(con => con.EmployeeId == auxEmployee.EmployeeId && con.Year == contribRecord.Year && con.FortnightNumber == contribRecord.FortnightNumber);

                                    if (auxContribution == null)
                                    {

                                        List<Contribution> interestContribList = new List<Contribution>();

                                        previousContrib = unitOfWork.Contributions.GetLastContribution(con => con.EmployeeId == auxEmployee.EmployeeId);

                                        //validar si es que no existe aportación previa, en dado caso que no exista se toma como 1era aportacion
                                        if (previousContrib != null)
                                        {
                                            int auxDaysInMonth = DateTime.DaysInMonth(previousContrib.ContributionDate.Year, previousContrib.ContributionDate.Month);
                                            DateTime interestDate = new DateTime(previousContrib.ContributionDate.Year, previousContrib.ContributionDate.Month, auxDaysInMonth);

                                            double auxAccumulatedAmount = previousContrib.ContributionAccumulated;
                                            //Interest interestPercentaje = unitOfWork.Interests.SingleOrDefault(i => i.Year == contribRecord.Year);

                                            while (interestDate < contribRecord.ContributionDate)
                                            {

                                                Contribution interestContrib = new Contribution
                                                {
                                                    Employee = auxEmployee,
                                                    FortnightNumber = null,
                                                    Year = interestDate.Year.ToString(),
                                                    ContributionDate = interestDate,
                                                    ContribType = 3
                                                };


                                                if (auxAccumulatedAmount > 0)
                                                {
                                                    interestContrib.ContributionBalance = calculateInterest(auxAccumulatedAmount, interestPercentaje.Percentage);
                                                }
                                                else {
                                                    interestContrib.ContributionBalance = 0;
                                                }
                                                
                                                interestContrib.ContributionAccumulated = auxAccumulatedAmount + interestContrib.ContributionBalance;

                                                auxAccumulatedAmount = interestContrib.ContributionAccumulated;

                                                interestContribList.Add(interestContrib);

                                                interestDate = interestDate.AddMonths(1);
                                            }

                                            if (interestContribList.Count > 0)
                                            {
                                                unitOfWork.Contributions.AddRange(interestContribList);
                                            }

                                            contribRecord.ContribType = contribRecord.ContributionBalance >= 0 ? 1 : 2;
                                            contribRecord.ContributionAccumulated = auxAccumulatedAmount + contribRecord.ContributionBalance;
                                        }
                                        else {

                                            contribRecord.ContribType = contribRecord.ContributionBalance >= 0 ? 1 : 2;
                                            contribRecord.ContributionAccumulated = contribRecord.ContributionBalance;
                                        }

                                        unitOfWork.Contributions.Add(contribRecord);
                                        unitOfWork.Complete();

                                        addedRecords++;

                                    }
                                    else {

                                        rejectedRecords++;

                                        using (StreamWriter sw = new StreamWriter(logFileName, true))
                                        {
                                            sw.WriteLine(String.Format("Ya existe registrada una aportación para el trabajador {0} en la quincena {1} del año {2}.", auxEmployee.RFC, contribRecord.FortnightNumber, contribRecord.Year));
                                        }
                                    }

                                }
                                else {

                                    rejectedRecords++;

                                    using (StreamWriter sw = new StreamWriter(logFileName, true))
                                    {
                                        sw.WriteLine("No se encontraron los datos laborales para el registro con RFC: " + contribRecord.Employee.RFC + " y número: " + contribRecord.Employee.EmployeeCode);
                                    }
                                }

                                #region Codigo Anterior
                                //if (radNumero.Checked)
                                //{
                                //    auxEmployee = unitOfWork.Employees.SingleOrDefault(emp => emp.EmployeeCode == contribRecord.Employee.EmployeeCode);
                                //}
                                //else
                                //{
                                //    auxEmployee = unitOfWork.Employees.SingleOrDefault(emp => emp.RFC == contribRecord.Employee.RFC);
                                //}

                                //if (auxEmployee != null)
                                //{

                                //    Contribution previousContrib = null;

                                //    Contribution auxContribution = unitOfWork.Contributions.SingleOrDefault(con => con.EmployeeId == auxEmployee.EmployeeId && con.Year == contribRecord.Year && con.FortnightNumber == contribRecord.FortnightNumber);


                                //    if (contribRecord.FortnightNumber == 1)
                                //    {
                                //        previousContrib = unitOfWork.Contributions.GetPrevious(contribRecord.Year);
                                //    }
                                //    else
                                //    {
                                //        previousContrib = unitOfWork.Contributions.SingleOrDefault(con => con.FortnightNumber == contribRecord.FortnightNumber - 1 && con.Year == contribRecord.Year);
                                //    }


                                //    if (auxContribution != null)
                                //    {
                                //        //Modificacion de contribucion
                                //        auxContribution.ContributionBalance = contribRecord.ContributionBalance;

                                //        if (contribRecord.CalculateInterest)
                                //        {
                                //            Interest periodInterest = unitOfWork.Interests.SingleOrDefault(i => i.Year == contribRecord.Year);
                                //            auxContribution.GeneratedInterest = previousContrib != null ? calculateInterest(previousContrib.ContributionAccumulated + contribRecord.ContributionBalance, periodInterest.Percentage) : calculateInterest(contribRecord.ContributionBalance, periodInterest.Percentage);
                                //            auxContribution.ContributionAccumulated = previousContrib != null ? previousContrib.ContributionAccumulated + contribRecord.ContributionBalance + auxContribution.GeneratedInterest : contribRecord.ContributionBalance + auxContribution.GeneratedInterest;
                                //        }
                                //        else {
                                //            auxContribution.ContributionAccumulated = previousContrib != null ? previousContrib.ContributionAccumulated + contribRecord.ContributionBalance : contribRecord.ContributionBalance;
                                //        }

                                //        modifiedRecords++;
                                //    }
                                //    else {
                                //        //Nueva contribucion
                                //        contribRecord.Employee = auxEmployee;

                                //        if (contribRecord.CalculateInterest)
                                //        {
                                //            Interest periodInterest = unitOfWork.Interests.SingleOrDefault(i => i.Year == contribRecord.Year);      
                                //            contribRecord.GeneratedInterest = previousContrib != null ? calculateInterest(previousContrib.ContributionAccumulated + contribRecord.ContributionBalance, periodInterest.Percentage) : calculateInterest(contribRecord.ContributionBalance, periodInterest.Percentage);
                                //            contribRecord.ContributionAccumulated = previousContrib != null ? previousContrib.ContributionAccumulated + contribRecord.ContributionBalance + contribRecord.GeneratedInterest : contribRecord.ContributionBalance + contribRecord.GeneratedInterest ;
                                //        }
                                //        else
                                //        {                           
                                //            contribRecord.ContributionAccumulated = previousContrib != null ? previousContrib.ContributionAccumulated + contribRecord.ContributionBalance : contribRecord.ContributionBalance;
                                //        }

                                //        addedRecords++;
                                //        unitOfWork.Contributions.Add(contribRecord);
                                //    }

                                //    unitOfWork.Complete();
                                //}
                                //else
                                //{

                                //    rejectedRecords++;

                                //    using (StreamWriter sw = new StreamWriter(logFileName, true))
                                //    {
                                //        sw.WriteLine("No se encontraron los datos laborales para el registro con RFC: " + contribRecord.Employee.RFC + " y número: " + contribRecord.Employee.EmployeeCode);
                                //    }
                                //}
                                #endregion
                            }
                            catch (Exception ex) {
                                rejectedRecords++;
                                using (StreamWriter sw = new StreamWriter(logFileName, true)) {
                                    sw.WriteLine("Ha ocurrido un error al guardar el acumulado de " + auxEmployee.EmployeeCode + ". ERR: " + ex.Message);
                                }
                            }
                        }
                    }

                    MessageBox.Show(string.Format("Ha finalizado la actualización: {0} Registros en Total: {1} Agregado(s). {2} Rechazado(s).", contribList.Count(), addedRecords, rejectedRecords), "Proceso finalizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    btnCancelar.Enabled = true;
                    btnCargar.Enabled = true;
                }
                else {
                    MessageBox.Show("No hay registros para agregar.", "Sin registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCancelar.Enabled = true;
                    btnCargar.Enabled = true;
                }

                libroExcel.Close(0);
                appExcel.Quit();


            }
            else {
                MessageBox.Show("No hay archivo seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLastFortnight_Click(object sender, EventArgs e)
        {
            string lastFortnight = "";
            string lastYear = "";

            try
            {
                using (var unitOfWork = new UnitOfWork(new ContributionContext()))
                {
                    Contribution auxLastContrib = unitOfWork.Contributions.GetLastContribution(con => con.ContribType == 1);
                    lastFortnight = auxLastContrib.FortnightNumber.ToString();
                    lastYear = auxLastContrib.Year;
                }

                MessageBox.Show(String.Format("La última quincena cargada fue la numero {0} del año {1}", lastFortnight, lastYear), "Última carga", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(String.Format("Ocurrió un error al conectarse a la BD. ERR:{0}", ex.Message), "Error en conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
