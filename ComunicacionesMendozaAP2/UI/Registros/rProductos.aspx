<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="rProductos.aspx.cs" Inherits="ComunicacionesMendozaAP2.UI.Registros.rProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <hr>
        <h2 style="color: #005a65">Registro Productos</h2>
        <hr>
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group row">
                <label class="control-label col-sm-2" for="ProductoIdTextBox">Id:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="ProductoIdTextBox" Text="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ProductoIdTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="ProductoIdTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ProductoIdTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="ProductoIdTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" class="btn btn-primary btn-sm" ValidationGroup="Buscar" OnClick="BtnBuscar_Click" />
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
                <label class="control-label col-sm-2" for="DescripcionTextBox">Descripcion:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox type="text" class="form-control" ID="DescripcionTextBox" placeholder="Ingrese Descripcion" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="DescripcionTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese alguna descripcion!" ValidationGroup="guardar" ControlToValidate="DescripcionTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="DescripcionTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese alguna descripcion!" ControlToValidate="DescripcionTextBox" ValidationExpression="(^[a-zA-Z0-9'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="CostoTextBox">Costo:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox type="Number" class="form-control" ID="CostoTextBox" placeholder="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CostoTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo Numero!" ValidationGroup="guardar" ControlToValidate="CostoTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="CostoTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo Numero!" ControlToValidate="CostoTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>              
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="PrecioTextBox">Precio:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox type="Number" class="form-control" ID="PrecioTextBox" AutoPostback="true" placeholder="0" runat="server" OnTextChanged="PrecioTextBox_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PrecioTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo Numero!" ValidationGroup="guardar" ControlToValidate="PrecioTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="PrecioTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo Numero!" ControlToValidate="PrecioTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>              
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="GananciaTextBox">Ganancia:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox type="Number" class="form-control" ID="GananciaTextBox" AutoPostback="true" placeholder="0" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <br>
            <div class="form-group row">
                <label class="control-label col-sm-2" for="InventarioTextBox">Inventario:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox type="Number" class="form-control" ID="InventarioTextBox" placeholder="0" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <hr>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" class="btn btn-warning btn-sm" OnClick="BtnNuevo_Click" />
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-success btn-sm" ValidationGroup="guardar" OnClick="BtnGuardar_Click" />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" class="btn btn-danger btn-sm" ValidationGroup="Buscar" OnClick="BtnEliminar_Click" />
                    </div>
                </div>
            </div>
            <hr>
        </div>
    </div>
</asp:Content>
