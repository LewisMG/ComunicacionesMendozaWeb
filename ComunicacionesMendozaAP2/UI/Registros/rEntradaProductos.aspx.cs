using DLN;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComunicacionesMendozaAP2.UI.Registros
{
    public partial class rEntradaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarDropDownList();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                EProductoIdTextBox.Text = "0";
            }
        }

        private void LimpiarCampos()
        {
            EProductoIdTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ProductoDropDownList.SelectedIndex = 0;
            CantidadTextBox.Text = "";
        }

        public void LlenarCampos(EntradaProductos eProducto)
        {
            LimpiarCampos();
            EProductoIdTextBox.Text = eProducto.EntradapId.ToString();
            FechaTextBox.Text = eProducto.Fecha.ToString("dd-MM-yyyy");
            ProductoDropDownList.Text = Convert.ToString(eProducto.ProductoId);
            CantidadTextBox.Text = eProducto.Cantidad.ToString();
        }

        private void LlenarDropDownList()
        {
            RepositorioBase<Productos> productos = new RepositorioBase<Productos>();
            ProductoDropDownList.Items.Clear();
            ProductoDropDownList.DataSource = productos.GetList(x => true);
            ProductoDropDownList.DataValueField = "ProductoId";
            ProductoDropDownList.DataTextField = "Descripcion";
            ProductoDropDownList.DataBind();
        }

        private EntradaProductos LlenaClase()
        {
            EntradaProductos eProducto = new EntradaProductos();

            eProducto.EntradapId = Utils.ToInt(EProductoIdTextBox.Text);
            eProducto.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            eProducto.ProductoId = Utils.ToInt(ProductoDropDownList.Text);
            eProducto.Cantidad = Utils.ToInt(CantidadTextBox.Text);

            return eProducto;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<EntradaProductos> repositorio = new RepositorioBase<EntradaProductos>();
            EntradaProductos eProducto = repositorio.Buscar(Utils.ToInt(EProductoIdTextBox.Text));

            if (eProducto != null)
            {
                LlenarCampos(eProducto);

                Utils.ShowToastr(this, "Encontrado!!", "Exito", "info");
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
            if (Utils.ToInt(EProductoIdTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            EntradaProductosBLL repositorio = new EntradaProductosBLL();
            EntradaProductos eProductos = LlenaClase();
            RepositorioBase<Productos> productos = new RepositorioBase<Productos>();

            bool paso = false;           

            if (ProductoDropDownList != null)
            {
                if (Page.IsValid)
                {
                    if(EProductoIdTextBox.Text == "0")
                    {
                        paso = repositorio.Guardar(eProductos);
                    }
                    else
                    {
                        var verificar = repositorio.Buscar(Utils.ToInt(EProductoIdTextBox.Text));
                        if (verificar != null)
                        {
                            paso = repositorio.Modificar(eProductos);
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
            RepositorioBase<EntradaProductos> repositorio = new RepositorioBase<EntradaProductos>();
            int id = Utils.ToInt(EProductoIdTextBox.Text);

            var EntradaProductos = repositorio.Buscar(id);

            if (EntradaProductos != null)
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
            if (Utils.ToInt(EProductoIdTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }
    }
}