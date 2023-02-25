<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="TestAlbumPhotos.aspx.cs" Inherits="view.webforms.TestAlbumPhotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">



    <script type="text/javascript">
        function ShowImage() {
            $("#Image_Click").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   

    <asp:Label ID="Label33" runat="server" CssClass="LabelCss" Text="Les pièces jointes de la Requête avec l'ID : "></asp:Label>
    <asp:Label ID="Label2" runat="server" Text='<%# Session["NumWilaya_Request"].ToString() %>' Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099"></asp:Label><asp:Label ID="Label3" runat="server" Text="-" Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099"></asp:Label><asp:Label ID="Label81" runat="server" Text='<%# Session["Year_Request"].ToString() %>' Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099"></asp:Label><asp:Label ID="Label4" runat="server" Text="-" Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099"></asp:Label><asp:Label ID="LabelIdReclam" runat="server" Text='<%# Session["Id_Request"].ToString() %>' Font-Names="Arial Black" Font-Size="Medium" ForeColor="#000099" Height="25px" Width="200px"></asp:Label>
&nbsp;<br />
    <asp:Panel ID="Panel1" runat="server">

    </asp:Panel>

    

    
    <br />

    <!-- Trigger the modal with a button -->
<button id="Image_Click" type="button" class="btn btn-primary btn-lg"
                data-toggle="modal" data-target="#myModall">Open Modal</button>

<!-- Modal -->
<div id="myModall" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Modal Header</h4>
      </div>
      <div class="modal-body">
        <p>
            <div id="Div2" runat="server" style="overflow-x:auto;width:960px;overflow-y:auto; height:350px" visible="true">
            <asp:Image ID="Image1" runat="server" /></p>
          </div>
        
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>
</asp:Content>
