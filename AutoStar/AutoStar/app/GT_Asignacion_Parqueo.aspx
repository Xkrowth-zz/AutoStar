<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Asignacion_Parqueo.aspx.cs" Inherits="AutoStar.app.GT_Asignacion_Parqueo"  
    %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" class="bodyUsuarios">
        body {
            background-image: url('/app/Images/backgrounds/parqueo.png');
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

    //function popup(mylink, windowname) {
    //    if (!window.focus) return true;
    //    var href;
    //    if (typeof (mylink) == 'string')
    //        href = mylink;
    //    else
    //        href = mylink.href;
    //    // You can set the height width scrollbar & menubar according to your 
    //    // requirement
    //    window.open(href, windowname, 'width=700,height=400,scrollbars=yes,resizable=false');
    //    return false;
    //}
    
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

    <asp:Label ID="Label1" CssClass="busquedalbl" runat="server" Text="Seleccionar area" Visible="False"></asp:Label>

    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="descripcion" DataValueField="descripcion" Visible="False" AutoPostBack="true" OnSelectedIndexChanged="onIndexChanged">
    <asp:ListItem>Seleccione el area</asp:ListItem>
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT descripcion FROM GT_Areas"></asp:SqlDataSource>


    <div >
        <asp:Table id="bahiasMercedez" CssClass="table" runat="server" Visible="False">

            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_001" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_001','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_002" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_002','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_003" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_003','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_004" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_004','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_005" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_005','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_006" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_006','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
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
                    <asp:ImageButton CssClass="botonFull" ID="btn_007" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_007','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_008" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_008','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>  
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_009" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_009','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>              
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_010" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_010','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>                
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_011" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_011','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
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
                    <asp:ImageButton CssClass="botonFull" ID="btn_012" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_012','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_013" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_013','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_014" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_014','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_015" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_015','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_016" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_016','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
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
                    <asp:ImageButton CssClass="botonFull" ID="btn_017" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_017','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_018" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_018','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>  
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_019" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_019','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>              
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_020" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconGrua.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_020','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>                
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_021" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconBahia.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_021','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                </asp:TableCell>                
            </asp:TableRow>
                
        </asp:Table>
    </div>


    <asp:Panel ID="parqueo_Nivel_1" runat="server" Visible="false">

        <asp:ImageButton CssClass="botonFull" ID="btn_022" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_022','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_023" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_023','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_024" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_024','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_025" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_025','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_026" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_026','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
            
                    <asp:ImageButton CssClass="botonFull" ID="btn_027" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_027','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
               
                    <asp:ImageButton CssClass="botonFull" ID="btn_028" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_028','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_029" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_029','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
               
                    <asp:ImageButton CssClass="botonFull" ID="btn_030" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_030','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_031" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_031','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
            
                    <asp:ImageButton CssClass="botonFull" ID="btn_032" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_032','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_033" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_033','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_034" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_034','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_035" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_035','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_036" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_036','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_037" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_037','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_038" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_038','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_039" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_039','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_040" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_040','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_041" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_041','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                    <asp:ImageButton CssClass="botonFull" ID="btn_042" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClick="asignarParqueo" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_042','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1'); ppAsignacion_Parqueo.aspx.boton.Text = this.ID;"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_043" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_043','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_044" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_044','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_045" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_045','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_046" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_046','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
            
                    <asp:ImageButton CssClass="botonFull" ID="btn_047" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_047','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_048" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_048','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_049" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_049','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_050" AlternateText="Grua" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_050','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>
                
                    <asp:ImageButton CssClass="botonFull" ID="btn_051" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_051','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_052" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_052','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_053" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_053','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_054" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_054','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_055" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_055','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_056" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_056','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_057" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_057','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_058" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_058','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_059" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_059','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_060" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_060','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_061" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_061','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_062" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_062','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_063" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_063','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_064" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_064','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_065" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_065','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_066" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_066','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_067" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_067','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_068" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_068','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_069" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_069','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_070" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_070','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_071" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_071','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_072" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_072','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_073" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_073','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_074" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_074','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_075" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_075','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_076" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_076','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_077" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_077','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_078" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_078','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_079" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_079','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

        <asp:ImageButton CssClass="botonFull" ID="btn_080" AlternateText="Bahia" runat="server" ImageUrl="~/app/Images/icons/iconParqueoLibre.png" OnClientClick="window.showModalDialog('http://localhost:1874/app/ppAsignacion_Parqueos.aspx?field1=btn_080','Search','width=550,height=170,left=150,top=200,scrollbars=1,toolbar=no,status=1')"/>

    </asp:Panel>
    
        
        



            
                            

        
   
       



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
