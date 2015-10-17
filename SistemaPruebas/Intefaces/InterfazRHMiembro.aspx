<%@ Page Title="Mi perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazRHMiembro.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazRHMiembro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    

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

    
    <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="EtiqErrorModificar" >*Ha habido problemas para modificar este recurso humano. Por favor vuelva a intentarlo.</asp:Label>

                    <div class="form-group">
                        <div class="col-md-offset-10 col-md-12">
                            <asp:Button runat="server" Text="Modificar" CssClass="btn btn-default" ID="BotonRHModificar" OnClick="BotonRHModificar_Click" />                          
                        </div>
                    </div>

    <div class="row">
        <div class="col-md-8">
                <div class="form-horizontal">
                    
                    <hr />
                      <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-2 control-label" ID="Etiqueta1" >Cédula:</asp:Label>
                        <div class="col-md-10">                           
  
                            <asp:TextBox runat="server" ID="TextBoxCedulaRH" CssClass="form-control" MaxLength="10" onkeypress="return solo_numeros(event)">.</asp:TextBox>
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="CedVal" >*Por favor ingrese solo el numero de la cedula, sin guiones u otros simbolos.</asp:Label>
                                <asp:requiredfieldvalidator id="ValidaCampos"
                                    controltovalidate="TextBoxCedulaRH"
                                    Display="Dynamic"
                                    validationgroup="CamposNoVacios"
                                    CssClass="text-danger" 
                                    errormessage="El campo de Cédula es obligatorio."
                                    runat="Server">
                                </asp:requiredfieldvalidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TextBoxNombreRH" CssClass="col-md-2 control-label">Nombre completo:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxNombreRH" CssClass="form-control" MaxLength="49" onkeypress="return solo_letras(event)">.</asp:TextBox>
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="NombVal">*En este campo solo se permiten letras y espacios</asp:Label>
                               <asp:requiredfieldvalidator id="Requiredfieldvalidator1"
                                    controltovalidate="TextBoxNombreRH"
                                    Display="Dynamic"
                                    validationgroup="CamposNoVacios"
                                    CssClass="text-danger" 
                                    errormessage="El campo de Nombre es obligatorio."
                                    runat="Server">
                                </asp:requiredfieldvalidator>
                        </div>
                    </div>
                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-2 control-label">Teléfono 1:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxTel1" CssClass="form-control" Columns="8" MaxLength="8" onkeypress="return solo_numeros(event)" />
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="TelVal1" >*Por favor ingrese un teléfono valido.</asp:Label>
                            </div>
                        </div>

                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-2 control-label">Teléfono 2:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxTel2" CssClass="form-control" MaxLength="8" onkeypress="return solo_numeros(event)" />
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="TelVal2" >*Por favor ingrese un teléfono valido.</asp:Label>
                            </div>
                        </div>

                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-2 control-label">Email:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxEmail" CssClass="form-control" MaxLength="30" />
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="EmailVal" >*Por favor ingrese un email valido valido.</asp:Label>
                            </div>
                        </div>         
                    </div>
                 </div>
                
                    <h4>Datos del Perfil</h4>
         <div class="col-md-4">
                <div class="form-horizontal">
                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-4 control-label">Nombre de usuario</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="TextBoxUsuario" CssClass="form-control" MaxLength="30" />
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="UserVal" >*Por favor ingrese un usuario valido.</asp:Label>
                            <asp:requiredfieldvalidator id="Requiredfieldvalidator3"
                                    controltovalidate="TextBoxUsuario"
                                    Display="Dynamic"
                                    validationgroup="CamposNoVacios"
                                    CssClass="text-danger" 
                                    errormessage="El campo de Nombre de Usuario es obligatorio."
                                    runat="Server">
                                </asp:requiredfieldvalidator>
                            </div>
                        </div>

                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-4 control-label">Contraseña</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="TextBoxClave" CssClass="form-control" MaxLength="12" />
                            <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="text-danger" ID="ClaveVal" >*Por favor ingrese una contraseña valida.</asp:Label>
                               <asp:requiredfieldvalidator
                                    controltovalidate="TextBoxClave"
                                    Display="Dynamic"
                                    validationgroup="CamposNoVacios"
                                    CssClass="text-danger" 
                                    errormessage="El campo de Contraseña es obligatorio."
                                    runat="Server">
                                </asp:requiredfieldvalidator>
                            </div>
                        </div>

                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-4 control-label">Tipo de perfil</asp:Label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="PerfilAccesoComboBox" runat="server" OnSelectedIndexChanged="PerfilAccesoComboBox_SelectedIndexChanged" AutoPostBack ="true" CssClass="form-control">
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
                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="TextBoxCedulaRH" CssClass="col-md-4 control-label">Proyecto Asociado</asp:Label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ProyectoAsociado" runat="server" OnSelectedIndexChanged="ProyectoAsociado_SelectedIndexChanged" CssClass="form-control">
                              </asp:DropDownList>
                            </div>
                        </div>
                    

</div>
                    </div>
             </div>

                    <div class="form-group">
                        <div class="col-md-offset-10 col-md-12">
                            <asp:Button runat="server" 
                                Text="Aceptar" 
                                causesvalidation="true" 
                                validationgroup="CamposNoVacios"
                                CssClass="btn btn-default" 
                                ID="BotonRHAceptar" 
                                OnClick="BotonRHAceptar_Click" />
                            <asp:Button runat="server" 
                                Text="Aceptar" 
                                causesvalidation="true" 
                                validationgroup="CamposNoVacios"
                                CssClass="btn btn-default" 
                                ID="BotonRHAceptarModificar" OnClick="BotonRHAceptarModificar_Click" 
                                />
                            <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-default" ID="BotonRHCancelar" OnClick="BotonRHCancelar_Click"  OnClientClick="return confirm('¿Está seguro que desea cancelar?')" />
                        </div>
                    </div>
        <div class="row">
        
    </div>  
</asp:Content>
