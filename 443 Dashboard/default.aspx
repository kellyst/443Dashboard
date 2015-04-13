﻿<%@ Page Language="vb" AutoEventWireup="false" Async="true" CodeBehind="default.aspx.vb" Inherits="_443_Dashboard._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="stylesheet.css" />
    <title></title>

    <script type ="text/javascript" >
        
      

    </script>


</head>
<body>
    <form id="form1" runat="server">
    <div id="left" style="width: 225px; text-align: center;">
    
        <br />
       

        <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Select Source" CssClass="headerTxt"></asp:Label>
        <asp:ImageButton ID="iBtn_nyTimes" runat="server" Height="75px" ImageUrl="~/Images/NYTimesLogo.jpg" Width="200px" CssClass="imgButton" />
        <asp:ImageButton ID="iBtn_facebook" runat="server" Height="75px" ImageUrl="~/Images/facebook-logo.jpg" Width="200px" CssClass="imgButton" />
        <asp:ImageButton ID="iBtn_twitter" runat="server" Height="75px" ImageUrl="~/Images/twitter_logo.jpg" Width="200px" CssClass="imgButton" />
    
    </div>

    <div id="content">
       
                    <asp:PlaceHolder ID="place" runat="server"></asp:PlaceHolder>        

    </div>

    <div id="footer">

    </div>
    </form>
</body>

    <!--Script references. -->
    <!--Reference the jQuery library. -->
    <script src="Scripts/jquery-1.6.4.min.js" ></script>
    <!--Reference the SignalR library. -->
    <script src="Scripts/jquery.signalR-2.1.0.min.js"></script>
    <!--Reference the autogenerated SignalR hub script. -->
    <script src="signalr/hubs"></script>
    <!--Add script to update the page and send messages.--> 
    <script type="text/javascript">
        $(function () {
            // Declare a proxy to reference the hub. 
            var dash = $.connection.DashHub;
            // Create a function that the hub can call to broadcast messages.
            //dash.client.broadcastMessage = function (name, message) {
            //    // Html encode display name and message. 
            //    var encodedName = $('<div />').text(name).html();
            //    var encodedMsg = $('<div />').text(message).html();
            //    // Add the message to the page. 
            //    $('#discussion').append('<li><strong>' + encodedName
            //        + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
            //};
            
            // Start the connection.
            $.connection.hub.start().done(function () {
                $('#sendrequest').click(function () {
                    // Call the Send method on the hub. 
                    dash.server.send($('#displayname').val(), $('#message').val());
                });
            });
        });
    </script>
</html>
