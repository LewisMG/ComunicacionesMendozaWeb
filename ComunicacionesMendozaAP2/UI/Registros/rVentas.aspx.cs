using DAL;
using DLN;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComunicacionesMendozaAP2.UI.Registros
{
    public partial class rVentas : System.Web.UI.Page
    {
        List<VentasDetalle> ListaDetalle = new List<VentasDetalle>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VentasGridView.DataSource = null;
                VentasGridView.DataBind();
                LlenarDropDownList();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void BindGrid()
        {
            VentasGridView.DataSource = ((Ventas)ViewState["Ventas"]).Detalle;
            VentasGridView.DataBind();
        }

        private void LlenarDropDownList()
        {
            RepositorioBase<Usuarios> usuarios = new RepositorioBase<Usuarios>();
            UsuarioDropDownList.Items.Clear();
            UsuarioDropDownList.DataSource = usuarios.GetList(x => true);
            UsuarioDropDownList.DataValueField = "UsuarioId";
            UsuarioDropDownList.DataTextField = "NombreUser";
            UsuarioDropDownList.DataBind();

            RepositorioBase<Productos> productos = new RepositorioBase<Productos>();
            ProductoDropDownList.Items.Clear();
            ProductoDropDownList.DataSource = productos.GetList(x => true);
            ProductoDropDownList.DataValueField = "ProductoId";
            ProductoDropDownList.DataTextField = "Descripcion";
            ProductoDropDownList.DataBind();

            ViewState["Ventas"] = new Ventas();
        }

        public void LimpiarCampos()
        {
            VentaIdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DescripcionTextBox.Text = "";
            UsuarioDropDownList.SelectedIndex = 0;
            ProductoDropDownList.SelectedIndex = 0;
            NClienteTextBox.Text = "";
            TClienteTextBox.Text = "";
            CantidadTextBox.Text = 0.ToString();
            PrecioTextBox.Text = 0.ToString();
            ImporteTextBox.Text = 0.ToString();
            SubTotalLabel.Text = 0.ToString();
            ItbisLabel.Text = 0.ToString();
            TotalLabel.Text = 0.ToString();
            ViewState["Ventas"] = new Ventas();
            VentasGridView.DataSource = null;
            this.BindGrid();
        }

        private Ventas LlenaClase()
        {
            Ventas ventas = new Ventas();

            ventas.VentaId = Utils.ToInt(VentaIdTextBox.Text);
            ventas.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            ventas.Descripcion = DescripcionTextBox.Text;
            ventas.UsuarioId = Utils.ToInt(UsuarioDropDownList.Text);
            ventas.NombreCliente = NClienteTextBox.Text;
            ventas.TelefonoCliente = TClienteTextBox.Text;
            ventas.SubTotal = Utils.ToInt(SubTotalLabel.Text);
            ventas.Itbis = Utils.ToInt(ItbisLabel.Text);
            ventas.Total = Utils.ToInt(TotalLabel.Text);
            ventas.Detalle = (List<VentasDetalle>)ViewState["VentasDetalle"];

            return ventas;
        }

        public void LlenarCampos(Ventas ventas)
        {
            VentaIdTextBox.Text = ventas.VentaId.ToString();
            DescripcionTextBox.Text = ventas.Descripcion;
            UsuarioDropDownList.Text = ventas.UsuarioId.ToString();
            NClienteTextBox.Text = ventas.NombreCliente.ToString();
            TClienteTextBox.Text = ventas.TelefonoCliente.ToString();
            SubTotalLabel.Text = ventas.SubTotal.ToString();
            ItbisLabel.Text = ventas.Itbis.ToString();
            TotalLabel.Text = ventas.Total.ToString();
            ViewState["VentasDetalle"] = ventas.Detalle;
            VentasGridView.DataSource = ViewState["VentasDetalle"];
            VentasGridView.DataBind();
        }

        private void LlenarImporte()
        {
            int Cantidad, Precio;

            Cantidad = Utils.ToInt(CantidadTextBox.Text);
            Precio = Utils.ToInt(PrecioTextBox.Text);
            ImporteTextBox.Text = RepositorioVentas.CalcularImporte(Precio, Cantidad).ToString();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            Ventas ventas = repositorio.Buscar(Utils.ToInt(VentaIdTextBox.Text));

            if (ventas != null)
            {
                LlenarCampos(ventas);

                Utils.ShowToastr(this, "Encontrado!!", "Exito", "info");
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
            if (Utils.ToInt(VentaIdTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }

        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            List<VentasDetalle> detalle = new List<VentasDetalle>();
            Ventas venta = new Ventas();

            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos productos = new Productos();
            int id = ToInt(ProductoDropDownList.SelectedValue);
            productos = repositorio.Buscar(id);


            if (IsValid)
            {
                if (ToInt(CantidadTextBox.Text) > productos.Inventario)
                {
                    Utils.ShowToastr(this, "no hay suficiente Productos para la venta!!", "Fallo", "error");
                }
                else
                {
                    DateTime date = DateTime.Now.Date;
                    int cantidad = Utils.ToInt(CantidadTextBox.Text);
                    int precio = Utils.ToInt(PrecioTextBox.Text);
                    int importe = Utils.ToInt(ImporteTextBox.Text);
                    int productoId = Utils.ToInt(ProductoDropDownList.SelectedValue);
                    string descripcion = ProductoDropDownList.SelectedItem.ToString();

                    if (VentasGridView.Rows.Count != 0)
                    {
                        venta.Detalle = (List<VentasDetalle>)ViewState["VentasDetalle"];
                    }
                    VentasDetalle vd = new VentasDetalle();
                    venta.Detalle.Add(new VentasDetalle(0, vd.VentaId, productoId, descripcion, cantidad, precio, importe));

                    int x = Convert.ToInt32(CantidadTextBox.Text);
                    productos.Inventario -= x;
                    if (ToInt(CantidadTextBox.Text) == 0)
                    {
                        Utils.ShowToastr(this, "Introduzca una cantidad!!", "Fallo", "error");
                    }

                    ViewState["VentasDetalle"] = venta.Detalle;
                    VentasGridView.DataSource = ViewState["VentasDetalle"];
                    VentasGridView.DataBind();
                    LlenaValores();
                }
            }

        }

        protected void ButtonRemover_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {

        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioVentas repositorio = new RepositorioVentas();
            Ventas ventas = LlenaClase();

            bool paso = false;

            if (UsuarioDropDownList != null)
            {

                if (Page.IsValid)
                {

                    if (ventas.VentaId == 0 && Utils.ToInt(TotalLabel.Text) != 0)
                    {
                        paso = repositorio.Guardar(ventas);
                    }
                    else if (Utils.ToInt(TotalLabel.Text) == 0)
                    {
                        Utils.ShowToastr(this, "Debe Agregar un producto ", "Fallo", "error");
                    }
                    else if (Utils.ToInt(VentaIdTextBox.Text) != 0)
                    {
                        var verificar = repositorio.Buscar(Utils.ToInt(VentaIdTextBox.Text));
                        if (verificar != null)
                        {
                            paso = repositorio.Modificar(ventas);
                        }
                        else
                        {
                            Utils.ShowToastr(this, "No se encuentra el ID", "Fallo", "error");
                            return;
                        }
                    }
                    if (paso)
                    {
                        Utils.ShowToastr(this, "Registro Con Exito", "Exito", "success");
                    }
                    else
                    {
                        Utils.ShowToastr(this, "No se pudo Guardar", "Fallo", "error");
                    }
                    LimpiarCampos();
                    return;
                }
            }
            else
            {
                Utils.ShowToastr(this, "El numero de cuenta no existe", "Fallo", "error");
                return;
            }
        }


        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioVentas repositorio = new RepositorioVentas();
            int id = Utils.ToInt(VentaIdTextBox.Text);

            var Ventas = repositorio.Buscar(id);

            if (Ventas != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado Exitosamente!!", "Exito", "info");
                    LimpiarCampos();
                }
                else
                    Utils.ShowToastr(this, "Fallo!! No se Puede Eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No Encontrado!!", "Error", "error");
            if (Utils.ToInt(VentaIdTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }

        protected void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            precio();
            LlenarImporte();
        }

        private void precio()
        {
            int id = Utils.ToInt(ProductoDropDownList.SelectedValue);
            RepositorioBase<Productos> productos = new RepositorioBase<Productos>();
            List<Productos> p = productos.GetList(x => x.ProductoId == id);
            foreach (var item in p)
            {
                PrecioTextBox.Text = item.Precio.ToString();
            }
        }

        protected void ProductoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            precio();
        }

        private void LlenaValores()
        {
            RepositorioVentas repositorio = new RepositorioVentas();
            decimal total = 0;
            List<VentasDetalle> lista = (List<VentasDetalle>)ViewState["VentasDetalle"];
            foreach (var item in lista)
            {
                total += item.Importe;
            }
            decimal Itbis = 0;
            decimal SubTotal = 0;

            Itbis = total * 18 / 100;
            SubTotal = total - Itbis;
            SubTotalLabel.Text = SubTotal.ToString();
            ItbisLabel.Text = Itbis.ToString();
            TotalLabel.Text = total.ToString();
        }

        private void VaciaValores()
        {
            decimal total = Utils.ToDecimal(TotalLabel.Text);
            decimal total2 = 0;
            decimal Itbis = 0;
            decimal Subtotal = 0;
            List<VentasDetalle> lista = (List<VentasDetalle>)ViewState["VentasDetalle"];
            foreach (var item in lista)
            {
                total2 = item.Importe;
            }
            total = total - total2;
            Itbis = total * 18 / 100;
            Subtotal = total - Itbis;
            SubTotalLabel.Text = Subtotal.ToString();  
            ItbisLabel.Text = Itbis.ToString();
            TotalLabel.Text = total.ToString();
        }

        private void Valores(int importe)
        {
            int Total = importe;
            double Itbis = 0;
            double SubTotal = 0;

            Itbis = Total * 0.18f;
            SubTotal = Total - Itbis;
            SubTotalLabel.Text = SubTotal.ToString();
            ItbisLabel.Text = Itbis.ToString();
            TotalLabel.Text = Total.ToString();
        }

        protected void VentasGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            VentasGridView.DataSource = ViewState["VentasDetalle"];
            VentasGridView.PageIndex = e.NewPageIndex;
            VentasGridView.DataBind();
        }

        protected void VentasGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Expression<Func<Productos, bool>> filtro = p => true;
                RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
                var lista = repositorio.GetList(c => true);
                var combos = repositorio.Buscar(lista[index].ProductoId);

                VaciaValores();
                ((List<VentasDetalle>)ViewState["VentasDetalle"]).RemoveAt(index);
                VentasGridView.DataSource = ViewState["VentasDetalle"];
                VentasGridView.DataBind();
            }
        }

        protected void VentasGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}