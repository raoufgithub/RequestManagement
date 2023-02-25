<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="ListViewTrace.aspx.cs" Inherits="view.Trace.ListViewTrace" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label33" runat="server" Text="Les interventions sur la Requête numéro :"></asp:Label>
&nbsp;<asp:Label ID="Label1" runat="server" Text='<%# Session["NumWilaya_Request_Trace"] %>' Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099"></asp:Label><asp:Label ID="Label2" runat="server" Text="-" Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099"></asp:Label><asp:Label ID="Label81" runat="server" Text='<%# Session["Year_Request_Trace"] %>' Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099"></asp:Label><asp:Label ID="Label3" runat="server" Text="-" Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099"></asp:Label><asp:Label ID="LabelIdReclam" runat="server" Text='<%# Session["Id_Request_Trace"] %>' Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099" Height="25px" Width="200px"></asp:Label>
&nbsp;<asp:ListView ID="ListView1" runat="server" DataSourceID="OdsUserActionRequest">
            <AlternatingItemTemplate>
                <li style="background-color: #FFF8DC;">
                    
                    Nom Utilisateur:
                    <asp:Label ID="id_userLabel" runat="server" Text='<%# getUserName(Eval("id_user").ToString()) %>' />
                    <br />
                    Date Action:
                    <asp:Label ID="date_actionLabel" runat="server" Text='<%# Eval("date_action") %>' />
                    <br />
                    Action:
                    <asp:Label ID="actionLabel" runat="server" Text='<%# Eval("action") %>' />
                    
                </li>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <li style="background-color: #008A8C; color: #FFFFFF;">
                    
                    Nom Utilisateur:
                    <asp:TextBox ID="id_userTextBox" runat="server" Text='<%# Bind("id_user") %>' />
                    <br />
                    Date Action:
                    <asp:TextBox ID="date_actionTextBox" runat="server" Text='<%# Bind("date_action") %>' />
                    <br />
                    Action:
                    <asp:TextBox ID="actionTextBox" runat="server" Text='<%# Bind("action") %>' />
                    <br />
                    
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </li>
            </EditItemTemplate>
            <EmptyDataTemplate>
                No data was returned.
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <li style="">
                    
                    <br />Nom Utilisateur:
                    <asp:TextBox ID="id_userTextBox" runat="server" Text='<%# Bind("id_user") %>' />
                    <br />
                    Date Action:
                    <asp:TextBox ID="date_actionTextBox" runat="server" Text='<%# Bind("date_action") %>' />
                    <br />
                    Action:
                    <asp:TextBox ID="actionTextBox" runat="server" Text='<%# Bind("action") %>' />
                    
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </li>
            </InsertItemTemplate>
            <ItemSeparatorTemplate>
<br />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <li style="background-color: #DCDCDC; color: #000000;">
                    
                    Nom Utilisateur:
                    <asp:Label ID="id_userLabel" runat="server" Text='<%# getUserName(Eval("id_user").ToString()) %>' />
                    <br />
                    Date Action:
                    <asp:Label ID="date_actionLabel" runat="server" Text='<%# Eval("date_action") %>' />
                    <br />
                    Action:
                    <asp:Label ID="actionLabel" runat="server" Text='<%# Eval("action") %>' />
                    
                </li>
            </ItemTemplate>
            <LayoutTemplate>
                <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
                <div style="text-align: center;background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                </div>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <li style="background-color: #008A8C; font-weight: bold;color: #FFFFFF;">
                    
                    Nom Utilisateur:
                    <asp:Label ID="id_userLabel" runat="server" Text='<%# getUserName(Eval("id_user").ToString()) %>' />
                    <br />
                    Date Action:
                    <asp:Label ID="date_actionLabel" runat="server" Text='<%# Eval("date_action") %>' />
                    <br />
                    Action:
                    <asp:Label ID="actionLabel" runat="server" Text='<%# Eval("action") %>' />
                    <br />
                    
                </li>
            </SelectedItemTemplate>
        </asp:ListView>
        <br />
    </p>
    <p>
        <asp:ObjectDataSource ID="OdsUserActionRequest" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getRequestActionsByNum" TypeName="controller.Action_User_Request">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="Num_Request" SessionField="Id_Request_Trace" Type="Int32" />
                <asp:SessionParameter Name="NumWilaya_Request" SessionField="NumWilaya_Request_Trace" Type="Int32" />
                <asp:SessionParameter Name="Year_Request" SessionField="Year_Request_Trace" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>
