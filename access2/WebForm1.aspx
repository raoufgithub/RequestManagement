<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="view.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>




           <script type="text/javascript">
                function openModal() {
                    $('#myModal').modal('show');
                }
           </script>
    
    <link href="bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.standalone.min.css" rel="stylesheet" />
    <link href="bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.standalone.min.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker({
                format: 'dd/mm/yyyy',
                "autoclose": true
            })
        });

        </script>





    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button2_Click1" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
        
    <div>
        
     <asp:Button ID="Button1" data-toggle="modal" data-target="#myModal" runat="server" Text="Button" OnClick="Button1_Click" />

    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModal-label" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModal-label">Modal title</h4>
                </div>
                <div class="modal-body">
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    <%--<asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1">--%>
                    <asp:GridView ID="GridView1" runat="server">

                    </asp:GridView>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </ContentTemplate>
                        </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:LinkButton OnClick="LinkButton1_Click" CssClass="btn btn-success" ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    </div>

        <asp:TextBox ID="TextBox2" CssClass="datepicker" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox1" onkeypress="return functionx(event)" runat="server" CssClass="datepicker"></asp:TextBox>
        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TextBox1" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
        --%>        
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click1" />
<%--            </ContentTemplate>
            </asp:UpdatePanel>--%>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>


    



    


    <script type = "text/javascript">
        function functionx(evt) {
            if (evt.charCode > 31 && (evt.charCode < 48 || evt.charCode > 57)) {
                //alert("Allow Only Numbers");
                document.getElementById("<%= Label1.ClientID %>").value = "new text value";
                return false;
            }
        }
     </script>


    <script src="calendar/js/jquery-1.10.2.js"></script>
    <script src="calendar/js/jquery-ui.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

                function EndRequestHandler(sender, args) {
                    $('.datepicker').datepicker({ dateFormat: 'dd-mm-yy' });
                }

            });
    </script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#TextBox2').datepicker()
        });
</script>








        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Model.reclamation" DeleteMethod="deleteRecalamation" InsertMethod="insertReclamation" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllReclamation" TypeName="controller.requete_controller" UpdateMethod="updatereclamation">
            <DeleteParameters>
                <asp:Parameter Name="guid" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>










          <div class="container">
    <div class="btn-group">
        <asp:Button ID="btnSubmit" class="btn-info" runat="server" Text="Submit"          
        OnClick="btnSubmit_Click"></asp:Button>
    </div>
</div>


<!-- Bootstrap Modal Dialog -->
<div class="modal fade" id="myModall" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <%--<asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>--%>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
         <%--   </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>
</div>



        <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
    <asp:Button ID="Button4" runat="server" OnClick="Upload_Click" Text="Button" />
    <br />
    <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
    </form>


    





    </body>
</html>
