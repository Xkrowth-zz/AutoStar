<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Usuario.aspx.cs" Inherits="AutoStar.app.GT_Usuario" EnableEventValidation="false" %>


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
    <h1>Usuarios</h1>
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
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton4" AlternateText="Guardar" runat="server" ImageUrl="~/app/Images/icons/iconGuardar.png" OnClick="update" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton5" AlternateText="Borrar" runat="server" ImageUrl="~/app/Images/icons/iconBorrar.png" OnClick="btn_eliminar_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>"
        DeleteCommand="deleteUsuario" DeleteCommandType="StoredProcedure"
        InsertCommand="insertUsuario" InsertCommandType="StoredProcedure"
        SelectCommand="usuariosBusqueda" SelectCommandType="StoredProcedure"
        UpdateCommand="updateUsuario" UpdateCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="idUsuario" Type="Int32" />
        </DeleteParameters>

        <InsertParameters>
            <asp:Parameter Name="idRol" Type="Int32" />
            <asp:Parameter Name="idDepartamento" Type="Int32" />
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="apellido1" Type="String" />
            <asp:Parameter Name="apellido2" Type="String" />
            <asp:Parameter Name="comentarios" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" DefaultValue="vacio" Name="valor" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" Name="campo" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="idUsuario" Type="Int32" />
            <asp:Parameter Name="idRol" Type="Int32" />
            <asp:Parameter Name="idDepartamento" Type="Int32" />
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="apellido1" Type="String" />
            <asp:Parameter Name="apellido2" Type="String" />
            <asp:Parameter Name="comentarios" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:Label ID="Label1" CssClass="busquedalbl" runat="server" Text="Valor a buscar:"></asp:Label>
    <asp:TextBox ID="TextBox1" CssClass="busquedatxt" runat="server"></asp:TextBox>
    <asp:DropDownList ID="DropDownList1" CssClass="busquedatxt" runat="server">
        <asp:ListItem>Nombre</asp:ListItem>
        <asp:ListItem>Apellido1</asp:ListItem>
        <asp:ListItem>Apellido2</asp:ListItem>
        <asp:ListItem>Rol</asp:ListItem>        
    </asp:DropDownList>

    <asp:GridView ID="GridView1" CssClass="GridViewConfig" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="OnSelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDataBound="OnRowDataBound" DataKeyNames="idUsuario" ShowFooter="True" ShowHeaderWhenEmpty="True">
        <Columns>            
            <asp:TemplateField ShowHeader="False">
                <%--<EditItemTemplate>
                    <asp:LinkButton ID="link_update" runat="server" CausesValidation="True" CommandName="Update"  Text="Guardar"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="link_cancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="link_edit" runat="server" CausesValidation="False" CommandName="Edit" ></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="link_select" runat="server" CausesValidation="False" CommandName="Select" ></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="link_delete" runat="server" CausesValidation="False" CommandName="Delete" ></asp:LinkButton>
                </ItemTemplate>--%>
                <FooterTemplate>
                    <asp:LinkButton ID="link_insert" ValidationGroup="Insert" runat="server" OnClick="lbInsert_Click">Información a insertar:</asp:LinkButton>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre" >
                <EditItemTemplate>
                    <asp:TextBox ID="txtfld_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ErrorMessage="Nombre es un campo obligatario" ControlToValidate="txtfld_nombre" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtfld_insert_nombre" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_insert_nombre" ValidationGroup="Insert" runat="server" ErrorMessage="Nombre es un campo obligatario" ControlToValidate="txtfld_insert_nombre" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Apellido1" SortExpression="Apellido1">
                <EditItemTemplate>
                    <asp:TextBox ID="txtfld_apellido1" runat="server" Text='<%# Bind("apellido1") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_apellido1" runat="server" ErrorMessage="Apellido1 es un campo obligatario" ControlToValidate="txtfld_apellido1" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_apellido1" runat="server" Text='<%# Bind("apellido1") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtfld_insert_apellido1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_insert_apellido1" ValidationGroup="Insert" runat="server" ErrorMessage="Apellido1 es un campo obligatario" ControlToValidate="txtfld_insert_apellido1" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Apellido2" SortExpression="Apellido2">
                <EditItemTemplate>
                    <asp:TextBox ID="txtfld_apellido2" runat="server" Text='<%# Bind("apellido2") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_apellido2" runat="server" ErrorMessage="Apellido2 es un campo obligatario" ControlToValidate="txtfld_apellido2" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_apellido2" runat="server" Text='<%# Bind("apellido2") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtfld_insert_apellido2" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_insert_apellido2" ValidationGroup="Insert" runat="server" ErrorMessage="Apellido2 es un campo obligatario" ControlToValidate="txtfld_insert_apellido2" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="Departamento" SortExpression="Departamento">
                <EditItemTemplate>
                    <asp:TextBox ID="txtfld_departamento" runat="server" Text='<%# Bind("idDepartamento") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_departamento" runat="server" ErrorMessage="Departamento es un campo obligatario" ControlToValidate="txtfld_departamento" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_departamento" runat="server" Text='<%# Bind("idDepartamento") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtfld_insert_departamento" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_insert_departamento" ValidationGroup="Insert" runat="server" ErrorMessage="Departamento es un campo obligatario" ControlToValidate="txtfld_insert_departamento" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Rol" SortExpression="Rol">
                <EditItemTemplate>
                    <asp:TextBox ID="txtfld_rol" runat="server" Text='<%# Bind("idRol") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_rol" runat="server" ErrorMessage="Rol es un campo obligatario" ControlToValidate="txtfld_rol" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_rol" runat="server" Text='<%# Bind("idRol") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="descripcion" DataValueField="descripcion"></asp:DropDownList>
                </FooterTemplate>
                <ControlStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comentarios" SortExpression="Comentarios">
                <EditItemTemplate>
                    <asp:TextBox ID="txtfld_comentarios" runat="server" Text='<%# Bind("comentarios") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_comentarios" runat="server" ErrorMessage="Comentarios es un campo obligatario" ControlToValidate="txtfld_comentarios" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_comentarios" runat="server" Text='<%# Bind("comentarios") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtfld_insert_comentarios" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_insert_comentarios" ValidationGroup="Insert" runat="server" ErrorMessage="Comentarios es un campo obligatario" ControlToValidate="txtfld_insert_comentarios" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="idUsuario" SortExpression="idUsuario" Visible="false">
                <EditItemTemplate>
                    <asp:TextBox ID="txtfld_idUsuario" runat="server" Text='<%# Bind("idUsuario") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_idUsuario" runat="server" Text='<%# Bind("idUsuario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT descripcion FROM GT_Rol"></asp:SqlDataSource>

    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Insert" ForeColor="Red" runat="server" />
    <asp:ValidationSummary ID="ValidationSummary2" ForeColor="Red" runat="server" />
</asp:Content>

