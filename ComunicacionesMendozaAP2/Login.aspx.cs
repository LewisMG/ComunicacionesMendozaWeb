using ComunicacionesMendozaAP2.UI.Registros;
using DLN;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComunicacionesMendozaAP2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            RepositorioLogin repositorio = new RepositorioLogin();

            if (UsuarioTextBox.Text.Length > 0 && PasswordTextBox.Text.Length > 0)
            {
                if (repositorio.Auntenticar(UsuarioTextBox.Text, PasswordTextBox.Text))
                {
                    FormsAuthentication.RedirectFromLoginPage(user.NombreUser, true);
                }
                else
                    Utils.ShowToastr(this.Page, "Usuario o contraseña Incorrecta", "Error", "error");
            }
            else
            {
                Utils.ShowToastr(this.Page, "Introduzca Usuario & Contraseña", "Error", "error");
            }
        }
    }
}