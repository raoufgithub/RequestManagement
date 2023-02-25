<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="GridViewModal.aspx.cs" Inherits="view.GridViewModal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript" src="bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />


    <%--<link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.standalone.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.standalone.min.css" rel="stylesheet" />--%>
    <%--</div>--%>
    
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.css" rel="stylesheet" />


    <style type="text/css">
        .ComponentLeft {}
    </style>



    <script type = "text/javascript">
        function ConfirmDelRequiring() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";

            if (confirm("Etes vous sûr de vouloir supprimer le Requerant?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
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

    &nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;



    <asp:Label ID="Label5" runat="server" Text="Cette page permet d'Ajouter, Supprimer ou Modifier des Requerants :" Font-Size="X-Large"></asp:Label>


    <br />
    <br />


    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr runat="server">
                    <td class="auto-style2">
                        <strong>Nombre de Requerants trouvés :&nbsp;&nbsp;
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
                            <asp:ListItem Selected="True">5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <strong> de Page : </strong>
                    </td>
                    <td>
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">

                    </td>
                </tr>
                <tr>
                    <td colspan="11">
                    <%--<div id="Div3" runat="server" style="overflow-x:auto;width:960px;overflow-y:auto; height:350px" visible="true">--%>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                    <ContentTemplate>                 
                    
                        
                        <asp:GridView ID="grid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="num" DataSourceID="OdsRequerant" GridLines="Vertical" OnPageIndexChanging="Grid1_PageIndexChanging" ShowFooter="True" ShowHeaderWhenEmpty="True" PageSize="6" ForeColor="Black" OnRowCancelingEdit="Grid1_RowCancelingEdit" OnRowEditing="Grid1_RowEditing" OnRowUpdating="grid1_RowUpdating" OnRowDeleting="Grid1_RowDeleting">

                                                        <AlternatingRowStyle BackColor="White" />
                                                        <Columns>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <EditItemTemplate>
                                                                    <asp:LinkButton ID="LinkButtonUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                                    &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="ConfirmDelRequiring()"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select" Visible='<%# IsGridEmpty(Eval("num").ToString()) %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField  SortExpression="num">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="Label30" runat="server" Text='<%# Bind("num") %>'  Visible="false"></asp:Label>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:LinkButton ID="LinkButton25" runat="server" OnClick="LinkButton225_Click11">ajouter</asp:LinkButton>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("num") %>' Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nom Requerant" SortExpression="nom_requerant">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nom_requerant") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox30" runat="server" CssClass="FooterGrid" Height="25px" OnTextChanged="NomRequerant_Click" AutoPostBack="True" Width="100px"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("nom_requerant") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Prenom Requerant" SortExpression="prenom_requerant">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("prenom_requerant") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox31" runat="server" CssClass="FooterGrid" Height="25px" OnTextChanged="PrenomRequerant_Click" AutoPostBack="True" Width="100px"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("prenom_requerant") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="WILAYA" SortExpression="WILAYA">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObDSWilaya" DataTextField="wilaya" DataValueField="num" SelectedValue='<%# Bind("id_wilaya") %>'>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="OdsWilaya" DataTextField="wilaya" DataValueField="num" CssClass="FooterGrid" Height="25px" OnSelectedIndexChanged="Wilaya_Click" Visible='<%# isDGCell() %>' AutoPostBack="True" Width="100px">
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="LabelWilayaPro" runat="server" Height="25px"  Visible='<%# !isDGCell() %>' Text='<%# getAgentWilaya() %>' Width="113px" CssClass="ComponentLeft"></asp:Label>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("WilayaRequerantC") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SEXE" SortExpression="SEXE">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("SEXE") %>'>
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem Text="Homme" Value="Homme"></asp:ListItem>
                                                                        <asp:ListItem Text="Femme" Value="Femme"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    
                                                                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="FooterGrid" Height="25px" OnSelectedIndexChanged="Sexe_Click" AutoPostBack="True">
                                                                        <asp:ListItem Value="0" Text=" "></asp:ListItem>
                                                                        <asp:ListItem>Homme</asp:ListItem>
                                                                        <asp:ListItem>Femme</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                         
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("SEXE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date Naissance" SortExpression="Date_Naissance">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox15" CssClass="datepicker" runat="server" Text='<%#  Bind("Date_Naissance", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox43" CssClass="datepicker" runat="server" Height="25px" OnTextChanged="Birthday_Click" AutoPostBack="True" Width="100px"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("Date_Naissance", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nom C.Animateur">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox54" runat="server"  Text='<%# Bind("Nom_CAnimateur") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox52" runat="server" Height="25px" Width="100px" AutoPostBack="True" CssClass="FooterGrid" OnTextChanged="TextBox_NomCAnim_TextChanged"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label33" runat="server" Text='<%# Bind("Nom_CAnimateur") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Prenom C.Animateur">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox55" runat="server" Text='<%# Bind("Prenom_CAnimateur") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox53" runat="server" Height="25px" Width="100px" AutoPostBack="True" CssClass="FooterGrid" OnTextChanged="TextBox_PrenomCAnim_TextChanged"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label34" runat="server" Text='<%# Bind("Prenom_CAnimateur") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Num Dossier" SortExpression="Num_Dossier">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBoxNum_Dossier" runat="server" Text='<%# Bind("Num_Dossier") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBoxNum_Dossier" runat="server" CssClass="FooterGrid" Height="25px" Width="100px"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LabelNum_Dossier" runat="server" Text='<%# Bind("Num_Dossier") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Adresse" SortExpression="Adresse">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Adresse") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox49" runat="server" CssClass="FooterGrid" Height="25px" Width="100px"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Adresse") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="E-mail">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox56" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox50" runat="server" CssClass="FooterGrid" Height="25px" Width="100px"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label31" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tel">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox57" runat="server" Text='<%# Bind("Tel") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox51" runat="server" CssClass="FooterGrid" Height="25px" Width="100px"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label32" runat="server" Text='<%# Bind("Tel") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#CCCC99" />
                                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
                                                        <RowStyle BackColor="#F7F7DE" />
                                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                        <SortedAscendingHeaderStyle BackColor="#848384" />
                                                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                        <SortedDescendingHeaderStyle BackColor="#575357" />
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
           </table>     
        
    </ContentTemplate>
    </asp:UpdatePanel>


    <asp:ObjectDataSource ID="OdsRequerant" runat="server" DataObjectTypeName="Model.requerant" DeleteMethod="deleteRequerant" InsertMethod="insertRequerant" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllRequerant" TypeName="controller.requerant_controller" UpdateMethod="updateRequerant">
                <DeleteParameters>
                    <asp:Parameter Name="num" Type="String" />
                </DeleteParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObDSWilaya" runat="server" DataObjectTypeName="Model.wilayas" DeleteMethod="deleteWilaya" InsertMethod="insertWilaya" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllWilaya" TypeName="controller.wilaya_controller" UpdateMethod="updateWilaya">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>
