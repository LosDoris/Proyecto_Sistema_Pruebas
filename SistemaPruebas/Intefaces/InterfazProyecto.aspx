<%@ Page EnableEventValidation="false" Title="Proyecto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazProyecto.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazProyecto" Async="true" %>

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
        //$(function () {
          //  $("#txt_date").datepicker();
        //});
    </script>
    <script type="text/javascript">
        function HideLabel() {
            var seconds = 5;           
            setTimeout(function () {

                $('#'+'<%=EtiqErrorLlaves.ClientID %>').fadeOut('5000');
            }, 2000);           
    };
</script>
      
    <div class="form-group">
        <div class="col-md-offset-10 col-md-12" style="margin-top:15px">
            <asp:Button runat="server" ID="Insertar" Text="Insertar" CssClass="btn btn-default" OnClick="Insertar_button" CausesValidation="false" />
            <asp:Button runat="server" ID="Modificar" Text="Modificar" CssClass="btn btn-default" OnClick="Modificar_Click"  CausesValidation="false"/>

            <asp:Button runat="server" ID="Eliminar" Text="Eliminar" CssClass="btn btn-default" OnClick="Eliminar_Click" CausesValidation="false"/>
        </div>
    </div>

    <div class="row">
        <div class="col-md-8">
            <div>
                <asp:Label runat="server" CssClass="text-danger" ID="EtiqErrorLlaves" Font-Size="Large" Visible="False"></asp:Label>

            </div>
            <div class="form-horizontal">

                <hr />
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>

                <div class="form-group">
                    <asp:Label runat="server" ID="nombre_label" CssClass="col-md-2 control-label">Nombre del Proyecto</asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="nombre_proyecto" style="width:250px;height:36px" CssClass="form-control" onkeypress="solo_letras(event)" OnTextChanged="nombre_proyecto_TextChanged" placeholder="Sólo letras."/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo requerido" ControlToValidate="nombre_proyecto" ForeColor="Salmon"></asp:RequiredFieldValidator>
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
                    <asp:Label runat="server" columns="3" CssClass="col-md-2 control-label" >Objetivo General</asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="obj_general" style="width:250px;height:90px" CssClass="form-control" TextMode="multiline" onkeypress="solo_letrasYNumeros(event)" placeHolder="Sólo letras."/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo requerido" ControlToValidate="obj_general" ForeColor="Salmon"></asp:RequiredFieldValidator>
                        <script type="text/javascript">
                            function solo_letrasYNumeros(evt) {
                                if ((evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122))
                                {
                                    if ((evt.keyCode != 32) && (evt.charCode != 32) && (evt.charCode != 46) && (evt.charCode != 44) && (evt.keyCode != 13) && (evt.keyCode != 37) && (evt.keyCode != 39) && (evt.keyCode != 8) && (evt.keyCode != 83))
                                    {
                                        if ($('#errorObjSistema').css('display') == 'none') {
                                            //alert(evt.charCode);
                                            $('#errorObjSistema').fadeIn();
                                            $('#errorObjSistema').fadeOut(6000);
                                        }
                                            if (window.event)//IE
                                                evt.returnValue = false;
                                            else//Firefox
                                                evt.preventDefault();
                                        
                                    }
                                }
                            }
                        </script>
                        <div id="errorObjSistema" style="display:none">
                            <asp:Label runat="server" ID="errorObjSistemalbl" text="Sólo se permite el ingreso de letras" ForeColor="Salmon"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Estado</asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="estado" style="width:250px" CssClass="form-control">
                            <asp:ListItem Value="1">Pendiente</asp:ListItem>
                            <asp:ListItem Value="2">Asignado</asp:ListItem>
                            <asp:ListItem Value="3">En Ejecución</asp:ListItem>
                            <asp:ListItem Value="4">Finalizado</asp:ListItem>
                            <asp:ListItem Value="5">Cerrado</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>

                <div class="form-group">
                     
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Fecha de Asignación</asp:Label>
                    <div class="col-md-4" runat="server">
                        <asp:TextBox runat="server" id="txt_date" name="txt_date" style="width:250px;height:36px" type="text" ReadOnly="True" placeholder="De un click para seleccionar fecha."></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date" PopupButtonID="txt_date" />
                    </div>
                    
                         
                </div>
            </div>
        </div>


        <h4>Datos de la oficina usuaria</h4>
        <div class="col-md-4">

            <div class="form-horizontal">


                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Nombre de la oficina</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="of_rep" style="width:250px;height:36px" CssClass="form-control" onkeypress="return solo_letras2(event)" MaxLength="17" />
                        <script type="text/javascript">
                            function solo_letras2(e) {
                                if ((evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122)) {
                                    if ((evt.keyCode != 32) && (evt.charCode != 32) && (evt.charCode != 46) && (evt.keyCode != 13) && (evt.keyCode != 37) && (evt.keyCode != 39) && (evt.keyCode != 8) && (evt.keyCode != 83) && (evt.charCode != 44)) {
                                        //alert(evt.charCode);
                                        if ($('#errorNombreOficina').css('display') == 'none') {
                                            $('#errorNombreOficina').fadeIn();
                                            $('#errorNombreOficina').fadeOut(6000);
                                        }
                                        if (window.event)//IE
                                            evt.returnValue = false;
                                        else//Firefox
                                            evt.preventDefault();
                                    }
                                }
                            }
                        </script>
                        <div id="errorNombreOficina" style="display:none">
                            <asp:Label runat="server" ID="errorNombreOficinaLbl" text="Sólo se permite el ingreso de letras" ForeColor="Salmon"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Teléfonos</asp:Label>

                    <div class="col-md-6">
                        <asp:label runat="server" id="tel1Label" text="Teléfono 1:"></asp:label>

                        <asp:TextBox runat="server" ID="tel_rep" style="width:250px;height:36px;margin-bottom:10px" CssClass="form-control" onkeyDown="check_txt(this,event,8)" placeholder="00000000"/>
                        <asp:RegularExpressionValidator Display ="Dynamic" ControlToValidate="tel_rep" ID="RegularExpressionValidator3" ValidationExpression = "^(\d{8})|()$" runat="server" 
                            foreColor="Salmon" ErrorMessage="Debe digitar 8 números."></asp:RegularExpressionValidator>
                        <script type="text/javascript">
                            function check_txt(textBox, e, length) {                              
                                if (!checkSpecialKeys(e)) {
                                    if ($('#errorTel1').css('display') == 'none') {
                                        $('#errorTel1').fadeIn();
                                        $('#errorTel1').fadeOut(6000);
                                    }
                                    if (window.event)//IE
                                        e.returnValue = false;
                                    else//Firefox
                                        e.preventDefault();                                    
                                }
                                else
                                    $('#errorTel1').fadeOut();
                            }
                            function checkSpecialKeys(e) {
                                if ((e.keyCode < 48 || e.keyCode > 57) && ((e.keyCode < 96 || e.keyCode > 105)) && e.keyCode != 8 && e.keyCode != 127 && e.keyCode != 37 && e.keyCode != 39 && e.keyCode != 13)
                                    return false;
                                else
                                    return true;
                            }                                   
                        </script>
                        <div id="errorTel1" Style="display:none">
                            <asp:label runat="server" ID="errorTel1Txt" visible="true" Enabled="true" Text="Este campo sólo recibe números" ForeColor="Salmon" ></asp:label>
                        </div>
                        <asp:label runat="server" id="tel2Label" text="Teléfono 2:" style="margin-top:20px"></asp:label>
                        <asp:TextBox runat="server" ID="tel_rep2" style="width:250px;height:36px" CssClass="form-control" onkeypress="check_txt2(this,event,8)" MaxLength="8" CausesValidation="True" placeholder="Complete primero el Tél. 1"/>
                        <asp:RegularExpressionValidator Display = "Dynamic"  ControlToValidate = "tel_rep2" ID="RegularExpressionValidator1" ValidationExpression = "^(\d{8})|()$" runat="server" ErrorMessage="Debe digitar 8 números." ForeColor="Salmon"></asp:RegularExpressionValidator>
                        <script type="text/javascript">
                            function check_txt2(textBox, e, length) {
                                if (document.getElementById('<%=tel_rep.ClientID%>').value.length != 8)
                                {
                                    if ($('#errorTel2').css('display') == 'none') {
                                        //document.getElementById("errorTel2Lbl").innerHTML = "Primero complete el campo de télefono 1";
                                        document.getElementById('<%=errorTel2Lbl.ClientID%>').innerHTML = "Primero complete el campo de télefono 1";
                                        $('#errorTel2').fadeIn();
                                        $('#errorTel2').fadeOut(5000);
                                    }
                                    if (window.event)//IE
                                        e.returnValue = false;
                                    else//Firefox
                                        e.preventDefault();
                                }
                                else
                                {                                    
                                    if ((e.charCode < 48 || e.charCode > 57) && (e.keyCode < 96 || e.keyCode > 105)) {
                                        if((e.keyCode != 37) && (e.keyCode != 39) && (e.keyCode != 8) && (e.keyCode != 83) && (e.keyCode != 46) && (e.keyCode != 13))
                                        {                                        
                                            //alert(e.charCode);
                                            if ($('#errorTel2').css('display') == 'none') {
                                                document.getElementById('<%=errorTel2Lbl.ClientID%>').innerHTML = "Este campo sólo recibe números";
                                                $('#errorTel2').fadeIn();
                                                $('#errorTel2').fadeOut(5000);
                                            }
                                        if (window.event)//IE
                                            e.returnValue = false;
                                        else//Firefox
                                            e.preventDefault();
                                    }
                                       
                                    }
                                }
                            }                            
                        </script>
                        <div id="errorTel2" Style="display:none">
                            <asp:label runat="server" ID="errorTel2Lbl" visible="true" Enabled="true" Text="Este campo sólo recibe números" ForeColor="Salmon" ></asp:label>
                        </div>
                    </div>                
                </div>                                
                <div class="form-group" style="margin-top:40px">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Nombre del representante</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" style="width:250px;height:36px"  ID="nombre_rep" CssClass="form-control" onkeypress="return solo_letras3(event)" MaxLength="30" />
                        <script type="text/javascript">
                            function solo_letras3(evt) {
                                if ((evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122)) {
                                    if ((evt.keyCode != 32) && (evt.charCode != 32) && (evt.charCode != 46) && (evt.charCode != 44) && (evt.keyCode != 13) && (evt.keyCode != 37) && (evt.keyCode != 39) && (evt.keyCode != 8) && (evt.keyCode != 83) && (evt.charCode != 44)) {
                                        //alert(evt.charCode);
                                        if ($('#errorNombreUsuario').css('display') == 'none') {
                                            $('#errorNombreUsuario').fadeIn();
                                            $('#errorNombreUsuario').fadeOut(5000);
                                        }
                                        if (window.event)//IE
                                            evt.returnValue = false;
                                        else//Firefox
                                            evt.preventDefault();
                                    }
                                }
                            }
                        </script>
                        <div id="errorNombreUsuario" style="display:none">
                            <asp:Label runat="server" ID="errorNombreUsuarioLbl" text="Sólo se permite el ingreso de letras" ForeColor="Salmon"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                     <asp:Label runat="server" id="LiderLbl" Text="Nombre del lidel del proyecto" CssClass="col-md-4 control-label"></asp:label>
                        <div class="col-md-6">
                     <asp:DropDownList ID="LiderProyecto" runat="server" style="width:250px" CssClass="form-control"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo requerido" ControlToValidate="LiderProyecto" ForeColor="Salmon"></asp:RequiredFieldValidator>                     
                            </div>
                 </div>

            </div>
        </div>
    </div>
    <div class="form-group">
        <div id="Botones_aceptar_cancelar" class="col-md-offset-10 col-md-12">
            <asp:Button runat="server" ID="aceptar" Text="Aceptar" CssClass="btn btn-default" OnClick="aceptar_Click" style="border-color:#4bb648;color:#4bb648" CausesValidation="true"/>
            <asp:Button runat="server" ID="cancelar" Text="Cancelar" style="border-color:#fe6c4f;color:#fe5e3e" CssClass="btn btn-default" OnClick="cancelar_Click" CausesValidation="False" />           
            <asp:Panel runat="server" ID="cancelarPanelModal" CssClass="modalPopup"> 
        <asp:label runat ="server" ID="cancelarLabelModal" style="padding-top:20px;padding-left:11px;padding-right:11px">¿Desea cancelar la operación?</asp:label>
        <br/> <br/>
        <div aria-pressed="true">
            <asp:button runat="server" ID="cancelarButtonSiModal" Text="Si" OnClick="cancelar_Click" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;margin-left:20px;margin-right:20px;margin-bottom:20px" CausesValidation="false"/>
            <asp:button runat="server" ID="cancelarButtonNoModal" Text="No" CssClass="btn btn-default" style="border-color:#fe6c4f;color:#fe5e3e;align-self:center;margin-left:20px;margin-right:20px;margin-bottom:20px" CausesValidation="false"/>           
       </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" PopupControlID="cancelarPanelModal" TargetControlID="cancelar" OnCancelScript="cancelarButtonNoModal" OnOkScript="cancelarButtonSiModal">
    </ajaxToolkit:ModalPopupExtender>
        </div>
    </div>

    <div id="tablaProyectos" class="row">

        <asp:GridView ID="gridProyecto" runat="server" HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" CellPadding="10" margin-right ="auto" HorizontalAlign="Center" 
            AutoGenerateColumns="false" OnSelectedIndexChanged="OnSelectedIndexChanged" BorderColor="#cdcdcd" border-radius="7px" 
            AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" AllowSorting="true" PageSize="5"   OnRowDataBound ="OnRowDataBound" CssClass ="GridView"  AutoPostBack ="true" CausesValidation="false">
            <Columns>
                <asp:BoundField DataField="Id Proyecto" ItemStyle-Width="185px" HeaderText=" Id Proyecto"  />
                <asp:TemplateField ItemStyle-Width="200px" HeaderText=" Nombre del sistema">
                    <ItemTemplate>
                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre del sistema") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
 
            </asp:GridView>
    </div>
    
    <asp:Panel runat="server" ID="panelModal" CssClass="modalPopup"> 
        <asp:label runat ="server" ID="textModal" style="padding-top:20px;padding-left:11px;padding-right:11px">¿Desea eliminar este proyecto?</asp:label>
        <br/> <br/>
        <div aria-pressed="true">
            <asp:button runat="server" ID="aceptarModal" Text="Eliminar" OnClick="aceptarModal_Click" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;align-self:center;margin-left:16px;margin-right:11px;margin-bottom:20px"/>
            <asp:button runat="server" ID="cancelarModal" Text="Cancelar" OnClick="cancelarModal_Click" CssClass="btn btn-default" style="border-color:#fe6c4f;color:#fe5e3e;align-self:center;margin-left:11px;margin-right:6px;margin-bottom:20px"/>           
       </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalEliminar" runat="server" BackgroundCssClass="modalBackground" PopupControlID="panelModal" TargetControlID="Eliminar" OnCancelScript="cancelarModal" OnOkScript="aceptarModal">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>

