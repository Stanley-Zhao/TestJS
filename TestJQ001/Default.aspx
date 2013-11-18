<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestJQ001.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test JQuery</title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script type="text/javascript">
        !window.jQuery && document.write('<script src=http://lib.sinaapp.com/js/jquery/1.7.2/jquery.min.js><\/script>');
    </script>
    <script type="text/javascript">
        function getOtherMessage() {
            $.ajax({
                type: "post",
                url: "GetMessage.aspx",
                success: function (msg) {
                    $("#view").html(msg);
                },
                error: function () {
                    alert("wrong");
                }
            });
        }
  </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="button" value="修改" onclick="getOtherMessage();" />
        <div id="view">
            456
        </div>
    </form>
</body>
</html>
