<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=txtDate]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: '../../Ressources/Images/arrow.png'
            });
        });

        $(function () {
            $("[id$=tt]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: '../../Ressources/Images/arrow.png'
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:TextBox ID="txtDate" runat="server" ReadOnly = "true"> </asp:TextBox>
            <asp:TextBox ID="tt" runat="server" ReadOnly = "true"> </asp:TextBox>

   
    </form>
</body>
</html>
