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
    <div class="jumbozCP" >
        <h4>Resumen</h4>

    </div>
</div>

<div class ="col-md-6">
    <div class="jumbozCP1">
            <h4>Datos Caso Prueba</h4>

        <div class="col-md-8">
		    <asp:Label ID="id_casoPrueba" runat="server" CssClass="col-md-2 control-label" style="text-align: right; width: 200px;height: 32px;" Text="ID:"></asp:Label>                      
		    <asp:TextBox runat="server" ID="TextBoxID" CssClass="form-control" style="width: 200px;height: 50px;" onkeypress="checkInput(event)" AutoPostBack="true" MaxLength="20"/>
		    <script type="text/javascript">
			    function checkInput(e) {
				    var ok = /[A-Za-z0-9-_]/.test(String.fromCharCode(e.charCode));
				    if (!ok)
					    e.preventDefault();
			    }
		    </script>
        </div>

		<div class="col-mdP">
		    <asp:Label ID="PropositoCP" runat="server"  CssClass="col-md-2 control-label" style="margin-top: 20px; text-align: right;  width: 200px;height: 50px;" Text="Propósito de Caso de Prueba:"></asp:Label>                        
		    <asp:TextBox runat="server" ID="TextBoxPropositoCP" CssClass="form-control" style="vertical-align: top; margin-top: 20px; width: 200px;height: 100px;" onkeypress="checkInput3(event)" TextMode="multiline"/>
		    <script type="text/javascript">
			    function checkInput3(e) {
				    var ok = /[A-Za-z0-9.\"\(\)áéíóú]/.test(String.fromCharCode(e.charCode));
				    if (!ok)
					    e.preventDefault();
			    }
		    </script>
        </div>

        <div class="jumbozCP2">
            <div class="form-horizontal">
            <h4>Entrada de Datos</h4>
                <div class="form-group">      
                    <asp:Label ID="EntradaDatosCP" runat="server" CssClass="col-md-2 control-label" style="width: 90px; text-align: right; margin-left: 30px;" Text ="Descripción:"></asp:Label>    
                    <asp:TextBox runat="server" ID="TextBoxDescripcion" style="width:200px" onkeypress="checkInput1(event)" CssClass="form-control"/>
                    <script type="text/javascript">
                        function checkInput1(e) {
                            var ok = /[A-Za-z]/.test(String.fromCharCode(e.charCode));
                            if (!ok)
                                e.preventDefault();
                        }
                    </script>
                </div>
                <div class="form-group">
                    <asp:Label ID="DatosCP" runat="server" CssClass="col-md-2 control-label" style="width: 90px; text-align: right; margin-left: 30px;" Text="Datos:"></asp:Label>

                    <asp:TextBox runat="server" ID="TextBoxDatos" style="width:80px;"  onkeypress="checkInput2(event)" CssClass="form-control"/>
                    <script type="text/javascript">
                        function checkInput2(e) {
                            var ok = /[A-Za-z0-9]/.test(String.fromCharCode(e.charCode));
                            if (!ok)
                                e.preventDefault();
                        }
                    </script>
                    
                </div>
                <div class="form-group">
                    <asp:Label ID="TiposCP" runat="server" CssClass="col-md-2 control-label" style="width: 90px; text-align: right; margin-left: 30px;" Text="Tipo:"></asp:Label>
                        <asp:DropDownList ID="TipoEntrada" runat="server" OnSelectedIndexChanged="TipoEntrada_SelectedIndexChanged">
                            <asp:ListItem Text ="Válido" Value =1/>
                            <asp:ListItem Text ="Inválido" Value =2/>
                            <asp:ListItem Text ="No Aplica" Value =3/>
                        </asp:DropDownList>
                </div>

                <div class="form-group">          
                        <div class="col-md-offset-5 col-md-12">
                            <asp:Button runat="server" Text="Agregar"                               
                                CssClass="btn btn-default" ID="AgregarEntrada" OnClick="AgregarEntrada_Click" />
                            <asp:Button runat="server" Text="Eliminar"  
                                CssClass="btn btn-default" ID="EliminarEntrada"/>
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
                var ok = /[A-Za-z.áéíóú]/.test(String.fromCharCode(e.charCode));
                if (!ok)
                    e.preventDefault();
            }
        </script>
    </div>
    <asp:Label ID="FlujoCP" runat="server" CssClass="col-md-2 control-label" style="width:20px;margin-top:20px;" Text="Flujo Central:"></asp:Label>    
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="TextBoxFlujoCentral" onkeypress="checkInput5(event)" style="margin-top:20px; width:250px; height:150px; margin-left: 63px;" CssClass="form-control" MaxLength="50" TextMode="multiline"/>
        <script type="text/javascript">
            function checkInput5(e) {
                var ok = /[A-Za-z0-9.\"\(\)áéíóú]/.test(String.fromCharCode(e.charCode));
                if (!ok)
                    e.preventDefault();
            }
        </script>
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
