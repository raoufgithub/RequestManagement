<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Dispositif.aspx.cs" Inherits="view.Referentielles.Dispositif" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../webforms/AddRequest.css" rel="stylesheet" />

        <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Etes vous sûr de supprimer cette Mission ?")) {
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
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label31" runat="server" Font-Size="Large" Text="Cette page vous permet de créer une nouvelle Mission de la CNAC"></asp:Label>
    <br __designer:mapid="15f4" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label32" runat="server" CssClass="LabelCss" Text="Mission" Height="25px" Width="200px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="200px" CssClass="ComponentLeft" Height="25px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ajouter" CssClass="ButtonCss" />
    <br />
    <br />
    <div class="DivCssRelance">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="OdsDispositif" GridLines="Vertical" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="734px">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Modifier"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Mettre à jour"></asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="LinkButton27" runat="server" OnClick="Delete_Dispo" OnClientClick="Confirm()">Supprimer</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField HeaderText="Mission" SortExpression="mission1">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("mission1") %>'></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("num") %>' Visible="False"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("mission1") %>'></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("num") %>' Visible="False"></asp:Label>
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
    <asp:ObjectDataSource ID="OdsDispositif" runat="server" DataObjectTypeName="Model.Mission" DeleteMethod="deleteDispositif" InsertMethod="insertDispositif" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllDispositifFooter" TypeName="controller.dispositif_controller" UpdateMethod="updateDispositif">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="String" />
        </DeleteParameters>
    </asp:ObjectDataSource>
        </div>
        </div>
</asp:Content>
