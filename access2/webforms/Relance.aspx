<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Relance.aspx.cs" Inherits="view.webforms.Relance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <%--<link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.standalone.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.standalone.min.css" rel="stylesheet" />--%>
    
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.css" rel="stylesheet" />

    <link href="AddRequest.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <script src="../bootstrap-datepicker-1.4.0-dist/js/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript">
             $(document).ready(function () {
                 Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

                 function EndRequestHandler(sender, args) {
                     $('.datepicker').datepicker
                         ({
                             format: 'dd/mm/yyyy',
                             "autoclose": true

                         });
                 }
             });
            </script>
           <script type="text/javascript">
               $(document).ready(function () {
                   $('.datepicker').datepicker({
                       format: 'dd/mm/yyyy',
                       "autoclose": true
                   })
               });

        </script>
    <div id="border" class="center-div"  style="overflow-x:auto;width:1050px;overflow-y:auto; height:1050px">
    <asp:FormView ID="FormView1" runat="server" DataSourceID="OdsRelance" DefaultMode="Insert" Width="1000px">
                                
                                
                                    <EditItemTemplate>
                                        TransmissionRelanceC:
                                        <asp:TextBox ID="TransmissionRelanceCTextBox" runat="server" Text='<%# Bind("TransmissionRelanceC") %>' />
                                        <br />
                                        id_relances:
                                        <asp:TextBox ID="id_relancesTextBox" runat="server" Text='<%# Bind("id_relances") %>' />
                                        <br />
                                        id_requete:
                                        <asp:TextBox ID="id_requeteTextBox" runat="server" Text='<%# Bind("id_requete") %>' />
                                        <br />
                                        id_transmission:
                                        <asp:TextBox ID="id_transmissionTextBox" runat="server" Text='<%# Bind("id_transmission") %>' />
                                        <br />
                                        date_relance:
                                        <asp:TextBox ID="date_relanceTextBox" runat="server" Text='<%# Bind("date_relance") %>' />
                                        <br />
                                        Description_relance:
                                        <asp:TextBox ID="Description_relanceTextBox" runat="server" Text='<%# Bind("Description_relance") %>' />
                                        <br />
                                        reclamation:
                                        <asp:TextBox ID="reclamationTextBox" runat="server" Text='<%# Bind("reclamation") %>' />
                                        <br />
                                        Transmission:
                                        <asp:TextBox ID="TransmissionTextBox" runat="server" Text='<%# Bind("Transmission") %>' />
                                        <br />
                                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="Label32" runat="server" Text="Gestion des Relances pour la Reclamation&nbsp;N° :" Font-Size="X-Large"></asp:Label>
                                        &nbsp;<asp:Label ID="Label1" runat="server" Text='<%# Session["NumWilaya_Request_Relance"] %>' Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099"></asp:Label><asp:Label ID="Label2" runat="server" Text="-" Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099"></asp:Label><asp:Label ID="Label81" runat="server" Text='<%# Session["Year_Request_Relance"] %>' Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099"></asp:Label><asp:Label ID="Label3" runat="server" Text="-" Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099"></asp:Label><asp:Label ID="LabelIdReclam" runat="server" Text='<%# Session["Id_Request_Relance"] %>' Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099" Height="25px" Width="200px"></asp:Label>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label35" runat="server" CssClass="LabelCss" Height="25px" Text="Numero du Requerant" Width="200px"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label36" runat="server" CssClass="ComponentLeft" Height="25px" Text="<%# getNomRequerant() %>" Width="200px"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label37" runat="server" CssClass="LabelCss" Height="25px" Text="Prenom du Requerant" Width="200px"></asp:Label>
                                        &nbsp; &nbsp;
                                        <asp:Label ID="Label38" runat="server" CssClass="ComponentLeft" Height="25px" Text="<%# getPrenomRequerant() %>" Width="200px"></asp:Label>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label31" runat="server" CssClass="LabelCss" Height="25px" Text="Mode de Transmission" Width="200px"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:DropDownList ID="DropDownListIdTrans" runat="server" DataSourceID="OdsTransmission" DataTextField="mode_trans" DataValueField="id_trans" Height="25px" Width="200px" CssClass="ComponentLeft">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label33" runat="server" CssClass="LabelCss" Height="25px" Text="Date de la Relance:" Width="200px"></asp:Label>
                                        &nbsp;&nbsp;&nbsp; <asp:TextBox ID="date_relanceTextBox" runat="server" CssClass="datepicker" Height="25px" Text='<%# Bind("date_relance") %>' Width="200px" />
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                        <asp:Label ID="Label34" runat="server" CssClass="LabelCss" Height="25px" Text="Description de la Relance: " Width="200px"></asp:Label>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="Description_relanceTextBox" runat="server" Text='<%# Bind("Description_relance") %>' Height="281px" Width="926px" TextMode="MultiLine" CssClass="ComponentDescription" />
                                        <br />
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="AJOUTER RELANCE" OnClick="InsertButton_Click" CssClass="LabelCss" Height="25px" Width="200px" Font-Size="Large" />
                                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="ANNULER" CssClass="LabelCss" Height="25px" Width="200px" Font-Size="Large" />
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        TransmissionRelanceC:
                                        <asp:Label ID="TransmissionRelanceCLabel" runat="server" Text='<%# Bind("TransmissionRelanceC") %>' />
                                        <br />
                                        id_relances:
                                        <asp:Label ID="id_relancesLabel" runat="server" Text='<%# Bind("id_relances") %>' />
                                        <br />
                                        id_requete:
                                        <asp:Label ID="id_requeteLabel" runat="server" Text='<%# Bind("id_requete") %>' />
                                        <br />
                                        id_transmission:
                                        <asp:Label ID="id_transmissionLabel" runat="server" Text='<%# Bind("id_transmission") %>' />
                                        <br />
                                        date_relance:
                                        <asp:Label ID="date_relanceLabel" runat="server" Text='<%# Bind("date_relance") %>' />
                                        <br />
                                        Description_relance:
                                        <asp:Label ID="Description_relanceLabel" runat="server" Text='<%# Bind("Description_relance") %>' />
                                        <br />
                                        reclamation:
                                        <asp:Label ID="reclamationLabel" runat="server" Text='<%# Bind("reclamation") %>' />
                                        <br />
                                        Transmission:
                                        <asp:Label ID="TransmissionLabel" runat="server" Text='<%# Bind("Transmission") %>' />
                                        <br />
                                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                                        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                                    </ItemTemplate>
                                
                                
                                </asp:FormView>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="DivCssRelance">
            <asp:Label ID="Label7" runat="server" Text="Le nombre de Relance de la Requête : " CssClass="LabelCss" Font-Size="Medium"></asp:Label><asp:Label ID="Label8" runat="server" CssClass="LabelCss"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" DataSourceID="OdsRelance" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1000px">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:TemplateField ShowHeader="False" HeaderText="Détail">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" OnClick="LinkButton1_Click" Text="Select"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="id_relances">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id_relances") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("id_relances") %>' Visible="False"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Requête" SortExpression="id_requete">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("id_requete") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("NumWilaya_Request") %>'></asp:Label>
                                                                <asp:Label ID="Label10" runat="server" Text="-"></asp:Label>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Year_Request") %>'></asp:Label>
                                                                <asp:Label ID="Label11" runat="server" Text="-"></asp:Label>
                                                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("id_requete") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="MODE DE TRANSMISSION" SortExpression="id_transmission">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("id_transmission") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("TransmissionRelanceC") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DATE" SortExpression="date_relance">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("date_relance") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("date_relance", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle BackColor="#999999" />
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
                                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                            </asp:GridView>
    <br />
    <div id="Details" runat="server">
        <asp:Label ID="Label5" runat="server" Text="Détails de la Relance : " CssClass="LabelCss" Font-Size="Large" Height="25px" Width="260px"></asp:Label><%--<asp:Label ID="Label6" runat="server" Text=""></asp:Label>--%>

    <asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="OdsRelanceDetail" Height="250px" Width="1000px" AutoGenerateRows="False" BackColor="White" BorderColor="#999999" BorderWidth="1px" CellPadding="3" GridLines="Vertical" BorderStyle="None">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <EditRowStyle BackColor="#008A8C" ForeColor="White" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="TransmissionRelanceC" HeaderText="Mode de Transmission" ReadOnly="True" SortExpression="TransmissionRelanceC" />
            <asp:BoundField DataField="date_relance" HeaderText="Date de la Relance" SortExpression="date_relance" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Description_relance" HeaderText="Descriptionde la Relance" SortExpression="Description_relance" />
        </Fields>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
    </asp:DetailsView>
    </div>
                </div>
    </ContentTemplate>
            </asp:UpdatePanel>
    

    <asp:ObjectDataSource ID="OdsRelanceDetail" runat="server" DataObjectTypeName="Model.relance" DeleteMethod="deleteRelance" InsertMethod="insertRelance" SelectMethod="getRelanceByKey" TypeName="controller.Relance_Controller" UpdateMethod="updateRelance" OldValuesParameterFormatString="original_{0}">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="id_relance" SessionField="id_relance" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>


    <asp:ObjectDataSource ID="OdsRelance" runat="server" DeleteMethod="deleteRelance" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllRelances" TypeName="controller.Relance_Controller" UpdateMethod="updateRelance">
                                    <DeleteParameters>
                                        <asp:Parameter Name="guid" Type="Int32" />
                                    </DeleteParameters>
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="" Name="id_Request" SessionField="Id_Request_Relance" Type="Int32" />
                                        <asp:SessionParameter DefaultValue="" Name="NumWilaya_Request" SessionField="NumWilaya_Request_Relance" Type="Int32" />
                                        <asp:SessionParameter DefaultValue="" Name="Year_Request" SessionField="Year_Request_Relance" Type="Int32" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="guid" Type="Int32" />
                                    </UpdateParameters>
                                </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="OdsRequerant" runat="server" DataObjectTypeName="Model.requerant" DeleteMethod="deleteRequerant" InsertMethod="insertRequerant" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllRequerant" TypeName="controller.requerant_controller" UpdateMethod="updateRequerant">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
        </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="OdsTransmission" runat="server" DataObjectTypeName="Model.Transmission" DeleteMethod="deleteModeTransmission" InsertMethod="insertModeTransmission" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllModeTransmission" TypeName="controller.ModeTranmission_Controller" UpdateMethod="updateModeTransmission">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>


        </div>





    
</asp:Content>
