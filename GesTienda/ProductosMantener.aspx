<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdm.Master" AutoEventWireup="true" CodeBehind="ProductosMantener.aspx.cs" Inherits="GesTienda.ProductosMantener" %>
<%@ OutputCache Duration="1" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InfoContenido" runat="server">
    <div class="contenidotitulo" style="text-align: center">
        Mantenimiento productos
    </div>
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [IdProducto], [DesPro], [PrePro] FROM [PRODUCTO]"></asp:SqlDataSource>
    </div>
    <div id="productos">      
        <asp:GridView ID="grdProductos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdProducto" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" PageSize="5" Width="95%" OnSelectedIndexChanged="grdProductos_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                <asp:BoundField DataField="IdProducto" HeaderText="Id Producto" ReadOnly="True" SortExpression="IdProducto" />
                <asp:BoundField DataField="DesPro" HeaderText="Descripción" SortExpression="DesPro" />
                <asp:BoundField DataField="PrePro" DataFormatString="{0:n2}" HeaderText="Precio" SortExpression="PrePro">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NextPreviousFirstLast" NextPageText="Siguiente" PreviousPageText="Anterior" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <div id="producto1">
            <div>
            <!--IdProducto-->
                <asp:Label ID="blIdProducto" runat="server" for="txtIdProducto">Id. Producto</asp:Label>
                <asp:TextBox ID="txtIdProducto" runat="server" Enabled="False"></asp:TextBox>  
            </div>
            <div>
                <!--Descripción--> 
                <asp:Label ID="lblDesPro" runat="server" for="txtDesPro">Descripción</asp:Label>
                <asp:TextBox ID="txtDesPro" runat="server" Enabled="False"></asp:TextBox>
            </div>
            <div>
                <!--Precio-->
                <asp:Label ID="lblPrePro" runat="server" for="txtPrePro">Precio</asp:Label>
                <asp:TextBox ID="txtPrePro" runat="server" Enabled="False"></asp:TextBox>
            </div>
            <div>
                <!--Unidad-->
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [UNIDAD]"></asp:SqlDataSource>
                <asp:Label ID="lblIdUnidad" runat="server" for="ddlIdUnidad">Unidad</asp:Label>
                <asp:DropDownList ID="ddlIdUnidad" runat="server" Enabled="False" DataSourceID="SqlDataSource2" DataTextField="IdUnidad" DataValueField="IdUnidad"></asp:DropDownList>         
            </div>
            <div>
                <!--Tipo-->
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TIPO]"></asp:SqlDataSource>
                <asp:Label ID="lblIdTipo" runat="server" for="ddlIdTipo">Tipo Producto</asp:Label>
                <asp:DropDownList ID="ddlIdTipo" runat="server" Enabled="False" DataSourceID="SqlDataSource3" DataTextField="DesTip" DataValueField="IdTipo"></asp:DropDownList>
            </div>
            <div id="botones">
                <asp:Button ID="btnNuevo" runat="server" Visible="true" text="Nuevo" OnClick="btnNuevo_Click"/>
                <asp:Button ID="btnEditar" runat="server" Visible="false" text="Editar" OnClick="btnEditar_Click"/>
                <asp:Button ID="btnEliminar" runat="server" Visible="false" text="Eliminar" OnClick="btnEliminar_Click"/>
                <asp:Button ID="btnInsertar" runat="server" Visible="false" text="Insertar" OnClick="btnInsertar_Click"/>
                <asp:Button ID="btnModificar" runat="server" Visible="false" text="Modificar" OnClick="btnModificar_Click"/>
                <asp:Button ID="btnBorrar" runat="server" Visible="false" text="Borrar" OnClick="btnBorrar_Click"/>
                <asp:Button ID="btnCancelar" runat="server" Visible="false" text="Cancelar" OnClick="btnCancelar_Click"/>
            </div>
        </div>     
    </div>
    <div>
        <asp:Label ID="lblResultado" runat="server"></asp:Label>
    </div>
    <br />
    <div>
        <asp:Label ID="lblMensajes" ForeColor="red" runat="server"></asp:Label>
    </div>
</asp:Content>
