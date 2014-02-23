<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Asignacion_Parqueo.aspx.cs" Inherits="AutoStar.app.GT_Asignacion_Parqueo"  
    %>


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

    <script type="text/javascript">
<!--
    function popup(mylink, windowname) {
        if (!window.focus) return true;
        var href;
        if (typeof (mylink) == 'string')
            href = mylink;
        else
            href = mylink.href;
        // You can set the height width scrollbar & menubar according to your 
        // requirement
        window.open(href, windowname, 'width=700,height=400,scrollbars=yes,resizable=false');
        return false;
    }
    //-->
</script>

    <%--<a  href ="http://localhost:1874/app/ppAsignacion_Parqueo.aspx"  onclick="return popup(this,'examplea')">this link</a>--%>

    <%--<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')" />--%>



    <div>
        <asp:Table CssClass="table" ID="Table2" runat="server">

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton1" onClick="parqueos_Click" AlternateText="Parqueos" runat="server" ImageUrl="~/app/Images/icons/iconParqueos.png" />
                </asp:TableCell>
                
            </asp:TableRow>
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton2" AlternateText="Bahias" runat="server" ImageUrl="~/app/Images/icons/iconBahias.png" onClick="btn_bahiasClick"/>
                </asp:TableCell>                
            </asp:TableRow>
                
        </asp:Table>
    </div>

    <asp:Label ID="Label2" runat="server" Text="Seleccionar parqueo: " CssClass="busquedalbl" Visible="false" >  </asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server" Visible="false" OnSelectedIndexChanged="DropDownList2_onSelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem>Nivel 1</asp:ListItem>
        <asp:ListItem>Nivel 2</asp:ListItem>
        <asp:ListItem>Nivel 3</asp:ListItem>                                                    
    </asp:DropDownList>
    <asp:Label ID="Label1" CssClass="busquedalbl" runat="server" Text="Seleccionar area" Visible="False"></asp:Label>

    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="descripcion" DataValueField="descripcion" Visible="False" AutoPostBack="true" OnSelectedIndexChanged="onIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT descripcion FROM GT_Areas"></asp:SqlDataSource>


    <div >
        <asp:Table id="bahiasMercedez" CssClass="table" runat="server" Visible="False">

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="grua1" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia1" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia2" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia3" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia4" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia5" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
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
                    <asp:ImageButton CssClass="botonFull" ID="bahia6" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia7" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>  
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia8" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>              
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia9" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>                
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia10" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
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
                    <asp:ImageButton CssClass="botonFull" ID="bahia11" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia12" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia13" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia14" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="grua2" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
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
                    <asp:ImageButton CssClass="botonFull" ID="bahia15" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia16" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>  
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="grua3" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>              
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="grua4" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>                
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="bahia17" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>                
            </asp:TableRow>
                
        </asp:Table>
    </div>



    <div >
        <asp:Table id="parqueo_Nivel_1" CssClass="table" runat="server" Visible="False">

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_001" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_002" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_003" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_004" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_005" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
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
                    <asp:ImageButton CssClass="botonFull" ID="btn_006" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_007" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>  
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_008" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>              
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_009" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>                
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_010" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>                
            </asp:TableRow>
                
        </asp:Table>
    </div>




    <div >
        <asp:Table id="parqueo_nivel_2" CssClass="table" runat="server" Visible="False">

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_011" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_012" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_013" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_014" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_015" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
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
                    <asp:ImageButton CssClass="botonFull" ID="btn_016" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_017" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>  
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_018" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>              
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_019" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>                
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_020" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>                
            </asp:TableRow>
                
        </asp:Table>
    </div>




    <div >
        <asp:Table id="parqueo_nivel_3" CssClass="table" runat="server" Visible="False">

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_021" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClick="asignarParqueo" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_022" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClick="asignarParqueo"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_023" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_024" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_025" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
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
                    <asp:ImageButton CssClass="botonFull" ID="btn_026" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_027" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>  
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_028" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>              
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_029" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>                
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_030" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>                
            </asp:TableRow>
                
        </asp:Table>
    </div>








    

    



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
