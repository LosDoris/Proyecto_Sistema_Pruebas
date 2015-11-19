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

                    <div class="col-md3">
                        <asp:GridView ID="GridPP" runat="server" OnSelectedIndexChanged="PP_SelectedIndexChanged" OnPageIndexChanging="PP_OnPageIndexChanging"
                            OnRowDataBound="PP_OnRowDataBound" CellPadding="10" margin-left="auto" CssClass="GridView" HorizontalAlign="Center" AllowRowSelect="true"
                            AllowPaging="true" PageSize="5" HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px">
                            <%-- %>Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" Text="Todos"
                                            onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server"
                                            onclick="Check_Click(this)" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns --%>
                        </asp:GridView>
                        <asp:Label ID="proyectoSeleccionado" runat="server" Text=""></asp:Label>

                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-horizontal">
                                <asp:CheckBox ID="CheckBoxNombreProyecto" runat="server" Text="Nombre." />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="CheckBoxFechAsignacionProyecto" runat="server" Text="Fecha de asignacion." />
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="CheckBoxOficinaProyecto" runat="server" Text="Datos de oficina usuaria." />
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="CheckBoxResponsableProyecto" runat="server" Text="Responsable." />
                        </div>
                    </div>
                    <div class="col-md3">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-horizontal">
                                    <asp:CheckBox ID="CheckBoxObjetivoProyecto" runat="server" Text="Objetivo general." />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:CheckBox ID="CheckBoxEstadoProyecto" runat="server" Text="Estado" />
                            </div>
                            <div class="col-md-6">
                                <asp:CheckBox ID="CheckBoxMiembrosProyecto" runat="server" Text="Miembros de equipo asociados." />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Diseño</h3>
            </div>
            <div class="panel-body">
                <div>
                    <div class="col-md3">
                        <asp:GridView ID="GridDP" runat="server" OnSelectedIndexChanged="DP_SelectedIndexChanged" OnPageIndexChanging="DP_OnPageIndexChanging"
                            OnRowDataBound="DP_OnRowDataBound" CellPadding="10" margin-left="auto" CssClass="GridView" HorizontalAlign="Center"
                            AllowPaging="true" PageSize="5" HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px"
                            AutoPostBack="true">
                        </asp:GridView>
                        <asp:Label ID="disennoSeleccionado" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-horizontal">
                                <asp:CheckBox ID="CheckBoxReqDisenno" runat="server" Text="Requerimientos." />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="CheckBoxNivelDisenno" runat="server" Text="Nivel y Técnica." />
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="CheckBoxCriteriosAceptacionDisenno" runat="server" Text="Criterios de aceptación." />
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="CheckBoxFechAsignacionDisenno" runat="server" Text="Fecha de asignación." />
                        </div>
                    </div>
                    <div class="col-md3">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-horizontal">
                                    <asp:CheckBox ID="CheckBoxPropositoDisenno" runat="server" Text="Propósito." />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:CheckBox ID="CheckBoxProcedimientoDisenno" runat="server" Text="Procedimiento." />
                            </div>
                            <div class="col-md-3">
                                <asp:CheckBox ID="CheckBoxResponsableDisenno" runat="server" Text="Responsable." />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Casos de Prueba</h3>
            </div>
            <div class="panel-body">
                <div>
                    <div class="col-md3">
                        <asp:GridView ID="GridCP" runat="server" OnSelectedIndexChanged="CP_SelectedIndexChanged" OnPageIndexChanging="CP_OnPageIndexChanging"
                            OnRowDataBound="CP_OnRowDataBound" CellPadding="10" margin-left="auto" CssClass="GridView" HorizontalAlign="Center"
                            AllowPaging="true" PageSize="5" HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px"
                            AutoPostBack="true">
                        </asp:GridView>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-horizontal">
                                <asp:CheckBox ID="CheckBoxIDCP" runat="server" Text="ID." />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="CheckBoxEntraDatosCP" runat="server" Text="Entrada de datos." />
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="CheckBoxFlujoCentralCP" runat="server" Text="Flujo central." />
                        </div>
                    </div>
                    <div class="col-md3">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-horizontal">
                                    <asp:CheckBox ID="CheckBoxPropositoCP" runat="server" Text="Propósito." />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:CheckBox ID="CheckBoxResultadoEsperadoCP" runat="server" Text="Resultado esperado." />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div style="margin-bottom: 0px" class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Ejecución de Pruebas</h3>
            </div>
            <div class="panel-body">
                <div>
                    <div class="col-md3">
                        <asp:GridView ID="GridEP" runat="server" OnSelectedIndexChanged="EP_SelectedIndexChanged" OnPageIndexChanging="EP_OnPageIndexChanging"
                            OnRowDataBound="EP_OnRowDataBound" CellPadding="10" margin-left="auto" CssClass="GridView" HorizontalAlign="Center"
                            AllowPaging="true" PageSize="5" HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px"
                            AutoPostBack="true">
                        </asp:GridView>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-horizontal">
                                <asp:CheckBox ID="CheckBoxIDEP" runat="server" Text="ID." />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="CheckBoxEntraDatosEP" runat="server" Text="Entrada de datos." />
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="CheckBoxFlujoCentralEP" runat="server" Text="Flujo central." />
                        </div>
                    </div>
                    <div class="col-md3">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-horizontal">
                                    <asp:CheckBox ID="CheckBoxPropositoEP" runat="server" Text="Propósito." />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:CheckBox ID="CheckBoxResultadoEsperadoEP" runat="server" Text="Resultado esperado." />
                            </div>
                        </div>
                    </div>
                    <%--<div class="col-md3">
            <asp:CheckBox ID="CheckBox22" runat="server" Text="ID."/>
            <asp:CheckBox ID="CheckBox23" runat="server" Text="Entrada de datos."/>
            <asp:CheckBox ID="CheckBox24" runat="server" Text="Flujo central."/>
        </div>
        <div class="col-md3">
            <asp:CheckBox ID="CheckBox26" runat="server" Text="Propósito." />
            <asp:CheckBox ID="CheckBox27" runat="server" Text="Resultado esperado."/>
        </div>   --%>
                </div>
            </div>
        </div>

        <div style="margin-top: 5px" class="well">
            <div class="form-group">
                <div class="col-md-2">
                    <asp:Button runat="server" Text="Generar Reporte" CssClass="btn btn-primary" ID="Generar" OnClick="BotonGE_Click" CausesValidation="false" />
                </div>
                <div class="col-md-4" style="padding-top: 25px">
                    <div class="progress progress-striped active">
                        <div class="progress-bar" style="width: 65%">
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </div>
    <%--</div>--%>
</asp:Content>
