<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testwithoutmasterpage.aspx.cs" Inherits="view.webforms.testwithoutmasterpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
            <Columns>
                <asp:BoundField DataField="num" HeaderText="num" SortExpression="num" />
                <asp:BoundField DataField="dispositif1" HeaderText="dispositif1" SortExpression="dispositif1" />
            </Columns>

        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="Model.dispositif" DeleteMethod="deleteDispositif" InsertMethod="insertDispositif" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllDispositif" TypeName="controller.dispositif_controller" UpdateMethod="updateDispositif">
            <DeleteParameters>
                <asp:Parameter Name="guid" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="guid" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Model.requerant" DeleteMethod="deleteRequerant" InsertMethod="insertRequerant" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllRequerant" TypeName="controller.requerant_controller" UpdateMethod="updateRequerant">
            <DeleteParameters>
                <asp:Parameter Name="guid" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="guid" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
