<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ComunicacionesMendozaAP2.Login" %>

<html>
<head>
    <title></title>
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <h1 class="text-center login-title">Comunicaciones Mendoza</h1>
                <div class="account-wall">
                    <div class="text-center">
                        <img class="profile-img" src="\Imagen\usuario.png"
                            alt="">
                    </div>
                    <form runat="server">
                        <br />
                        <div class="text-center">
                            <asp:TextBox ID="UsuarioTextBox" placeholder="Email" runat="server" Width="228px"></asp:TextBox>
                        </div>
                        <br />
                        <div class="text-center">
                            <asp:TextBox ID="PasswordTextBox" type="password" placeholder="Password" runat="server" Width="228px"></asp:TextBox>
                        </div>
                        <br />
                        <asp:Button runat="server" Text="Iniciar" class="btn btn-md btn-primary btn-block" OnClick="Unnamed_Click" />
                        <label class="checkbox pull-left">
                            <input type="checkbox" value="remember-me">
                            Recuerdame               
                        </label>
                        <br />
                    </form>
                </div>
                <a href="UI/Registros/rUsuarios.aspx" class="text-center new-account">Crear Cuenta </a>
            </div>
        </div>
    </div>
</body>
</html>
