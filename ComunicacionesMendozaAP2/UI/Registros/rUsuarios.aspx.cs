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
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void LimpiarCampos()
        {
            UsuarioIdTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = string.Empty;
            NombreUserTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CorreoTextBox.Text = string.Empty;
            ContraseñaTextBox.Text = string.Empty;
            VContraseñaTextBox.Text = string.Empty;
            TotalVendidoTextBox.Text = string.Empty;
        }

        private void LlenaCampos(Usuarios usuarios)
        {
            UsuarioIdTextBox.Text = usuarios.UsuarioId.ToString();
            FechaTextBox.Text = usuarios.Fecha.ToString();
            NombreTextBox.Text = usuarios.Nombres;
            NombreUserTextBox.Text = usuarios.NombreUser.ToString();
            CedulaTextBox.Text = usuarios.Cedula.ToString();
            TelefonoTextBox.Text = usuarios.Telefono.ToString();
            CorreoTextBox.Text = usuarios.Correo.ToString();
            ContraseñaTextBox.Text = usuarios.Clave.ToString();
            VContraseñaTextBox.Text = usuarios.Clave.ToString();
            TotalVendidoTextBox.Text = usuarios.TotalVendido.ToString();
        }

        private Usuarios LlenaClase()
        {
            Usuarios u = new Usuarios();

            u.UsuarioId = Utils.ToInt(UsuarioIdTextBox.Text);
            u.Fecha = Convert.ToDateTime(FechaTextBox.Text).Date;
            u.Nombres = NombreTextBox.Text;
            u.NombreUser = NombreUserTextBox.Text;
            u.Cedula = CedulaTextBox.Text;
            u.Telefono = TelefonoTextBox.Text;
            u.Correo = CorreoTextBox.Text;
            u.Clave = ContraseñaTextBox.Text;
            u.TotalVendido = Utils.ToDecimal(TotalVendidoTextBox.Text);

            return u;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios u = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));

            if (u != null)
            {
                LimpiarCampos();
                LlenaCampos(u);
                Utils.ShowToastr(this, "Encontrado!!", "Exito", "info");
            }
            else
            {
                LimpiarCampos();
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
            if (Utils.ToInt(UsuarioIdTextBox.Text) == 0)
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
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios u = new Usuarios();
            bool paso = false;

            if (Verificar())
            {
                Utils.ShowToastr(this, "Solo Letras en Nombre y NombreUsuario!", "Error", "error");
                return;
            }
            u = LlenaClase();

            if (ContraseñaTextBox.Text == VContraseñaTextBox.Text)
            {
                if (u.UsuarioId == 0)
                {
                    paso = repositorio.Guardar(u);
                    Utils.ShowToastr(this, "Guardado Exitosamente!!", "Exito", "success");
                    LimpiarCampos();
                }
                else
                {
                    Usuarios user = new Usuarios();
                    int id = Utils.ToInt(UsuarioIdTextBox.Text);
                    RepositorioBase<Usuarios> repository = new RepositorioBase<Usuarios>();
                    u = repository.Buscar(id);

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
            else
                Utils.ShowToastr(this, "Fallo!! Contraseña no coinciden", "Error", "error");
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            int id = Utils.ToInt(UsuarioIdTextBox.Text);

            var Usuarios = repositorio.Buscar(id);

            if (Usuarios != null)
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

        private bool Verificar()
        {
            bool paso = false;
            bool resultado = Regex.IsMatch(NombreTextBox.Text, @"^[a-z A-Z]+$");
            bool resultado1 = Regex.IsMatch(NombreUserTextBox.Text, @"^[a-z A-Z]+$");

            if (!resultado)
            {
                resultado = Regex.IsMatch(NombreTextBox.Text, @"^[a-z A-Z]+$");
                if (resultado)
                {
                    paso = false;
                }
                else
                {
                    paso = true;
                    Utils.ShowToastr(this, "Solo Letras en Nombre y NombreUsuario!", "Error", "error");
                }
                Utils.ShowToastr(this, "Solo Letras en Nombre y NombreUsuario!", "Error", "error");
                paso = true;
            }

            if (!resultado1)
            {
                resultado1 = Regex.IsMatch(NombreUserTextBox.Text, @"^[a-z A-Z]+$");
                if (resultado1)
                {
                    paso = false;
                }
                else
                {
                    paso = true;
                    Utils.ShowToastr(this, "Solo Letras en Nombre y NombreUsuario!", "Error", "error");
                }
                Utils.ShowToastr(this, "Solo Letras en Nombre y NombreUsuario!", "Error", "error");
                paso = true;
            }

            return paso;
        }
    }
}