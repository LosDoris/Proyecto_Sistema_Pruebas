<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntefazRecursosHumanos.aspx.cs" Inherits="SistemaPruebas.Intefaces.IntefazRecursosHumanos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 639px">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <p>
            Cédula:&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Height="16px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="BotonRHAgregar" runat="server" Text="Agregar" OnClick="BotonRHAgregar_Click" />
            <asp:Button ID="BotonRHModificar" runat="server" Text="Modificar" />
            <asp:Button ID="BotonRHEliminar" runat="server" Text="Eliminar" />
        </p>
        <p>
            Nombre completo:&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            Teléfonos:&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p>
            Email:&nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </p>
        <p>
            Perfil de Acceso:&nbsp;
            <asp:DropDownList ID="PerfilAccesoComboBox" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </p>
        Rol:&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        :<p>
            Nombre de Usuario:&nbsp;
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
           </p>
        <p>
            Contraseña:&nbsp; :<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="BotonRHCancelar" runat="server" Text="Cancelar" />
            <asp:Button ID="BotonRHAceptar" runat="server" OnClick="Button1_Click" Text="Aceptar" />
        </p>
        <asp:Button ID="BotonRHConsultar" runat="server" Text="Consultar" />
        <asp:GridView ID="GridRH" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
