<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestLoginPopup.aspx.cs" Inherits="view.Account.TestLoginPopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    



        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModal-label" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModal-label">Modal title</h4>
                </div>
                <div class="modal-body">

                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <div id="Div2" runat="server" style="overflow-x:auto;width:960px;overflow-y:auto; height:350px" visible="true">
                        
                    <%--<asp:GridView ID="grid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="num" DataSourceID="OdsRequerant" GridLines="Horizontal" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleted="GridView1_RowDeleted1" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdated="GridView1_RowUpdated" OnRowUpdating="GridView1_RowUpdating" ShowFooter="True" ShowHeaderWhenEmpty="True">
                                                        <AlternatingRowStyle BackColor="#F7F7F7" />
                                                        <Columns>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <EditItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" OnClick="Grid1_Edit_Button" Text="Update"></asp:LinkButton>
                                                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit" OnClick="LinkButton222_Click" Text="Edit"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClick="LinkButton111_Click111" Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:CommandField HeaderText="Modification" ShowEditButton="True" />
                                                            <asp:CommandField HeaderText="Suppression" ShowDeleteButton="True" />
                                                            <asp:CommandField ShowSelectButton="True" />
                                                            <asp:TemplateField HeaderText="num" SortExpression="num">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="Label30" runat="server" Text='<%# Bind("num") %>'></asp:Label>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:LinkButton ID="LinkButton25" runat="server" OnClick="LinkButton225_Click11">ajouter</asp:LinkButton>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("num") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nom Requerant" SortExpression="nom_requerant">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nom_requerant") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox30" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("nom_requerant") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Prenom Requerant" SortExpression="prenom_requerant">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("prenom_requerant") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox31" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("prenom_requerant") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NOM AGENCE CNAC" SortExpression="NOM_AGENCE_CNAC">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("NOM_AGENCE_CNAC") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox34" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("NOM_AGENCE_CNAC") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NOM COMMUNE" SortExpression="NOM_COMMUNE">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("NOM_COMMUNE") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox35" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("NOM_COMMUNE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="WILAYA" SortExpression="WILAYA">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("WILAYA") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox36" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("WILAYA") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SEXE" SortExpression="LIB_SEXE">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("LIB_SEXE") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox41" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("LIB_SEXE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date Naissance" SortExpression="Date_Naissance">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox15" CssClass="datepicker" runat="server" Text='<%# Bind("Date_Naissance") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox43" CssClass="datepicker" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("Date_Naissance") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Agence Bancaire" SortExpression="agencebancaire">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("agencebancaire") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox47" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label19" runat="server" Text='<%# Bind("agencebancaire") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NUM CPT BANQUE" SortExpression="NUM_CPT_BANC">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("NUM_CPT_BANC") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox48" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label20" runat="server" Text='<%# Bind("NUM_CPT_BANC") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                                                    </asp:GridView>--%>


                        
                    </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Fermer</button>
                    <asp:LinkButton OnClick="LinkButton25_Click11" CssClass="btn btn-success" ID="LinkButton12" runat="server">Selectionner un requerant</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>



    </div>
    </form>
</body>
</html>
