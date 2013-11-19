<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestJQ001.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test JQuery - Show Build Process</title>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript">
        !window.jQuery && document.write('<script src=http://lib.sinaapp.com/js/jquery/1.7.2/jquery.min.js><\/script>');
    </script>
    <script type="text/javascript">
        var time = 1000;
        var interval;

        /** ******************************************************************************* 
        when clicking on run, call Fake_MakeBuild.aspx to start the "Fake" building process
        Fake_MakeBuild.aspx will start a thread and write information into a temp.txt file.
        ******************************************************************************* **/
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

            // Start to get message back from server and show them on DIV panel
            interval = setInterval(getOtherMessage, time);
        }

        /** ******************************************************************************* 
        A timer to call GetMessage.aspx to get building process information. It will read 
        temp.txt file to get all these information.
        ******************************************************************************* **/
        function getOtherMessage() {
            $.ajax({
                type: "post",
                url: "GetMessage.aspx",
                success: function (msg) {
                    $("#view").html(msg); // get message back from server and show them in to DIV panel
                    if (msg.indexOf("[[  Used time:") >= 0) {
                        window.clearInterval(interval); // read last line? stop the timer
                    }
                },
                error: function () {
                    alert("wrong"); // something wrong
                }
            });
        }
  </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="button" value="Make Build" onclick="run();" />
        <!-- A DIV panel here, with dark grey background and light blue foreground -->
        <div id="view" style="color:#AFEEEE; background-color:#272727;font-family:Consolas;font-size:14px;font-weight:bold;width:400px;height:600px">
            [[  READY  ]]
        </div>
    </form>
</body>
</html>
