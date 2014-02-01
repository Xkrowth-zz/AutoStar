<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Acceso_Menu.aspx.cs" Inherits="AutoStar.app.GT_Acceso_Menu1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" class="bodyUsuarios">
        body {
            background-image: url('/app/Images/backgrounds/MB3.jpg');
            background-repeat: no-repeat;
            -moz-background-size: cover;
            -o-background-size: cover;
            -webkit-background-size: cover;
            background-size: cover;
        }
    </style>
    <h1>Acceso</h1>
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
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton1" AlternateText="Crear" runat="server" ImageUrl="~/app/Images/icons/iconCrear.png" ValidationGroup="Insert" OnClick="lbInsert_Click" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton2" AlternateText="Editar" runat="server" ImageUrl="~/app/Images/icons/iconEditar.png" OnClick="btn_editar_Click" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton4" AlternateText="Guardar" runat="server" ImageUrl="~/app/Images/icons/iconGuardar.png" OnClick="btn_guardarClick" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton5" AlternateText="Borrar" runat="server" ImageUrl="~/app/Images/icons/iconBorrar.png" OnClick="btn_eliminar_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" DeleteCommand="deleteAcceso" DeleteCommandType="StoredProcedure" InsertCommand="insertAcceso" InsertCommandType="StoredProcedure" SelectCommand="accesoBusquedas" UpdateCommand="updateAcceso" UpdateCommandType="StoredProcedure" SelectCommandType="StoredProcedure">
                <DeleteParameters>
                    <asp:Parameter Name="idAcceso" Type="int32" />
                    <asp:Parameter Name="idOpcion" Type="int32" />
                    <asp:Parameter Name="idRol" Type="Int32" />                    
                    <asp:Parameter Name="comentarios" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="idOpcion" Type="int32" />
                    <asp:Parameter Name="idRol" Type="Int32" /> 
                    <asp:Parameter Name="comentarios" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" DefaultValue="vacio" Name="valor" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" Name="campo" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="idAcceso" Type="int32" />
                    <asp:Parameter Name="idOpcion" Type="int32" />
                    <asp:Parameter Name="idRol" Type="Int32" /> 
                    <asp:Parameter Name="comentarios" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>



        
            <asp:Label ID="Label1" runat="server" Text="Valor a buscar:"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>



        
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" >
                <Columns>
                    <asp:TemplateField></asp:TemplateField>
                    <asp:TemplateField HeaderText="idAcceso" SortExpression="idAcceso">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("idAcceso") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("idAcceso") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="idRol" SortExpression="idRol">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("idRol") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("idRol") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="idOpcion" SortExpression="idOpcion">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idOpcion") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("idOpcion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="comentarios" SortExpression="comentarios">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("comentarios") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("comentarios") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
</asp:Content>
