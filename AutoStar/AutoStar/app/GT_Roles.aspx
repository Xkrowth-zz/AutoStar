<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Roles.aspx.cs" Inherits="AutoStar.app.GT_Rol" EnableEventValidation="false" %>
<%@ Register TagPrefix="CCS" Namespace="CustomControls" 
Assembly="GridViewExtended" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" class="bodyUsuarios">
        body {
            background-image: url('/app/Images/backgrounds/MB3.jpg');
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>
        <div>
            <asp:Table CssClass="table" ID="Table1" runat="server">
                <asp:TableRow CssClass="tableRow">
                    <asp:TableCell CssClass="tableCell">
                        <asp:ImageButton PostBackUrl="~/app/Default.aspx" CssClass="botonFull" ID="ImageButton3" AlternateText="Home" runat="server" ImageUrl="~/app/Images/icons/iconInicio.png" />
                    </asp:TableCell>
                    <asp:TableCell CssClass="tableCell">
                        <asp:ImageButton CssClass="botonFull" ID="btn_buscar" AlternateText="Buscar" runat="server" ImageUrl="~/app/Images/icons/iconBuscar.png" onClick="btn_buscarClick"/>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tableCell">
                        <asp:ImageButton CssClass="botonFull" ID="ImageButton1" AlternateText="Crear" runat="server" ImageUrl="~/app/Images/icons/iconCrear.png" ValidationGroup="Insert" OnClick="btn_crearClick" />
                    </asp:TableCell>
                    <asp:TableCell CssClass="tableCell">
                        <asp:ImageButton CssClass="botonFull" ID="ImageButton2" AlternateText="Editar" runat="server" ImageUrl="~/app/Images/icons/iconEditar.png" OnClick="btn_editarClick" />
                    </asp:TableCell>
                    <asp:TableCell CssClass="tableCell">
                        <asp:ImageButton CssClass="botonFull" ID="ImageButton4" AlternateText="Guardar" runat="server" ImageUrl="~/app/Images/icons/iconGuardar.png" OnClick="btn_guardarClick" />
                    </asp:TableCell>
                    <asp:TableCell CssClass="tableCell">
                        <asp:ImageButton CssClass="botonFull" ID="ImageButton5" AlternateText="Borrar" runat="server" ImageUrl="~/app/Images/icons/iconBorrar.png" OnClick="btn_eliminarClick" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>

        <h1>Roles</h1>
        <hr/>
            <asp:Label ID="Label1" runat="server" CssClass="busquedalbl" Text="Valor a buscar:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Font-Names="Adobe Caslon Pro Bold" Font-Size="Large" ForeColor="Black"></asp:TextBox>
        <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="Adobe Caslon Pro Bold" Font-Size="Large">
            <asp:ListItem>Descripcion</asp:ListItem>
        </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" DeleteCommand="deleteRol" DeleteCommandType="StoredProcedure" InsertCommand="insertRol" InsertCommandType="StoredProcedure" SelectCommand="rolesBusqueda" UpdateCommand="updateRol" UpdateCommandType="StoredProcedure" SelectCommandType="StoredProcedure">
                <DeleteParameters>
                    <asp:Parameter Name="idRol" Type="Int32" />
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="comentarios" Type="String" />
                    
                </DeleteParameters>

                <InsertParameters>
                    
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="comentarios" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" DefaultValue="vacio" Name="valor" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" Name="campo" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="idRol" Type="Int32" />
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="comentarios" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>



        
            <CCS:GridViewExtended ID="GridView1" CssClass="GridViewConfig" runat="server" _showFooterWhenEmpty="true" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="OnSelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" onRowCreated="GridView1_RowCreated" Height="286px" style="margin-left: 396px; margin-right: 0px; margin-top: 137px" Width="595px" DataKeyNames="idRol" ShowFooter="True" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:TemplateField HeaderText="idRol" InsertVisible="False" SortExpression="idRol" Visible="False">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("idRol") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("idRol") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField FooterText="Informacion a insertar:"></asp:TemplateField>

                    <asp:TemplateField HeaderText="Descripcion" SortExpression="descripcion">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descripcion") %>' TextMode="MultiLine"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status" SortExpression="status">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked ='<%# Bind("status") %>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox2" runat="server" Checked ='<%# Bind("status") %>' Enabled="false" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:CheckBox ID="CheckBox3" runat="server" />
                        </FooterTemplate>
            </asp:TemplateField>

                    <asp:TemplateField HeaderText="Comentarios" SortExpression="comentarios">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("comentarios") %>' TextMode="MultiLine"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("comentarios") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </CCS:GridViewExtended>
</asp:Content>


