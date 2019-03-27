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
    public partial class cUsuarios : System.Web.UI.Page
    {
        Expression<Func<Usuarios, bool>> filtro = p => true;
        RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
        List<Usuarios> list = new List<Usuarios>();
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
            CBGridView.DataSource = Metodos.FiltrarUsuarios(index, CriterioTextBox.Text, desde, hasta);
            CBGridView.DataBind();

            CriterioTextBox.Text = FiltroDropDownList.Text.ToString();
        }

        public void LlenaReport()
        {
            UsuariosReportViewer.ProcessingMode = ProcessingMode.Local;
            UsuariosReportViewer.Reset();
            UsuariosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ListadoDeUsuario.rdlc");
            UsuariosReportViewer.LocalReport.DataSources.Clear();
            UsuariosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Usuarios", list));
            UsuariosReportViewer.LocalReport.Refresh();
        }
    }
}