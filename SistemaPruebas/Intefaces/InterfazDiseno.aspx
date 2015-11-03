<%@ Page EnableEventValidation="false" Title="Diseño" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazDiseno.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazDiseno" Async="true" %>


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

    <h2><%: Title %>.</h2>
    <link rel="stylesheet" type="text/css" media="screen"
        href="http://tarruda.github.com/bootstrap-datetimepicker/assets/css/bootstrap-datetimepicker.min.css">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script type="text/javascript">
        $(function () {
            $("#txt_date").datepicker();
        });
    </script>
     <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
        
        <div class="form-group">
        <div class="col-md-offset-10 col-md-12">
            <asp:Button runat="server" ID="Insertar" Text="Insertar" CssClass="btn btn-default" OnClick="insertarClick" CausesValidation="false"/>
            <asp:Button runat="server" ID="Modificar" Text="Modificar" CssClass="btn btn-default" OnClick="modificarClick" CausesValidation="false"/>
            <asp:Button runat="server" ID="Eliminar" Text="Eliminar" CssClass="btn btn-default" OnClick="eliminarClick" CausesValidation="false"/>
        </div>
    </div>

    <asp:Panel runat="server" ID="panelModalEliminar" CssClass="modalPopup"> 
        <asp:label runat ="server" ID="textModal" style="padding-top:20px;padding-left:11px;padding-right:11px">¿Desea eliminar este diseño?</asp:label>
        <br/> <br/>
        <div aria-pressed="true">
            <asp:button runat="server" ID="aceptarModalEliminar" Text="Eliminar" OnClick="aceptarModal_ClickEliminar" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;align-self:center;margin-left:16px;margin-right:11px;margin-bottom:20px" CausesValidation="false"/>
            <asp:button runat="server" ID="cancelarModalEliminar" Text="Cancelar" OnClick="cancelarModal_ClickEliminar" CssClass="btn btn-default" style="border-color:#fe6c4f;color:#fe5e3e;align-self:center;margin-left:11px;margin-right:6px;margin-bottom:20px" CausesValidation="false"/>           
       </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" OnCancelScript="cancelarModalEliminar" OnOkScript="aceptarModalEliminar" TargetControlID="Eliminar" PopupControlID="panelModalEliminar"></ajaxToolkit:ModalPopupExtender>


    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Proyecto asociado:</asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="proyectoAsociado" style="width:250px" CssClass="form-control" OnSelectedIndexChanged="proyectoAsociado_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="1">Seleccionar</asp:ListItem>
                        </asp:DropDownList>
        </div>
        </div>

        </div>
        </div>
        </div>
    <h4>Requerimientos a Probar</h4>

<div class="cajaAnchoPagina">

    <div id="tablasReqs" class="row">
<%--
        <asp:GridView ID="gridNoAsociado" runat="server" HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" CellPadding="10" margin-right ="auto" HorizontalAlign="Center" 
            AutoGenerateColumns="false" OnSelectedIndexChanged="OnSelectedIndexChangedNoAsoc" BorderColor="#cdcdcd" border-radius="7px" 
            AllowPaging="true" OnPageIndexChanging="OnPageIndexChangingNoAsoc" AllowSorting="true" PageSize="5"   OnRowDataBound ="OnRowDataBoundNoAsoc" CssClass ="GridView"  AutoPostBack ="true" CausesValidation="false">
            <Columns>
                <asp:BoundField DataField="Id Proyecto" ItemStyle-Width="185px" HeaderText=" Id Requerimiento"/>
                </Columns>
            </asp:GridView>
--%>
    </div>
        <div class="col-md-offset-10 col-md-12">
            <asp:Button runat="server" ID="iraRequerimientoBtn" Text="Ir a Requerimiento" CssClass="btn btn-default" OnClick="irAReq" CausesValidation="false"/>
        </div>
</div>

<div class="row">
<div class="col-md-8">
<div class="form-horizontal">



<div class="form-group">
                    <asp:Label runat="server" ID="propositoLabel" CssClass="col-md-2 control-label">Propósito:</asp:Label>
                    <div class="col-md-4">
                    <asp:TextBox runat="server" ID="propositoTxtbox" style="width:250px;height:36px" CssClass="form-control" MaxLength="80"
                        onkeypress="solo_letras(event)" placeholder="Sólo letras."/> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo requerido" ControlToValidate="propositoTxtbox" ForeColor="Salmon"></asp:RequiredFieldValidator>
                    <script type="text/javascript">
                        function solo_letras(evt) {

                            if ((evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122)) {
                                if ((evt.keyCode != 32) && (evt.charCode != 32) && (evt.charCode != 46) && (evt.charCode != 44) && (evt.keyCode != 13) && (evt.keyCode != 37) && (evt.keyCode != 39) && (evt.keyCode != 8) && (evt.keyCode != 83)) {
                                    //alert();
                                    if ($('#errorNombreSistema').css('display') == 'none') {
                                        $('#errorNombreSistema').fadeIn();
                                        $('#errorNombreSistema').fadeOut(6000);
                                    }
                                    if (window.event)//IE
                                        evt.returnValue = false;
                                    else//Firefox
                                        evt.preventDefault();

                                }
                            }
                        }
                        </script>
                        <div id="errorNombreSistema" style="display:none">
                            <asp:Label runat="server" ID="errorNombreSistLbl" text="Sólo se permite el ingreso de letras" ForeColor="Salmon"></asp:Label>
                        </div>      
                    </div>

</div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Nivel:</asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="Nivel" style="width:250px" CssClass="form-control">
                            <asp:ListItem Selected="True" Value="1">Seleccionar</asp:ListItem>
                           <asp:ListItem Value="2">Unitaria</asp:ListItem>
                            <asp:ListItem Value="3">Integración</asp:ListItem>
                            <asp:ListItem Value="4">Sistema</asp:ListItem>
                            <asp:ListItem Value="5">Aceptación</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo requerido" ControlToValidate="procedimientoTxtbox" ForeColor="Salmon"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Técnica:</asp:Label>
                    <div class="col-md-6">
                        <asp:DropDownList runat="server" ID="Tecnica" style="width:250px" CssClass="form-control">
                            <asp:ListItem Selected="True" Value="1">Seleccionar</asp:ListItem>
                           <asp:ListItem Value="2">Caja Negra</asp:ListItem>
                            <asp:ListItem Value="3">Caja Blanca</asp:ListItem>
                            <asp:ListItem Value="4">Exploratoria</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo requerido" ControlToValidate="procedimientoTxtbox" ForeColor="Salmon"></asp:RequiredFieldValidator>
                    </div>
                </div>

            


</div>
</div>

<div class="col-md-4">
<div class="form-horizontal">


<div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Ambiente:</asp:Label>
                    <div class="col-md-4">
                    <asp:TextBox runat="server" ID="ambienteTxtbox" style="width:250px;height:130px" CssClass="form-control" MaxLength="150" TextMode="multiline"
                        onkeypress="solo_letras1(event)" placeholder="Sólo letras y espacios."/>
                    <script type="text/javascript">
                            function solo_letras1(evt) {

                                if ((evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122)) {
                                    if ((evt.keyCode != 32) && (evt.charCode != 32) && (evt.charCode != 46) && (evt.charCode != 44) && (evt.keyCode != 13) && (evt.keyCode != 37) && (evt.keyCode != 39) && (evt.keyCode != 8) && (evt.keyCode != 83)) {
                                        //alert();
                                        if ($('#errorNombreSistema1').css('display') == 'none') {
                                            $('#errorNombreSistema1').fadeIn();
                                            $('#errorNombreSistema1').fadeOut(6000);
                                        }
                                        if (window.event)//IE
                                            evt.returnValue = false;
                                        else//Firefox
                                            evt.preventDefault();

                                    }
                                }
                            }
                        </script>
                        <div id="errorNombreSistema1" style="display:none; width: 250px;">
                            <asp:Label runat="server" ID="errorNombreSistLbl1" text="Sólo se permite el ingreso de letras y espacios" ForeColor="Salmon"></asp:Label>
                        </div>  
                    </div>
</div>

</div>
</div>

<div class="col-md-8">
<div class="form-horizontal">

<div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Procedimiento Utilizado:</asp:Label>

<div class="col-md-6">
                    <asp:TextBox runat="server" ID="procedimientoTxtbox" style="width:284%;height:90px" CssClass="form-control" MaxLength="150" TextMode="multiline"
                        onkeypress="solo_letras2(event)" placeholder="Sólo letras y espacios."/>
                    
                        <script type="text/javascript">
                            function solo_letras2(evt) {

                                if ((evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122)) {
                                    if ((evt.keyCode != 32) && (evt.charCode != 32) && (evt.charCode != 46) && (evt.charCode != 44) && (evt.keyCode != 13) && (evt.keyCode != 37) && (evt.keyCode != 39) && (evt.keyCode != 8) && (evt.keyCode != 83)) {
                                        //alert();
                                        if ($('#errorNombreSistema2').css('display') == 'none') {
                                            $('#errorNombreSistema2').fadeIn();
                                            $('#errorNombreSistema2').fadeOut(6000);
                                        }
                                        if (window.event)//IE
                                            evt.returnValue = false;
                                        else//Firefox
                                            evt.preventDefault();

                                    }
                                }
                            }
                        </script>
                        <div id="errorNombreSistema2" style="display:none; width: 500px;">
                            <asp:Label runat="server" ID="errorNombreSistLbl2" text="Sólo se permite el ingreso de letras y espacios" ForeColor="Salmon"></asp:Label>
                        </div>  
</div>
</div>

<div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Criterios de Aceptación:</asp:Label>
<div class="col-md-6">
                    <asp:TextBox runat="server" ID="criteriosTxtbox" style="width:284%;height:90px" CssClass="form-control" MaxLength="150" TextMode="multiline"
                        onkeypress="solo_letras3(event)" placeholder="Sólo letras y espacios."/>
                    <script type="text/javascript">
                        function solo_letras3(evt) {

                            if ((evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122)) {
                                if ((evt.keyCode != 32) && (evt.charCode != 32) && (evt.charCode != 46) && (evt.charCode != 44) && (evt.keyCode != 13) && (evt.keyCode != 37) && (evt.keyCode != 39) && (evt.keyCode != 8) && (evt.keyCode != 83)) {
                                    //alert();
                                    if ($('#errorNombreSistema3').css('display') == 'none') {
                                        $('#errorNombreSistema3').fadeIn();
                                        $('#errorNombreSistema3').fadeOut(6000);
                                    }
                                    if (window.event)//IE
                                        evt.returnValue = false;
                                    else//Firefox
                                        evt.preventDefault();

                                }
                            }
                        }
                        </script>
                        <div id="errorNombreSistema3" style="display:none; width: 500px;">
                            <asp:Label runat="server" ID="Label1" text="Sólo se permite el ingreso de letras y espacios" ForeColor="Salmon"></asp:Label>
                        </div>  
</div>
</div>

</div>
</div>
</div>

<div class="row">
<div class="col-md-8">
<div class="form-horizontal">


<div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Responsable:</asp:Label>
<div class="col-md-6">
                    <asp:DropDownList runat="server" ID="responsable" style="width:250px" CssClass="form-control">
                            <asp:ListItem Selected="True" Value="1">Seleccionar</asp:ListItem>
                    </asp:DropDownList>
</div>
</div>
</div>
</div>
<div class="col-md-4">
<div class="form-horizontal">


<div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Fecha de Diseño:</asp:Label>
<div class="col-md-4" runat="server">
                    <input id="txt_date" name="txt_date" style="width:250px;height:36px" type="text" readonly="readonly"/>
                    </div>
</div>

</div>
</div>

</div>

   <div class="form-group">
        <div id="Botones_aceptar_cancelar" class="col-md-offset-10 col-md-12">
            <asp:Button runat="server" ID="aceptar" Text="Aceptar" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648; margin-top:20px;" OnClick="aceptarClick"/>
            <asp:Button runat="server" ID="cancelar" Text="Cancelar" style="border-color:#fe6c4f;color:#fe5e3e; margin-top:20px;" CssClass="btn btn-default" OnClick="cancelarClick" CausesValidation="false"/>

        </div>
    </div>

    <div id="tablaDisenos" class="row">

        <asp:GridView ID="gridDisenos" runat="server" margin-right="auto"
            CellPadding="10" CellSpacing="500"
            margin-left="auto" OnSelectedIndexChanged="OnSelectedIndexChanged"
            OnRowDataBound="OnRowDataBound" CssClass="GridView" HorizontalAlign="Center"
            AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="5"
            HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px"
            AutoPostBack="true">
        </asp:GridView>
    </div>

</asp:Content>

