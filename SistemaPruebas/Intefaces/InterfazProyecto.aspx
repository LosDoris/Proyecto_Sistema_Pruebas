<%@ Page EnableEventValidation="false" Title="Proyecto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazProyecto.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazProyecto" Async="true" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>


   <%-- PRODUCIA ERRORES CON LA NAVEGACION %> <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet"> --%>
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
    <script type="text/javascript">
        function HideLabel() {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=EtiqErrorLlaves.ClientID %>").style.display = "none";
        }, seconds * 1000);
    };
</script>   
    <div class="form-group">
        <div class="col-md-offset-10 col-md-12">
            <asp:Button runat="server" ID="Insertar" Text="Insertar" CssClass="btn btn-default" OnClick="Insertar_button" />
            <asp:Button runat="server" ID="Modificar" Text="Modificar" CssClass="btn btn-default" OnClick="Modificar_Click" />

            <asp:Button runat="server" ID="Eliminar" Text="   Eliminar" CssClass="btn btn-default" OnClick="Eliminar_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-8">
            <div>
                <asp:Label runat="server" CssClass="text-danger" ID="EtiqErrorLlaves">*EL nombre del proyecto ya ha sido ingresado anteriormente. Por favor ingrese otro nombre para el proyecto.</asp:Label>

            </div>
            <div class="form-horizontal">

                <hr />
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>

                <div class="form-group">
                    <asp:Label runat="server" ID="nombre_label" CssClass="col-md-2 control-label">Nombre del Proyecto</asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="nombre_proyecto" style="width:250px;height:36px" CssClass="form-control" onkeypress="return solo_letras(event)" MaxLength="20" OnTextChanged="nombre_proyecto_TextChanged"/>
                        <script type="text/javascript">
                            function solo_letras(evt) {
                                if ((evt.charCode < 32 || evt.charCode > 32) && (evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122) && (evt.charCode < 209 || evt.charCode > 209) && (evt.charCode < 241 || evt.charCode > 241)) {
                                    alert("Sólo se permite letras");
                                    return false;
                                }                               
                            }
                        </script>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" columns="3" CssClass="col-md-2 control-label" >Objetivo General</asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="obj_general" style="width:250px;height:90px" CssClass="form-control" MaxLength="50" TextMode="multiline" onkeypress="return solo_letrasYNumeros(event)"/>
                        <script type="text/javascript">
                            function solo_letrasYNumeros(evt) {
                                if ((evt.charCode != 32) && (evt.charCode != 13) && (evt.charCode != 46) && (evt.charCode != 44) && (evt.charCode < 32 || evt.charCode > 32) && (evt.charCode < 65 || evt.charCode > 90) && (evt.charCode < 97 || evt.charCode > 122) && (evt.charCode < 209 || evt.charCode > 209) && (evt.charCode < 241 || evt.charCode > 241)) {
                                    alert("Sólo se permite letras");
                                    return false;
                                }
                            }
                        </script>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Estado</asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="estado" style="width:250px" CssClass="form-control">
                            <asp:ListItem Selected="True" Value="1">Pendiente</asp:ListItem>
                            <asp:ListItem Value="2">Asignado</asp:ListItem>
                            <asp:ListItem Value="3">En Ejecución</asp:ListItem>
                            <asp:ListItem Value="4">Finalizado</asp:ListItem>
                            <asp:ListItem Value="5">Cerrado</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>

                <div class="form-group">
                     
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Fecha de Asignación</asp:Label>
                    <div class="col-md-4" runat="server">
                        <input id="txt_date" style="width:250px;height:36px" type="text" readonly="readonly"/>
                    </div>
                         
                </div>
            </div>
        </div>


        <h4>Oficina Usuaria</h4>
        <div class="col-md-4">

            <div class="form-horizontal">


                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Nombre</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" style="width:250px;height:36px"  ID="nombre_rep" CssClass="form-control" onkeypress="return solo_letras(event)" MaxLength="30" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Teléfonos</asp:Label>

                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="tel_rep" style="width:250px;height:36px" CssClass="form-control" onkeypress="return solo_numeros(event)" MaxLength="8" CausesValidation="True" />
                        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "tel_rep" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{8,8}$" runat="server" ErrorMessage="Debe digitar 8 números."></asp:RegularExpressionValidator>
                        <script type="text/javascript">
                            function solo_numeros(evt) {
                                if (evt.charCode > 31 && (evt.charCode < 48 || evt.charCode > 57)) {
                                    alert("Sólo se permite números");
                                    return false;
                                }
                            }
                        </script>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Oficina</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="of_rep" style="width:250px;height:36px" CssClass="form-control" onkeypress="return solo_letras(event)" MaxLength="17" />
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div class="form-group">
        <div id="Botones_aceptar_cancelar" class="col-md-offset-10 col-md-12">
            <asp:Button runat="server" ID="aceptar" Text="Aceptar" CssClass="btn btn-default" OnClick="aceptar_Click" style="border-color:#36df7c;color:#33d275"/>
            <asp:Button runat="server" ID="cancelar" Text="Cancelar" style="border-color:#fe6c4f;color:#fe5e3e" CssClass="btn btn-default" OnClick="cancelar_Click" OnClientClick="return confirm('¿Está seguro que desea cancelar?')" />

        </div>
    </div>

    <div id="tablaProyectos" class="row">

        <asp:GridView ID="gridProyecto" runat="server" HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333" CellPadding="10" margin-right ="auto" HorizontalAlign="Center" 
            AutoGenerateColumns="false" OnSelectedIndexChanged="OnSelectedIndexChanged" BorderColor="#cdcdcd" border-radius="7px" 
            AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" AllowSorting="true" PageSize="5"   OnRowDataBound ="OnRowDataBound" CssClass ="GridView"  AutoPostBack ="true" CausesValidation="false">
            <Columns>
                <asp:BoundField DataField="Id Proyecto" ItemStyle-Width="185px" HeaderText=" Id Proyecto"  />
                <asp:TemplateField ItemStyle-Width="200px" HeaderText=" Nombre del sistema">
                    <ItemTemplate>
                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre del sistema") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
 
            </asp:GridView>
    </div>
</asp:Content>

