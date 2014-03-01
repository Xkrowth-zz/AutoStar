<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Parametros.aspx.cs" Inherits="AutoStar.app.GT_Parametros" EnableEventValidation="false"%>
<%@ Register TagPrefix="CCS" Namespace="CustomControls" 
Assembly="GridViewExtended" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" class="bodyUsuarios">
        body {
            background-image: url('/app/Images/backgrounds/MB13.jpg');
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" DeleteCommand="deleteParametro" DeleteCommandType="StoredProcedure" InsertCommand="insertParametro" InsertCommandType="StoredProcedure" SelectCommand="selectParametros" SelectCommandType="StoredProcedure" UpdateCommand="updateParametro" UpdateCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="idParametro" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="slideShow" Type="Int32" />
            <asp:Parameter Name="avisoRojo" Type="Int32" />
            <asp:Parameter Name="avisoAmarillo" Type="Int32" />
            <asp:Parameter Name="status" Type="Boolean" />
            <asp:Parameter Name="comentarios" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="idParametro" Type="Int32" />
            <asp:Parameter Name="slideShow" Type="Int32" />
            <asp:Parameter Name="avisoAmarillo" Type="Int32" />
            <asp:Parameter Name="avisoRojo" Type="Int32" />
            <asp:Parameter Name="status" Type="Boolean" />
            <asp:Parameter Name="comentarios" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>

    
        <div>
            <asp:Table CssClass="table" ID="Table1" runat="server">
                <asp:TableRow CssClass="tableRow">
                    <asp:TableCell CssClass="tableCell">
                        <asp:ImageButton PostBackUrl="~/app/Default.aspx" CssClass="botonFull" ID="ImageButton3" AlternateText="Home" runat="server" ImageUrl="~/app/Images/icons/iconInicio.png" />
                    </asp:TableCell>
                    <asp:TableCell CssClass="tableCell">
                        <asp:ImageButton CssClass="botonFull" ID="btn_buscar" AlternateText="Buscar" runat="server" ImageUrl="~/app/Images/icons/iconBuscar.png" />
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

    <CCS:GridViewExtended ID="GridView1" runat="server" _showFooterWhenEmpty="true" CssClass="GridViewConfig" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idParametro" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="OnSelectedIndexChanged" OnRowCreated="GridView1_RowCreated" ShowHeaderWhenEmpty="True" ShowFooter="True">
        
        <Columns>
            <asp:TemplateField FooterText="Informacion a insertar:"></asp:TemplateField>
            <asp:TemplateField HeaderText="idParametro" InsertVisible="False" SortExpression="idParametro" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("idParametro") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("idParametro") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SlideShow" SortExpression="slideShow">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("slideShow") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("slideShow") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Aviso Amarillo" SortExpression="avisoAmarillo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("avisoAmarillo") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("avisoAmarillo") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Aviso Rojo" SortExpression="avisoRojo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("avisoRojo") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("avisoRojo") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
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
                    <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("status") %>' />                
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("comentarios") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("comentarios") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" TextMode="MultiLine"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>

        </Columns>
    </CCS:GridViewExtended>





</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
