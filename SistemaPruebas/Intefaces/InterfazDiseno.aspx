<%@ Page EnableEventValidation="false" Title="Diseño" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazDiseno.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazDiseno" Async="true" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <link rel="stylesheet" type="text/css" media="screen"
        href="http://tarruda.github.com/bootstrap-datetimepicker/assets/css/bootstrap-datetimepicker.min.css">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script type="text/javascript">
        $(function () {
            $("#txt_date").datepicker();
        });
    </script>

        <div class="form-group">
        <div class="col-md-offset-10 col-md-12">
            <asp:Button runat="server" ID="Insertar" Text="Insertar" CssClass="btn btn-default"/>
            <asp:Button runat="server" ID="Modificar" Text="Modificar" CssClass="btn btn-default"/>
            <asp:Button runat="server" ID="Eliminar" Text="Eliminar" CssClass="btn btn-default"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Proyecto asociado:</asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="proyectoAsociado" style="width:250px" CssClass="form-control">
                            <asp:ListItem Selected="True" Value="1">Seleccionar</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
    <h4>Requerimientos a Probar</h4>

                <div class="form-group">
                    <asp:Label runat="server" ID="nombreReqLabel" CssClass="col-md-2 control-label">Nombre:</asp:Label>
                    <div class="col-md-4">
                    <asp:TextBox runat="server" ID="nombreReqTxtbox" style="width:250px;height:36px" CssClass="form-control" MaxLength="30"/> 
</div>
</div>
                    <div class="form-group">
                    <asp:Label runat="server" ID="precondicionReqLabel" CssClass="col-md-2 control-label">Precondiciones:</asp:Label>
                    <div class="col-md-4">
                    <asp:TextBox runat="server" ID="precondicionReqTxtbox" style="width:250px;height:36px" CssClass="form-control" MaxLength="150"/> 
</div>
</div>
                    <div class="form-group">
                    <asp:Label runat="server" ID="reqEspecialesReqLabel" CssClass="col-md-2 control-label">Requerimientos Especiales:</asp:Label>
                    <div class="col-md-4">
                    <asp:TextBox runat="server" ID="reqEspecialesReqTxtbox" style="width:250px;height:36px" CssClass="form-control" MaxLength="150"/> 
</div>
</div>


                    <div class="form-group">
                    <asp:Label runat="server" ID="propositoLabel" CssClass="col-md-2 control-label">Propósito:</asp:Label>
                    <div class="col-md-4">
                    <asp:TextBox runat="server" ID="propositoTxtbox" style="width:250px;height:36px" CssClass="form-control" MaxLength="80"/> 
</div>
</div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Nivel:</asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="Nivel" style="width:250px" CssClass="form-control">
                            <asp:ListItem Selected="True" Value="1">Seleccionar</asp:ListItem>
                           <asp:ListItem Value="2">Unitaria</asp:ListItem>
                            <asp:ListItem Value="3">Integración</asp:ListItem>
                            <asp:ListItem Value="4">Sistema</asp:ListItem>
                            <asp:ListItem Value="5">Aceptación</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

</div>
</div>

        <div class="col-md-4">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Técnica:</asp:Label>
                    <div class="col-md-6">
                        <asp:DropDownList runat="server" ID="Tecnica" style="width:250px" CssClass="form-control">
                            <asp:ListItem Selected="True" Value="1">Seleccionar</asp:ListItem>
                           <asp:ListItem Value="2">Caja Negra</asp:ListItem>
                            <asp:ListItem Value="3">Caja Blanca</asp:ListItem>
                            <asp:ListItem Value="4">Exploratoria</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
              </div>
            </div>
        <div class="col-md-4">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Tipo:</asp:Label>
                    <div class="col-md-6">
                        <asp:DropDownList runat="server" ID="Tipo" style="width:250px" CssClass="form-control">
                            <asp:ListItem Selected="True" Value="1">Seleccionar</asp:ListItem>
                           <asp:ListItem Value="2">Funcional</asp:ListItem>
                            <asp:ListItem Value="3">Interfaz de Usuario</asp:ListItem>
                            <asp:ListItem Value="4">Rendimiento</asp:ListItem>
                           <asp:ListItem Value="5">Stress</asp:ListItem>
                            <asp:ListItem Value="6">Volumen</asp:ListItem>
                            <asp:ListItem Value="7">Configuración</asp:ListItem>
                            <asp:ListItem Value="7">Instalación</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                </div>
                </div>

                <div class="col-md-4">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Ambiente:</asp:Label>

                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="ambienteTxtbox" style="width:250px;height:90px" CssClass="form-control" MaxLength="150" TextMode="multiline"/>

</div>
</div>
</div>
</div>

                <div class="col-md-4">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Procedimiento Utilizado:</asp:Label>

                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="procedimientoTxtbox" style="width:250px;height:90px" CssClass="form-control" MaxLength="150" TextMode="multiline"/>


</div>
</div>
</div>
</div>

        <div class="col-md-4">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Responsable:</asp:Label>
                    <div class="col-md-6">
                        <asp:DropDownList runat="server" ID="responsable" style="width:250px" CssClass="form-control">
                            <asp:ListItem Selected="True" Value="1">Seleccionar</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                </div>
                </div>

        <div class="col-md-4">
            <div class="form-horizontal">
                <div class="form-group">                     
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Fecha de Diseño:</asp:Label>
                    <div class="col-md-4" runat="server">
                        <input id="txt_date" name="txt_date" style="width:250px;height:36px" type="text" readonly="readonly"/>
                    </div>                         
                </div>
                </div>                         
                </div>

                <div class="col-md-4">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Criterios de Aceptación:</asp:Label>

                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="criteriosTxtbox" style="width:250px;height:90px" CssClass="form-control" MaxLength="150" TextMode="multiline"/>

</div>
</div>
</div>
</div>

</div>
</div>

   <div class="form-group">
        <div id="Botones_aceptar_cancelar" class="col-md-offset-9 col-md-10">
            <asp:Button runat="server" ID="aceptar" Text="Aceptar" CssClass="btn btn-default" style="border-color:#4bb648;color:#4bb648"/>
            <asp:Button runat="server" ID="cancelar" Text="Cancelar" style="border-color:#fe6c4f;color:#fe5e3e" CssClass="btn btn-default"/>

        </div>
    </div>

</div>
</asp:Content>