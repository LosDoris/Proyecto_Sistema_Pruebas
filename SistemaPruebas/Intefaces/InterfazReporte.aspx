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
          <asp:Label ID="Label1" runat="server" Text="Proyecto"></asp:Label>
      </div>
    <div>
        <div class="col-md3">
            <asp:GridView ID="GridProyecto" runat="server"></asp:GridView>
            </div>
        <div class="col-md3">
            <asp:CheckBox ID="CheckBox1" runat="server" />
            <asp:CheckBox ID="CheckBox2" runat="server" />
            <asp:CheckBox ID="CheckBox7" runat="server" />
            </div>
        <div class="col-md3">
            <asp:CheckBox ID="CheckBox3" runat="server" />
            <asp:CheckBox ID="CheckBox4" runat="server" />
            <asp:CheckBox ID="CheckBox8" runat="server" />
            </div>        
    </div>

    </asp:content>
