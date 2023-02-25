<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="view.Referentielles.Role" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Referentials.css" rel="stylesheet" />
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Voulez vous vraiment supprimer ce Rôle?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="center-div">
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label31" runat="server" Font-Size="Large" Text="Cette page vous permet de créer un nouveau Rôle"></asp:Label>
    <br designer:mapid="15f4" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="Label32" runat="server" CssClass="LabelCss" Height="25px" Text=" Intitulé du Rôle" Width="200px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:TextBox ID="TextBox4" runat="server" Width="200px" CssClass="ComponentLeft" Height="25px"></asp:TextBox>
&nbsp;&nbsp;
&nbsp;
    <br />
    <br />
    <br />
    <div class="DivPermissions">
        <asp:CheckBoxList ID="RoleCheckBoxs" runat="server" Width="978px" RepeatColumns="3">
            <asp:ListItem>Dashboard</asp:ListItem>
            <asp:ListItem>Role_Management</asp:ListItem>
            <asp:ListItem>Statistics</asp:ListItem>
            <asp:ListItem>Request_Management</asp:ListItem>
            <asp:ListItem>referentials</asp:ListItem>
        </asp:CheckBoxList>
    </div>
        
        <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ajouter" CssClass="ButtonCss" />
    <br />
    <br />
        <div class="grid-div">
             <asp:UpdatePanel ID="ModalPanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="OdsRole" ForeColor="#333333" GridLines="None" Width="764px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supprimer">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton27" runat="server" OnClick="LinkButton_Delete" OnClientClick="Confirm()">Supprimer</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Id" SortExpression="Id">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

        </div>
<asp:ObjectDataSource ID="OdsRole" runat="server" DataObjectTypeName="Model.AspNetRoles" DeleteMethod="deleteRole" InsertMethod="insertRole" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllRole" TypeName="controller.role_controller" UpdateMethod="updateRole">
    <DeleteParameters>
        <asp:Parameter Name="guid" Type="String" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="guid" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>


</div>
</asp:Content>
