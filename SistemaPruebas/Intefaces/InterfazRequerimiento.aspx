<%@ Page Title="Requerimientos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazRequerimiento.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazRequerimiento" %>
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

    <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorInsertar" >*Ha habido problemas para agregar este requerimiento al sistema. Por favor vuelva a intentarlo.</asp:Label>
    <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorConsultar" >*Ha habido problemas para consultar este requerimiento. Por favor vuelva a intentarlo mas tarde.</asp:Label>
    <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorLlaves" >*El ID ingresado ya pertenece a un requerimiento del proyecto. Por favor ingrese otra identificación.</asp:Label>
    <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorModificar" >*Ha habido problemas para modificar este recurso humano. Por favor vuelva a intentarlo.</asp:Label>
        <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorEliminar" >*Ha habido problemas para eliminar este recurso humano del sistema. Por favor vuelva a intentarlo.</asp:Label>
                    <div class="form-group">
                        <div class="col-md-offset-5 col-md-12">
                            <asp:Button runat="server" Text="Insertar" CssClass="btn btn-default" ID="BotonREQInsertar" OnClick="BotonREQInsertar_Click"  />

                            <asp:Button runat="server" Text="Modificar" CssClass="btn btn-default" ID="BotonREQModificar" OnClick="BotonREQModificar_Click" />

                            <asp:Button runat="server" Text="   Eliminar" CssClass="btn btn-default" ID="BotonREQEliminar"  OnClientClick="return confirm('¿Está seguro que desea eliminar esta cuenta?')"  OnClick="BotonREQEliminar_Click" />
                        </div>
                    </div>

    <div class="row">
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
                                    <asp:DropDownList ID="ProyectoAsociado" runat="server" OnSelectedIndexChanged="ProyectoAsociado_SelectedIndexChanged" CssClass="form-control" Width="232px">
                                    </asp:DropDownList>
                                </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-16">
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="col-md-3 control-label">ID del requerimiento:</asp:Label>
                            <asp:TextBox runat="server" ID="TextBoxNombreREQ" CssClass="form-control" MaxLength="49" onkeypress="return solo_letras(event)" Width="230px">.</asp:TextBox>
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="NombVal">*En este campo solo se permiten letras y espacios</asp:Label>
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
                            <asp:TextBox runat="server" ID="TextBoxPrecondiciones" CssClass="form-control" MaxLength="49" onkeypress="return solo_letras(event)" Width="230px">.</asp:TextBox>
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="EtiqErrorPrecondiciones">*En este campo solo se permiten letras y espacios.</asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="col-md-3 control-label">Condiciones Especiales:</asp:Label>
                            <div class="col-md-16">
                            <asp:TextBox runat="server" ID="TextBoxRequerimientosEspeciales" CssClass="form-control" MaxLength="49" onkeypress="return solo_letras(event)" Width="230px" Height="79px">.</asp:TextBox>
                            <asp:Label runat="server" AssociatedControlID="TextBoxNombreREQ" CssClass="text-danger" ID="Label1">*En este campo solo se permiten letras y espacios.</asp:Label>
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
                <asp:Button runat="server" Text="Cancelar" style="border-color:#fe6c4f;color:#fe5e3e" CssClass="btn btn-default" ID="BotonREQCancelar" OnClick="BotonREQCancelar_Click"  OnClientClick="return confirm('¿Está seguro que desea cancelar?')" />
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
</asp:Content>
