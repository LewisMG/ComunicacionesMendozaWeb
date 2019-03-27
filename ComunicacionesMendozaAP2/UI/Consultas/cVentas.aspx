<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="cVentas.aspx.cs" Inherits="ComunicacionesMendozaAP2.UI.Consultas.cVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

    <div class="jumbotron" style="background-color: #46a58b">
        <hr>
        <h5 class="display-4" style="color: #005a65; font-weight: bold;">Consulta de Ventas</h5>
        <hr>
        <div class="form-row justify-content-center">
            <div class="form-group col-md-2">
                <asp:Label Text="Filtro" ForeColor="#005a65" runat="server" Font-Bold="True" />
                <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                    <asp:ListItem>Todo</asp:ListItem>
                    <asp:ListItem>Todo por Fecha</asp:ListItem>
                    <asp:ListItem>VentaId</asp:ListItem>
                    <asp:ListItem>UsuarioId</asp:ListItem>
                    <asp:ListItem>Descripcion</asp:ListItem>
                    <asp:ListItem>NombreCliente</asp:ListItem>
                    <asp:ListItem>TelefonoCliente</asp:ListItem>
                    <asp:ListItem>SubTotal</asp:ListItem>
                    <asp:ListItem>Itbis</asp:ListItem>
                    <asp:ListItem>Total</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="Label1" runat="server" ForeColor="#005a65" Font-Bold="True">Criterio:</asp:Label>
                <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
            </div>

            <div class="col-sm-2">
                <br>
                <asp:Button ID="BtnBuscar" class="form-control btn btn-primary btn-sm" runat="server" Text="Buscar" Font-Bold="True" BackColor="#005A65" Font-Italic="True" OnClick="BtnBuscar_Click" />
            </div>
        </div>
        <div class="form-row justify-content-center">
            <div class="form-group col-md-2">
                <asp:Label Text="Desde" ForeColor="#005a65" Font-Bold="True" runat="server" />
                <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
            </div>
            <div class="form-group col-md-2">
                <asp:Label Text="Hasta" ForeColor="#005a65" Font-Bold="True" runat="server" />
                <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
            </div>
        </div>
        <hr>

        <div class="form-row justify-content-center">
            <asp:GridView ID="CBGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="#93cbd8" />
                <Columns>
                    <asp:BoundField DataField="VentaId" HeaderText="Venta Id" />
                    <asp:BoundField DataField="UsuarioId" HeaderText="Usuario Id" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="NombreCliente" HeaderText="NombreCliente" />
                    <asp:BoundField DataField="TelefonoCliente" HeaderText="TelefonoCliente" />
                    <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" />
                    <asp:BoundField DataField="Itbis" HeaderText="Itbis" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                </Columns>
                <HeaderStyle BackColor="#005a65" Font-Bold="True" />
            </asp:GridView>
        </div>
        <hr>
        <div class="card-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">
                    <button type="button"  class="btn btn-primary lg" data-toggle="modal" data-target=".bd-example-modal-lg">Imprimir</button>
                </div>
            </div>
        </div>
        <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg" style="max-width: 1000px!important; min-width: 980px!important">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Litado de Ventas</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <rsweb:ReportViewer ID="VentasReportViewer" runat="server" ProcessingMode="Remote" Height="1000px" Width="980px">
                            <ServerReport ReportPath="" ReportServerUrl="" />
                        </rsweb:ReportViewer>
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>
        <hr>
    </div>
</asp:Content>
