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
                    <asp:ImageButton PostBackUrl="~/app/GT_Planografo_Digital.aspx" CssClass="botonFull" ID="ImageButton2" AlternateText="Refresh" runat="server" ImageUrl="~/app/Images/icons/iconActualizar.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton1" AlternateText="Crear" runat="server" ImageUrl="~/app/Images/icons/iconCrear.png" OnClick="ImageButton1_Click" />
                </asp:TableCell>
                <asp:TableCell CssClass="reloj">
                    <label id="reloj" class="rel0j"></label>
                    <br />
                    <asp:Label ID="fecha_actual" runat="server" Font-Size="16px" Text="Label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Button ID="btnatras" CssClass="botonFecha1" runat="server" OnClick="btnatras_Click" Text="&lt;&lt;" />
        <asp:Button ID="btndias" CssClass="botonFecha2" runat="server" OnClick="btndias_Click" Text="&gt;&gt;" />

        <asp:DropDownList ID="drpAreas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpAreas_SelectedIndexChanged">
        </asp:DropDownList>

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

        <div class="divPopupPlanografo" runat="server" id="ventana">
            <div runat="server" class="divComponentesPlanografo" id="div1" style="width: 39.5%">
                <div runat="server" class="divParejaComponentes" id="divAdentro1">
                    <asp:Label ID="Label3" CssClass="lblCrearPlanografo" runat="server" Text="Técnico:"></asp:Label>
                    <asp:DropDownList ID="drpTecnico" CssClass="ddlCrearPlanografo" runat="server"></asp:DropDownList>
                </div>
                <div runat="server" class="divParejaComponentes" id="div5">
                    <asp:Label ID="Label2" CssClass="lblCrearPlanografo" runat="server" Text="O.T:"></asp:Label>
                    <asp:DropDownList ID="drpOt" CssClass="ddlCrearPlanografo" runat="server"></asp:DropDownList>
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
                    <asp:TextBox ID="htazada" CssClass="ddlCrearPlanografo" runat="server" AutoPostBack="True" OnTextChanged="htazada_TextChanged"></asp:TextBox>
                </div>

                <div runat="server" class="divParejaComponentes" id="div10">
                    <asp:Label ID="Label29" CssClass="lblCrearPlanografo" runat="server" Text="Hora Real:"></asp:Label>
                    <asp:TextBox ID="txtHorareal" CssClass="ddlCrearPlanografo" runat="server" Enabled="False"></asp:TextBox>
                </div>
                <div runat="server" class="divParejaComponentes" id="div11">
                    <asp:Label ID="Label27" CssClass="lblCrearPlanografo" runat="server" Text="Ampliación:"></asp:Label>
                    <asp:TextBox ID="txtHoraExtra" CssClass="ddlCrearPlanografo" runat="server" AutoPostBack="True" OnTextChanged="htazada_TextChanged">0,0</asp:TextBox>
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
            </div>
            <div runat="server" id="div4" class="divComponentesPlanografo" style="width: 15.5%">
                <asp:ImageButton PostBackUrl="~/app/GT_Orden_Trabajo.aspx" CssClass="btnPopupToolbar" ID="ordenTrabajo" AlternateText="Orden de Trabajo" runat="server" ImageUrl="~/app/Images/icons/iconOrdenTrabajo.png" />
                <br />
                <asp:ImageButton PostBackUrl="~/app/GT_Asignacion_Parqueo.aspx" CssClass="btnPopupToolbar" ID="ImageButton4" AlternateText="Asignacion de Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconAsignacionParqueo.png" />
                <br />
                <asp:ImageButton PostBackUrl="~/app/GT_Asignacion_Parqueo.aspx" CssClass="btnPopupToolbar" ID="ImageButton5" AlternateText="Comentarios" runat="server" />
            </div>
            <div runat="server" id="div2" style="padding: 5px; text-align: right">
                <asp:Button ID="Button1" CssClass="btnCrearPlanografo" runat="server" Text="Agregar" OnClick="Button1_Click" />
                <asp:Button ID="btneliminar" CssClass="btnCrearPlanografo" runat="server" OnClick="btneliminar_Click" Text="Eliminar" Visible="False" />
                <asp:Button ID="btncerrar" CssClass="btnCrearPlanografo" runat="server" OnClick="btncerrar_Click" Text="Cerrar" />
            </div>
        </div>

        <div id="estdos" runat="server" class="divColEspera" >
            <div id="estado1" runat="server" class="divListEspera">
                <p class="lblOrdenesEspera">Pendiente de Repuestos</p>
            </div>
            <div id="estado2" runat="server" class="divListEspera">
                <p class="lblOrdenesEspera">Pendiente de Aprobación Cliente</p>
            </div>
            <div id="estado3" runat="server" class="divListEspera">
                <p class="lblOrdenesEspera">Trabajos de Taller Externo</p>
            </div>
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
