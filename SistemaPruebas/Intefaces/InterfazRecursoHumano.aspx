<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazRecursoHumano.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazRecursoHumano" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    </b>
    <asp:Label runat="server" AssociatedControlID="UserName" CssClass="text-danger" ID="EtiqErrorInsertar" >*Ha habido problemas para agregar este recurso humano al sistema. Por favor vuelva a intentarlo.</asp:Label>
    <asp:Label runat="server" AssociatedControlID="UserName" CssClass="text-danger" ID="EtiqErrorModificar" >*Ha habido problemas para modificar este recurso humano. Por favor vuelva a intentarlo.</asp:Label>
        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="text-danger" ID="EtiqErrorEliminar" >*Ha habido problemas para eliminar este recurso humano del sistema. Por favor vuelva a intentarlo.</asp:Label>
                    <div class="form-group">
                        <div class="col-md-offset-10 col-md-12">
                            <asp:Button runat="server" Text="Insertar" CssClass="btn btn-default" ID="BotonRHInsertar" OnClick="BotonRHInsertar_Click"  />

                            <asp:Button runat="server" Text="Modificar" CssClass="btn btn-default" ID="BotonRHModificar" OnClick="BotonRHModificar_Click" />

                            <asp:Button runat="server" Text="   Eliminar" CssClass="btn btn-default" ID="BotonRHEliminar" OnClick="BotonRHEliminar_Click" />
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
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label" ID="Etiqueta1" >Cédula:</asp:Label>
                        <div class="col-md-10">
                            
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" MaxLength="10" OnTextChanged="UserName_TextChanged" >.</asp:TextBox>
                            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="text-danger" ID="CedVal" >*Por favor ingrese solo el numero de la cedula, sin guiones u otros simbolos.</asp:Label>
                                <asp:requiredfieldvalidator id="ValidaCampos"
                                    controltovalidate="UserName"
                                    validationgroup="CamposNoVacios"
                                    CssClass="text-danger" 
                                    errormessage="El campo de Cédula es obligatorio."
                                    runat="Server">
                                </asp:requiredfieldvalidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Nombre completo:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" CssClass="form-control" MaxLength="49" >.</asp:TextBox>
                            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="text-danger" ID="NombVal" >*En este campo solo se permiten letras y espacios</asp:Label>
                               <asp:requiredfieldvalidator id="Requiredfieldvalidator1"
                                    controltovalidate="Password"
                                    validationgroup="CamposNoVacios"
                                    CssClass="text-danger" 
                                    errormessage="El campo de Nombre es obligatorio."
                                    runat="Server">
                                </asp:requiredfieldvalidator>
                        </div>
                    </div>
                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Teléfono 1:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxTel1" CssClass="form-control" Columns="8" />
                            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="text-danger" ID="TelVal1" >*Por favor ingrese un teléfono valido.</asp:Label>
                            </div>
                        </div>

                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Teléfono 2:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxTel2" CssClass="form-control" MaxLength="8" />
                            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="text-danger" ID="TelVal2" >*Por favor ingrese un teléfono valido.</asp:Label>
                            </div>
                        </div>

                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Email:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxEmail" CssClass="form-control" MaxLength="30" />
                            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="text-danger" ID="EmailVal" >*Por favor ingrese un email valido valido.</asp:Label>
                            </div>
                        </div>         
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
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
                            <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-default" ID="BotonRHCancelar" OnClick="BotonRHCancelar_Click" />
                        </div>
                    </div>
                </div>
                
                    <h4>Datos del Perfil</h4>
         <div class="col-md-4">
                <div class="form-horizontal">
                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-4 control-label">Nombre de usuario</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="TextBoxUsuario" CssClass="form-control" MaxLength="30" />
                            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="text-danger" ID="UserVal" >*Por favor ingrese un usuario valido.</asp:Label>
                            <asp:requiredfieldvalidator id="Requiredfieldvalidator2"
                                    controltovalidate="TextBoxUsuario"
                                    validationgroup="CamposNoVacios"
                                    CssClass="text-danger" 
                                    errormessage="El campo de Nombre de Usuario es obligatorio."
                                    runat="Server">
                                </asp:requiredfieldvalidator>
                            </div>
                        </div>

                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-4 control-label">Contraseña</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="TextBoxClave" CssClass="form-control" MaxLength="12" />
                            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="text-danger" ID="ClaveVal" >*Por favor ingrese una contraseña valida.</asp:Label>
                               <asp:requiredfieldvalidator
                                    controltovalidate="TextBoxClave"
                                    validationgroup="CamposNoVacios"
                                    CssClass="text-danger" 
                                    errormessage="El campo de Contraseña es obligatorio."
                                    runat="Server">
                                </asp:requiredfieldvalidator>
                            </div>
                        </div>

                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-4 control-label">Tipo de perfil</asp:Label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="PerfilAccesoComboBox" runat="server" OnSelectedIndexChanged="PerfilAccesoComboBox_SelectedIndexChanged" AutoPostBack ="true">
                              </asp:DropDownList>
                            </div>
                        </div>
                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-4 control-label">Rol</asp:Label>
                        <div class="col-md-8">
                                <asp:DropDownList ID="RolComboBox" runat="server" OnSelectedIndexChanged="RolComboBox_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    <div class="form-group">      
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-4 control-label">Proyecto Asociado</asp:Label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ProyectoAsociado" runat="server" OnSelectedIndexChanged="ProyectoAsociado_SelectedIndexChanged" >
                              </asp:DropDownList>
                            </div>
                        </div>
                    

</div>
                    </div>
             </div>
    <div class="row">
        <asp:GridView ID="RH" runat="server"  AutoGenerateColumns ="false"  >
            <Columns>
                <asp:BoundField DataField ="Nombre" HeaderText = "Nombre"    />
                <asp:BoundField DataField ="Cedula" HeaderText = "Cedula"/>
                <asp:BoundField DataField ="Perfil" HeaderText = "Perfil" />
                <asp:BoundField DataField ="Rol"    HeaderText = "Rol" />
            </Columns>

        </asp:GridView>
    </div>  
</asp:Content>
