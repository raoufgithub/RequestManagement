<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="FindAgent.aspx.cs" Inherits="view.Messaging.FindAgent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Messaging.css" rel="stylesheet" />


    <%--<link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.standalone.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.standalone.min.css" rel="stylesheet" />--%>
    
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.css" rel="stylesheet" />

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


    
    <asp:Label ID="Label32" runat="server" Text="Agent ACCES" Font-Size="Large"></asp:Label>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label37" runat="server" CssClass="LabelCss" Height="25px" Text="Nom d'utilisateur" Width="200px"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox_UserName" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px" AutoPostBack="True" OnTextChanged="Username_Onclick"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label36" runat="server" Text="wilaya" CssClass="LabelCss" Height="25px" Width="200px"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList_Structure" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px" DataSourceID="OdsStructure" DataTextField="IntituleFr" DataValueField="StructureId" AutoPostBack="True" OnSelectedIndexChanged="Wilaya_OnClick">
    </asp:DropDownList>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label33" runat="server" Text="Nom" CssClass="LabelCss" Height="25px" Width="200px"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox_Name" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px" AutoPostBack="True" OnTextChanged="TextBox_Name_TextChanged"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:Label ID="Label34" runat="server" Text="Prenom" CssClass="LabelCss" Height="25px" Width="200px"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox_FirstName" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px" AutoPostBack="True" OnTextChanged="TextBox_FirstName_TextChanged"></asp:TextBox>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label35" runat="server" Text="Date de naissance" CssClass="LabelCss" Height="25px" Width="200px"></asp:Label>
    &nbsp;
    &nbsp;
    <asp:TextBox ID="TextBox_Birthday" runat="server" CssClass="datepicker" Height="25px" Width="200px" AutoPostBack="True" OnTextChanged="TextBox_Birthday_TextChanged"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:ObjectDataSource ID="OdsStructure" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllStructures" TypeName="controller.StructureBLL" DataObjectTypeName="Model.Structure" >
        
    </asp:ObjectDataSource>
    <br />
    <div class="center-div">


      
       
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
                        <strong>Nombre de lignes par Page : </strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList10" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList10_SelectedIndexChanged">
                            <asp:ListItem Selected="True">5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <strong> <%--de Page :--%> </strong>
                    </td>
                    <td>
                       <%-- <asp:DropDownList ID="DropDownList11" runat="server">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                        </asp:DropDownList>--%>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">

                    </td>
                </tr>
                <tr>
                    <td colspan="11">

    <%--<asp:UpdatePanel ID="ModalPanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>--%>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="OdsAgents" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5" AllowPaging="True">
        <Columns>
            <asp:TemplateField HeaderText="Messaging">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton26" runat="server" CssClass="Picture-Message" Height="40px" Width="45px" OnClick="SendMessage_Onclick"></asp:LinkButton>
                    <asp:Label ID="LabelMessage" runat="server" Text='<%# GetNbreMessages(Eval("id").ToString()) %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UserName" SortExpression="UserName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre de messages Reçus" SortExpression="NombreSentMessages">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NombreSentMessages") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelMessageSent" runat="server" Text='<%# Bind("NombreSentMessages") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre de Messages Envoyés" SortExpression="NombreReceivedMessages">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NombreReceivedMessages") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelMessageReceived" runat="server" Text='<%# Bind("NombreReceivedMessages") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="structure" SortExpression="structure">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("structure") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelStructure" runat="server" Text='<%# Bind("structure") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PhoneNumber" SortExpression="PhoneNumber">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    
    <%--</ContentTemplate>
        </asp:UpdatePanel>    --%>                    
   
                        
                        
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
            
        
        
        
               
        
        
       
        
        
        
               
        
        
           </table     
        </ContentTemplate>
        </asp:UpdatePanel>           
   
                        
                        
   </div>                        
    <br />
    <br />
    <asp:ObjectDataSource ID="OdsAgents1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllUsers" TypeName="controller.Users_Controller"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsAgents" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllUsersOfUser" TypeName="controller.Users_Controller" DataObjectTypeName="Model.AspNetUsers" DeleteMethod="deleteUser" UpdateMethod="updateUser">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32"></asp:Parameter>
        </DeleteParameters>
    </asp:ObjectDataSource>
    <br />
    </asp:Content>
