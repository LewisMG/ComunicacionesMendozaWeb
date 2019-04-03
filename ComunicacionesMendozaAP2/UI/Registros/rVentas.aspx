<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="rVentas.aspx.cs" Inherits="ComunicacionesMendozaAP2.UI.Registros.rVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <hr>
        <h2 style="color: #005a65">Registro de Venta</h2>
        <hr>
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group row">
                <label class="control-label col-sm-2" for="VentaIdTextBox">Venta ID:</label>
                <div class="col-sm-1 col-md-2 col-xs4">
                    <asp:TextBox type="Number" class="form-control" ID="VentaIdTextBox" placeholder="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="VentaIdTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="VentaIdTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="VentaIdTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="VentaIdTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
                <div class="col-sm-1 col-md-1 col-xs-2">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" ValidationGroup="Buscar" OnClick="BuscarButton_Click" />
                </div>
                <div>
                    <label class="control-label col-sm-3" for="FechaTextBox">Fecha:</label>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <div class="col-sm-1 col-md-2 col-xs4">
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="True" />
                </div>
            </div>
            <br>
            <div class="form-group row">
                <label class="control-label col-sm-2" for="UsuarioTextBox">Usuario:</label>
                <div class="col-sm-1 col-md-3 col-xs4">
                    <asp:DropDownList class="form-control" ID="UsuarioDropDownList" runat="server"></asp:DropDownList>
                </div>
                <div>
                    <label class="control-label col-sm-1 col-md-2 col-xs4" for="DescripcionTextBox">Descripcion:</label>
                </div>
                <div class="col-sm-1 col-md-3">
                    <asp:TextBox type="text" class="form-control" ID="DescripcionTextBox" placeholder="Ingrese Descripcion" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese alguna Descripcion!" ValidationGroup="guardar" ControlToValidate="DescripcionTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ingrese alguna Descripcion!" ControlToValidate="DescripcionTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="NClienteTextBox">Nombre Cliente:</label>
                <div class="col-sm-1 col-md-3 col-xs4">
                    <asp:TextBox type="Text" class="form-control" ID="NClienteTextBox" placeholder="Ingrese un nombre" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NClienteTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun Nombre!" ValidationGroup="guardar" ControlToValidate="NClienteTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="NClienteTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese algun Nombre!" ControlToValidate="NClienteTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <label class="control-label col-sm-1 col-md-2 col-xs4" for="TClienteTextBox">Telefono:</label>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <div class="col-sm-1 col-md-3">
                    <asp:TextBox type="Text" class="form-control" ID="TClienteTextBox" placeholder="Ingrese Telefono" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="TClienteTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun telefono!" ValidationGroup="guardar" ControlToValidate="TClienteTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="TClienteTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="TClienteTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
            </div>
            <hr>
            <div class="form-row">
                <div class="form-group col-md-2">
                    <asp:Label ID="Label3" runat="server" Text="Producto:"></asp:Label>
                    <asp:DropDownList class="form-control" ID="ProductoDropDownList" runat="server" Width="240px" OnSelectedIndexChanged="ProductoDropDownList_SelectedIndexChanged"></asp:DropDownList>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <div class="form-group col-md-2">
                    <asp:Label ID="Label1" runat="server" Text="Cantidad:"></asp:Label>
                    <asp:TextBox class="form-control" type="Number" ID="CantidadTextBox" AutoPostBack="true" placeholder="0" runat="server" Width="150px" OnTextChanged="CantidadTextBox_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="CantidadTextBox" ValidationGroup="guardar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="CantidadTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group col-md-2">
                    <asp:Label ID="Label2" runat="server" Text="Precio:"></asp:Label>
                    <asp:TextBox class="form-control" type="Number" ID="PrecioTextBox" AutoPostBack="true" placeholder="0" runat="server" ReadOnly="true" Width="150px"></asp:TextBox>
                </div>
                <div class="form-group col-md-1">
                    <asp:Label ID="Label8" runat="server" Text="Importe:"></asp:Label>
                    <asp:TextBox class="form-control" type="Number" ID="ImporteTextBox" AutoPostBack="true" placeholder="0" runat="server" ReadOnly="true" Width="150px"></asp:TextBox>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <div class="col-lg-0 p-4">
                    <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar" class="btn btn-info" OnClick="ButtonAgregar_Click" />
                </div>
            </div>
            <hr>
            <div class="col row">
                <asp:GridView ID="VentasGridView" runat="server" class="table table-condensed table-bordered table-responsive" CellPadding="4" ForeColor="#0066FF" GridLines="None" OnPageIndexChanging="VentasGridView_PageIndexChanging" OnRowCommand="VentasGridView_RowCommand" OnSelectedIndexChanged="VentasGridView_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#999999" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False" HeaderText="Opciones">
                            <ItemTemplate>
                                <asp:Button ID="Remover" runat="server" CausesValidation="false" CommandName="Select" CommandArgument="<%# ((GridViewRow) Container).DataItemIndex %>"
                                    Text="Remover" class="btn btn-danger btn-sm"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#005a65" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#005a65" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
            <hr>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Label ID="NombreLabel" runat="server" Text="SubTotal:" Font-Bold="True" Font-Italic="True"></asp:Label>
                        <asp:Label ID="SubTotalLabel" runat="server" AutoPostback="true" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" Text="Itbis 18%:" Font-Bold="True" Font-Italic="True"></asp:Label>
                        <asp:Label ID="ItbisLabel" runat="server" AutoPostback="true" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label6" runat="server" Text="Total:" Font-Bold="True" Font-Italic="True"></asp:Label>
                        <asp:Label ID="TotalLabel" runat="server" AutoPostback="true" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="ButtonImprimir" runat="server" Text="Imprimir" class="btn btn-success btn-sm" OnClick="ButtonImprimir_Click" />
                    </div>
                </div>
            </div>
            <hr>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" class="btn btn-warning" OnClick="BtnNuevo_Click" />
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="guardar" OnClick="BtnGuardar_Click" />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" ValidationGroup="Buscar" OnClick="BtnEliminar_Click" />
                    </div>
                </div>
            </div>
            <hr>
        </div>
    </div>
</asp:Content>
