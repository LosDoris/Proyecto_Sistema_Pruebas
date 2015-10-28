<%@ Page EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazCasosDePrueba.aspx.cs" Inherits="SistemaPruebas.Intefaces.CasosDePrueba" Async="true"  %>
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
                <asp:Label ID="id_casoPrueba" runat="server" CssClass="col-md-2 control-label" Text="ID:"></asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxID" CssClass="form-control" onkeypress="checkInput(event)" AutoPostBack="true" />
                    <script type="text/javascript">
                        function checkInput(e) {
                            var ok = /[A-Za-z0-9-_]/.test(String.fromCharCode(e.charCode));
                            if (!ok)
                                e.preventDefault();
                        }
                    </script>

                    <asp:Label ID="errorID" runat="server" CssClass="text-danger" Text=""></asp:Label>
                </div>
           </div>

           <div class="form-group">      
                <asp:Label ID="PropositoCP" runat="server" CssClass="col-md-2 control-label" Text="Propósito de Caso de Prueba:"></asp:Label>    
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxPropositoCP" onkeypress="checkInput3(event)" style="width:250px;height:50px" CssClass="form-control" MaxLength="50" TextMode="multiline"/>
                    <script type="text/javascript">
                        function checkInput3(e) {
                            var ok = /[A-Za-z0-9.\"\(\)áéíóú]/.test(String.fromCharCode(e.charCode));
                            if (!ok)
                                e.preventDefault();
                        }
                    </script>
                </div>
           </div>
           <div class="form-group">      
                <asp:Label ID="ResultadoCP" runat="server" CssClass="col-md-2 control-label" Text="Resultado esperado:"></asp:Label>    
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="TextBoxResultadoCP" onkeypress="checkInput4(event)" style="width:250px;height:50px" CssClass="form-control" MaxLength="50" TextMode="multiline"/>
                    <script type="text/javascript">
                        function checkInput4(e) {
                            var ok = /[A-Za-z.áéíóú]/.test(String.fromCharCode(e.charCode));
                            if (!ok)
                                e.preventDefault();
                        }
                    </script>
                </div>
           </div>
            <div class="form-group">      
                <asp:Label ID="FlujoCP" runat="server" CssClass="col-md-2 control-label" Text="Flujo Central:"></asp:Label>    
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="TextBoxFlujoCentral" onkeypress="checkInput5(event)" style="width:250px;height:50px" CssClass="form-control" MaxLength="50" TextMode="multiline"/>
                    <script type="text/javascript">
                        function checkInput5(e) {
                            var ok = /[A-Za-z0-9.\"\(\)áéíóú]/.test(String.fromCharCode(e.charCode));
                            if (!ok)
                                e.preventDefault();
                        }
                    </script>
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-4">
         <div class="form-horizontal">
            <h4>Entrada de Datos</h4>
            <div class ="borderCP" >
                <div class="form-group">      
                    <asp:Label ID="EntradaDatosCP" runat="server" CssClass="col-md-2 control-label" Text="Descripción:"></asp:Label>    
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="TextBoxDescripcion" style="width:250px" onkeypress="checkInput1(event)" CssClass="form-control"/>
                        <script type="text/javascript">
                            function checkInput1(e) {
                                var ok = /[A-Za-z]/.test(String.fromCharCode(e.charCode));
                                if (!ok)
                                    e.preventDefault();
                            }
                        </script>
                    </div>
                </div>
                <div class="form-group">  
                    <div class="col-md-8">
                        <asp:Label ID="DatosCP" runat="server" CssClass="col-md-2 control-label" Text="Datos:"></asp:Label>

                        <asp:TextBox runat="server" ID="TextBoxDatos" CssClass="form-control" onkeypress="checkInput2(event)" />
                        <script type="text/javascript">
                            function checkInput2(e) {
                                var ok = /[A-Za-z0-9]/.test(String.fromCharCode(e.charCode));
                                if (!ok)
                                    e.preventDefault();
                            }
                        </script>
                        <asp:Label ID="TiposCP" runat="server" CssClass="col-md-2 control-label" Text="Tipo:"></asp:Label>
                         <asp:DropDownList ID="TipoEntrada" runat="server">
                             <asp:ListItem Text ="Válido" Value =1/>
                             <asp:ListItem Text ="Inválido" Value =2/>
                             <asp:ListItem Text ="No Aplica" Value =3/>
                         </asp:DropDownList>
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
            ID="BotonCPAceptar" OnClick="BotonCPAceptar_Click" 
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
