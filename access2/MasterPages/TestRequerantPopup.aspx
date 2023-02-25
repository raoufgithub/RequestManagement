<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="TestRequerantPopup.aspx.cs" Inherits="view.MasterPages.TestRequerantPopup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../webforms/Test.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">




    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <div id="Div2" runat="server" style="overflow-x:auto;width:960px;overflow-y:auto; height:350px" visible="true">
                        
                    
                        
                        


                                                <asp:GridView ID="grid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="num" DataSourceID="OdsRequerant" GridLines="Vertical" OnPageIndexChanging="GridView1_PageIndexChanging" ShowFooter="True" ShowHeaderWhenEmpty="True" PageSize="6" ForeColor="Black">

                                                        <AlternatingRowStyle BackColor="White" />
                                                        <Columns>
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
                                                                    <asp:TextBox ID="TextBox30" runat="server" CssClass="FooterGrid" Height="25px"></asp:TextBox>
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
                                                                    <asp:TextBox ID="TextBox31" runat="server" CssClass="FooterGrid" Height="25px"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("prenom_requerant") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="WILAYA" SortExpression="WILAYA">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="OdsWilaya" DataTextField="num" DataValueField="wilaya">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="OdsWilaya" DataTextField="wilaya" DataValueField="num" CssClass="FooterGrid" Height="25px">
                                                                    </asp:DropDownList>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("WilayaRequerantC") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SEXE" SortExpression="SEXE">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Homme</asp:ListItem>
                                                                        <asp:ListItem>Femme</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="FooterGrid" Height="25px">
                                                                        <asp:ListItem></asp:ListItem>
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
                                                                    <asp:TextBox ID="TextBox15" CssClass="datepicker" runat="server" Text='<%# Bind("Date_Naissance") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox43" CssClass="datepicker" runat="server" Height="25px"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("Date_Naissance") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Adresse" SortExpression="Adresse">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox49" runat="server" CssClass="FooterGrid" Height="25px"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Adresse") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="E-mail">
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox50" runat="server" CssClass="FooterGrid" Height="25px"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label31" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tel">
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="TextBox51" runat="server" CssClass="FooterGrid" Height="25px"></asp:TextBox>
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
                    </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>



    <asp:ObjectDataSource ID="OdsWilaya" runat="server" DataObjectTypeName="Model.wilayas" DeleteMethod="deleteWilaya" InsertMethod="insertWilaya" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllWilaya" TypeName="controller.wilaya_controller" UpdateMethod="updateWilaya">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
</asp:ObjectDataSource>
</asp:Content>
