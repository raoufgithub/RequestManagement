<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="VoieTransmission.aspx.cs" Inherits="view.Referentielles.VoieTransmission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../webforms/AddRequest.css" rel="stylesheet" />

    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Etes vous sûr de supprimer cet Emetteur de Requête?")) {
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
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label32" runat="server" Text="Cette page vous permet de créer une nouveau Emetteur de Requête :" Font-Size="Large"></asp:Label>
    <br designer:mapid="15f4" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp; &nbsp;&nbsp; &nbsp;
    <asp:Label ID="Label33" runat="server" CssClass="LabelCss" Height="25px" Text="Emetteur&nbsp; :" Width="200px"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="200px" CssClass="ComponentLeft" Height="25px"></asp:TextBox>
&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ajouter" CssClass="ButtonCss"/>
    <br />
    <br />
    <div id="dialog"  runat="server" visible="true" class="DivCssRelance">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="OdsVoieTransmission" GridLines="Vertical" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="734px">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:TemplateField HeaderText="Modifier" ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Modifier"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Modifier"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton27" runat="server" OnClick="Delete_LinkButton" OnClientClick="Confirm()">Supprimer</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="voie_trans" SortExpression="voie_trans">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("voie_trans") %>'></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("id_voie") %>' Visible="false"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("id_voie") %>' Visible="false"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("voie_trans") %>'></asp:Label>
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
    </div>
    <asp:ObjectDataSource ID="OdsVoieTransmission" runat="server" DataObjectTypeName="Model.Voie_Transmission" DeleteMethod="deleteVoieModeTransmission" InsertMethod="insertVoieModeTransmission" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllVoieModeTransmissionFooter" TypeName="controller.VoieTrans_Controller" UpdateMethod="updateVoieModeTransmission">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="String" />
        </DeleteParameters>
    </asp:ObjectDataSource>
        </div>
</asp:Content>
