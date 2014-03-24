<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="ppEsperaPlanografo.aspx.cs" Inherits="AutoStar.app.ppEsperaPlanografo" %>
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

    <div id="estdos" runat="server" class="divColEspera">
            <div id="Div13" runat="server" class="divListEspera">
                <p>Pendiente de Repuestos    |</p>
                <div id="estado1" runat="server">
                </div>
            </div>
            <div id="Div14" runat="server" class="divListEspera">
                <p>Pendiente de Aprobación    |</p>
                <div id="estado2" runat="server">
                </div>
            </div>
            <div id="Div15" runat="server" class="divListEspera">
                <p>Trabajos de Taller Externo</p>
                <div id="estado3" runat="server">
                </div>
            </div>
            
        </div>

    <script>
        function llamar_ventana() {
            window.showModalDialog('http://localhost:1874/app/ppCrearPlanografo.aspx', 'Search', 'width=1025,height=700,left=150,top=200,scrollbars=1,toolbar=no,status=1');
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
