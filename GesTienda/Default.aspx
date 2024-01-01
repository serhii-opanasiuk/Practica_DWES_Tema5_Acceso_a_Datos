<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GesTienda.Default" %>
<%@ OutputCache Duration="1" VaryByParam="None" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="~/Estilos/HojaEstilo.css" />
    <title>Ges Tienda - Entrada</title>
    <style type="text/css">
        .login {}
        .auto-style2 {
            width: 431px;
            height: 100%;
            vertical-align: central;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="cabecera">
           <div id="cabecera1">
              <br />
              comerciodaw.com &nbsp;
           </div>
           <div id="cabecera2">
               <br />
               &nbsp;&nbsp;TIENDA ONLINE - SHOPPING DAW<br />
               <br />
           </div>
        </div>
        <div id="cuerpo">
            <div class="contenidotitulo" style="text-align: center">
                <br /><br />
                GesTienda
                <br /><br />
            </div>
            <div id="datos">
                <div id="loginmenu">
                    <asp:Login ID="Login1" runat="server" CssClass="login" Height="146px" Width="552px" OnAuthenticate="Login1_Authenticate">
                        <LayoutTemplate>
                            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                                <tr>
                                    <td>
                                        <table cellpadding="0">
                                            <tr>
                                                <td align="center" colspan="2"><h3>Iniciar sesión</h3></td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Correo electrónico:</asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:TextBox ID="UserName" runat="server" Width="396px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="396px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color:Red;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" CssClass="botoninicio" Text="Inicio de sesión" ValidationGroup="Login1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:Login>
                </div>
                <br />
            </div>
            <div>
                <asp:Label ID="lblMensajes" ForeColor="red" runat="server"></asp:Label>
            </div>
        </div>
        <div id="pie">
            <br />
            <br />
            © Desarrollo de Aplicaciones Web interactivas con Acceso a Datos
            <br />
            IES Mare Nostrum (Alicante)
        </div>
    </form>
</body>
</html>
