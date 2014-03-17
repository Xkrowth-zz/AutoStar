<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Tiempos_Parada.aspx.cs" EnableEventValidation="false" Inherits="AutoStar.app.GT_Tiempos_Parada" %>
<%@ Register TagPrefix="CCS" Namespace="CustomControls" 
Assembly="GridViewExtended" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" class="bodyUsuarios">
        body {
            background-image: url('/app/Images/backgrounds/MB9.jpg');
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>
    <h1>Tiempos</h1>
    <div>
        <asp:Table CssClass="table" ID="Table1" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/Default.aspx" CssClass="botonFull" ID="ImageButton3" AlternateText="Home" runat="server" ImageUrl="~/app/Images/icons/iconInicio.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_buscar" AlternateText="Buscar" runat="server" ImageUrl="~/app/Images/icons/iconBuscar.png" onClick="btn_buscar_Click"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton5" AlternateText="Buscar" runat="server" ImageUrl="~/app/Images/icons/iconCrear.png" onClick="btn_crear_Click"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton2" AlternateText="Editar" runat="server" ImageUrl="~/app/Images/icons/iconEditar.png" OnClick="btn_editar_Click" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton4" AlternateText="Guardar" runat="server" ImageUrl="~/app/Images/icons/iconGuardar.png" OnClick="btn_guardar_Click" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton1" AlternateText="Eliminar" runat="server" ImageUrl="~/app/Images/icons/iconBorrar.png" OnClick="btn_eliminar_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <asp:Label ID="Label1" runat="server" CssClass="busquedalbl" Text="Valor a buscar:"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="busquedatxt"></asp:TextBox>
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="busquedatxt">
        <asp:ListItem>Area</asp:ListItem>
        <asp:ListItem>Descripcion</asp:ListItem>
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" DeleteCommand="deleteTiempos" DeleteCommandType="StoredProcedure" InsertCommand="insertTiempos" InsertCommandType="StoredProcedure" SelectCommand="tiemposBusqueda" SelectCommandType="StoredProcedure" UpdateCommand="updateTiempos" UpdateCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="idTiempos" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="area" Type="String" />
            <asp:Parameter Name="descripcion" Type="String" />
            <asp:Parameter Name="horaInicio" Type="DateTime" />
            <asp:Parameter Name="duracion" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" DefaultValue="vacio" Name="valor" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" Name="campo" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="idTiempos" Type="Int32" />
            <asp:Parameter Name="area" Type="String" />
            <asp:Parameter Name="descripcion" Type="String" />
            <asp:Parameter Name="horaInicio" Type="DateTime" />
            <asp:Parameter Name="duracion" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT descripcion FROM GT_Areas"></asp:SqlDataSource>
    <CCS:GridViewExtended ID="GridView1" runat="server" _showFooterWhenEmpty="true" CssClass="GridViewConfig" ShowFooter="true" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idTiempos" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="OnSelectedIndexChanged" SelectedIndexChanging="SelectedIndexChanging" onRowCreated="GridView1_RowCreated">
        <Columns>

            <asp:TemplateField></asp:TemplateField>
            <asp:TemplateField HeaderText="idTiempos" InsertVisible="False" SortExpression="idTiempos" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("idTiempos") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("idTiempos") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Area" SortExpression="idArea">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource2" DataTextField="descripcion" DataValueField="descripcion" SelectedValue='<%# Bind("idArea") %>'></asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("idArea") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="descripcion" DataValueField="descripcion"></asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Descripcion" SortExpression="descripcion">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("descripcion") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="HoraInicio" SortExpression="horaInicio">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Time" Text='<%# Bind("horaInicio") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("horaInicio") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" TextMode="Time"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Duracion" SortExpression="duracion">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("duracion") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("duracion") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_TextBox9" ValidationGroup="Insert" runat="server" ErrorMessage="Duracion es un campo obligatario" ControlToValidate="TextBox9" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Comentarios" SortExpression="comentarios">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("comentarios") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("comentarios") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox10" runat="server" TextMode="MultiLine"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </CCS:GridViewExtended>

    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Insert" ForeColor="Red" runat="server" />
    <asp:HiddenField ID="hidSourceID" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
