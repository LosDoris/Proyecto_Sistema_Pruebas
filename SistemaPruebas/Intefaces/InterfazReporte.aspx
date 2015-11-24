<%@ Page EnableEventValidation="false" Title="Generar Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazReporte.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazReporte" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <legend style="margin-top: 45px">
        <h2>Generar Reportes</h2>
    </legend>

    <style type="text/css">
        .modalBackground {
            background-color: black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #ffffff;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
        }
    </style>

    <link rel="stylesheet" type="text/css" media="screen"
        href="http://tarruda.github.com/bootstrap-datetimepicker/assets/css/bootstrap-datetimepicker.min.css">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">

    <script type="text/javascript">
        function HideLabel() {
            var seconds = 5;
            setTimeout(function () {

            }, 2000);
        };
    </script>
    <div style="margin-top: 45px; margin-bottom: 0px" class="well">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Proyecto</h3>
            </div>
            <div class="panel-body">
                <div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-horizontal">
                                <asp:GridView ID="GridPP" runat="server" OnSelectedIndexChanged="PP_SelectedIndexChanged" OnPageIndexChanging="PP_OnPageIndexChanging"
                                    OnRowDataBound="PP_OnRowDataBound" CellPadding="10" margin-left="auto" CssClass="GridView" HorizontalAlign="Center" AllowRowSelect="true"
                                    AllowPaging="true" PageSize="5" HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px">
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:GridView ID="GridMod" runat="server" OnSelectedIndexChanged="Mod_SelectedIndexChanged" OnPageIndexChanging="Mod_OnPageIndexChanging"
                                OnRowDataBound="Mod_OnRowDataBound" CellPadding="10" margin-left="auto" CssClass="GridView" HorizontalAlign="Center" AllowRowSelect="true"
                                AllowPaging="true" PageSize="5" HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px">
                            </asp:GridView>
                        </div>
                        <div class="col-md-4">
                            <asp:GridView ID="GridReq" runat="server" OnSelectedIndexChanged="Req_SelectedIndexChanged" OnPageIndexChanging="Req_OnPageIndexChanging"
                                OnRowDataBound="Req_OnRowDataBound" CellPadding="10" margin-left="auto" CssClass="GridView" HorizontalAlign="Center" AllowRowSelect="true"
                                AllowPaging="true" PageSize="5" HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px">
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="col-md10">
                    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                </div>
                <div class="col-md10">
                    <asp:Label ID="proyectoSeleccionado" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-md10">
                    <asp:Label ID="modSeleccionado" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-md10">
                    <asp:Label ID="reqSeleccionado" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-horizontal">
                        &nbsp;<asp:CheckBox ID="CheckBoxNombreProyecto" runat="server" Text="Nombre sistema."/>
                    </div>
                </div>
                <div class="col-md-4">
                    &nbsp;<asp:CheckBox ID="CheckBoxNombModulo" runat="server" Text="Nombre módulo."/>
                </div>
                <div class="col-md-4">
                    &nbsp;<asp:CheckBox ID="CheckBoxNombReq" runat="server" Text="Nombre requerimiento."/>
                </div>
            </div>
            <div class="col-md3">
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-horizontal">
                            &nbsp;<asp:CheckBox ID="CheckBoxFechAsignacionProyecto" runat="server" Text="Fecha de asignacion." />
                        </div>
                    </div>
                    <div class="col-md-4">
                        &nbsp;<asp:CheckBox ID="CheckBoxOficinaProyecto" runat="server" Text="Datos de oficina usuaria." />
                    </div>
                    <div class="col-md-4">
                        &nbsp;<asp:CheckBox ID="CheckBoxResponsableProyecto" runat="server" Text="Lider." />
                    </div>
                </div>
            </div>
            <div class="col-md3">
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-horizontal">
                            &nbsp;<asp:CheckBox ID="CheckBoxObjetivoProyecto" runat="server" Text="Objetivo general." />
                        </div>
                    </div>
                    <div class="col-md-4">
                        &nbsp;<asp:CheckBox ID="CheckBoxEstadoProyecto" runat="server" Text="Estado" />
                    </div>
                    <div class="col-md-4">
                        &nbsp;<asp:CheckBox ID="CheckBoxMiembrosProyecto" runat="server" Text="Miembros de equipo asociados." />
                    </div>
                </div>
            </div>
            <div class="col-md3">
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-horizontal">
                            &nbsp;<asp:CheckBox ID="CheckBoxExitos" runat="server" Text="Cantidad éxitos." />
                        </div>
                    </div>
                    <div class="col-md-4">
                        &nbsp;<asp:CheckBox ID="CheckBoxTipoNoConf" runat="server" Text="Tipos no conformidades." />
                    </div>
                    <div class="col-md-4">
                        &nbsp;<asp:CheckBox ID="CheckBoxCantNoConf" runat="server" Text="Cantidad no conformidades." />
                    </div>
                </div>
            </div>
        </div>        
            <div class="col-md-4">
                <asp:GridView ID="preGrid" runat="server" CellPadding="10" margin-left="auto" CssClass="GridView" HorizontalAlign="Center" AllowRowSelect="false"
                    HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px">
                </asp:GridView>
            </div>       
    </div>
    <div style="margin-top: 5px" class="well">
        <div class="form-group">
            <div class="col-md-2">
                <asp:Button runat="server" Text="Generar Reporte" CssClass="btn btn-primary" ID="Generar" OnClick="BotonGE_Click" CausesValidation="false" />
            </div>
            <div class="col-md-4" style="padding-top: 25px">
                <div class="progress progress-striped active">
                    <div class="progress-bar" style="width: 65%" ID="barraProgreso" visible="false">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
         <div class="col-md-4">
              <div class="form-horizontal">
                   <asp:GridView ID="GridGR" runat="server" OnSelectedIndexChanged="Reporte_SelectedIndexChanged" OnPageIndexChanging="Reporte_OnPageIndexChanging"
                        OnRowDataBound="Reporte_OnRowDataBound" CellPadding="10" margin-left="auto" CssClass="GridView" HorizontalAlign="Center" AllowRowSelect="false"
                        AllowPaging="true" PageSize="5" HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px">
                   </asp:GridView>
              </div>
        </div>
    </div>
    <div class="row">
    <div class="col-md-2">
        <asp:DropDownList ID="DDLTipoArchivo" runat="server"></asp:DropDownList>
    </div>
    <div class="col-md2">
          <asp:Button runat="server" Text="Descargar" CssClass="btn btn-primary" ID="Button1" OnClick="BotonGE_Click" CausesValidation="false" />
          <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-primary" ID="Button2" OnClick="BotonGE_Click" CausesValidation="false" />
    </div>
    </div>

    <%--</div>--%>
</asp:Content>
