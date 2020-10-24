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

    public partial class Principal : Form
    {

        private Boolean isAdmin;
        public Principal(string pUsuario)
        {
            isAdmin = pUsuario == "Administrador" ? true : false;
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            #region CodigoPrueba
            //using (var unitOfWork = new UnitOfWork(new ContributionContext())) {
            //    var test = unitOfWork.Interests.GetAll();
            //}

            //using (ContributionContext dbContext = new ContributionContext()) {

            //    Interest interest = new Interest
            //    {
            //        Year = "2012",
            //        Percentage = 5.22
            //    };

            //    dbContext.Interests.Add(interest);

            //    dbContext.SaveChanges();
            //}
            #endregion

            if (!isAdmin) {
                btnActualizacionQ.Enabled = false;
                btnCargaInicial.Enabled = false;
                btnCargaManual.Enabled = false;
                btnParametros.Enabled = false;
                btnPagoParcialForm.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargaInicial cargaInicialForm = new CargaInicial();
            cargaInicialForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CargaEmpleados cargaEmpleados = new CargaEmpleados();
            cargaEmpleados.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActualizacionQuincenal formActualizacion = new ActualizacionQuincenal();
            formActualizacion.ShowDialog();
        }

        private void btnParametros_Click(object sender, EventArgs e)
        {
            ActualizacionParametros formActParametros = new ActualizacionParametros();
            formActParametros.ShowDialog();
        }

        private void btn_ResumenLiquidacion_Click(object sender, EventArgs e)
        {
            ResumenLiquidacion formResumenLiquidacion = new ResumenLiquidacion();
            formResumenLiquidacion.ShowDialog();
        }

        private void btnPagoParcialForm_Click(object sender, EventArgs e)
        {
            PagoParcial formPagoParcial = new PagoParcial();
            formPagoParcial.ShowDialog();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            DatosEmpleados formEmpleados = new DatosEmpleados();
            formEmpleados.ShowDialog();
        }

        private void btn_reporteSaldos_Click(object sender, EventArgs e)
        {
            ReporteSaldos reporteForms = new ReporteSaldos();
            reporteForms.ShowDialog();
        }
    }
}
