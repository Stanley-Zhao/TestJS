<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestJQ001.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test JQuery</title>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript">
        !window.jQuery && document.write('<script src=http://lib.sinaapp.com/js/jquery/1.7.2/jquery.min.js><\/script>');
    </script>
    <script type="text/javascript">
        var time = 1000;
        var interval; 
        function run() {
            $.ajax({
                type: "post",
                url: "Fake_MakeBuild.aspx",
                success: function (msg) {
                    // do nothing
                },
                error: function () {
                    // do nothing
                }
            });

            interval = setInterval(getOtherMessage, time);
        }
        function getOtherMessage() {
            $.ajax({
                type: "post",
                url: "GetMessage.aspx",
                success: function (msg) {
                    $("#view").html(msg);
                    if (msg.indexOf("[[  Used time:") >= 0) {
                        window.clearInterval(interval);
                    }
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
        <input type="button" value="Make Build" onclick="run();" />
        <div id="view" style="color:#AFEEEE; background-color:#272727;font-family:Consolas;font-size:14px;font-weight:bold;width:400px;height:600px">
            [[  READY  ]]
        </div>
    </form>
</body>
</html>
