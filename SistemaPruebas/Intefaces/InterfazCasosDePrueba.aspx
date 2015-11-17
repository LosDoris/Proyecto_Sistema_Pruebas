<%@ Page EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazCasosDePrueba.aspx.cs" Inherits="SistemaPruebas.Intefaces.CasosDePrueba" Async="true"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
        function HideLabel() {
            var seconds = 5;           
            setTimeout(function () {

                $('#'+'<%=EtiqMensajeOperacion.ClientID %>').fadeOut('5000');
            }, 2000);           
    };
</script>


<h2><%: Title %>Casos de Prueba</h2>

<asp:Label runat="server" CssClass="text-danger" ID="EtiqMensajeOperacion" >.</asp:Label>
<asp:Label runat="server" CssClass="text-danger" ID="EtiqErrorInsertar" >*Ha habido problemas para agregar este caso de prueba al sistema. Por favor vuelva a intentarlo.</asp:Label>
<asp:Label runat="server" CssClass="text-danger" ID="EtiqErrorConsultar" >*Ha habido problemas para consultar este caso de prueba. Por favor vuelva a intentarlo mas tarde.</asp:Label>
<asp:Label runat="server" CssClass="text-danger" ID="EtiqErrorModificar" >*Ha habido problemas para modificar este caso de prueba. Por favor vuelva a intentarlo.</asp:Label>
<asp:Label runat="server" CssClass="text-danger" ID="EtiqErrorEliminar" >*Ha habido problemas para eliminar este caso de prueba del sistema. Por favor vuelva a intentarlo.</asp:Label>
<div class="form-group">
    <div class="col-md-offset-10 col-md-12">
        <asp:Button runat="server" Text="Insertar" CssClass="btn btn-default" ID="BotonCPInsertar" OnClick="BotonCPInsertar_Click" CausesValidation="false"/>
        <asp:Button runat="server" Text="Modificar" CssClass="btn btn-default" ID="BotonCPModificar" OnClick="BotonCPModificar_Click" CausesValidation="false"/>
        <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-default" ID="BotonCPEliminar" OnClick="BotonCPEliminar_Click" CausesValidation="false"/>
    </div>
</div>
<div class ="row" style ="width: 100%">    
    <div class="jumbozCP" >
        <h4>Resumen</h4>
        <div class="col-md-6">
            <div class ="form-group">
		        <asp:Label ID="Proposito" runat="server" CssClass="control-label"
                    style="text-align: right; width: 1100px;height: 32px; margin-left: 50px; margin-right: 360px"  Text ="Propósito"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="Nivel" runat="server" CssClass="control-label"
                    style="text-align: right; width: 1100px;height: 32px; margin-left: 50px; margin-right: 360px" Text="Nivel"></asp:Label>
            </div>
            <div class ="form-group">
                <asp:Label ID="Tecnica" runat="server" CssClass="control-label"
                    style="text-align: right; width: 1100px;height: 32px; margin-left: 50px; margin-right: 360px" Text="Técnica"></asp:Label>
            </div>
            <div class ="form-group">
                <asp:Label ID="Proyecto" runat="server" CssClass="control-label"
                    style="text-align: right; width: 1100px;height: 32px; margin-left: 50px; margin-right: 360px" Text="Proyecto"></asp:Label>
            </div>
        </div>
        
        <div class="col-md-12">
		    <asp:Label ID="Requerimientos" runat="server" CssClass="control-label"
                style="text-align: right; width: 1100px;height: 32px; margin-left: 50px;" Text="Requerimientos"></asp:Label>
        </div>
        <asp:Button runat="server" Text="Regresar a Diseño" OnClick="regresarADiseno" CssClass="btn btn-default" ID="Regresar" CausesValidation="false"/>
        <div style="clear:both"></div>

    </div>
</div>

<div class ="col-md-6">
    <div class="jumbozCP1">
            <h4>Datos Caso Prueba</h4>

        <div class="col-md-8">
		    <asp:Label ID="id_casoPrueba" runat="server" CssClass="col-md-2 control-label" style="text-align: right; width: 200px;height: 32px;" Text="ID*:"></asp:Label>                      
		    <asp:TextBox runat="server" ID="TextBoxID" CssClass="form-control" style="width: 200px;height: 50px;" onkeypress="checkInput(event)" AutoPostBack="true" MaxLength="20"/>
		    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" style="margin-left:200px" runat="server" ErrorMessage="Campo requerido" ControlToValidate="TextBoxID" ForeColor="Salmon"></asp:RequiredFieldValidator>
            <script type="text/javascript">
			    function checkInput(e) {
			        var ok = /[A-Za-z0-9-_]/.test(String.fromCharCode(e.charCode));
			        if (e.keyCode == 8) {
			            //alert();
			        }
			        else if (!ok)
                            e.preventDefault();    
			    }
		    </script>
        </div>

		<div class="col-mdP">
		    <asp:Label ID="PropositoCP" runat="server"  CssClass="col-md-2 control-label" style="margin-top: 20px; text-align: right;  width: 200px;height: 50px;" Text="Propósito de Caso de Prueba*:"></asp:Label>                        
		    <asp:TextBox runat="server" ID="TextBoxPropositoCP" CssClass="form-control" style="vertical-align: top; margin-top: 20px; width: 200px;height: 100px;"
                 onkeypress="checkInput3(event)" TextMode="multiline"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" style="margin-left:200px" ErrorMessage="Campo requerido" ControlToValidate="TextBoxPropositoCP" ForeColor="Salmon"></asp:RequiredFieldValidator>
		    <script type="text/javascript">
		        function checkInput3(e) {
		            var key = theEvent.keyCode || theEvent.which;
		            
		            var ok = /[A-Za-z0-9.\"\(\)áéíóú ]/.test(String.fromCharCode(e.charCode));
		            if (e.keyCode == 8) {
		                //alert();
		            }
		            else if (!ok)
				        e.preventDefault();
			    }
		    </script>
            
        </div>

        <div class="jumbozCP2">
            <div class="form-horizontal">
            <h4>Entrada de Datos</h4>
                <div class="form-group">      
                    <asp:Label ID="EntradaDatosCP" runat="server" CssClass="col-md-2 control-label" style="width: 90px; text-align: right; margin-left: 30px; margin-top:20px" Text ="Descripción:"></asp:Label>    
                    <asp:TextBox runat="server" ID="TextBoxDescripcion" style="width:200px" onkeypress="checkInput1(event)" CssClass="form-control"/>
                    <script type="text/javascript">
                        function checkInput1(e) {
                            var ok = /[A-Za-z]/.test(String.fromCharCode(e.charCode));
                            if (e.keyCode == 8) {
                                //alert();
                            }
                            else if (!ok)
                                if ($('#errorNombreSistema').css('display') == 'none') {
                                    $('#errorNombreSistema').fadeIn();
                                    $('#errorNombreSistema').fadeOut(6000);
                                }
                                if (window.event)//IE
                                    e.returnValue = false;
                                else//Firefox
                                    e.preventDefault();
                        }
                    </script>
                </div>
                <div class="form-group">
                    <asp:Label ID="TiposCP" runat="server" CssClass="col-md-2 control-label" style="width: 90px; text-align: right; margin-left: 30px;" Text="Tipo:"></asp:Label>
                        <asp:DropDownList ID="TipoEntrada" runat="server" style="width: 100px;"  CssClass="form-control"  OnSelectedIndexChanged="TipoEntrada_SelectedIndexChanged">
                            <asp:ListItem Text ="Válido" Value =1/>
                            <asp:ListItem Text ="Inválido" Value =2/>
                            <asp:ListItem Text ="No Aplica" Value =3/>
                        </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="DatosCP" runat="server" CssClass="col-md-2 control-label" style="width: 90px; text-align: right; margin-left: 30px;" Text="Datos:"></asp:Label>

                    <asp:TextBox runat="server" ID="TextBoxDatos" style="width:80px;"  onkeypress="checkInput2(event)" CssClass="form-control"/>
                    <script type="text/javascript">
                        function checkInput2(e) {
                            var ok = /[A-Za-z0-9]/.test(String.fromCharCode(e.charCode));
                            if (e.keyCode == 8) {
                                //alert();
                            }
                            else if (!ok)
                                if ($('#errorNombreSistema').css('display') == 'none') {
                                    $('#errorNombreSistema').fadeIn();
                                    $('#errorNombreSistema').fadeOut(6000);
                                }
                        if (window.event)//IE
                            e.returnValue = false;
                        else//Firefox
                            e.preventDefault();
                        }
                    </script>
                    
                </div>
                

                <div class="form-group">          
                        <div class="col-md-offset-5 col-md-12">
                            <asp:Button runat="server" Text="Agregar"                               
                                CssClass="btn btn-default" ID="AgregarEntrada" OnClick="AgregarEntrada_Click" CausesValidation="false"/>
                            <asp:Button runat="server" Text="Eliminar"  
                                CssClass="btn btn-default" ID="EliminarEntrada" OnClick="EliminarEntrada_Click" CausesValidation="false"/>
                        </div>
                </div>

                <div class="form-group">          
                    <div class="col-md-8">
                        <asp:GridView ID="DECP" runat ="server" margin-right ="auto" 
                                    CellPadding="10" 
                                    margin-left="auto" AutoGenerateColumns ="true" 
                                    CssClass ="GridView" HorizontalAlign="Center"   
                                    HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#CDCDCD" border-radius="15px" 
                                    AutoPostBack ="true" OnSelectedIndexChanged="DECP_SelectedIndexChanged"
                                    AllowPaging="true" PageSize="3" OnPageIndexChanging="OnDECPPageIndexChanging" OnRowDataBound ="OnDECPRowDataBound">                            
                        </asp:GridView>
                    </div>
                </div>
                <div style="clear:both"></div>
            </div>


        </div>

    </div>
</div>

<div class="col-md-6">    
    <asp:Label ID="ResultadoCP" runat="server" CssClass="col-md-2 control-label" style="margin-top:120px;" Text="Resultado esperado:"></asp:Label>    
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="TextBoxResultadoCP" onkeypress="checkInput4(event)" style="width:250px;height:150px; margin-top:120px;" CssClass="form-control" MaxLength="50" TextMode="multiline"/>
        <script type="text/javascript">
            function checkInput4(e) {
                var ok = /[A-Za-z.áéíóú ]/.test(String.fromCharCode(e.charCode));
                if (e.keyCode == 8) {
                    //alert();
                }
                else if (!ok)
                    if ($('#errorNombreSistema').css('display') == 'none') {
                        $('#errorNombreSistema').fadeIn();
                        $('#errorNombreSistema').fadeOut(6000);
                    }
                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
            }
        </script>
    </div>
    <asp:Label ID="FlujoCP" runat="server" CssClass="col-md-2 control-label" style="width:20px;margin-top:20px;" Text="Flujo Central:"></asp:Label>    
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="TextBoxFlujoCentral" onkeypress="checkInput5(event)" style="margin-top:20px; width:250px; height:150px; margin-left: 63px;" CssClass="form-control" MaxLength="50" TextMode="multiline"/>
        <script type="text/javascript">
            function checkInput5(e) {
                var ok = /[A-Za-z0-9.\"\(\)áéíóú +]/.test(String.fromCharCode(e.charCode));
                if (e.keyCode == 8) {
                    //alert();
                }
                else if (!ok)
                    if ($('#errorNombreSistema').css('display') == 'none') {
                        $('#errorNombreSistema').fadeIn();
                        $('#errorNombreSistema').fadeOut(6000);
                    }
                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
            }
        </script>
    </div>
    <div class="form-group col-md-offset-10 col-md-12">
        <asp:Label runat="server" id="CamposObligarotios" Text="Campos Obligatorios*" style="color: #C0C0C0;" CssClass="control-label"></asp:label>
    </div>
    <div class="col-md-10">
        <asp:Button runat="server" style="border-color:#4bb648;color:#4bb648;margin-top:200px;margin-left: 200px;margin-top: 50px;"
            Text="Aceptar" 
            causesvalidation="true"                              
            CssClass="btn btn-default" 
            ID="BotonCPAceptar" OnClick="BotonCPAceptar_Click" 
        />
        <asp:Button runat="server" Text="Cancelar" style="border-color:#fe6c4f;color:#fe5e3e;margin-top: 50px;" 
            CssClass="btn btn-default" ID="BotonCPCancelar"  
            OnClick="BotonCPCancelar_Click" 
            CausesValidation="false"
        />
    </div>
</div>



 <div class="row">        
    <asp:GridView ID="CP" runat ="server" margin-right ="auto"
            style="margin-top: 900px;"
            CellPadding="10" 
            margin-left="auto"
            CssClass ="GridView" HorizontalAlign="Center" 
            OnRowDataBound="OnCPRowDataBound" 
            AllowPaging="true"   PageSize="5" 
            OnPageIndexChanging="OnCPPageIndexChanging"
            HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px" 
            AutoPostBack ="true" OnSelectedIndexChanged="CP_SelectedIndexChanged" >      
    </asp:GridView>
</div> 



<asp:Panel runat="server" ID="cancelarPanelModal" CssClass="modalPopup"> 
    <asp:label runat ="server" ID="cancelarLabelModal" style="padding-top:20px;padding-left:11px;padding-right:11px">¿Desea cancelar la operación?</asp:label>
    <br/> <br/>
    <div aria-pressed="true">
        <asp:button runat="server" ID="cancelarBotonSiModal" Text="Si" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;margin-left:20px;margin-right:20px;margin-bottom:20px" CausesValidation="false" OnClick="cancelarModal_Click"/>
        <asp:button runat="server" ID="cancelarBotonNoModal" Text="No" CssClass="btn btn-default" style="border-color:#fe6c4f;color:#fe5e3e;align-self:center;margin-left:20px;margin-right:20px;margin-bottom:20px" CausesValidation="false" />           
    </div>
</asp:Panel>
<ajaxToolkit:ModalPopupExtender ID="ModalCancelar" runat="server" BackgroundCssClass="modalBackground" PopupControlID="cancelarPanelModal" TargetControlID="BotonCPCancelar" OnCancelScript="cancelarButtonNoModal" OnOkScript="cancelarButtonSiModal"></ajaxToolkit:ModalPopupExtender>

<asp:Panel runat="server" ID="panelModal" CssClass="modalPopup"> 
    <asp:label runat ="server" ID="textModal" style="padding-top:20px;padding-left:11px;padding-right:11px">¿Desea eliminar este caso de prueba?</asp:label>
    <br/> <br/>
    <div aria-pressed="true">
        <asp:button runat="server" ID="aceptarModal" Text="Eliminar"  CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;align-self:center;margin-left:16px;margin-right:11px;margin-bottom:20px" OnClick="aceptarModalEliminar_Click" CausesValidation="false"/>
        <asp:button runat="server" ID="cancelarModal" Text="Cancelar"  CssClass="btn btn-default" style="border-color:#fe6c4f;color:#fe5e3e;align-self:center;margin-left:11px;margin-right:6px;margin-bottom:20px" OnClick="cancelarModal_Click" CausesValidation="false"/>           
    </div>
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="ModalEliminar" runat="server" BackgroundCssClass="modalBackground" PopupControlID="panelModal" TargetControlID="BotonCPEliminar" OnCancelScript="cancelarModal" OnOkScript="aceptarModal"></ajaxToolkit:ModalPopupExtender>
</asp:Content>
