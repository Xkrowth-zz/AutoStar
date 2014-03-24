<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="GT_Status_Orden.aspx.cs" Inherits="AutoStar.app.GT_Estado_Orden" %>

<%@ Register TagPrefix="CCS" Namespace="CustomControls"
    Assembly="GridViewExtended" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" class="bodyUsuarios">
        body {
            background-image: url('/app/Images/backgrounds/MB8.jpg');
            background-repeat: no-repeat;
            background-size: cover;
            background-attachment: fixed;
        }
    </style>
    <script>
        function UserDeleteConfirmation() {
            return confirm("Desea eliminar este status?");
        }
    </script>
    <h1>Status</h1>
    <div>
        <asp:Table CssClass="table" ID="Table1" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/Default.aspx" CssClass="botonFull" ID="ImageButton3" AlternateText="Home" runat="server" ImageUrl="~/app/Images/icons/iconInicio.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_buscar" AlternateText="Buscar" runat="server" ImageUrl="~/app/Images/icons/iconBuscar.png" OnClick="btn_buscarClick" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton5" AlternateText="Buscar" runat="server" ImageUrl="~/app/Images/icons/iconCrear.png" OnClick="btn_crearClick" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton2" AlternateText="Editar" runat="server" ImageUrl="~/app/Images/icons/iconEditar.png" OnClick="btn_editarClick" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton4" AlternateText="Guardar" runat="server" ImageUrl="~/app/Images/icons/iconGuardar.png" OnClick="btn_guardarClick" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton1" AlternateText="Eliminar" runat="server" ImageUrl="~/app/Images/icons/iconBorrar.png" OnClick="btn_eliminarClick" OnClientClick="if ( ! UserDeleteConfirmation()) return false;" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" DeleteCommand="deleteStatus" DeleteCommandType="StoredProcedure" InsertCommand="insertStatus" InsertCommandType="StoredProcedure" SelectCommand="statusBusqueda" SelectCommandType="StoredProcedure" UpdateCommand="updateStatus" UpdateCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="idStatus" Type="Int32" />
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
            <asp:Parameter Name="idStatus" Type="Int32" />
            <asp:Parameter Name="descripcion" Type="String" />
            <asp:Parameter Name="comentarios" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>


    <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_buscar">
        <asp:Label ID="Label1" CssClass="busquedalbl" runat="server" Text="Valor a buscar:"></asp:Label>
        <asp:TextBox ID="TextBox1" CssClass="busquedatxt" runat="server"></asp:TextBox>
        <asp:DropDownList ID="DropDownList1" CssClass="busquedatxt" runat="server">
            <asp:ListItem>Descripcion</asp:ListItem>
        </asp:DropDownList>
    </asp:Panel>


    <CCS:GridViewExtended ID="GridView1" CssClass="GridViewConfig" runat="server" _showFooterWhenEmpty="true" AutoGenerateColumns="False" DataKeyNames="idStatus" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="OnSelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowCreated="GridView1_RowCreated" ShowFooter="True">
        <Columns>
            <asp:TemplateField FooterText="Informacion a insertar:"></asp:TemplateField>

            <asp:TemplateField HeaderText="idStatus" InsertVisible="False" SortExpression="idStatus" Visible="false">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("idStatus") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("idStatus") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="descripcion" SortExpression="descripcion">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("descripcion") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_status" ValidationGroup="Insert" runat="server" ErrorMessage="Status es un campo obligatario" ControlToValidate="TextBox5" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status" SortExpression="status">
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("status") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("status") %>' Enabled="false" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:CheckBox ID="CheckBox3" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="comentarios" SortExpression="comentarios">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Text='<%# Bind("comentarios") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("comentarios") %>'></asp:Label>
                </ItemTemplate>

                <FooterTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </CCS:GridViewExtended>

   <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Insert" ForeColor="Red" runat="server" />

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT GT_Status_Orden_Trabajo.descripcion FROM GT_Status_Orden_Trabajo"></asp:SqlDataSource>


</asp:Content>
