﻿<%@ Page Title="Recursos Humanos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazRecursoHumano.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazRecursoHumano" Async="true" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
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

        .errorDiv {
            display: none;
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

                $('#' + '<%=EtiqErrorGen.ClientID %>').fadeOut('5000');
            }, 2000);
        }
    </script>
    <script type="text/javascript">
        function solo_numeros(evt) {
            if (evt.charCode > 31 && (evt.charCode < 48 || evt.charCode > 57)) {
                //alert("Sólo se permite números");
                return false;
            }
            else
                return true;
        }
    </script>
    <script type="text/javascript">
        function solo_letras(evt) {
            if ((evt.charCode < 32 || evt.charCode > 32) && (evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122) && (evt.charCode < 209 || evt.charCode > 209) && (evt.charCode < 241 || evt.charCode > 241)) {
                //alert("Sólo se permite letras");
                return false;
            }
            else
                return true;
        }
    </script>
    <asp:Label runat="server" ID="EtiqErrorGen" Visible="false"></asp:Label>
    <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="EtiqErrorInsertar">*Ha habido problemas para agregar este recurso humano al sistema. Por favor vuelva a intentarlo.</asp:Label>
    <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="EtiqErrorConsultar">*Ha habido problemas para consultar este recurso humano. Por favor vuelva a intentarlo mas tarde.</asp:Label>
    <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="EtiqErrorLlaves">*La cédula ingresada ya pertenece a un usuario de la aplicación. Por favor ingrese otra identificación.</asp:Label>
    <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="EtiqErrorModificar">*Ha habido problemas para modificar este recurso humano. Por favor vuelva a intentarlo.</asp:Label>
    <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="EtiqErrorEliminar">*Ha habido problemas para eliminar este recurso humano del sistema. Por favor vuelva a intentarlo.</asp:Label>
    <div class="form-group">
        <div class="col-md-offset-10 col-md-12">
            <asp:Button runat="server" Text="Insertar" CssClass="btn btn-default" ID="BotonRHInsertar" OnClick="BotonRHInsertar_Click" CausesValidation="False" />

            <asp:Button runat="server" Text="Modificar" CssClass="btn btn-default" ID="BotonRHModificar" OnClick="BotonRHModificar_Click" CausesValidation="False" />

            <asp:Button runat="server" Text="   Eliminar" CssClass="btn btn-default" ID="BotonRHEliminar" OnClick="BotonRHEliminar_Click" CausesValidation="False" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-8">
            <div class="col-md-8">
                <div class="form-horizontal">


                    <div class="jumbozRH">
                        <h4>Datos Personales</h4>
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-2 control-label" ID="Etiqueta1">Cédula:</asp:Label>
                            <div class="col-md-10">

                                <asp:TextBox runat="server" ID="TextBoxCedulaRH" Style="width: 250px" CssClass="form-control" MaxLength="10" onkeypress="check_txt(event)" placeholder="Formato: 000000000">.</asp:TextBox>
                                <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="CedVal">*Por favor ingrese solo el numero de la cedula, sin guiones u otros simbolos.</asp:Label>
                                <asp:RequiredFieldValidator ID="ValidaCampos"
                                    ControlToValidate="TextBoxCedulaRH"
                                    Display="Dynamic"
                                    ValidationGroup="CamposNoVacios"
                                    CssClass="text-danger"
                                    ErrorMessage="El campo de Cédula es obligatorio."
                                    runat="Server">
                                </asp:RequiredFieldValidator>
                                <script type="text/javascript">
                                    function check_txt(e) {
                                        if (!solo_numeros(e)) {
                                            $('#errorCedula').fadeIn();
                                            $('#errorCedula').fadeOut(5000);

                                            if (window.event)//IE
                                                e.returnValue = false;
                                            else//Firefox
                                                e.preventDefault();
                                        }
                                        else
                                            $('#errorCedula').fadeOut();
                                    };
                                </script>
                                <div id="errorCedula" class="errorDiv">
                                    <asp:Label runat="server" Text="Este campo sólo acepta números" CssClass="text-danger"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreRH" CssClass="col-md-2 control-label">Nombre completo:</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBoxNombreRH" Style="width: 250px" CssClass="form-control" MaxLength="49" onkeypress="return solo_letras(event)">.</asp:TextBox>
                                <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="NombVal">*En este campo solo se permiten letras y espacios</asp:Label>
                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator1"
                                    ControlToValidate="TextBoxNombreRH"
                                    Display="Dynamic"
                                    ValidationGroup="CamposNoVacios"
                                    CssClass="text-danger"
                                    ErrorMessage="El campo de Nombre es obligatorio."
                                    runat="Server">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-2 control-label">Teléfono 1:</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBoxTel1" Style="width: 250px" CssClass="form-control" Columns="8" MaxLength="8" onkeypress="return solo_numeros(event)" />
                                <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="TelVal1">*Por favor ingrese un teléfono valido.</asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-2 control-label">Teléfono 2:</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBoxTel2" Style="width: 250px" CssClass="form-control" MaxLength="8" onkeypress="return solo_numeros(event)" />
                                <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="TelVal2">*Por favor ingrese un teléfono valido.</asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-2 control-label">Email:</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBoxEmail" Style="width: 250px" CssClass="form-control" MaxLength="30" />
                                <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="EmailVal">*Por favor ingrese un email valido valido.</asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="jumbozRH">
                <h4>Datos del Perfil</h4>
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-4 control-label">Nombre de usuario</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="TextBoxUsuario" CssClass="form-control" MaxLength="30" />
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="UserVal">*Por favor ingrese un usuario valido.</asp:Label>
                            <asp:RequiredFieldValidator ID="Requiredfieldvalidator3"
                                ControlToValidate="TextBoxUsuario"
                                Display="Dynamic"
                                ValidationGroup="CamposNoVacios"
                                CssClass="text-danger"
                                ErrorMessage="El campo de Nombre de Usuario es obligatorio."
                                runat="Server">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-4 control-label">Contraseña</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="TextBoxClave" CssClass="form-control" MaxLength="12" />
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="ClaveVal">*Por favor ingrese una contraseña valida.</asp:Label>
                            <asp:RequiredFieldValidator
                                ControlToValidate="TextBoxClave"
                                Display="Dynamic"
                                ValidationGroup="CamposNoVacios"
                                CssClass="text-danger"
                                ErrorMessage="El campo de Contraseña es obligatorio."
                                runat="Server">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-4 control-label">Tipo de perfil</asp:Label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="PerfilAccesoComboBox" runat="server" OnSelectedIndexChanged="PerfilAccesoComboBox_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-4 control-label">Rol</asp:Label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="RolComboBox" runat="server" OnSelectedIndexChanged="RolComboBox_SelectedIndexChanged" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>



                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-4 control-label">Proyecto Asociado</asp:Label>
                <div class="col-md-8">
                    <asp:DropDownList ID="ProyectoAsociado" runat="server" OnSelectedIndexChanged="ProyectoAsociado_SelectedIndexChanged" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>

        </div>
    </div>
    <div class="form-group">
        <div class="col-md-offset-10 col-md-12">
            <asp:Button runat="server" Style="border-color: #4bb648; color: #4bb648"
                Text="Aceptar"
                CausesValidation="True"
                ValidationGroup="CamposNoVacios"
                CssClass="btn btn-default"
                ID="BotonRHAceptar"
                OnClick="BotonRHAceptar_Click" />
            <asp:Button runat="server" Style="border-color: #4bb648; color: #4bb648"
                Text="Aceptar"
                CausesValidation="True"
                ValidationGroup="CamposNoVacios"
                CssClass="btn btn-default"
                ID="BotonRHAceptarModificar" OnClick="BotonRHAceptarModificar_Click" />
            <asp:Button runat="server" Text="Cancelar" Style="border-color: #fe6c4f; color: #fe5e3e" CssClass="btn btn-default" ID="BotonRHCancelar" OnClick="BotonRHCancelar_Click" CausesValidation="False" />
            <asp:Panel runat="server" ID="cancelarPanelModal" CssClass="modalPopup"> 
        <asp:label runat ="server" ID="cancelarLabelModal" style="padding-top:20px;padding-left:11px;padding-right:11px">¿Desea cancelar la operación?</asp:label>
        <br/> <br/>
        <div aria-pressed="true">
            <asp:button runat="server" ID="cancelarButtonSiModal" Text="Si" OnClick="cancelar_Click" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;margin-left:20px;margin-right:20px;margin-bottom:20px" CausesValidation="false"/>
            <asp:button runat="server" ID="cancelarButtonNoModal" Text="No" CssClass="btn btn-default" style="border-color:#fe6c4f;color:#fe5e3e;align-self:center;margin-left:20px;margin-right:20px;margin-bottom:20px" CausesValidation="false"/>           
       </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" PopupControlID="cancelarPanelModal" TargetControlID="BotonRHCancelar" OnCancelScript="cancelarButtonNoModal" OnOkScript="cancelarButtonSiModal">
    </ajaxToolkit:ModalPopupExtender>
        </div>
    </div>
    <div class="row">

        <asp:GridView ID="RH" runat="server" margin-right="auto"
            CellPadding="10"
            margin-left="auto" OnSelectedIndexChanged="RH_SelectedIndexChanged"
            OnRowDataBound="OnRowDataBound" CssClass="GridView" HorizontalAlign="Center"
            AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="5"
            HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px"
            AutoPostBack="true">
        </asp:GridView>
    </div>
    <asp:Panel runat="server" ID="panelModal" CssClass="modalPopup"> 
        <asp:label runat ="server" ID="textModal" style="padding-top:20px;padding-left:11px;padding-right:11px">¿Desea eliminar este Recurso Humano?</asp:label>
        <br/> <br/>
        <div aria-pressed="true">
            <asp:button runat="server" ID="aceptarModal" Text="Eliminar" OnClick="aceptarModal_Click" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;align-self:center;margin-left:16px;margin-right:11px;margin-bottom:20px"/>
            <asp:button runat="server" ID="cancelarModal" Text="Cancelar" OnClick="cancelarModal_Click" CssClass="btn btn-default" style="border-color:#fe6c4f;color:#fe5e3e;align-self:center;margin-left:11px;margin-right:6px;margin-bottom:20px"/>           
       </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalEliminar" runat="server" BackgroundCssClass="modalBackground" PopupControlID="panelModal" TargetControlID="BotonRHEliminar" OnCancelScript="cancelarModal" OnOkScript="aceptarModal">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>
