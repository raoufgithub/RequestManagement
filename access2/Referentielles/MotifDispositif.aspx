<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="MotifDispositif.aspx.cs" Inherits="view.Referentielles.MotifDispositif" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../webforms/request.css" rel="stylesheet" />
    
    <script type="text/javascript" src="../bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Voulez vous vraiment supprimer cet Objet de Requête?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div class="row">
                <asp:Label ID="Label31" runat="server" CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 LabelCss" Font-Size="Large" Text="La Création d'un Nouvel Objet de Requête"></asp:Label>
            </div>
            <div class="row">
                 
                    <asp:Label ID="Label33" runat="server" Text="Mission" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss"></asp:Label>
            
                     <asp:DropDownList ID="DropDownList1"  runat="server" DataSourceID="OdsDispositif" DataTextField="mission1" DataValueField="num" CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12 " ID="RequiredFieldMission" ControlToValidate="DropDownList1" InitialValue="00000000-0000-0000-0000-000000000000" ErrorMessage="La Mission est obligatoire"  ForeColor="Red"  runat="server" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                    
                    <asp:Label CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" ID="Label41" runat="server" Text="Phase" ></asp:Label>
                    
                    <asp:DropDownList CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss" ID="DropDownList6" runat="server" DataSourceID="OdsPhaseMission" DataTextField="PhaseName" DataValueField="PhaseId" >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12" ID="RequiredFieldValidator3" ControlToValidate="DropDownList6" InitialValue="00000000-0000-0000-0000-000000000000" ErrorMessage="La Phase est obligatoire"  ForeColor="Red"  runat="server" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                
               </div>
                <div class="row">
                    <asp:Label ID="Label32" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Objet de Requête"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12" ID="RequiredFieldValidator1" ControlToValidate="TextBox1" ForeColor="Red"  runat="server" ErrorMessage="L'Objet est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                    <asp:Button ID="ButtonAdd" runat="server" OnClick="Button1_Click" ValidationGroup="Validation" Text="Ajouter" CssClass="col-lg-3 col-md-3 col-sm-12 col-xs-12 btn-default" />
                    <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="Rechercher" CssClass="col-lg-3 col-md-3 col-sm-12 col-xs-12 btn-default" />
                </div>
                <div class="row">     
                    <asp:ValidationSummary CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="ValidationSummary1" ForeColor="Red" runat="server" ValidationGroup="Validation" />
                </div>
    <div id="border" class="center-div">
    
    
    
    

    
    <asp:ObjectDataSource ID="OdsDispositif" runat="server" DataObjectTypeName="Model.dispositif" DeleteMethod="deleteDispositif" InsertMethod="insertDispositif" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllDispositif" TypeName="controller.dispositif_controller" UpdateMethod="updateDispositif">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="OdsPhaseMission" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getPhaseByMission" TypeName="controller.PhaseObjetBLL">
        <SelectParameters>
            <asp:Parameter DbType="Guid" Name="MissionId"></asp:Parameter>


        </SelectParameters>
    </asp:ObjectDataSource>



        <asp:ObjectDataSource ID="OdsMotifOfObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getMotifObjectByObject" TypeName="controller.MotifObjectBLL" DataObjectTypeName="System.Guid">
                <SelectParameters>
                    <asp:Parameter DbType="Guid" Name="ObjectId" />
                </SelectParameters>
        </asp:ObjectDataSource>


        <div class="DivCssRelance" style="overflow-x:auto;width:990px;overflow-y:auto; height:400px">
   
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="OdsMotifDispositif" ForeColor="#333333" GridLines="None" Width="968px" AllowPaging="true">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton11" runat="server" CausesValidation="True" CommandName="Update" Text="Ok" ></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Mettre à jour" OnClick="LinkButton1_Click"></asp:LinkButton>
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton27" runat="server" OnClick="LinkButton27_Delete" OnClientClick="Confirm()">Supprimer</asp:LinkButton>
                        &nbsp; <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Numero objet" SortExpression="ObjectNum">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxObjectNum" runat="server" Text='<%# Bind("ObjectNum") %>' ></asp:TextBox>
                        
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelObjectNum" runat="server" Text='<%# Bind("ObjectNum") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="objet" SortExpression="objet">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("objet") %>' Width="229px"></asp:TextBox>
                        &nbsp;
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("id_objet") %>' Visible="False"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("objet") %>'></asp:Label>
                        &nbsp;<asp:Label ID="Label1" runat="server" Text='<%# Bind("id_objet") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Mission" SortExpression="MissionC">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownListMission" runat="server" DataSourceID="OdsDispositif" DataTextField="mission1" DataValueField="num" SelectedValue='<%# GetBindMissionId() %>' AutoPostBack="true" OnSelectedIndexChanged="DropDownListMission_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelMission" runat="server" Text='<%# Bind("MissionC") %>'></asp:Label>
                        <%--<asp:Label ID="LabelMissionId" Visible="false" runat="server" Text='<%# Bind("MissionId") %>'></asp:Label>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phase" SortExpression="PhaseId">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownListPhase" runat="server" DataSourceID="OdsPhaseMission" DataTextField="PhaseName" DataValueField="PhaseId" SelectedValue='<%# GetBindPhaseId() %>' OnSelectedIndexChanged="DropDownListPhase_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="LabelPhaseIdEdit" Visible="false" runat="server" Text='<%# Bind("PhaseId") %>'></asp:Label>
                        
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelPhase" runat="server" Text='<%# Bind("PhaseC") %>'></asp:Label>
                        <asp:Label ID="LabelPhaseId" Visible="false" runat="server" Text='<%# Bind("PhaseId") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#ffffcc" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        
            </ContentTemplate>
                </asp:UpdatePanel>            
                            <br />
            <br />
        </div>
    <asp:ObjectDataSource ID="OdsMotifDispositif" runat="server" DataObjectTypeName="Model.Objet_Disp" DeleteMethod="deleteMotifDispositif" InsertMethod="insertMotifDispositif" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllMotifDispositif" TypeName="controller.MotifDispositif_Controller" UpdateMethod="updateMotifDispositif">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="String" />
        </DeleteParameters>
    </asp:ObjectDataSource>


        </div>
</asp:Content>
