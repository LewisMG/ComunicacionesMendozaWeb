using DLN;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComunicacionesMendozaAP2.UI.Registros
{
    public partial class rProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void LimpiarCampos()
        {
            ProductoIdTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DescripcionTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            GananciaTextBox.Text = string.Empty;
            InventarioTextBox.Text = string.Empty;
        }

        private void LlenaCampos(Productos productos)
        {
            ProductoIdTextBox.Text = productos.ProductoId.ToString();
            FechaTextBox.Text = productos.Fecha.ToString();
            DescripcionTextBox.Text = productos.Descripcion;
            CostoTextBox.Text = productos.Costo.ToString();
            PrecioTextBox.Text = productos.Precio.ToString();
            GananciaTextBox.Text = productos.Ganancia.ToString();
            InventarioTextBox.Text = productos.Inventario.ToString();
        }

        private Productos LlenaClase()
        {
            Productos p = new Productos();

            p.ProductoId = Utils.ToInt(ProductoIdTextBox.Text);
            p.Fecha = Convert.ToDateTime(FechaTextBox.Text).Date;
            p.Descripcion = DescripcionTextBox.Text;
            p.Costo = Utils.ToInt(CostoTextBox.Text);
            p.Precio = Utils.ToInt(PrecioTextBox.Text);
            p.Ganancia = Utils.ToInt(GananciaTextBox.Text);
            p.Inventario = Utils.ToInt(InventarioTextBox.Text);

            return p;
        }

        protected void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal costo = Convert.ToInt32(CostoTextBox.Text);
            decimal precio = Convert.ToInt32(PrecioTextBox.Text);

            if (costo > precio)
            {
                Utils.ShowToastr(this, "No puede tener más alto el costo que el precio", "Error Perdida!", "error");
                return;
            }
            else
                GananciaTextBox.Text = Metodos.CalcularGanancia(costo, precio).ToString();
        }


        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos p = repositorio.Buscar(Utils.ToInt(ProductoIdTextBox.Text));

            if (p != null)
            {
                LimpiarCampos();
                LlenaCampos(p);
                Utils.ShowToastr(this, "Encontrado!!", "Exito", "info");
            }
            else
            {
                LimpiarCampos();
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
            if (Utils.ToInt(ProductoIdTextBox.Text) == 0)
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
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos p = new Productos();
            bool paso = false;

            p = LlenaClase();

            if (p.ProductoId == 0)
            {
                paso = repositorio.Guardar(p);
                Utils.ShowToastr(this, "Guardado Exitosamente!!", "Exito", "success");
                LimpiarCampos();
            }
            else
            {
                Productos user = new Productos();
                int id = Utils.ToInt(ProductoIdTextBox.Text);
                RepositorioBase<Productos> repository = new RepositorioBase<Productos>();
                p = repository.Buscar(id);

                if (user != null)
                {
                    paso = repositorio.Modificar(LlenaClase());
                    Utils.ShowToastr(this, "Modificado Exitosamente!!", "Exito", "success");
                }
                else
                    Utils.ShowToastr(this, "No Encontrado!!", "Error", "error");
            }

            if (paso)
            {
                LimpiarCampos();
            }
            else
                Utils.ShowToastr(this, "Fallo!! no ha podido Guardar", "Error", "error");
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            int id = Utils.ToInt(ProductoIdTextBox.Text);

            var Productos = repositorio.Buscar(id);

            if (Productos != null)
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
        }
    }
}