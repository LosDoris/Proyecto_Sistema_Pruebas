﻿<%@ Page EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazCasosDePrueba.aspx.cs" Inherits="SistemaPruebas.Intefaces.CasosDePrueba" Async="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2><%: Title %>Casos de Prueba</h2>


<asp:Label runat="server" CssClass="text-danger" ID="EtiqErrorInsertar" >*Ha habido problemas para agregar este caso de prueba al sistema. Por favor vuelva a intentarlo.</asp:Label>
<asp:Label runat="server" CssClass="text-danger" ID="EtiqErrorConsultar" >*Ha habido problemas para consultar este caso de prueba. Por favor vuelva a intentarlo mas tarde.</asp:Label>
<asp:Label runat="server" CssClass="text-danger" ID="EtiqErrorModificar" >*Ha habido problemas para modificar este caso de prueba. Por favor vuelva a intentarlo.</asp:Label>
<asp:Label runat="server" CssClass="text-danger" ID="EtiqErrorEliminar" >*Ha habido problemas para eliminar este caso de prueba del sistema. Por favor vuelva a intentarlo.</asp:Label>
<div class="form-group">
    <div class="col-md-offset-10 col-md-12">
        <asp:Button runat="server" Text="Insertar" CssClass="btn btn-default" ID="BotonCPInsertar" OnClick="BotonCPInsertar_Click"/>

        <asp:Button runat="server" Text="Modificar" CssClass="btn btn-default" ID="BotonCPModificar" OnClick="BotonCPModificar_Click" />

        <asp:Button runat="server" Text="   Eliminar" CssClass="btn btn-default" ID="BotonCPEliminar"  OnClientClick="return confirm('¿Está seguro que desea eliminar este caso de prueba?')" />
    </div>
</div>


<div class ="row">
    <div class ="col-md-8" style = "margin-top: 40px">
        <div class="form-horizontal">
           <div class="form-group">      
                <asp:Label ID="ProyectoCP" CssClass="col-md-2 control-label" runat="server" Text="Proyecto:"></asp:Label>    
                <div class="col-md-10">
                    <asp:DropDownList ID="ProyectoComboBox" runat="server">
                        <asp:ListItem Enabled="True">Seleccionar</asp:ListItem>
                    </asp:DropDownList>
               </div>
           </div>
           <div class="form-group">      
                <asp:Label ID="DisenoCP" runat="server" CssClass="col-md-2 control-label" Text="Diseño:"></asp:Label>    
                <div class="col-md-10">
                    <asp:DropDownList ID="DisenoComboBox" runat="server">
                        <asp:ListItem Enabled="True">Seleccionar</asp:ListItem>
                    </asp:DropDownList>
               </div>
           </div>
           <div class="form-group">      
                <asp:Label ID="RequerimientoCP" runat="server" CssClass="col-md-2 control-label" Text="Requerimiento:"></asp:Label>    
                <div class="col-md-10">
                    <asp:DropDownList ID="RequerimientoComboBox" runat="server">
                        <asp:ListItem Enabled="True">Seleccionar</asp:ListItem>
                    </asp:DropDownList>
               </div>
           </div>
           <div class="form-group">      
                <asp:Label ID="PropositoCP" runat="server" CssClass="col-md-2 control-label" Text="Propósito:"></asp:Label>    
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxPropositoCP" style="width:250px;height:50px" CssClass="form-control" MaxLength="50" TextMode="multiline"/>
                </div>
           </div>
           <div class="form-group">      
                <asp:Label ID="ResultadoCP" runat="server" CssClass="col-md-2 control-label" Text="Resultado esperado:"></asp:Label>    
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="TextBoxResultadoCP" style="width:250px;height:50px" CssClass="form-control" MaxLength="50" TextMode="multiline"/>
               </div>
           </div>
            <div class="form-group">      
                <asp:Label ID="FlujoCP" runat="server" CssClass="col-md-2 control-label" Text="Flujo Central:"></asp:Label>    
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="TextBoxFlujoCentral" style="width:250px;height:50px" CssClass="form-control" MaxLength="50" TextMode="multiline"/>
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-4">
         <div class="form-horizontal">
            <h4>Entrada de Datos</h4>
            <div class ="borderCP" >
                <div class="form-group">      
                    <asp:Label ID="EntradaDatosCP" runat="server" CssClass="col-md-2 control-label" Text="Entrada de Datos:"></asp:Label>    
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="TextBoxEntradaDatos" style="width:250px" CssClass="form-control"/>
                    </div>
                </div>
                <div class="form-group">          
                    <div class="col-md-8">
                         <asp:DropDownList ID="TipoEntrada" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">          
                    <div class="col-md-8">
                          <div class="col-md-offset-10 col-md-12">
                                <asp:Button runat="server" Text="Agregar"                               
                                    CssClass="btn btn-default" ID="AgregarEntrada" />
                                <asp:Button runat="server" Text="Eliminar"  
                                    CssClass="btn btn-default" ID="EliminarEntrada"/>
                          </div>
                    </div>
                </div>
                <div class="form-group">          
                    <div class="col-md-8">
                        <asp:GridView ID="DECP" runat ="server" margin-right ="auto" 
                                    CellPadding="10" 
                                    margin-left="auto" 
                                    CssClass ="GridView" HorizontalAlign="Center"  
                                    HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#CDCDCD" border-radius="15px" 
                                    AutoPostBack ="true" OnSelectedIndexChanged="DECP_SelectedIndexChanged">                            
                        </asp:GridView>
                    </div>
                </div>


                <div style="clear:both"></div>
            </div>
        </div>
    </div>

</div>


<div class="form-group">
    <div class="col-md-offset-10 col-md-12">
        <asp:Button runat="server" style="border-color:#4bb648;color:#4bb648"
            Text="Aceptar" 
            causesvalidation="true"                              
            CssClass="btn btn-default" 
            ID="BotonCPAceptar" 
        />
        <asp:Button runat="server" Text="Cancelar" style="border-color:#fe6c4f;color:#fe5e3e" 
            CssClass="btn btn-default" ID="BotonCPCancelar"  
            OnClientClick="return confirm('¿Está seguro que desea cancelar?')" OnClick="BotonCPCancelar_Click" 
        />
    </div>
</div>

 <div class="row">        
    <asp:GridView ID="CP" runat ="server" margin-right ="auto" 
            CellPadding="10" 
            margin-left="auto" 
            CssClass ="GridView" HorizontalAlign="Center" 
            AllowPaging="true"   PageSize="5" 
            HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" BorderColor="#cdcdcd" border-radius="15px" 
            AutoPostBack ="true" >      
    </asp:GridView>
</div> 
</asp:Content>
