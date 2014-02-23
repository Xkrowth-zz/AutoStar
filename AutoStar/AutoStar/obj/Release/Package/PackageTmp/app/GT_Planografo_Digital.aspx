<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Planografo_Digital.aspx.cs" Inherits="AutoStar.app.GT_Planografo_Digital" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" class="bodyUsuarios">
        body {
            background-image: url('/app/Images/backgrounds/MB2.jpg');
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>
    <h2>Planografo Digital</h2>
    <div>
        <asp:Table CssClass="table" ID="Table1" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/Default.aspx" CssClass="botonFull" ID="ImageButton3" AlternateText="Home" runat="server" ImageUrl="~/app/Images/icons/iconInicio.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton1" AlternateText="Crear" runat="server" ImageUrl="~/app/Images/icons/iconCrear.png" OnClick="ImageButton1_Click" />
                </asp:TableCell>
                <asp:TableCell CssClass="reloj" BorderColor="White" BorderStyle="Solid">
                    <asp:Label ID="fecha_actual" CssClass="busquedalbl" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="reloj" BorderColor="White" BorderStyle="Solid">
                    <label id="reloj" class="rel0j"></label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Button ID="btnatras" CssClass="botonFecha1" runat="server" OnClick="btnatras_Click" Text="&lt;&lt;" />
        <asp:Button ID="btndias" CssClass="botonFecha2" runat="server" OnClick="btndias_Click" Text="&gt;&gt;" />

        <asp:Table CssClass="tablePlanografo1" ID="tPlano" runat="server">
            <asp:TableRow>
                <asp:TableCell CssClass="tableCellPlanografoTecnicos"></asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label1" CssClass="labelHoras">7:30</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label7" CssClass="labelHoras">8:00</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label8" CssClass="labelHoras">8:30</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label9" CssClass="labelHoras">9:00</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label10" CssClass="labelHoras">9:30</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label11" CssClass="labelHoras">10:00</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label12" CssClass="labelHoras">10:30</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label13" CssClass="labelHoras">11:00</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label14" CssClass="labelHoras">11:30</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label15" CssClass="labelHoras">12:00</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label16" CssClass="labelHoras">12:30</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label17" CssClass="labelHoras">13:00</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label18" CssClass="labelHoras">13:30</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label19" CssClass="labelHoras">14:00</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label20" CssClass="labelHoras">14:30</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label21" CssClass="labelHoras">15:00</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label22" CssClass="labelHoras">15:30</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label23" CssClass="labelHoras">16:00</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label24" CssClass="labelHoras">16:30</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label25" CssClass="labelHoras">17:00</asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="titulo_horas" ColumnSpan="2">
                    <asp:Label runat="server" ID="Label26" CssClass="labelHoras">17:30</asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- DIV SIN FORMATO BONITO 
        <div class="temporal" runat="server" id="ventana">
        <asp:Table CssClass="temporal" ID="Table2" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:Label ID="Label2" runat="server" Text="O.T:" ForeColor="White"></asp:Label>
                    <asp:DropDownList ID="drpOt" runat="server" ForeColor="Black"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Label ID="Label3" runat="server" Text="Técnico:" ForeColor="White"></asp:Label>
                    <asp:DropDownList ID="drpTecnico" runat="server" ForeColor="Black"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Label ID="Label4" runat="server" Text="Hora Inicio:" ForeColor="White"></asp:Label>
                    <asp:DropDownList ID="drpHoraInicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="htazada_TextChanged"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Label ID="Label28" runat="server" Text="Hora tasada:" ForeColor="White"></asp:Label>
                    <asp:TextBox ID="htazada" runat="server" AutoPostBack="True" OnTextChanged="htazada_TextChanged"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>
        </asp:Table>
            </div>
        --%>


        <div class="temporal" runat="server" id="ventana">
            <asp:Label ID="Label2" CssClass="busquedalbl" runat="server" Text="O.T:"></asp:Label>
            <asp:DropDownList ID="drpOt" CssClass="planografotxt" runat="server"></asp:DropDownList>
            <br />
            <asp:Label ID="Label3" CssClass="busquedalbl" runat="server" Text="Técnico:"></asp:Label>
            <asp:DropDownList ID="drpTecnico" CssClass="planografotxt" runat="server"></asp:DropDownList>
            <br />
            <asp:Label ID="Label4" CssClass="busquedalbl" runat="server" Text="Hora Inicio:"></asp:Label>
            <asp:DropDownList ID="drpHoraInicio" CssClass="planografotxt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="htazada_TextChanged"></asp:DropDownList>
            <br />
            <asp:Label ID="Label28" CssClass="busquedalbl" runat="server" Text="Hora Tasada:"></asp:Label>
            <asp:TextBox ID="htazada" CssClass="planografotxt" runat="server" AutoPostBack="True" OnTextChanged="htazada_TextChanged"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="htazada" ErrorMessage="*" ValidationGroup="validar"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="htazada" ErrorMessage="Introduzca formato H,m" ValidationExpression="[0-9]?[0-9],[0-9]?[0-9]" ValidationGroup="validar"></asp:RegularExpressionValidator>

            <asp:Label ID="Label5" CssClass="busquedalbl" runat="server" Text="Hora Final:"></asp:Label>
            <asp:TextBox ID="txthorafinal" CssClass="planografotxt" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" CssClass="busquedalbl" runat="server" Text="Status:" ForeColor="White"></asp:Label>
            <asp:DropDownList ID="drpStatus" CssClass="planografotxt" runat="server"></asp:DropDownList>
            <br />
            <asp:Button ID="Button1" CssClass="btnCrearPlan" runat="server" Text="Agregar" OnClick="Button1_Click" />
            <asp:Button ID="btneliminar" CssClass="btnCrearPlan" runat="server" OnClick="btneliminar_Click" Text="Eliminar" Visible="False" />
            <asp:Button ID="btncerrar" CssClass="btnCrearPlan" runat="server" OnClick="btncerrar_Click" Text="Cerrar" />

        </div>


    </div>

    <script>
        var myVar = setInterval(function () { myTimer() }, 1000);
        var refres = setInterval(function () { refresh() }, 900000);

        function myTimer() {
            var d = new Date();
            var h = d.getHours();
            var m = d.getMinutes();
            var s = d.getSeconds();

            if (m < 10) {
                m = "0" + m.toString();
            }
            if (s < 10) {
                s = "0" + s.toString();
            }

            var hora = h + ":" + m + ":" + s;
            document.getElementById("reloj").innerHTML = hora;
        }

        function refresh() {
            document.location.href = document.location.href;
        }



    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
