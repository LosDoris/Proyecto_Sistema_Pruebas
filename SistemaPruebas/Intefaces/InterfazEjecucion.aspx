<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazEjecucion.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazEjecucion" EnableEventValidation="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
<script type="text/javascript">
        $(document).ready(function () {
            $("[id$=A5]").addClass("active");
        });
</script>

<legend style="margin-top:45px"><h2><%: Title %>Módulo Ejecución de Prueba</h2></legend>

<asp:Label runat="server" CssClass="text-danger" ID="EtiqMensajeOperacion" Visible ="false" ></asp:Label>

<asp:Panel ID= "BotonesPrincipales" runat="server" CssClass="form-group">
    <div class="col-md-offset-9 col-md-12">
        <div class="btn-group">
        <asp:Button runat="server" Text="Insertar" CssClass="btn btn-default"  ID="BotonEPInsertar"    CausesValidation="false" OnClick="BotonEPInsertar_Click"/>
        <asp:Button runat="server" Text="Modificar" CssClass="btn btn-default" ID="BotonEPModificar"   CausesValidation ="false" OnClick="BotonEPModificar_Click"/>
        <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-default"  ID="BotonEPEliminar"    CausesValidation="false"/>
    </div>
    </div>
</asp:Panel>
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
 <legend><h4>Ejecución de Prueba</h4></legend>
 <asp:Panel ID="DatosEjecucion" runat ="server">
    <div class ="row" >
       <div class="form-horizontal">
            <div class ="form-group">
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
           <div class ="row">
               <asp:GridView runat ="server" ID ="gridNoConformidades" OnRowDataBound ="gridNoConformidades_RowDataBound"  AutoGenerateColumns="false"
                   CssClass ="GridView" HorizontalAlign="Center" OnRowCommand="gridNoConformidades_RowCommand"  >
                   <Columns>
                       <%--<asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />--%>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="checkEliminar" ToolTip="Seleccione si quiere eliminar fila" OnCheckedChanged="checkEliminar_CheckedChanged" AutoPostBack="true" />
                            <asp:Label runat="server" ID="lblId" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Tipo de no conformidad">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblTipo" Visible="false" Text='<%# Eval("Tipo") %>'></asp:Label>
                            <asp:DropDownList ID="ddlTipo" runat="server" ClientIDMode="Static" CssClass="form-control" Width="250px"> 
                                <asp:ListItem Text="Seleccionar" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Funcionalidad" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Validación" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Opciones que no funcionan" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Errores de usabilidad" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Excepciones" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Implementación diferente a documentación"></asp:ListItem>
                                <asp:ListItem Text="Ortografía" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ValidarTipo" runat="server" ControlToValidate="ddlTipo" InitialValue="1" ErrorMessage="Campo Requerido" ForeColor="Salmon"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Id Caso de Prueba">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblIdCaso" Visible="false" Text='<%# Eval("IdCaso") %>'></asp:Label>
                            <asp:DropDownList ID="ddlIdCaso" runat="server" ClientIDMode="Static" CssClass="form-control"> </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Descripción">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDescripcion" Visible="false"></asp:Label>
                            <asp:TextBox ID="txtDescripcion" runat="server" Text='<%# Eval("Descripcion") %>' CssClass="form-control" TextMode="multiline"    ></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Justificación">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblJustificacion" Visible="false"></asp:Label>
                            <asp:TextBox ID="txtJustificacion" runat="server" Text='<%# Eval("Justificacion") %>' CssClass="form-control" TextMode="multiline"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Resultado">
                        <ItemTemplate>
				            <asp:Button ID="botonImagen" runat="server" Text="Imagen" CausesValidation="false" />
                            <asp:Panel runat="server" ID="panelSubirImagen" CssClass="modalPopup"> 
                                <asp:Image ID="imagenSubida" runat="server" style="max-height:400px" />
                                <asp:FileUpload id="Uploader" runat="server" />
                                <br/> <br/>
                                <div aria-pressed="true">
                                    <asp:button runat="server" ID="subirImagen" Text="Subir" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648;margin-left:20px;margin-right:20px;margin-bottom:20px" CausesValidation="false" OnClick="subirImagen_Click" CommandArgument="0"/>
                                    <asp:button runat="server" ID="mostrarImagen" Text="Cerrar" CssClass="btn btn-default" style="border-color:#fe6c4f;color:#fe5e3e;align-self:center;margin-left:20px;margin-right:20px;margin-bottom:20px"     CausesValidation="false"        CommandArgument="0" />           
                                </div>
                            </asp:Panel>
                            <ajaxToolkit:ModalPopupExtender ID="modalSubir" runat="server" BackgroundCssClass="modalBackground" PopupControlID="panelSubirImagen" TargetControlID="botonImagen"></ajaxToolkit:ModalPopupExtender>
			            </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblEstado" Visible="false" Text='<%# Eval("Estado") %>'></asp:Label>
                            <asp:DropDownList ID="ddlEstado" runat="server" ClientIDMode="Static" CssClass="form-control">
                                <asp:ListItem Text="Seleccionar" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Satisfactorio" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Fallido" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Pendiente" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Cancelado" Value="5"></asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                   </Columns>
               </asp:GridView>
               <div class="form-group">
                    <div class="col-md-offset-8 col-md-12">
                        <asp:Button runat="server" style="margin-top:200px;margin-left: 200px;margin-top: 50px;"
                            Text="+" causesvalidation="false" CssClass="btn btn-default"  ID="AgregarFIla" OnClick="AgregarFIla_Click"/>
                        <asp:Button runat="server" Text="-" style="margin-top: 50px;" 
                            CssClass="btn btn-default" ID="EliminarFila" CausesValidation="false" OnClick="EliminarFila_Click"/>
                    </div>
              </div>
           </div>


           
       </div>
        <div class="form-group">          		
                <asp:GridView ID="gridEjecucion" runat ="server" margin-right ="auto" 		
                    CellPadding="10" 		
                    margin-left="auto" AutoGenerateColumns ="true" 		
                    CssClass ="GridView" HorizontalAlign="Center"   		
                    HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#CDCDCD" border-radius="15px" 		
                    AutoPostBack ="true" AllowPaging="true" PageSize="5"
                    OnRowDataBound= "OnGridEjecucionRowDataBound"
                    OnPageIndexChanging="OnGridEjecucionPageIndexChanging"	
                    OnSelectedIndexChanged= "GridEjecucion_SelectedIndexChanged"
             >		
                </asp:GridView>			
        </div>	
    </div>  
</asp:Panel>
</div>

<div class="form-group">
    <div class="col-md-offset-8 col-md-12">
        <asp:Button runat="server" style="border-color:#4bb648;color:#4bb648;margin-top:200px;margin-left: 200px;margin-top: 50px;"
            Text="Aceptar" causesvalidation="true" CssClass="btn btn-default"  ID="BotonEPAceptar" OnClick="BotonEPAceptar_Click"/>
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


</asp:Content>
