<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="GT_Orden_Trabajo.aspx.cs" Inherits="AutoStar.app.GT_Estado_Orden_Trabajo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" class="bodyUsuarios">
        body {
            background-image: url('/app/Images/backgrounds/J1.jpg');
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>
    <h1>Orden de trabajo</h1>
    <div>
        <asp:Table CssClass="table" ID="Table1" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/Default.aspx" CssClass="botonFull" ID="ImageButton3" AlternateText="Home" runat="server" ImageUrl="~/app/Images/icons/iconInicio.png" />
                </asp:TableCell>                                
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton1" AlternateText="Crear" runat="server" ImageUrl="~/app/Images/icons/iconCrear.png" ValidationGroup="Insert" OnClick="link_insertClick" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                <asp:ImageButton CssClass="botonFull" ID="btn_search" AlternateText="Buscar" onclick="btnSearch_Click" runat="server" ImageUrl="~/app/Images/icons/iconBuscar.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton2" AlternateText="Editar" runat="server" ImageUrl="~/app/Images/icons/iconEditar.png" OnClick="btn_orden_editar_Click" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton4" AlternateText="Guardar" runat="server" ImageUrl="~/app/Images/icons/iconGuardar.png" Onclick="btn_orden_guardar_Click" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="ImageButton5" AlternateText="Borrar" runat="server" ImageUrl="~/app/Images/icons/iconBorrar.png" OnClick="btn_orden_eliminar_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>"
        DeleteCommand="deleteOrden" DeleteCommandType="StoredProcedure" InsertCommand="insertOrden" InsertCommandType="StoredProcedure"
        SelectCommand="ordenesBusqueda" UpdateCommand="updateOrden" UpdateCommandType="StoredProcedure" SelectCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="idOrdenTrabajo" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="numeroOrden" Type="Int32" />
            <asp:Parameter Name="Estado" Type="String" />
            <asp:Parameter Name="Asesor" Type="String" />
            <asp:Parameter Name="Tecnico" Type="String" />
            <asp:Parameter Name="Area" Type="String" />
            <asp:Parameter Name="placa" Type="String" />
            <asp:Parameter Name="dia" Type="Int32" />
            <asp:Parameter Name="mes" Type="Int32" />
            <asp:Parameter Name="año" Type="Int32" />
            <asp:Parameter Name="comentarios" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="txtSearch" DbType="String"  Name="valor" PropertyName="Text" DefaultValue="vacio"  />
            <asp:ControlParameter ControlID="DropDownList1" DbType="String"  Name="campo" PropertyName="SelectedItem.Text"  />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="index" Type="Int32" />
            <asp:Parameter Name="numeroOrden" Type="Int32" />
            <asp:Parameter Name="Asesor" Type="String" />
            <asp:Parameter Name="Estado" Type="string" />
            <asp:Parameter Name="Tecnico" Type="String" />
            <asp:Parameter Name="placa" Type="String" />
            <asp:Parameter Name="dia" Type="Int32" />
            <asp:Parameter Name="mes" Type="Int32" />
            <asp:Parameter Name="año" Type="Int32" />
            <asp:Parameter Name="comentarios" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>


    <%--ELEMENTOS PARA LA BUSQUEDA, NO FUNCIONAN AUN--%>
    <asp:Label ID="lbl_search" CssClass="busquedalbl" runat="server" Text="Valor a buscar:"></asp:Label>
    <asp:TextBox ID="txtSearch" CssClass="busquedatxt" runat="server"></asp:TextBox>
    <asp:DropDownList ID="DropDownList1" CssClass="busquedatxt" runat="server">
        <asp:ListItem>Numero de Orden</asp:ListItem>
        <asp:ListItem>Estado</asp:ListItem>
        <asp:ListItem>Tecnico</asp:ListItem>
        <asp:ListItem>Asesor</asp:ListItem>
        <asp:ListItem>Placa</asp:ListItem>
        <asp:ListItem>Area</asp:ListItem>
    </asp:DropDownList>
    
    
    
    <br />
    <%--FIN--%>    

    
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT descripcion 
FROM GT_Status_Orden_Trabajo"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT [descripcion] FROM [GT_Areas]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT nombre FROM GT_Tecnicos"></asp:SqlDataSource>    
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT nombre FROM GT_Tecnicos"></asp:SqlDataSource>      

    <asp:GridView ID="GridView1" CssClass="GridViewConfig" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="idOrdenTrabajo" OnSelectedIndexChanged="OnSelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDataBound="OnRowDataBound" ShowFooter="True" ShowHeaderWhenEmpty="True">
        <Columns>            
            <asp:TemplateField ShowHeader="False">
                <%--<EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Guardar"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="link_edit" runat="server" CausesValidation="False" CommandName="Edit" ></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="link_select" runat="server" CausesValidation="False" CommandName="Select" ></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="link_delete" runat="server" CausesValidation="False" CommandName="Delete" ></asp:LinkButton>
                </ItemTemplate>--%>
                <FooterTemplate>
                    <asp:LinkButton ID="link_insert" ValidationGroup="Insert" runat="server" OnClick="link_insertClick">Información a insertar:</asp:LinkButton>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="idOrdenTrabajo" InsertVisible="False" SortExpression="idOrdenTrabajo" Visible="false">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("idOrdenTrabajo") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("idOrdenTrabajo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Número de Orden" SortExpression="numeroOrden">
                <EditItemTemplate>
                    <asp:TextBox ID="txtfld_numeroOrden" runat="server" Text='<%# Bind("numeroOrden") %>' ReadOnly="true"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("numeroOrden") %>'> </asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtfld_insert_numeroOrden" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_insert_numeroOrden" ValidationGroup="Insert" runat="server" ErrorMessage="Numero de Orden es un campo obligatario" ControlToValidate="txtfld_insert_numeroOrden" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estado" SortExpression="idEstado">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList15" runat="server" DataSourceID="SqlDataSource2" DataTextField="descripcion" DataValueField="descripcion">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("idEstado") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="descripcion" DataValueField="descripcion">
                    </asp:DropDownList><%--<asp:TextBox ID="txtfld_insert_idEstado" runat="server"></asp:TextBox>--%>
                    <asp:RequiredFieldValidator ID="rfv_insert_idEstado" ValidationGroup="Insert" runat="server" ErrorMessage="Estado es un campo obligatario" ControlToValidate="DropDownList2" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                </FooterTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Técnico" SortExpression="idTecnico">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList14" runat="server" DataSourceID="SqlDataSource3" DataTextField="nombre" DataValueField="nombre">
    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("idTecnico") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3" DataTextField="nombre" DataValueField="nombre">
    </asp:DropDownList><%--<asp:TextBox ID="txtfld_insert_idTecnico" runat="server"></asp:TextBox>--%>
                    <asp:RequiredFieldValidator ID="rfv_insert_idTecnico" ValidationGroup="Insert" runat="server" ErrorMessage="Tecnico es un campo obligatario" ControlToValidate="DropDownList3" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Area" SortExpression="idArea">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList13" runat="server" DataSourceID="SqlDataSource4" DataTextField="descripcion" DataValueField="descripcion">
    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("idArea") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource4" DataTextField="descripcion" DataValueField="descripcion">
    </asp:DropDownList><%--<asp:TextBox ID="txtfld_insert_idArea" runat="server"></asp:TextBox>--%>
                    <asp:RequiredFieldValidator ID="rfv_insert_idArea" ValidationGroup="Insert" runat="server" ErrorMessage="Area es un campo obligatario" ControlToValidate="DropDownList4" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Placa" SortExpression="placa">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("placa") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("placa") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtfld_insert_placa" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_insert_placa" ValidationGroup="Insert" runat="server" ErrorMessage="Placa es un campo obligatario" ControlToValidate="txtfld_insert_placa" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Asesor" SortExpression="idAsesor">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList12" runat="server" DataSourceID="SqlDataSource5" DataTextField="nombre" DataValueField="nombre">
    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("idAsesor") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource5" DataTextField="nombre" DataValueField="nombre">
    </asp:DropDownList><%--<asp:TextBox ID="txtfld_insert_idAsesor" runat="server"></asp:TextBox>--%>
                    <asp:RequiredFieldValidator ID="rfv_insert_idAsesor" ValidationGroup="Insert" runat="server" ErrorMessage="Asesor es un campo obligatario" ControlToValidate="DropDownList5" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Fecha de Ingreso" SortExpression="fechaIngreso">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList9" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem> 2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList10" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>                        
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList11" runat="server">
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                        <asp:ListItem>2016</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                        <asp:ListItem>2018</asp:ListItem>
                        <asp:ListItem>2019</asp:ListItem>
                        <asp:ListItem>2020</asp:ListItem>                        
                    </asp:DropDownList>
                    <%--<asp:TextBox ID="txtfld_insert_fechaIngreso" runat="server"></asp:TextBox>--%>
                    <asp:RequiredFieldValidator ID="rfv_insert_dia" ValidationGroup="Insert" runat="server" ErrorMessage="Dia es un campo obligatario" ControlToValidate="DropDownList9" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfv_insert_mes" ValidationGroup="Insert" runat="server" ErrorMessage="Mes es un campo obligatario" ControlToValidate="DropDownList10" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfv_insert_año" ValidationGroup="Insert" runat="server" ErrorMessage="Año de Ingreso es un campo obligatario" ControlToValidate="DropDownList11" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("fechaIngreso") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownList6" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem> 2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList7" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>                        
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList8" runat="server">
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                        <asp:ListItem>2016</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                        <asp:ListItem>2018</asp:ListItem>
                        <asp:ListItem>2019</asp:ListItem>
                        <asp:ListItem>2020</asp:ListItem>                        
                    </asp:DropDownList>
                    
                    <asp:RequiredFieldValidator ID="rfv_insert_dia" ValidationGroup="Insert" runat="server" ErrorMessage="Dia es un campo obligatario" ControlToValidate="DropDownList6" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfv_insert_mes" ValidationGroup="Insert" runat="server" ErrorMessage="Mes es un campo obligatario" ControlToValidate="DropDownList7" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfv_insert_año" ValidationGroup="Insert" runat="server" ErrorMessage="Año de Ingreso es un campo obligatario" ControlToValidate="DropDownList8" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comentarios" SortExpression="comentarios">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("comentarios") %>' TextMode="MultiLine"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("comentarios") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtfld_insert_comentarios" runat="server" TextMode="MultiLine" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_insert_comentarios" ValidationGroup="Insert" runat="server" ErrorMessage="Comentarios es un campo obligatario" ControlToValidate="txtfld_insert_comentarios" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Respuestas" SortExpression="respuestas">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("respuestas") %>' TextMode="MultiLine"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("respuestas") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtfld_insert_respuestas" runat="server" TextMode="MultiLine" ></asp:TextBox>
                    

                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Garantia" SortExpression="garantia">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("garantia") %>' TextMode="MultiLine"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("garantia") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtfld_insert_garantia" runat="server" TextMode="MultiLine" ></asp:TextBox>
                    

                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Logistica" SortExpression="logistica">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("logistica") %>' TextMode="MultiLine"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label14" runat="server" Text='<%# Bind("logistica") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtfld_insert_logistica" runat="server" TextMode="MultiLine" ></asp:TextBox>
                    

                </FooterTemplate>
            </asp:TemplateField>


        </Columns>
    </asp:GridView>

    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Insert" ForeColor="Red" runat="server" />




</asp:Content>
