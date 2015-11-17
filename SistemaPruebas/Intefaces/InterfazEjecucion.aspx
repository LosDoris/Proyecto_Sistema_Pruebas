<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazEjecucion.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazEjecucion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
<legend style="margin-top:45px"><h2><%: Title %>Módulo Ejecución de Prueba</h2></legend>

<asp:Label runat="server" CssClass="text-danger" ID="EtiqMensajeOperacion" Visible ="false" ></asp:Label>

<div class="form-group">
    <div class="col-md-offset-9 col-md-12">
        <div class="btn-group">
        <asp:Button runat="server" Text="Insertar" CssClass="btn btn-default"  ID="BotonEPInsertar"    CausesValidation="false" OnClick="BotonEPInsertar_Click"/>
        <asp:Button runat="server" Text="Modificar" CssClass="btn btn-default" ID="BotonEPModificar"   CausesValidation ="false"/>
        <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-default"  ID="BotonEPEliminar"    CausesValidation="false"/>
    </div>
    </div>
</div>
<hr style="margin:50px;">

  <div class="panel panel-primary">
  <div class="panel-heading">
    <h3 class="panel-title">Selección del origen</h3>
  </div>
  <div class="panel-body">

     <div class ="row">
        <div class ="col-md-2" style="text-align:center">
            <asp:Label ID="LabelProyecto" runat="server" Text="Proyecto:" CssClass = "col-md-2 control-label"></asp:Label>
        </div>
        <div class ="col-md-4">
            <asp:DropDownList ID="DropDownProyecto" runat="server" CssClass ="form-control"  style="width:250px" OnSelectedIndexChanged="DropDownProyecto_SelectedIndexChanged" AutoPostBack="true" >
                <asp:ListItem Text ="Seleccionar" Value =1/>
            </asp:DropDownList>
        </div>
        <div class ="col-md-2">
             <asp:Label ID="LabelDiseno" runat="server" Text="Diseño:" CssClass = "col-md-2 control-label"></asp:Label>
        </div>
        <div class ="col-md-4">
              <asp:DropDownList ID="DropDownDiseno" runat="server" CssClass ="form-control" style="width:250px" AutoPostBack ="true" OnSelectedIndexChanged="DropDownDiseno_SelectedIndexChanged" >
                 <asp:ListItem Text ="Seleccionar" Value =1/>
              </asp:DropDownList>
        </div>
    </div>
  
  </div>
</div> 

<div class="well" style="margin-bottom:0px">
 <legend><h4>Lista de no conformidades</h4></legend>
 <asp:Panel ID="DatosEjecucion" runat ="server">
    <div class ="row" >
       <div class="form-horizontal">
           <div class ="form-group">
               <div class ="col-md-2">
                    <asp:Label ID="TipoEP" runat="server" Text="Tipo:" CssClass = "col-md-2 control-label"></asp:Label>
                </div>
                <div class ="col-md-4">
                    <asp:DropDownList ID="DropDownTipoEP" runat="server" CssClass ="form-control" style="width:250px">
                        <asp:ListItem Text ="Seleccionar" Value =1/>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="CasoDePrueba" runat="server" CssClass = "col-md-6 control-label" Width="200px">Caso de Prueba:</asp:Label>   
                </div>
                <div class ="col-md-4">
                    <asp:DropDownList ID="DropDownCasoDePrueba" runat="server" CssClass ="form-control" style="width:250px" >
                        <asp:ListItem Text ="Seleccionar" Value =1/>
                    </asp:DropDownList>
                </div>
           </div>
            <div class ="form-group">
                <div class="col-md-2">
                    <asp:Label ID="DescripcionEP" runat="server" CssClass="col-md-2 control-label" Text ="Descripción:"></asp:Label>  
                </div>  
                <div class ="col-md-9">
                    <asp:TextBox runat="server" ID="TextBoxDescripcion" CssClass="form-control" MaxLength="300" TextMode="multiline" Style="height: 90px"/>
                    <div id="errorTextBoxDescripcion" style="display: none; width: 500px;">
                        <asp:Label runat="server" ID="errorNombreSistLbl2" Text="Sólo se permite el ingreso de letras y espacios" ForeColor="Salmon" Visible ="false"></asp:Label>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo requerido" ControlToValidate="TextBoxDescripcion" ForeColor="Salmon"></asp:RequiredFieldValidator>
                </div>
            </div>
           <div class ="form-group">
                <div class="col-md-2">
                    <asp:Label ID="JustificacionEP" runat="server" CssClass="col-md-2 control-label" Text ="Justificación:"></asp:Label>  
                </div>  
                <div class ="col-md-9">
                    <asp:TextBox runat="server" ID="TextBoxJustificacion" CssClass="form-control" MaxLength="300" TextMode="multiline" Style="height: 90px"/>
                    <div id="errorTextBoxJustificacion" style="display: none; width: 500px;">
                        <asp:Label runat="server" ID="Label2" Text="Sólo se permite el ingreso de letras y espacios" ForeColor="Salmon" Visible ="false"></asp:Label>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo requerido" ControlToValidate="TextBoxDescripcion" ForeColor="Salmon"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class ="form-group">
                <div class="col-md-2">
                    <asp:Label ID="ResultadoEP" runat="server" CssClass="col-md-2 control-label" Text ="Resultado:"></asp:Label>  
                </div>  
                <div class="col-md-3">
                    <%--<asp:Image ID="ImagenResultado" runat="server" ImageUrl="~/Intefaces/ejemplo.jpg" style="max-height:100px;max-width:100px;border-color:#2e8e9e"/>--%>
                    <asp:FileUpload id="FileUploadControl" runat="server" />
                    </div>
            </div>

<div class="form-group">
    <div class="col-md-offset-2 col-md-12">

<asp:Button runat="server" Text="Subir Imagen"   CssClass="btn btn-primary"   ID="Subir"     CausesValidation ="false" OnClick="Subir_Click"/>
<asp:Button runat="server" Text="Mostrar Imagen" CssClass="btn btn-default" ID="Mostrar"   CausesValidation ="false"/>
    </div>
</div>

           <div class ="form-group">
               <div class ="col-md-2">
                    <asp:Label ID="EstadoEP" runat="server" Text="Estado:" CssClass = "col-md-2 control-label"></asp:Label>
                </div>
                <div class ="col-md-4">
                    <asp:DropDownList ID="DropDownEstado" runat="server" CssClass ="form-control" style="width:250px">
                        <asp:ListItem Text ="Seleccionar" Value =1/>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="ResponsableEP" runat="server" CssClass = "col-md-1 control-label" >Responsable:</asp:Label>  
                </div>
                <div class ="col-md-4">
                    <asp:DropDownList ID="DropDownResponsable" runat="server" CssClass ="form-control" style="width:250px">
                        <asp:ListItem Text ="Seleccionar" Value =1/>
                    </asp:DropDownList>
                </div>
           </div>

           <div class ="form-group">
               <div class ="col-md-2">
                    <asp:Label ID="FechaEP" runat="server" CssClass = "col-md-6 control-label" >Fecha:</asp:Label> 
                </div>
                   <asp:ImageButton ID="imgPopup" ImageUrl="~/Imagenes/calendar.png" runat="server" />
                <div class ="col-md-2">
                   <asp:TextBox runat="server" ID="ControlFecha" CssClass="form-control"></asp:TextBox>
                   <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgPopup" TargetControlID="ControlFecha" />
                </div>            
           </div>

           <div class ="form-group">
                <div class="col-md-2">
                    <asp:Label ID="Incidencias" runat="server" CssClass="col-md-2 control-label" Text ="Incidencias:"></asp:Label>  
                </div>  
                <div class ="col-md-9">
                    <asp:TextBox runat="server" ID="TextBoxIncidencias" CssClass="form-control" MaxLength="300" TextMode="multiline" Style="height: 90px"/>
                    <div id="errorTextBoxIncidencias" style="display: none; width: 500px;">
                        <asp:Label runat="server" ID="Label3" Text="Sólo se permite el ingreso de letras y espacios" ForeColor="Salmon" Visible ="false"></asp:Label>
                    </div>
                </div>
            </div>
       </div>
    </div>
</asp:Panel>
</div>

<div class="form-group">
    <div class="col-md-offset-8 col-md-12">
        <asp:Button runat="server" style="border-color:#4bb648;color:#4bb648;margin-top:200px;margin-left: 200px;margin-top: 50px;"
            Text="Aceptar" causesvalidation="true" CssClass="btn btn-default"  ID="BotonEPAceptar"/>
        <asp:Button runat="server" Text="Cancelar" style="border-color:#fe6c4f;color:#fe5e3e;margin-top: 50px;" 
            CssClass="btn btn-default" ID="BotonEPCancelar" CausesValidation="false"/>
    </div>
</div>
   
<div class="row">
    <asp:GridView ID="GridEP" runat="server" margin-right="auto"
        CellPadding="10"
        margin-left="auto"
        CssClass="GridView" HorizontalAlign="Center"
        AllowPaging="true"  PageSize="5"
        HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px"
        AutoPostBack="true">
    </asp:GridView>
</div>
<asp:Panel runat="server" ID="cancelarPanelModal" CssClass="modalPopup"> 
    <asp:label runat ="server" ID="cancelarLabelModal" style="padding-top:20px;padding-left:11px;padding-right:11px">¿Desea cancelar la operación?</asp:label>
    <br/> <br/>
    <div aria-pressed="true">
        <asp:button runat="server" ID="cancelarBotonSiModal" Text="Si" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;margin-left:20px;margin-right:20px;margin-bottom:20px" CausesValidation="false"/>
        <asp:button runat="server" ID="cancelarBotonNoModal" Text="No" CssClass="btn btn-default" style="border-color:#fe6c4f;color:#fe5e3e;align-self:center;margin-left:20px;margin-right:20px;margin-bottom:20px" CausesValidation="false" />           
    </div>
</asp:Panel>
<ajaxToolkit:ModalPopupExtender ID="ModalCancelar" runat="server" BackgroundCssClass="modalBackground" PopupControlID="cancelarPanelModal" TargetControlID="BotonEPCancelar" ></ajaxToolkit:ModalPopupExtender>

<asp:Panel runat="server" ID="panelModal" CssClass="modalPopup"> 
    <asp:label runat ="server" ID="textModal" style="padding-top:20px;padding-left:11px;padding-right:11px">¿Desea eliminar este caso de prueba?</asp:label>
    <br/> <br/>
    <div aria-pressed="true">
        <asp:button runat="server" ID="aceptarModal" Text="Eliminar"  CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;align-self:center;margin-left:16px;margin-right:11px;margin-bottom:20px" CausesValidation="false"/>
        <asp:button runat="server" ID="cancelarModal" Text="Cancelar"  CssClass="btn btn-default" style="border-color:#fe6c4f;color:#fe5e3e;align-self:center;margin-left:11px;margin-right:6px;margin-bottom:20px" CausesValidation="false"/>           
    </div>
</asp:Panel>
<ajaxToolkit:ModalPopupExtender ID="ModalEliminar" runat="server" BackgroundCssClass="modalBackground" PopupControlID="panelModal" TargetControlID="BotonEPEliminar" OnCancelScript="cancelarModal" OnOkScript="aceptarModal"></ajaxToolkit:ModalPopupExtender>

<asp:Panel runat="server" ID="PanelImagen" CssClass="modalPopup"> 
    <asp:Image ID="ImagenResultado" runat="server" style="max-height:400px" />
    <br/> <br/>
    <div aria-pressed="true">
        <asp:button runat="server" ID="CerrarPanel" Text="Cerrar" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;margin-left:20px;margin-right:20px;margin-bottom:20px" CausesValidation="false" />
    </div>
</asp:Panel>
<ajaxToolkit:ModalPopupExtender ID="ModalImagen" runat="server" BackgroundCssClass="modalBackground" PopupControlID="PanelImagen" TargetControlID="Mostrar" ></ajaxToolkit:ModalPopupExtender>

</asp:Content>
