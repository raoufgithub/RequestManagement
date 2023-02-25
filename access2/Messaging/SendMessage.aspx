<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="view.Messaging.SendMessage" %>

<%-- to retrieve the RegisterTrigger --%>
<%@ MasterType VirtualPath="~/MasterPages/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Messaging.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="center-div">
    <asp:Label ID="Label32" runat="server" Font-Size="Large" Text="Cette Page permet de communiquer avec tous les Agents des Wilayas"></asp:Label>
    <br />
        <br />
        <asp:Label ID="Label35" runat="server" CssClass="LabelCss" Height="25px" Text="Trouver l'Agent " Width="200px"></asp:Label>
        &nbsp;
        <asp:Label ID="Label_UserName" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label38" runat="server" CssClass="LabelCss" Height="25px" Text="Structure" Width="200px"></asp:Label>
&nbsp;
        <asp:Label ID="Label_Structure" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px"></asp:Label>
        <br />
    <br />
    <asp:Label ID="Label33" runat="server" Text="Nom de l'Agent" CssClass="LabelCss" Height="25px" Width="200px"></asp:Label>
    &nbsp;
        <asp:Label ID="Label_AgentName" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label34" runat="server" CssClass="LabelCss" Height="25px" Text="Prenom de l'Agent" Width="200px"></asp:Label>
&nbsp;
        <asp:Label ID="Label_AgentFirstName" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px"></asp:Label>
    <br />
    <br />


    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="LabelCss" Width="400px" />
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Selected="True" Value="1">ListView</asp:ListItem>
            <asp:ListItem Value="2">GridView</asp:ListItem>
        </asp:RadioButtonList>
    <br />
    <asp:Label ID="Label31" runat="server"></asp:Label>

        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="DIV_ListView_Message" runat="server" style="overflow-x:auto;width:850px;overflow-y:auto; height:300px" visible="true">
            <asp:ListView ID="ListView1" runat="server" DataSourceID="OdsMessages">
                <AlternatingItemTemplate>
                    <li style="background-color: #FFF8DC;">
                        Message:
                        <asp:Label ID="MessageLabel" runat="server" Text='<%# Eval("Message") %>' />
                        <br />
                        Envoyé par
                        <asp:Label ID="userLabel" runat="server" Text='<%# Eval("UserNameSendingC") %>' />
                        <br />
                        State_Message:
                        <asp:Label ID="State_MessageLabel" runat="server" Text='<%# Eval("State_Message") %>' />
                        <br />
                        Pièce Jointe:
                        <asp:LinkButton ID="LinkButton26" runat="server" Text='<%# Bind("link") %>'  OnClick="LinkButton26_Click"></asp:LinkButton>
                        <br />
                        Id_User_Destination:
                        <asp:Label ID="User_DestinationLabel" runat="server" Text='<%# Eval("UserNameReceivingC") %>' />
                        <br />
                        Date Message:
                        <asp:Label ID="Date_MessageLabel" runat="server" Text='<%# Eval("Date_Message") %>' />
                       
                        <br />
                    </li>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <li style="background-color: #008A8C;color: #FFFFFF;">
                        Message:
                        <asp:TextBox ID="MessageTextBox" runat="server" Text='<%# Bind("Message") %>' />
                        <br />
                        Envoyé par
                        <asp:TextBox ID="id_userTextBox" runat="server" Text='<%# Bind("UserNameSendingC") %>' />
                        <br />
                        State_Message:
                        <asp:TextBox ID="State_MessageTextBox" runat="server" Text='<%# Bind("State_Message") %>' />
                        <br />
                        Pièce Jointe:
                        <asp:TextBox ID="linkTextBox" runat="server" Text='<%# Bind("link") %>' />
                        <br />
                        Id_User_Destination:
                        <asp:TextBox ID="Id_User_DestinationTextBox" runat="server" Text='<%# Bind("UserNameReceivingC") %>' />
                        <br />
                        Date Message:
                        <asp:TextBox ID="Date_MessageTextBox" runat="server" Text='<%# Bind("Date_Message") %>' />
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
                        Message:
                        <asp:TextBox ID="MessageTextBox" runat="server" Text='<%# Bind("Message") %>' />
                        <br />
                        Envoyé par
                        <asp:TextBox ID="id_userTextBox" runat="server" Text='<%# Bind("UserNameSendingC") %>' />
                        <br />
                        State_Message:
                        <asp:TextBox ID="State_MessageTextBox" runat="server" Text='<%# Bind("State_Message") %>' />
                        <br />
                        link:
                        <asp:TextBox ID="linkTextBox" runat="server" Text='<%# Bind("link") %>' />
                        <br />
                        Id_User_Destination:
                        <asp:TextBox ID="Id_User_DestinationTextBox" runat="server" Text='<%# Bind("UserNameReceivingC") %>' />
                        <br />
                        Date Message:
                        <asp:TextBox ID="Date_MessageTextBox" runat="server" Text='<%# Bind("Date_Message") %>' />
                        <br />
                       
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </li>
                </InsertItemTemplate>
                <ItemSeparatorTemplate>
                    <br />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <li style="background-color: #DCDCDC;color: #000000;">
                        Message:
                        <asp:Label ID="MessageLabel" runat="server" Text='<%# Eval("Message") %>' />
                        <br />
                        Envoyé par
                        <asp:Label ID="userLabel" runat="server" Text='<%# Eval("UserNameSendingC") %>' />
                        <br />
                        State_Message:
                        <asp:Label ID="State_MessageLabel" runat="server" Text='<%# Eval("State_Message") %>' />
                        <br />
                        Pièce Jointe:
                        <asp:LinkButton ID="LinkButton26" runat="server" Text='<%# Bind("link") %>'  OnClick="LinkButton26_Click"></asp:LinkButton>
                        <br />
                        Id_User_Destination:
                        <asp:Label ID="User_DestinationLabel" runat="server" Text='<%# Eval("UserNameReceivingC") %>' />
                        <br />
                        Date Message:
                        <asp:Label ID="Date_MessageLabel" runat="server" Text='<%# Eval("Date_Message") %>' />
                        <br />
                        
                        <br />
                    </li>
                </ItemTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                    <div style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    </div>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <li style="background-color: #008A8C;font-weight: bold;color: #FFFFFF;">                        
                        Message:
                        <asp:Label ID="MessageLabel" runat="server" Text='<%# Eval("Message") %>' />
                        <br />
                        Envoyé par:
                        <asp:Label ID="userLabel" runat="server" Text='<%# Eval("UserNameSendingC") %>' />
                        <br />
                        State_Message:
                        <asp:Label ID="State_MessageLabel" runat="server" Text='<%# Eval("State_Message") %>' />
                        <br />
                        Pièce Jointe:
                        <asp:LinkButton ID="LinkButton26" runat="server" Text='<%# Eval("link") %>' OnClick="LinkButton26_Click"></asp:LinkButton>
                        <br />
                        Id_User_Destination:
                        <asp:Label ID="User_DestinationLabel" runat="server" Text='<%# Eval("UserNameReceivingC") %>' />
                        <br />
                        Date Message:
                        <asp:Label ID="Date_MessageLabel" runat="server" Text='<%# Eval("Date_Message") %>' />
                        <br />
                       
                    </li>
                </SelectedItemTemplate>
            </asp:ListView>
            </div>
            <div id="DIV_Grid_Messages" runat="server" style="overflow-x:auto;width:auto;max-width:960px;overflow-y:auto; height:auto;max-height:400px" visible="false">
            <asp:GridView ID="GridView1" runat="server" DataSourceID="OdsMessages" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="6">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Détail" OnClick="Grid_MessageDetail"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="envoyé par" SortExpression="id_user">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id_user") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserNameSendingC") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Envoyé à" SortExpression="Id_User_Destination">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Id_User_Destination") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserNameReceivingC") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="State_Message" SortExpression="State_Message">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("State_Message") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("State_Message") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pièce jointe" SortExpression="link">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("link") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton_PieceJointe" runat="server" OnClick="Download_PieceJoint" Text='<%# Eval("link") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Message" SortExpression="Date_Message">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Date_Message") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%--<asp:Label ID="Label5" runat="server" Text='<%# Bind("Date_Message") %>'></asp:Label>--%>
                            <asp:Label ID="Label5" runat="server" Text='<%# ((DateTime)Eval("Date_Message")).ToString("dd/MM/yyyy HH:mm:ss.fff tt") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>




                <asp:DetailsView ID="DetailsView1" runat="server" Height="119px" Width="681px" AutoGenerateRows="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="OdsMessageDetails" GridLines="Horizontal">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <Fields>
                        <asp:TemplateField HeaderText="Envoyé par" SortExpression="id_user">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id_user") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id_user") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserNameSendingC") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Envoyé à" SortExpression="Id_User_Destination">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Id_User_Destination") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Id_User_Destination") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserNameReceivingC") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pièce Jointe" SortExpression="link">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("link") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("link") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("link") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Etat" SortExpression="State_Message">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("State_Message") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("State_Message") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("State_Message") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date du Message" SortExpression="Date_Message">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Date_Message") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Date_Message") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Date_Message") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Message" SortExpression="Message">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Message") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Message") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Message") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Fields>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                </asp:DetailsView>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:ObjectDataSource ID="OdsMessages" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getMessages" TypeName="controller.Messaging_Controller" InsertMethod="InsertMessages">
            <InsertParameters>
                <asp:Parameter Name="IdUser_Sending" Type="String" />
                <asp:Parameter Name="IdUser_Receiving" Type="String" />
                <asp:Parameter Name="link" Type="String" />
                <asp:Parameter Name="message" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="" Name="IdUser_Sending" Type="String" />
                <asp:Parameter Name="IdUser_Receiving" Type="String" DefaultValue="" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="OdsMessageDetails" runat="server" InsertMethod="InsertMessages" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMessageByUserName" TypeName="controller.Messaging_Controller">
            <InsertParameters>
                <asp:Parameter Name="IdUser_Sending" Type="String" />
                <asp:Parameter Name="IdUser_Receiving" Type="String" />
                <asp:Parameter Name="link" Type="String" />
                <asp:Parameter Name="message" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter Name="IdUserName_Sending" Type="String" DefaultValue="" />
                <asp:Parameter Name="IdUserName_Receiving" Type="String" DefaultValue="" />
                <asp:Parameter Name="DateSending" Type="DateTime" DefaultValue="" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:Label ID="Label36" runat="server" Height="25px" Text="Le message :" Width="200px"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox_Message" runat="server" CssClass="ComponentLeft" TextMode="MultiLine" Width="639px" AutoPostBack="True" OnTextChanged="TextBox_Message_TextChanged"></asp:TextBox>




        <br />




        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button_SendMessage" runat="server" CssClass="ButtonCss" Height="25px" OnClick="SendButton_Click" Text="Envoyer" Width="200px" />




        </div>
</asp:Content>
