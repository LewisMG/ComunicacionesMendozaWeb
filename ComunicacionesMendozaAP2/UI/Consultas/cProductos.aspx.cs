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
    public partial class cProductos : System.Web.UI.Page
    {
        Expression<Func<Productos, bool>> filtro = p => true;
        RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
        List<Productos> list = new List<Productos>();
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
            CBGridView.DataSource = Metodos.FiltrarProductos(index, CriterioTextBox.Text, desde, hasta);
            CBGridView.DataBind();

            CriterioTextBox.Text = FiltroDropDownList.Text.ToString();
        }

        public void LlenaReport()
        {
            ProductosReportViewer.ProcessingMode = ProcessingMode.Local;
            ProductosReportViewer.Reset();
            ProductosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ListadoDeProductos.rdlc");
            ProductosReportViewer.LocalReport.DataSources.Clear();
            ProductosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Productos", list));
            ProductosReportViewer.LocalReport.Refresh();
        }
    }
}