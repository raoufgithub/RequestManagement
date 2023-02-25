<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="view.webforms.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="MainContent">
    
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server" />--%>
<div id="test">
    <!--Using Partial Rendering to Update the Customer View -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <b>Customer ID:</b>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblCustomerID" Text="C00001" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Company Name:</b>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblCompanyName" Text="Eastern Connection" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Contact Name:</b>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblContactName" Text="Ann Devon" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Country:</b>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblCountry" Text="Germany" />
                    </td>
                </tr>
            </table>
            

            

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="editBox_OK" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Button runat="server" ID="btnEditText" Text="Edit text" />
    
</div>



            <asp:ObjectDataSource ID="OdsRequerant" runat="server" DataObjectTypeName="Model.requerant" DeleteMethod="deleteRequerant" InsertMethod="insertRequerant" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllRequerant" TypeName="controller.requerant_controller" UpdateMethod="updateRequerant">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>





<div id="dialog">
    <!-- Dialog box:: Edit customer info -->
    <asp:UpdatePanel runat="server" ID="ModalPanel1" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <b>Customer ID:</b>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="editCustomerID" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Company Name:</b>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="editTxtCompanyName" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Contact Name:</b>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="editTxtContactName" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Country:</b>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="editTxtCountry" />
                    </td>
                </tr>
            </table>
            <hr />
            <asp:Button ID="btnApply" runat="server" Text="Apply" OnClick="btnApply_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="editBox_OK" runat="server" Text="OK" OnClick="editBox_OK_Click" />
    <asp:Button ID="editBox_Cancel" runat="server" Text="Cancel" />

    </div>
</asp:Content>



