<%@ Page Title="Requerimientos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazRequerimiento.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazRequerimiento" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <h2><%: Title %>.</h2>
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

                       <script type="text/javascript">
                           function solo_numeros(evt) {
                               if (evt.charCode > 31 && (evt.charCode < 48 || evt.charCode > 57)) {
                                   alert("Sólo se permite números");
                                   return false;
                               }
                           }
                        </script>

                        <script type="text/javascript">
                            function solo_letras(evt) {
                                if ((evt.charCode < 32 || evt.charCode > 32) && (evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122) && (evt.charCode < 209 || evt.charCode > 209) && (evt.charCode < 241 || evt.charCode > 241)) {
                                    alert("Sólo se permite letras");
                                    return false;
                                }
                            }
                        </script>

    <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorInsertar" >*Ha habido problemas para agregar este requerimiento al sistema. Por favor vuelva a intentarlo.</asp:Label>
    <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorConsultar" >*Ha habido problemas para consultar este requerimiento. Por favor vuelva a intentarlo mas tarde.</asp:Label>
    <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorLlaves" >*El ID ingresado ya pertenece a un requerimiento del proyecto. Por favor ingrese otra identificación.</asp:Label>
    <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorModificar" >*Ha habido problemas para modificar este recurso humano. Por favor vuelva a intentarlo.</asp:Label>
        <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorEliminar" >*Ha habido problemas para eliminar este recurso humano del sistema. Por favor vuelva a intentarlo.</asp:Label>
                    <div class="form-group">
                        <div class="col-md-offset-5 col-md-12">
                            <asp:Button runat="server" Text="Insertar" CssClass="btn btn-default" ID="BotonREQInsertar" OnClick="BotonREQInsertar_Click"  />

                            <asp:Button runat="server" Text="Modificar" CssClass="btn btn-default" ID="BotonREQModificar" OnClick="BotonREQModificar_Click" />

                            <asp:Button runat="server" Text="   Eliminar" CssClass="btn btn-default" ID="BotonREQEliminar" OnClick="BotonREQEliminar_Click" />
                            <%--OnClientClick="return confirm('¿Está seguro que desea eliminar esta cuenta?')"--%>
                        </div>
                    </div>
    <div class="col-md-16">
    <div class="row">
        <div class="col-md-16">
        <div class="col-md-16">
            <div class="col-md-16">
                <div class="form-horizontal">
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>
                        <div class="form-group">      
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="col-md-3 control-label">Proyecto Asociado:</asp:Label>
                                <div class="col-md-">
                                    <asp:DropDownList ID="ProyectoAsociado" runat="server" OnSelectedIndexChanged="ProyectoAsociado_SelectedIndexChanged" CssClass="form-control" Width="232px" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-16">
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="col-md-3 control-label">ID del requerimiento:</asp:Label>
                            <asp:TextBox runat="server" ID="TextBoxNombreREQ" CssClass="form-control" MaxLength="6" onkeypress="return solo_letrasYNumeros2(event)" Width="230px">.</asp:TextBox>
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorNombre">*En este campo solo se permiten letras y espacios</asp:Label>
                                <script type="text/javascript">
                                    function solo_letrasYNumeros2(evt) {
                                        if ((evt.charCode < 48 || evt.charCode > 57) && (evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122)) {
                                            if ((evt.charCode != 32)) {
                                                if ($('#errorObjSistema2').css('display') == 'none') {
                                                    //alert(evt.charCode);
                                                    $('#errorObjSistema2').fadeIn();
                                                    $('#errorObjSistema2').fadeOut(6000);
                                                }
                                                if (window.event)//IE
                                                    evt.returnValue = false;
                                                else//Firefox
                                                    evt.preventDefault();
                                            }
                                        }
                                    }
                                 </script>
                                 <div id="errorObjSistema2" style="display:none">
                                    <asp:Label runat="server" ID="Label1" text="Sólo se permite el ingreso de letras y numeros." ForeColor="Salmon"></asp:Label>
                                </div>
                               <asp:requiredfieldvalidator id="Requiredfieldvalidator1"
                                    controltovalidate="TextBoxNombreREQ"
                                    Display="Dynamic"
                                    validationgroup="CamposNoVacios"
                                    CssClass="text-danger" 
                                    errormessage="El campo de Nombre es obligatorio."
                                    runat="Server">
                                </asp:requiredfieldvalidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="col-md-3 control-label">Precondiciones:</asp:Label>
                            <div class="col-md-16">
                            <asp:TextBox runat="server" ID="TextBoxPrecondicionesREQ" CssClass="form-control" MaxLength="150" onkeypress="return solo_letrasYNumeros1(event)" Width="230px">.</asp:TextBox>
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorPrecondiciones">*En este campo solo se permiten letras y espacios.</asp:Label>
                                <script type="text/javascript">
                                    function solo_letrasYNumeros1(evt) {
                                        if ((evt.charCode < 48 || evt.charCode > 59) && (evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122)) {
                                            if ((evt.charCode != 32) && (evt.charCode != 46) && (evt.charCode != 44) && (evt.keyCode != 13) && (evt.keyCode != 37) && (evt.keyCode != 8) && (evt.keyCode != 83)) {
                                                if ($('#errorObjSistema1').css('display') == 'none') {
                                                    //alert(evt.charCode);
                                                    $('#errorObjSistema1').fadeIn();
                                                    $('#errorObjSistema1').fadeOut(6000);
                                                }
                                                if (window.event)//IE
                                                    evt.returnValue = false;
                                                else//Firefox
                                                    evt.preventDefault();
                                            }
                                        }
                                    }
                                 </script>
                                 <div id="errorObjSistema1" style="display:none">
                                    <asp:Label runat="server" ID="errorObjSistemalbl1" text="Sólo se permite el ingreso de letras, numeros, puntos('.'), comas(','), dos puntos(':') y punto y coma(';') " ForeColor="Salmon"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="col-md-3 control-label">Condiciones Especiales:</asp:Label>
                            <div class="col-md-16">
                            <asp:TextBox runat="server" ID="TextBoxRequerimientosEspecialesREQ" CssClass="form-control" MaxLength="150" TextMode="multiline" onkeypress="return ( this.value.length<=149 && solo_letrasYNumeros(event))" Width="230px" Height="79px">.</asp:TextBox>
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorReqEsp">*En este campo solo se permiten letras y espacios.</asp:Label>

                                <script type="text/javascript">
                                    function solo_letrasYNumeros(evt) {
                                        if ((evt.charCode < 48 || evt.charCode > 59) && (evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122)) {
                                            if ((evt.charCode != 32) && (evt.charCode != 46) && (evt.charCode != 44) && (evt.keyCode != 13) && (evt.keyCode != 37) && (evt.keyCode != 8) && (evt.keyCode != 83)) 
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
                                    <asp:Label runat="server" ID="errorObjSistemalbl" text="Sólo se permite el ingreso de letras, numeros, puntos('.'), comas(','), dos puntos(':') y punto y coma(';') " ForeColor="Salmon"></asp:Label>
                                </div>

                            </div>
                        </div>
                </div>
            </div>
        </div>
        </div>
        <div class="col-md-4">
            <div class="form-horizontal">
            </div>

         
        </div>
    </div>
    </div>
        <div class="form-group">
            <div class="col-md-offset-5 col-md-12">
                <asp:Button runat="server" style="border-color:#4bb648;color:#4bb648" 
                    Text="Aceptar" 
                    causesvalidation="true" 
                    validationgroup="CamposNoVacios"
                    CssClass="btn btn-default" 
                    ID="BotonREQAceptar" 
                    OnClick="BotonREQAceptar_Click" />
                <asp:Button runat="server" style="border-color:#4bb648;color:#4bb648"
                    Text="Aceptar" 
                    causesvalidation="true" 
                    validationgroup="CamposNoVacios"                               
                    CssClass="btn btn-default" 
                    ID="BotonREQAceptarModificar" OnClick="BotonREQAceptarModificar_Click" />
                <asp:Button runat="server" Text="Cancelar" style="border-color:#fe6c4f;color:#fe5e3e" CssClass="btn btn-default" ID="BotonREQCancelar" OnClick="BotonREQCancelar_Click"   />
                <%--OnClientClick="return confirm('¿Está seguro que desea cancelar?')"--%>
            </div>
        </div>
        <div class="row">
            <asp:GridView ID="gridRequerimiento" runat ="server" margin-right ="auto" 
                CellPadding="10" 

                margin-left="auto" OnSelectedIndexChanged="gridRequerimiento_SelectedIndexChanged"
                OnRowDataBound ="OnRowDataBound" CssClass ="GridView" HorizontalAlign="Center" 
                AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="5" 
                HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px" 
                AutoPostBack ="true" >
            </asp:GridView>
        </div>  
        <asp:Panel runat="server" ID="panelModal1" CssClass="modalPopup" Style="display:none"> 
            <asp:label runat ="server" ID="textModal" style="padding-top:20px;padding-left:11px;padding-right:11px">¿Desea eliminar este requerimiento?</asp:label>
            <br/> <br/>
            <div aria-pressed="true">
                <asp:button runat="server" ID="aceptarModal" Text="Eliminar" OnClick="aceptarModal_Click" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;align-self:center;margin-left:16px;margin-right:11px;margin-bottom:20px"/>
                <asp:button runat="server" ID="cancelarModal" Text="Cancelar" OnClick="cancelarModal_Click" CssClass="btn btn-default" style="border-color:#fe6c4f;color:#fe5e3e;align-self:center;margin-left:11px;margin-right:6px;margin-bottom:20px"/>           
            </div>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="ModalEliminar" runat="server" BackgroundCssClass="modalBackground" PopupControlID="panelModal1" TargetControlID="BotonREQEliminar" OnCancelScript="cancelarModal" OnOkScript="aceptarModal" BehaviorID="ModalEliminar">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" ID="panelModal2" CssClass="modalPopup" Style="display:none"> 
            <asp:label runat ="server" ID="textModal2" style="padding-top:20px;padding-left:11px;padding-right:11px">¿Esta seguro de que quiere cancelar?</asp:label>
            <br/> <br/>
            <div aria-pressed="true">
                <asp:button runat="server" ID="siModalCancelar" Text="Si" OnClick="cancelarModal_Click" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;align-self:center;margin-left:16px;margin-right:11px;margin-bottom:20px"/>
                <asp:button runat="server" ID="noModalCancelar" Text="No" OnClick="siModalCancelar_Click" CssClass="btn btn-default" style="border-color:#fe6c4f;color:#fe5e3e;align-self:center;margin-left:11px;margin-right:6px;margin-bottom:20px"/>           
            </div>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="ModalCancelar" runat="server" BackgroundCssClass="modalBackground" PopupControlID="panelModal2" TargetControlID="BotonREQCancelar" OnCancelScript="noModalCancelar" OnOkScript="siModalCancelar" BehaviorID="ModalCancelar">
        </ajaxToolkit:ModalPopupExtender>
</asp:Content>
