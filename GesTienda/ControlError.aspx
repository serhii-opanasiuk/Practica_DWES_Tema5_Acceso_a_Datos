<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlError.aspx.cs" Inherits="GesTienda.ControlError" %>
<%@ OutputCache Duration="1" VaryByParam="None" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="~/Estilos/HojaEstilo.css" />
    <title>Error en tiempo de ejecución</title>
</head>
<body>
    <form id="formulario1" runat="server" style="text-align: center; display: flex; flex-direction: column; justify-content: center;">
        <div><h1 style="text-align: center">Aplicación Web Ges Tienda</h1></div>
        <div><h2 style="text-align: center">Error en tiempo de ejecución</h2></div>
        <div style="text-align: center; border: thin solid #000000; width: 70%; overflow: auto;">
            Error ASP.NET:<br />
            <asp:Label ID="lblErrorASP" runat="server" ForeColor="Red"></asp:Label><br />
            Error ADO.NET:<br />
            <asp:Label ID="lblErrorADO" runat="server" ForeColor="Red"></asp:Label><br />
        </div>
    </form>
</body>
</html>
