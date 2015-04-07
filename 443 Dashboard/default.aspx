<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="_443_Dashboard._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="stylesheet.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="left" style="width: 225px; text-align: center;">
    
        <br />
       

        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Select Source"></asp:Label>
         <br />
        <asp:ImageButton ID="ImageButton1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" Height="75px" ImageUrl="~/Images/NYTimesLogo.jpg" Width="200px" />
        <br />
        <asp:ImageButton ID="ImageButton2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" Height="75px" ImageUrl="~/Images/facebookLogo.png" Width="200px" />
        <br />
        <asp:ImageButton ID="ImageButton3" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" Height="75px" ImageUrl="~/Images/twitter_logo.jpg" Width="200px" />
    
    </div>

    <div id="content">
        <div class="holder">
            <div class="img">
                <asp:Image ID="Image1" runat="server" />
                
            </div>
            <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <div id="footer">

    </div>
    </form>
</body>
</html>
