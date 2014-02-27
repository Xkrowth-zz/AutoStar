<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Areas.aspx.cs" Inherits="AutoStar.app.GT_Departamento" EnableEventValidation="false" %>
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
            <h1>Áreas</h1>
        <div>
        <asp:Table CssClass="table" ID="Table1" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/Default.aspx" CssClass="botonFull" ID="ImageButton3" AlternateText="Home" runat="server" ImageUrl="~/app/Images/icons/iconInicio.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_buscar" AlternateText="Buscar" runat="server" ImageUrl="~/app/Images/icons/iconBuscar.png" onClick="btn_buscar_click"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton5" AlternateText="Crear" runat="server" ImageUrl="~/app/Images/icons/iconCrear.png" onClick="btn_crearclick"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton2" AlternateText="Editar" runat="server" ImageUrl="~/app/Images/icons/iconEditar.png" OnClick="btn_editar" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton4" AlternateText="Guardar" runat="server" ImageUrl="~/app/Images/icons/iconGuardar.png" OnClick="btn_guardarClick" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton1" AlternateText="Eliminar" runat="server" ImageUrl="~/app/Images/icons/iconBorrar.png" OnClick="btn_eliminarClick" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" DeleteCommand="deleteArea" DeleteCommandType="StoredProcedure" InsertCommand="insertArea" InsertCommandType="StoredProcedure" SelectCommand="areasBusqueda" UpdateCommand="updateArea" UpdateCommandType="StoredProcedure" SelectCommandType="StoredProcedure">
                <DeleteParameters>
                    <asp:Parameter Name="idArea" Type="Int32" />
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
                    <asp:Parameter Name="idArea" Type="Int32" />
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="comentarios" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>



        
            <asp:Label ID="Label1" CssClass="busquedalbl" runat="server" Text="Valor a buscar:"></asp:Label>
        <asp:TextBox ID="TextBox1" CssClass="busquedatxt" runat="server"></asp:TextBox>
        <asp:DropDownList ID="DropDownList1" CssClass="busquedatxt" runat="server">
            <asp:ListItem>Descripcion</asp:ListItem>            
        </asp:DropDownList>



        
            <CCS:GridViewExtended ID="GridView1" CssClass="GridViewConfig" runat="server" _showFooterWhenEmpty="true" OnSelectedIndexChanged="OnSelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" onRowCreated="GridView1_RowCreated" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="idArea" ShowFooter="True" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:TemplateField HeaderText="idArea" InsertVisible="False" SortExpression="idArea" Visible="False">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("idArea") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("idArea") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField FooterText="Informacion a insertar"></asp:TemplateField>


                    <asp:TemplateField HeaderText="Descripcion" SortExpression="descripcion">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Text='<%# Bind("descripcion") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" ></asp:TextBox>
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
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Text='<%# Bind("comentarios") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("comentarios") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" ></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </CCS:GridViewExtended>


</asp:Content>

