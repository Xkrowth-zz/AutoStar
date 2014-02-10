<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Asignacion_Parqueo.aspx.cs" Inherits="AutoStar.app.GT_Asignacion_Parqueo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" class="bodyUsuarios">
        body {
            background-image: url('/app/Images/backgrounds/J2.jpg');
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>

    <div>
        <asp:Table CssClass="table" ID="Table1" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/Default.aspx" CssClass="botonFull" ID="ImageButton3" AlternateText="Home" runat="server" ImageUrl="~/app/Images/icons/iconInicio.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>








    <div>
        <asp:Table CssClass="table" ID="Table2" runat="server">

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton1" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconParqueos.png" />
                </asp:TableCell>
                
            </asp:TableRow>
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton2" AlternateText="Bahias" runat="server" ImageUrl="~/app/Images/icons/iconBahias.png" onClick="btn_bahiasClick"/>
                </asp:TableCell>                
            </asp:TableRow>
                
        </asp:Table>
    </div>

    <asp:Label ID="Label1" CssClass="busquedalbl" runat="server" Text="Seleccionar area" Visible="False"></asp:Label>

    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="descripcion" DataValueField="descripcion" Visible="False" AutoPostBack="true" OnSelectedIndexChanged="onIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT descripcion FROM GT_Areas"></asp:SqlDataSource>


    <div >
        <asp:Table id="bahiasMercedez" CssClass="table" runat="server" Visible="False">

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton4" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" onClick="irAorden" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton6" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton7" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton10" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton9" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton8" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                
            </asp:TableRow>
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>                
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton14" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton13" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>  
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton12" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>              
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton11" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>                
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton5" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>                
            </asp:TableRow>
                
        </asp:Table>
    </div>





    <div >
        <asp:Table id="bahiasCDJR" CssClass="table" runat="server" Visible="False">

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton17" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton18" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton19" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton20" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton15" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>
                
            </asp:TableRow>
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>                
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton21" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton22" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>  
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton23" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>              
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton24" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>                
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton25" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" />
                </asp:TableCell>                
            </asp:TableRow>
                
        </asp:Table>
    </div>

    <asp:Panel ID="Panel1" runat="server" Visible="false" class="temporal">
        <asp:Label ID="lbl_numeroOrden" CssClass="busquedalbl" runat="server" Text="Numero de Orden:"></asp:Label>
        <asp:TextBox ID="TextBox1"  runat="server"></asp:TextBox>
        <asp:Label ID="lbl_status" CssClass="busquedalbl" runat="server" Text="Status:"></asp:Label>
        <asp:TextBox ID="TextBox2"  runat="server"></asp:TextBox>
        <asp:Label ID="lbl_tecnico" CssClass="busquedalbl" runat="server" Text="Tecnico:"></asp:Label>
        <asp:TextBox ID="TextBox3"  runat="server"></asp:TextBox>
        <asp:Label ID="lbl_area" CssClass="busquedalbl" runat="server" Text="Area:"></asp:Label>
        <asp:TextBox ID="TextBox4"  runat="server"></asp:TextBox>
        <asp:Label ID="lbl_asesor" CssClass="busquedalbl" runat="server" Text="Asesor"></asp:Label>
        <asp:TextBox ID="TextBox5"  runat="server"></asp:TextBox>
        <asp:Label ID="lbl_placa" CssClass="busquedalbl" runat="server" Text="Placa"></asp:Label>
        <asp:TextBox ID="TextBox6"  runat="server"></asp:TextBox>
        <asp:Label ID="lbl_fechaIngreso" CssClass="busquedalbl" runat="server" Text="Fecha Ingreso:"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_comentarios" CssClass="busquedalbl"  runat="server" Text="Comentarios:"></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_garantia" CssClass="busquedalbl" runat="server" Text="Garantia:"></asp:Label>
        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_logistica" CssClass="busquedalbl" runat="server" Text="Logistica"></asp:Label>
        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_repuestos" CssClass="busquedalbl" runat="server" Text="Repuestos:"></asp:Label>
        <asp:TextBox ID="TextBox11"  runat="server"></asp:TextBox>
        <asp:Label ID="lbl_cliente" CssClass="busquedalbl" runat="server" Text="Cliente:"></asp:Label>
        <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
    </asp:Panel>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
