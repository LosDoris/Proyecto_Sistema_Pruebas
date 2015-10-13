<%@ Page Title="Proyecto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazProyecto.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazProyecto" Async="true" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>


    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet">
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
            <asp:Button runat="server" ID="Insertar" Text="Insertar" CssClass="btn btn-default" OnClick="Insertar_button" />
            <asp:Button runat="server" ID="Modificar" Text="Modificar" CssClass="btn btn-default" OnClick="Modificar_Click" />

            <asp:Button runat="server" ID="Eliminar" Text="   Eliminar" CssClass="btn btn-default" OnClick="Eliminar_Click" />
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
                    <asp:Label runat="server" ID="nombre_label" CssClass="col-md-2 control-label">Nombre del Proyecto</asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="nombre_proyecto" CssClass="form-control" onkeypress="return solo_letras(event)" MaxLength="20" />
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
                    <asp:Label runat="server" TextMode="multiline" columns="3" CssClass="col-md-2 control-label">Objetivo General</asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="obj_general" CssClass="form-control" MaxLength="50" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Estado</asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="estado" CssClass="form-control">
                            <asp:ListItem Selected="True" Value="1">Pendiente</asp:ListItem>
                            <asp:ListItem Value="2">Asignado</asp:ListItem>
                            <asp:ListItem Value="3">En Ejecución</asp:ListItem>
                            <asp:ListItem Value="4">Finalizado</asp:ListItem>
                            <asp:ListItem Value="5">Cerrado</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-6 control-label">Fecha de Asignación</asp:Label>
                    <div class="form-horizontal" runat="server">
                        <input id="txt_date" type="text" readonly="readonly" />
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
                        <asp:TextBox runat="server" ID="nombre_rep" CssClass="form-control" onkeypress="return solo_letras(event)" MaxLength="30" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Teléfonos</asp:Label>

                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="tel_rep" CssClass="form-control" onkeypress="return solo_numeros(event)" MaxLength="8" CausesValidation="True" />
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
                    <asp:Label runat="server" AssociatedControlID="of_rep" CssClass="col-md-4 control-label">Oficina</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="of_rep" CssClass="form-control" onkeypress="return solo_letras(event)" MaxLength="17" />
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div class="form-group">
        <div id="Botones_aceptar_cancelar" class="col-md-offset-10 col-md-12">
            <asp:Button runat="server" ID="aceptar" Text="Aceptar" CssClass="btn btn-default" OnClick="aceptar_Click" />
            <asp:Button runat="server" ID="cancelar" Text="Cancelar" CssClass="btn btn-default" OnClick="cancelar_Click" OnClientClick="return confirm('¿Está seguro que desea cancelar?')" />

        </div>
    </div>

    <div id="tablaProyectos" class="col-md-offset-4">

        <asp:GridView ID="gridProyecto" runat="server" HeaderStyle-BackColor="#eeeeee" HeaderStyle-ForeColor="#333333"
            AutoGenerateColumns="false" OnSelectedIndexChanged="OnSelectedIndexChanged" BorderColor="#cdcdcd" border-radius="15px">
            <Columns>
                <asp:BoundField DataField="Id Proyecto" HeaderText=" Id Proyecto" ItemStyle-Width="160" />
                <asp:TemplateField HeaderText=" Nombre del sistema" ItemStyle-Width="160">
                    <ItemTemplate>
                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre del sistema") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField Text=" Seleccionar" CommandName="Select" ItemStyle-Width="160" />
            </Columns>
        </asp:GridView>
        <%--<asp:GridView ID="gridProyecto" runat="server" OnRowCommand="gridProyecto_RowCommand">
                <Columns>
                    <asp:ButtonField ButtonType="Button" Text="Consultar" CommandName="seleccionarProyecto" Visible="true" CausesValidation="false" />                 
                </Columns> 
            </asp:GridView>  --%>
    </div>
</asp:Content>

