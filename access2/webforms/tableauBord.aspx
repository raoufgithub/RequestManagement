<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="tableauBord.aspx.cs" Inherits="view.webforms.tableauBord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <%--<link href="../Content/bootstrap.css" rel="stylesheet" />--%>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    


    
    <link href="../calendar/css/jquery-ui.css" rel="stylesheet" />
    <script src="../calendar/js/jquery-1.10.2.js"></script>
    <script src="../calendar/js/jquery-ui.js"></script>
    
    <script type="text/javascript">
        $(document).ready (function(){
            $('.datepicker').datepicker()
        });
    </script>
    <%-- ***************************************************************************************************************** --%>
                           

     <%-- ***************************************************************************************************************** --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
            <div class="modal fade" id="myModal" style="display: none">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">
                                Registration done Successfully</h4>
                        </div>
                        <div class="modal-body">
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                                <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1">


                                </asp:GridView>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Close</button>
                            <button type="button" class="btn btn-primary">
                                Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button runat="server" ID="btnShowPopup" Text="Test Show" OnClick="btn_click"
                CssClass="btn btn-primary" data-toggle="modal" data-target="#myModal" />                                           
 
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Model.reclamation" DeleteMethod="deleteRecalamation" InsertMethod="insertReclamation" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllReclamation" TypeName="controller.requete_controller" UpdateMethod="updatereclamation">
            <DeleteParameters>
                <asp:Parameter Name="guid" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            tableau de bord
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
