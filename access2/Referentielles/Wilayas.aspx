<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Wilayas.aspx.cs" Inherits="view.Referentielles.Wilayas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../webforms/AddRequest.css" rel="stylesheet" />

    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Voulez vous vraiment supprimer cette Wilaya?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="border" class="center-div">
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label31" runat="server" Text="Cette page vous permet de créer une nouvelle Wilaya" Font-Size="Large"></asp:Label>
    <br designer:mapid="15f4" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label32" runat="server" CssClass="LabelCss" Height="25px" Text="Numero de Wilaya" Width="200px"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="200px" CssClass="ComponentLeft" Height="25px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label33" runat="server" CssClass="LabelCss" Height="25px" Text="Intitulé de Wilaya" Width="200px"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox4" runat="server" Width="200px" CssClass="ComponentLeft" Height="25px"></asp:TextBox>
&nbsp;&nbsp;
&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ajouter" CssClass="ButtonCss" />
    <br />
    <br />
    <div class="DivCssRelance">
    <asp:UpdatePanel ID="ModalPanel1" runat="server" RenderMode="Inline" UpdateMode="Always">
    <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="OdsWilayas" GridLines="Vertical" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="1000px">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton27" runat="server" OnClick="LinkButton27_Delete" OnClientClick="Confirm()">Supprimer</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField HeaderText="num" SortExpression="num">
                <EditItemTemplate>
                    <asp:Label ID="Label34" runat="server" Text='<%# Bind("num") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("num") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="wilaya" SortExpression="wilaya">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("wilaya") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("wilaya") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
<asp:ObjectDataSource ID="OdsWilayas" runat="server" DataObjectTypeName="Model.wilayas" DeleteMethod="deleteWilaya" InsertMethod="insertWilaya" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllWilaya" TypeName="controller.wilaya_controller" UpdateMethod="updateWilaya">
    <DeleteParameters>
        <asp:Parameter Name="guid" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="guid" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>

        <br />

        </div>

        </div>
</asp:Content>
