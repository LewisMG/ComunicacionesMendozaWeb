using DLN;
using Entities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComunicacionesMendozaAP2.UI.Consultas
{
    public partial class cVentas : System.Web.UI.Page
    {
        Expression<Func<Ventas, bool>> filtro = p => true;
        RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
        List<Ventas> list = new List<Ventas>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                list = repositorio.GetList(filtro);
                LlenaReport();
            }
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(CriterioTextBox.Text);
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            DateTime desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Utils.ToDateTime(HastaTextBox.Text);
            CBGridView.DataSource = Metodos.FiltrarVentas(index, CriterioTextBox.Text, desde, hasta);
            CBGridView.DataBind();

            CriterioTextBox.Text = FiltroDropDownList.Text.ToString();
        }

        public void LlenaReport()
        {
            VentasReportViewer.ProcessingMode = ProcessingMode.Local;
            VentasReportViewer.Reset();
            VentasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ListadoDeVentas.rdlc");
            VentasReportViewer.LocalReport.DataSources.Clear();
            VentasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Ventas", list));
            VentasReportViewer.LocalReport.Refresh();
        }
    }
}