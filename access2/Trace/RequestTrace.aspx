<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="RequestTrace.aspx.cs" Inherits="view.Trace.RequestTrace" %>
<%@ MasterType VirtualPath="~/MasterPages/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        

    <script type="text/javascript" src="bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />

    
    <link href="../webforms/AddRequest.css" rel="stylesheet" />

    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.standalone.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.standalone.min.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <script src="../bootstrap-datepicker-1.4.0-dist/js/bootstrap-datepicker.min.js"></script>
    
        <script type="text/javascript">
            $(document).ready(function () {
                $('.datepicker').datepicker({
                    format: 'dd/mm/yyyy',
                    "autoclose": true
                })
            });

        </script>
   

       

         <script type="text/javascript">
             $(document).ready(function () {
                 Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

                 function EndRequestHandler(sender, args) {
                     $('.datepicker').datepicker
                         ({
                             format: 'dd/mm/yyyy',
                             "autoclose": true

                         });
                 }
             });
            </script>

         


        <%--</div>--%>

        <%--<div style="overflow-x:auto;width:1050px;overflow-y:auto; height:327px">--%>


    
    <%--</div>--%>

   
    <%--<div style="overflow-x:auto;width:1050px;overflow-y:auto; height:327px">--%>
    <asp:FormView ID="FormView1" runat="server" DataSourceID="request" Width="996px" DefaultMode="Insert" >
        <EditItemTemplate>
            
        </EditItemTemplate>
        <InsertItemTemplate>
            &nbsp;&nbsp;&nbsp; <asp:Label ID="Label42" runat="server" CssClass="title-form" Text="Requêtes Introduites" Font-Size="X-Large"></asp:Label>
            <br /> <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label31" runat="server" CssClass="LabelCss" Text="Numero de la Requête" Height="25px" Width="200px"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="numTextBox" runat="server" Height="25px" Width="200px" AutoPostBack="True" OnTextChanged="numTextBox_TextChanged" CssClass="ComponentLeft" ></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label32" runat="server" CssClass="LabelCss" Text="Date(Du-Au)" Height="25px" Width="200px"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("date", "{0:d}") %>' CssClass="datepicker" Height="25px" Width="95px" AutoPostBack="True" OnTextChanged="TextBox10_TextChanged" />
            &nbsp;<asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("date", "{0:d}") %>' CssClass="datepicker" Height="25px" Width="95px" AutoPostBack="True" OnTextChanged="TextBox12_TextChanged" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label33" runat="server" CssClass="LabelCss" Text="Wilaya" Height="25px" Width="200px"></asp:Label>
            &nbsp; &nbsp;<asp:Label ID="LabelWilaya" runat="server" Height="25px"  Text='<%# getAgentWilaya() %>' Visible='<%# !isDGCell() %>'  Width="200px" CssClass="ComponentLeft"></asp:Label>
            <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="OdsWilayas" DataTextField="wilaya" DataValueField="num" Height="25px" SelectedValue='<%# Bind("num_wilaya") %>'  Visible='<%# isDGCell() %>'  Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" CssClass="ComponentLeft">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label34" runat="server" CssClass="LabelCss" Text="Numero de Requerant" Height="25px" Width="200px"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("num_requerant") %>' Height="25px" Width="200px" AutoPostBack="True" OnTextChanged="TextBox11_TextChanged" CssClass="ComponentLeft" />
            <%--<asp:Button ID="Button5" data-toggle="modal" data-target="#myModal" runat="server" Text="..." Width="18px" Height="25px" CssClass="ButtonCss" />--%>
            <asp:Button ID="Button5" OnClick="Button5_Click" runat="server" Text="..." Width="18px" Height="25px" CssClass="ButtonCss" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label35" runat="server" CssClass="LabelCss" Text="Missions CNAC" Height="25px" Width="200px"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList8" runat="server" Height="25px" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged" SelectedValue='<%# Bind("num_mission") %>' Width="200px" AutoPostBack="True" DataSourceID="OdsDispositif" DataTextField="mission1" DataValueField="num" CssClass="ComponentLeft">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label36" runat="server" CssClass="LabelCss" Text="Objet de Dispositif" Height="25px" Width="200px"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList9" runat="server" Height="25px" Width="200px" DataSourceID="OdsMotifDispositif" DataTextField="objet" DataValueField="id_objet" AutoPostBack="True" OnSelectedIndexChanged="DropDownList9_SelectedIndexChanged" CssClass="ComponentLeft">
                <asp:ListItem Value=" ">Choisir une mission</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label37" runat="server" CssClass="LabelCss" Text="Etat de la Requête" Height="25px" Width="200px"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="OdsStateRequest" DataTextField="nom_state" DataValueField="id_state" Height="25px" SelectedValue='<%# Bind("id_state") %>' Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" CssClass="ComponentLeft">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label38" runat="server" CssClass="LabelCss" Text="Mode de Transmission" Height="25px" Width="200px"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="OdsModeTransmission" DataTextField="mode_trans" DataValueField="id_trans" Height="25px" SelectedValue='<%# Bind("id_trans") %>' Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged" CssClass="ComponentLeft">
            </asp:DropDownList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />&nbsp;&nbsp;&nbsp; <asp:Label ID="Label39" runat="server" CssClass="LabelCss" Text="Type de la Requête" Height="25px" Width="200px"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList12" runat="server" Height="25px" Width="200px" DataSourceID="OdsType" DataTextField="type" DataValueField="id_types" CssClass="ComponentLeft" OnSelectedIndexChanged="DropDownList12_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label40" runat="server" CssClass="LabelCss" Text="Voie de Transmission" Height="25px" Width="200px"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList13" runat="server" Height="25px" Width="200px" DataSourceID="OdsVoieTransmission" DataTextField="voie_trans" DataValueField="id_voie" CssClass="ComponentLeft" AutoPostBack="True" OnSelectedIndexChanged="DropDownList13_SelectedIndexChanged">
            </asp:DropDownList>
            <%--<br />
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label41" runat="server" Text="Mots Clés" CssClass="LabelCss" Height="25px" Width="200px"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="objetTextBox" runat="server" Text='<%# Eval("objet") %>' Height="25px" Width="700px" AutoPostBack="True" OnTextChanged="objetTextBox_TextChanged" CssClass="ComponentDescription" />
            &nbsp;&nbsp;&nbsp;
            <br />--%>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" Visible="False" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" Visible="False" />
            &nbsp;
        </InsertItemTemplate>
        <ItemTemplate>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; formview1<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Numero de requête&nbsp; :
            <asp:TextBox ID="TextBox2" runat="server" Width="180px" Height="25px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date de Requête&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:TextBox ID="TextBox3" CssClass="datepicker" runat="server" Width="180px" Height="25px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Wilayas&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="OdsWilayas" DataTextField="wilaya" DataValueField="num" Width="180px" Height="25px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Numero Requerant&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
            <asp:DropDownList ID="DropDownList2" runat="server" Width="180px" Height="25px">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mission&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:DropDownList ID="DropDownList3" runat="server" Height="25px" Width="180px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mode de Transmission&nbsp;&nbsp;:&nbsp;
            <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="OdsModeTransmission" DataTextField="mode_trans" DataValueField="id_trans" Width="180px" Height="25px">
            </asp:DropDownList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Objet&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:TextBox ID="TextBox1" runat="server" Width="649px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" OnClick="EditButton_Click" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" Visible="False" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" Visible="False" />
        </ItemTemplate>
    </asp:FormView>
    





        &nbsp;&nbsp;&nbsp;&nbsp;
    





    

    <%--</div>--%>


    <div id="dialog"  runat="server" visible="true">
       
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr runat="server">
                    <td class="auto-style2">
                        <strong>Nombre de Requêtes trouvées :&nbsp;&nbsp;
                        <asp:Label ID="RqFound" runat="server" Font-Italic="True" ForeColor="#006666"></asp:Label>
                        </strong>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Nombre de ligne par page : </strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList10" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList10_SelectedIndexChanged">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem Selected="True">10</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <strong> de Page : </strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList11" runat="server">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td colspan="11">
                        <asp:UpdatePanel ID="ModalPanel1" runat="server" RenderMode="Inline" UpdateMode="Always">
                        <ContentTemplate>
            <%--<div style="overflow-x:auto;width:1050px;overflow-y:auto; height:327px">--%>
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="OdsRequest" OnRowEditing="GridView2_RowEditing" Width="1015px" AllowPaging="True" GridLines="Vertical" OnPageIndexChanging="GridView1_PageIndexChanging">
                      <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton27" runat="server" OnClick="LinkButton27_Click">Voir</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField HeaderText="Numero" SortExpression="num">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("num_wilaya") %>'></asp:Label><asp:Label ID="Label2" runat="server" Text="-"></asp:Label><asp:Label ID="Label81" runat="server" Text='<%# Bind("Year") %>'></asp:Label><asp:Label ID="Label3" runat="server" Text="-"></asp:Label><asp:Label ID="Label82" runat="server" Text='<%# Bind("num") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="date" SortExpression="date">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("date") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("date", "{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mission" SortExpression="DispositifC">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# getDispostifValue1(Eval("id_objet").ToString()) %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# getDispostifValue1(Eval("id_objet").ToString()) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Objet de la Requête" SortExpression="MotifDispositifC">
                <ItemTemplate>
                    <asp:Label ID="LabelGridMotif" runat="server" Text='<%# Bind("MotifDispositifC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Wilaya" SortExpression="WilayaC">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("WilayaC") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("WilayaC", "{0}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Requerant" SortExpression="num_requerant">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("num_requerant") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("num_requerant") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mode de Transmission" SortExpression="ModeTransmissionC">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("ModeTransmissionC") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("ModeTransmissionC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Etat" SortExpression="EtatRequestC">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("EtatRequestC") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("EtatRequestC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle ForeColor="Black" BackColor="#EEEEEE" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
                <%--</div>--%>
                    </td>        
                </tr>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
           </table     
        </ContentTemplate>
        </asp:UpdatePanel>

        </div>
    





        <br />
        <br />
        <asp:ObjectDataSource ID="OdsUserActionRequest" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getRequestActionsByNum" TypeName="controller.Action_User_Request">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="Num_Request" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        
            <asp:ObjectDataSource ID="OdsRequerant" runat="server" DataObjectTypeName="Model.requerant" InsertMethod="insertRequerant" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllRequerant" TypeName="controller.requerant_controller" UpdateMethod="updateRequerant">
        </asp:ObjectDataSource>
        
            <br />
            <asp:ObjectDataSource ID="request" runat="server" DataObjectTypeName="Model.Request" OldValuesParameterFormatString="original_{0}" SelectMethod="getRequestByNum" TypeName="controller.requete_controller" UpdateMethod="updateRequest" DeleteMethod="deleteRequest" InsertMethod="GetCountAttachmentRequest">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Id_Request" Type="Int32" />
                    <asp:Parameter Name="NumWilaya_Request" Type="Int32" />
                    <asp:Parameter Name="Year" Type="Int32" />
                </InsertParameters>
                <SelectParameters>
                    <asp:Parameter Name="Num" Type="Int32" />
                    <asp:Parameter Name="NumWilaya_Request" Type="Int32" />
                    <asp:Parameter Name="Year_Request" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsMotifDispositif" runat="server" DeleteMethod="deleteMotifDispositif" OldValuesParameterFormatString="original_{0}" SelectMethod="getMotifByDispositif" TypeName="controller.MotifDispositif_Controller">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="String" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:Parameter DbType="Guid" Name="num_mission" />
                </SelectParameters>
        </asp:ObjectDataSource>
            <br />
            <asp:ObjectDataSource ID="OdsWilayas" runat="server" DataObjectTypeName="Model.wilayas" DeleteMethod="deleteWilaya" InsertMethod="insertWilaya" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllWilaya" TypeName="controller.wilaya_controller" UpdateMethod="updateWilaya">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsDispositif" runat="server" DeleteMethod="deleteDispositif" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllDispositif" TypeName="controller.dispositif_controller" DataObjectTypeName="Model.Mission" InsertMethod="insertDispositif">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="String" />
                </DeleteParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsModeTransmission" runat="server" DataObjectTypeName="Model.Transmission" DeleteMethod="deleteModeTransmission" InsertMethod="insertModeTransmission" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllModeTransmission" TypeName="controller.ModeTranmission_Controller" UpdateMethod="updateModeTransmission">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="String" />
                </DeleteParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsRequest" runat="server" DataObjectTypeName="Model.Request" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllRequest" TypeName="controller.requete_controller" UpdateMethod="updateRequest" DeleteMethod="deleteRequest" InsertMethod="GetCountAttachmentRequest">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Id_Request" Type="Int32" />
                    <asp:Parameter Name="NumWilaya_Request" Type="Int32" />
                    <asp:Parameter Name="Year" Type="Int32" />
                </InsertParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsStateRequest" runat="server" DeleteMethod="deleteState_Request" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllState_Request" TypeName="controller.StateRequest_Controller" UpdateMethod="updateState_Request">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        
    <asp:ObjectDataSource ID="OdsType" runat="server" DataObjectTypeName="Model.types" InsertMethod="insertType" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllType" TypeName="controller.Type_Controller" UpdateMethod="updateType" DeleteMethod="deleteType">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="String" />
        </DeleteParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsVoieTransmission" runat="server" DataObjectTypeName="Model.Voie_Transmission" DeleteMethod="deleteVoieModeTransmission" InsertMethod="insertVoieModeTransmission" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllVoieModeTransmission" TypeName="controller.VoieTrans_Controller" UpdateMethod="updateVoieModeTransmission">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="String" />
        </DeleteParameters>
        </asp:ObjectDataSource>
    

<br />
    </asp:Content>
