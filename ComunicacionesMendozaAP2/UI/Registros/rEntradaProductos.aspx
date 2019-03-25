<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="rEntradaProductos.aspx.cs" Inherits="ComunicacionesMendozaAP2.UI.Registros.rEntradaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <hr>
        <h2 style="color: #3366FF">Registro Entrada de Producto</h2>
        <hr>
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group row">
                <label class="control-label col-sm-2" for="EProductoIdTextBox">Id:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="EProductoIdTextBox" Text="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EProductoIdTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="EProductoIdTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="EProductoIdTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="EProductoIdTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary btn-sm" ValidationGroup="Buscar" />
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="FechaTextBox">Fecha:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="True" />
                </div>
            </div>
            <br>
            <div class="form-group row">
                <label class="control-label col-sm-2" for="Producto">Producto:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:DropDownList class="form-control" ID="ProductoDropDownList" runat="server">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="CantidadTextBox">Cantidad:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox type="Number" class="form-control" ID="CantidadTextBox" Text="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CantidadTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo Numero!" ValidationGroup="guardar" ControlToValidate="CantidadTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="CantidadTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo Numero!" ControlToValidate="CantidadTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>              
                </div>
            </div>           
            <hr>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" class="btn btn-warning btn-sm" />
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-success btn-sm" ValidationGroup="guardar" />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" class="btn btn-danger btn-sm" ValidationGroup="Buscar" />
                    </div>
                </div>
            </div>
            <hr>
        </div>
    </div>
</asp:Content>
