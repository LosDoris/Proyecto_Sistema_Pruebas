<%@ Page Title="Proyecto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazProyecto.aspx.cs" Inherits="SistemaPruebas.Intefaces.InterfazProyecto" Async="true" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <head>
        <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet">
        <link rel="stylesheet" type="text/css" media="screen"
            href="http://tarruda.github.com/bootstrap-datetimepicker/assets/css/bootstrap-datetimepicker.min.css">
    </head>

    <div class="form-group">
        <div class="col-md-offset-10 col-md-12">
            <asp:Button runat="server" Text="Insertar" CssClass="btn btn-default" OnClick="Insertar_button" />

            <asp:Button runat="server" Text="Modificar" CssClass="btn btn-default" />

            <asp:Button runat="server" Text="   Eliminar" CssClass="btn btn-default" />
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
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="nombre_proyecto" CssClass="form-control" />

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Objetivo General</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="obj_general" CssClass="form-control" />
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
                <div class="row">
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Fecha de Asignación</asp:Label>
                        <div class="col-md-10">

                            <div id="datetimepicker" class="col-md-10">
                                <input type="text"></input>
                                <span class="add-on">
                                    <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                                </span>
                            </div>
                            <script type="text/javascript"
                                src="http://cdnjs.cloudflare.com/ajax/libs/jquery/1.8.3/jquery.min.js">
                            </script>
                            <script type="text/javascript"
                                src="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/js/bootstrap.min.js">
                            </script>
                            <script type="text/javascript"
                                src="http://tarruda.github.com/bootstrap-datetimepicker/assets/js/bootstrap-datetimepicker.min.js">
                            </script>
                            <script type="text/javascript"
                                src="http://tarruda.github.com/bootstrap-datetimepicker/assets/js/bootstrap-datetimepicker.pt-BR.js">
                            </script>
                            <script type="text/javascript">
                                $('#datetimepicker').datetimepicker({
                                    format: 'dd/MM/yyyy hh:mm:ss',
                                    language: "es",
                                    todayHighlight: true
                                });
                            </script>

                        </div>
                    </div>
                </div>
            </div>
        </div>


        <h4>Oficina Usuaria</h4>
        <div class="col-md-4">

            <div class="form-horizontal">


                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Nombre</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="nombre_rep" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">Teléfonos</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="tel_rep" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="of_rep" CssClass="col-md-4 control-label">Representante</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="of_rep" CssClass="form-control" />
                    </div>
                </div>

            </div>
        </div>
          </div>
    <div class="form-group">
        <div id="Botones_aceptar_cancelar"  class="col-md-offset-10 col-md-12">
            <asp:Button runat="server" ID="aceptar" Text="Aceptar"  CssClass="btn btn-default" OnClick="aceptar_Click"/>
            <asp:Button runat="server" ID="cancelar" Text="Cancelar"  CssClass="btn btn-default" OnClick="cancelar_Click"/>
            </div>
        </div>
  
</asp:Content>

