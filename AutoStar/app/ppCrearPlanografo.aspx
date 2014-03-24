<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="ppCrearPlanografo.aspx.cs" Inherits="AutoStar.app.ppCrearPlanografo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" class="bodyUsuarios">
        body {
            background-image: url('/app/Images/backgrounds/MB22.jpg');
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>

    <div class="divPopupPlanografo" runat="server" id="ventana">
            <div runat="server" id="div2" class="divCrearPlanografo">
                <asp:Button ID="Button1" CssClass="btnCrearPlanografo" runat="server" Text="Agregar" OnClick="Button1_Click" />
                <asp:Button ID="btneliminar" CssClass="btnCrearPlanografo" runat="server" OnClick="btneliminar_Click" Text="Eliminar" Visible="False" />
                <%--<asp:Button ID="btncerrar" CssClass="btnCrearPlanografo" runat="server" OnClick="btncerrar_Click" Text="Cerrar" />--%>
            </div>
            <div runat="server" class="divComponentesPlanografo" id="div1" style="width: 39.5%">
                <div runat="server" class="divParejaComponentes" id="divAdentro1">
                    <asp:Label ID="Label3" CssClass="lblCrearPlanografo" runat="server" Text="Técnico:"></asp:Label>
                    <asp:DropDownList ID="drpTecnico" CssClass="ddlCrearPlanografo" runat="server"></asp:DropDownList>
                </div>
                <div runat="server" class="divParejaComponentes" id="div5">
                    <asp:Label ID="Label2" CssClass="lblCrearPlanografo" runat="server" Text="O.T:"></asp:Label>
                    <asp:DropDownList ID="drpOt" CssClass="ddlCrearPlanografo" runat="server" OnSelectedIndexChanged="drpOt_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div runat="server" class="divParejaComponentes" id="div9">
                    <asp:Label ID="Label29" CssClass="lblCrearPlanografo" runat="server" Text="Cliente:"></asp:Label>
                    <asp:TextBox ID="txtCliente" CssClass="ddlCrearPlanografo" runat="server" AutoPostBack="True" Enabled="false" OnTextChanged="htazada_TextChanged"></asp:TextBox>
                </div>
                <div runat="server" class="divParejaComponentes" id="div10">
                    <asp:Label ID="Label30" CssClass="lblCrearPlanografo" runat="server" Text="Asesor:"></asp:Label>
                    <asp:TextBox ID="txtAsesor" CssClass="ddlCrearPlanografo" runat="server" AutoPostBack="True" Enabled="false" OnTextChanged="htazada_TextChanged"></asp:TextBox>
                </div>
                <div runat="server" class="divParejaComponentes" id="div6">
                    <asp:Label ID="Label6" CssClass="lblCrearPlanografo" runat="server" Text="Status:"></asp:Label>
                    <asp:DropDownList ID="drpStatus" CssClass="ddlCrearPlanografo" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div runat="server" id="div3" class="divComponentesPlanografo" style="width: 45%">
                <div runat="server" class="divParejaComponentes" id="div7">
                    <asp:Label ID="Label4" CssClass="lblCrearPlanografo" runat="server" Text="Hora Inicio:"></asp:Label>
                    <asp:DropDownList ID="drpHoraInicio" CssClass="ddlCrearPlanografo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="htazada_TextChanged"></asp:DropDownList>
                </div>
                <div runat="server" class="divParejaComponentes" id="div8">
                    <asp:Label ID="Label28" CssClass="lblCrearPlanografo" runat="server" Text="Hora Tasada:"></asp:Label>
                    <asp:TextBox ID="htazada" CssClass="ddlCrearPlanografo" runat="server" AutoPostBack="True" OnTextChanged="htazada_TextChanged" Width="23%"></asp:TextBox>
                    <asp:TextBox ID="txtHorareal" CssClass="ddlCrearPlanografo" runat="server" Enabled="False" Width="23%"></asp:TextBox>
                </div>
                <div runat="server" class="divParejaComponentes" id="div11">
                    <asp:Label ID="Label27" CssClass="lblCrearPlanografo" runat="server" Text="Ampliación:"></asp:Label>
                    <asp:TextBox ID="txtHoraExtra" CssClass="ddlCrearPlanografo" runat="server" AutoPostBack="True" OnTextChanged="htazada_TextChanged" Width="23%">0,0</asp:TextBox>
                    <asp:TextBox ID="txtTiemAmp" CssClass="ddlCrearPlanografo" runat="server" Enabled="False" Width="23%"></asp:TextBox>
                </div>
                <div runat="server" class="divParejaComponentes" id="div12">
                    <asp:Label ID="Label5" CssClass="lblCrearPlanografo" runat="server" Text="Hora Final:"></asp:Label>
                    <asp:TextBox ID="txthorafinal" CssClass="ddlCrearPlanografo" runat="server" Enabled="False"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="htazada" ErrorMessage="*" ValidationGroup="validar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="htazada" ErrorMessage="Introducir formato H,M en Hora Tasada" ValidationExpression="[0-9]*[0-9],[0-9]*[0-9]" ValidationGroup="validar" ForeColor="Red" Font-Size="Small"></asp:RegularExpressionValidator>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHoraExtra" ErrorMessage="*" ValidationGroup="validar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHoraExtra" ErrorMessage="Introducir formato H,M en Ampliación de Tiempo" ValidationExpression="[0-9]*[0-9],[0-9]*[0-9]" ValidationGroup="validar" ForeColor="Red" Font-Size="Small"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpOt" ErrorMessage="*" ValidationGroup="validar"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drpTecnico" ErrorMessage="*" ValidationGroup="validar"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtComentario" CssClass="tbComentariosPlanografo" runat="server" TextMode="MultiLine" Visible="False" ></asp:TextBox>
            </div>
            <div runat="server" id="div4" class="divComponentesPlanografo" style="width: 15.5%">
                <asp:ImageButton PostBackUrl="~/app/GT_Orden_Trabajo.aspx" CssClass="btnPopupToolbar" ID="ordenTrabajo" AlternateText="Orden de Trabajo" runat="server" ImageUrl="~/app/Images/icons/iconOrdenTrabajo.png" />
                <br />
                <asp:ImageButton PostBackUrl="~/app/GT_Asignacion_Parqueo.aspx" CssClass="btnPopupToolbar" ID="ImageButton4" AlternateText="Asignacion de Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconAsignacionParqueo.png" />
                <br />
                <asp:ImageButton CssClass="btnPopupToolbar" ID="ImageButton5" AlternateText="Comentarios" runat="server" ImageUrl="~/app/Images/icons/iconComentarios.png" OnClick="ImageButton5_Click1" />
            </div>
        </div>

    <script>
        function cerrar() {
            window.close();
        }
        
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
