using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using SntsepomexContributionLoader.Models;
using System.Globalization;
using System.IO;
using SntsepomexContributionLoader.Persistence;

namespace SntsepomexContributionLoader
{
    public partial class CargaInicial : Form
    {
        string contributionFileName = "";

        public CargaInicial()
        {
            InitializeComponent();
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog archivoExcelDialog = new OpenFileDialog();
                archivoExcelDialog.Filter = "Archivos Excel|*.xls;*xlsx";
                archivoExcelDialog.Title = "Selecciona Archivo Excel";

                if (archivoExcelDialog.ShowDialog() == DialogResult.OK)
                {
                    contributionFileName = archivoExcelDialog.FileName;
                    btnCargar.Enabled = true;
                    FilenameTxt.Text = contributionFileName;
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ha ocurrido un error al seleccionar el archivo. ERR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            btnCargar.Enabled = false;
            btnCancelar.Enabled = false;

            string logFileName = "C:\\Development\\AportacionesLog\\" + "logEjecucion" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            if (!File.Exists(logFileName))
            {
                File.Create(logFileName).Close();
            }

            List<Employee> empleados = new List<Employee>();

            Excel.Application appExcel = new Excel.Application();
            Excel.Workbook libroExcel = appExcel.Workbooks.Open(contributionFileName, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Excel.Worksheet hojaExcel = (Excel.Worksheet)libroExcel.Worksheets[1];
            Excel.Range rangoExcel = hojaExcel.UsedRange;

            int rows = rangoExcel.Rows.Count;
            int columns = rangoExcel.Columns.Count;

            for (int x = 1; x <= rows; x++)
            {
                try
                {
                    string bufferGovernmentEntry = hojaExcel.Cells[x, 15].Text;
                    string bufferDependecyEntry = hojaExcel.Cells[x, 16].Text;

                    Employee bufferEmployee = new Employee
                    {
                        EmployeeCode = hojaExcel.Cells[x, 9].Text.Trim(),
                        LastName = hojaExcel.Cells[x, 12].Text.Trim(),
                        MaidenName = hojaExcel.Cells[x, 13].Text.Trim(),
                        Name = hojaExcel.Cells[x, 14].Text.Trim(),
                        RFC = hojaExcel.Cells[x, 10].Text.Trim(),
                        CURP = hojaExcel.Cells[x, 11].Text.Trim(),
                        GovernmentEntry = DateTime.ParseExact(bufferGovernmentEntry.Trim(), "yyyyMMdd", CultureInfo.CurrentCulture),
                        DependencyEntry = DateTime.ParseExact(bufferDependecyEntry.Trim(), "yyyyMMdd", CultureInfo.CurrentCulture),
                        WorkPlace = new Workplace
                        {
                            WorkplaceCode = hojaExcel.Cells[x, 17].Text.Trim(),
                            WorkplaceDescription = hojaExcel.Cells[x, 18].Text.Trim(),
                            WorkplaceCity = hojaExcel.Cells[x, 2].Text.Trim(),
                            WorkplaceZone = hojaExcel.Cells[x, 3].Text.Trim()
                        },
                        WorkPosition = new WorkPosition
                        {
                            WorkPositionCode = hojaExcel.Cells[x, 4].Text.Trim(),
                            WorkPositionLevel = hojaExcel.Cells[x, 7].Text.Trim(),
                            WorkPositionDescription = hojaExcel.Cells[x, 6].Text.Trim(),
                            WorkPositionType = hojaExcel.Cells[x, 8].Text.Trim()
                        }
                    };

                    Boolean isValid = validateEmployee(bufferEmployee);

                    if (isValid)
                    {
                        empleados.Add(bufferEmployee);
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter(logFileName, true))
                        {
                            sw.WriteLine("La informacion de " + bufferEmployee.Name + " " + bufferEmployee.LastName + " " + bufferEmployee.MaidenName + " con RFC " + bufferEmployee.RFC + " y numero de empleado " + bufferEmployee.EmployeeCode + " no es válida.");
                        }
                    }
                }
                catch (Exception ex) {
                    using (StreamWriter sw = new StreamWriter(logFileName, true))
                    {
                        sw.WriteLine("Ocurrio un error al añadir el registro: " + hojaExcel.Cells[x, 9].Text.Trim() + " " + ex.Message);
                    }
                }
            }


            if (empleados.Count > 1)
            {
                foreach (Employee record in empleados) {

                    using (var unitOfWork = new UnitOfWork(new ContributionContext())) {

                        Employee bufferEmployee = unitOfWork.Employees.SingleOrDefault(w => w.EmployeeCode == record.EmployeeCode);
                        Workplace bufferWorkplace = unitOfWork.Workplaces.SingleOrDefault(w => w.WorkplaceCode == record.WorkPlace.WorkplaceCode);
                        WorkPosition bufferWorkposition = unitOfWork.WorkPositions.SingleOrDefault(w => w.WorkPositionCode == record.WorkPosition.WorkPositionCode);

                        if (bufferEmployee == null)
                        {

                            Employee newEmployeeRecord = new Employee
                            {
                                EmployeeCode = record.EmployeeCode,
                                LastName = record.LastName,
                                MaidenName = record.MaidenName,
                                Name = record.Name,
                                RFC = record.RFC,
                                CURP = record.CURP,
                                GovernmentEntry = record.GovernmentEntry,
                                DependencyEntry = record.DependencyEntry,
                                WorkPlace = bufferWorkplace == null ? record.WorkPlace : bufferWorkplace,
                                WorkPosition = bufferWorkposition == null ? record.WorkPosition : bufferWorkposition
                            };

                            unitOfWork.Employees.Add(newEmployeeRecord);
                            unitOfWork.Complete();
                        }
                        else {
                            using (StreamWriter sw = new StreamWriter(logFileName, true)) {
                                sw.WriteLine(String.Format("Ya existe un empleado con el número {0} : {1}", record.EmployeeCode, record.LastName));
                            }
                        }
                    }
                }

                libroExcel.Close(0);
                appExcel.Quit();

                MessageBox.Show("Carga Terminada. Se cargaron " + empleados.Count + " registros.", "Carga completa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnCargar.Enabled = true;
                btnCancelar.Enabled = true;

            }
            else {
                using (StreamWriter sw = new StreamWriter(logFileName, true))
                {
                    sw.WriteLine("No existen registros de empleados para agregar.");
                    btnCargar.Enabled = true;
                    btnCancelar.Enabled = true;
                    MessageBox.Show("No hay registros para agregar", "Sin registros", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

        }

        private Boolean validateEmployee(Employee auxEmployee) {

            Boolean isValid = false;

            if (auxEmployee.EmployeeCode == "" || auxEmployee.LastName == "" || auxEmployee.MaidenName == "" || auxEmployee.Name == "" || auxEmployee.RFC == "" || auxEmployee.CURP == "" || 
                auxEmployee.WorkPlace.WorkplaceCity == "" || auxEmployee.WorkPlace.WorkplaceCode == "" || auxEmployee.WorkPosition.WorkPositionCode == "") {
                isValid = false;
            }
            else {
                if (auxEmployee.RFC.Length < 10 || auxEmployee.RFC.Length > 14)
                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }


            return isValid;
        }

        private void CargaInicial_Load(object sender, EventArgs e)
        {
            btnCargar.Enabled = false;
        }
    }
}
