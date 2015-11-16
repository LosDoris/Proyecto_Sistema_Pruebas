<%@ Page EnableEventValidation="false" Title="Generar Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazReporte.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazReporte" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style type="text/css">
        .modalBackground 
        {
            background-color: black;
            filter: alpha(opacity=90);
            opacity:0.8;
        }
        .modalPopup 
        {
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
      <div>
          <asp:Label ID="Label1" runat="server" Text="Proyecto."></asp:Label>
      </div>
    <div>
        <div class="col-md3">
            <asp:GridView ID="GridProyecto" runat="server"></asp:GridView>
            </div>
        <div class="col-md3">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Nombre."/>
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Fecha de asignacion."/>
            <asp:CheckBox ID="CheckBox3" runat="server" Text="Datos de oficina usuaria."/>
            <asp:CheckBox ID="CheckBox4" runat="server" Text="Responsable."/>
        </div>
        <div class="col-md3">
            <asp:CheckBox ID="CheckBox5" runat="server" Text="Objetivo general." />
            <asp:CheckBox ID="CheckBox6" runat="server" Text="Estado"/>
            <asp:CheckBox ID="CheckBox7" runat="server" Text="Miembros de equipo asociados." />
        </div>        
    </div>
    <div>
          <asp:Label ID="Label2" runat="server" Text="Diseño."></asp:Label>
      </div>
    <div>
        <div class="col-md3">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </div>
        <div class="col-md3">
            <asp:CheckBox ID="CheckBox8" runat="server" Text="Requerimientos."/>
            <asp:CheckBox ID="CheckBox9" runat="server" Text="Nivel y Técnica.."/>
            <asp:CheckBox ID="CheckBox10" runat="server" Text="Criterios de aceptación."/>
            <asp:CheckBox ID="CheckBox11" runat="server" Text="Fecha de asignación."/>
        </div>
        <div class="col-md3">
            <asp:CheckBox ID="CheckBox12" runat="server" Text="Propósito." />
            <asp:CheckBox ID="CheckBox13" runat="server" Text="Procedimiento."/>
            <asp:CheckBox ID="CheckBox14" runat="server" Text="Responsable." />
        </div>        
    </div>
    <div>
          <asp:Label ID="Label3" runat="server" Text="Casos de Prueba."></asp:Label>
      </div>
    <div>
        <div class="col-md3">
            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
            </div>
        <div class="col-md3">
            <asp:CheckBox ID="CheckBox15" runat="server" Text="ID."/>
            <asp:CheckBox ID="CheckBox16" runat="server" Text="Entrada de datos."/>
            <asp:CheckBox ID="CheckBox17" runat="server" Text="Flujo central."/>
        </div>
        <div class="col-md3">
            <asp:CheckBox ID="CheckBox19" runat="server" Text="Propósito." />
            <asp:CheckBox ID="CheckBox20" runat="server" Text="Resultado esperado."/>
        </div>        
    </div>
    <div>
          <asp:Label ID="Label4" runat="server" Text="Ejecución de Pruebas."></asp:Label>
      </div>
    <div>
        <div class="col-md3">
            <asp:GridView ID="GridView3" runat="server"></asp:GridView>
            </div>
        <div class="col-md3">
            <asp:CheckBox ID="CheckBox22" runat="server" Text="ID."/>
            <asp:CheckBox ID="CheckBox23" runat="server" Text="Entrada de datos."/>
            <asp:CheckBox ID="CheckBox24" runat="server" Text="Flujo central."/>
        </div>
        <div class="col-md3">
            <asp:CheckBox ID="CheckBox26" runat="server" Text="Propósito." />
            <asp:CheckBox ID="CheckBox27" runat="server" Text="Resultado esperado."/>
        </div>        
    </div>
    </asp:content>
