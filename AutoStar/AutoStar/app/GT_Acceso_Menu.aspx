<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Acceso_Menu.aspx.cs" EnableEventValidation="false" Inherits="AutoStar.app.GT_Acceso_Menu1" %>
<%@ Register TagPrefix="CCS" Namespace="CustomControls" 
Assembly="GridViewExtended" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" class="bodyUsuarios">
        body {
            background-image: url('/app/Images/backgrounds/MB16.jpg');
            background-repeat: no-repeat;
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
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="opcion" Type="String" />
                    <asp:Parameter Name="rol" Type="String" /> 
                    <asp:Parameter Name="comentarios" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" DefaultValue="vacio" Name="valor" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" Name="campo" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="idAcceso" Type="int32" />
                    <asp:Parameter Name="opcion" Type="String" />
                    <asp:Parameter Name="rol" Type="String" /> 
                    <asp:Parameter Name="comentarios" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>



        
            <asp:Label ID="Label1" runat="server" Text="Valor a buscar:" CssClass="busquedalbl"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="busquedatxt" ></asp:TextBox>
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="busquedatxt">
        <asp:ListItem>Puesto</asp:ListItem>
        <asp:ListItem>Opcion</asp:ListItem>        
    </asp:DropDownList>
        
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT descripcion FROM GT_Rol"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT descripcion FROM GT_Opcion_Menu"></asp:SqlDataSource>
        
            <CCS:GridViewExtended ID="GridView1" CssClass="GridViewConfig" runat="server" AllowPaging="True" AllowSorting="True" _showFooterWhenEmpty="true" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCreated="GridView1_RowCreated" OnSelectedIndexChanged="OnSelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"  DataKeyNames="idAcceso" ShowFooter="True" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:TemplateField>
                        <FooterTemplate>
                            <asp:Label ID="Label5" runat="server" Text="Informacion a insertar:"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Acceso" SortExpression="idAcceso" Visible="False">
                        <EditItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("idAcceso") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("idAcceso") %>'></asp:Label>
                        </ItemTemplate>                                             
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Puesto" SortExpression="idRol">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource2" DataTextField="descripcion" DataValueField="descripcion" SelectedValue='<%# Bind("idRol") %>'></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("idRol") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource2" DataTextField="descripcion" DataValueField="descripcion" ></asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Opcion" SortExpression="idOpcion">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3" DataTextField="descripcion" DataValueField="descripcion" SelectedValue='<%# Bind("idOpcion") %>'></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("idOpcion") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource3" DataTextField="descripcion" DataValueField="descripcion"></asp:DropDownList>
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
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("comentarios") %>' ></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                </Columns>
            </CCS:GridViewExtended>
</asp:Content>
