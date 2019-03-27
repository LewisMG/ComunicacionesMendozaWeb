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
    public partial class cEntradaProductos : System.Web.UI.Page
    {
        Expression<Func<EntradaProductos, bool>> filtro = p => true;
        RepositorioBase<EntradaProductos> repositorio = new RepositorioBase<EntradaProductos>();
        List<EntradaProductos> list = new List<EntradaProductos>();
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
            CBGridView.DataSource = Metodos.FiltrarEntradaProductos(index, CriterioTextBox.Text, desde, hasta);
            CBGridView.DataBind();

            CriterioTextBox.Text = FiltroDropDownList.Text.ToString();
        }

        public void LlenaReport()
        {
            EntradaProductosReportViewer.ProcessingMode = ProcessingMode.Local;
            EntradaProductosReportViewer.Reset();
            EntradaProductosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ListadoDeEntradaProductoss.rdlc");
            EntradaProductosReportViewer.LocalReport.DataSources.Clear();
            EntradaProductosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("EntradaProductos", list));
            EntradaProductosReportViewer.LocalReport.Refresh();
        }
    }
}