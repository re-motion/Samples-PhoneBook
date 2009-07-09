﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="PhoneBook.Web.DefaultPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <title>PhoneBook Web Sample</title>
  <link type="text/css" rel="stylesheet" href="./res/Remotion.Web/HTML/Style.css">
  <script language="javascript" type="text/javascript">
  function StartApp(url)
  {
    // Set height so that IE window fits for 1024x768 with windows taskbar
    var windowMaxWidth = 1010;
    var windowMaxHeight = 700;
    var windowLeft = (screen.width - windowMaxWidth) / 2;

    var windowTop;
    if (screen.height > 768)
    {
      // Center window vertical for resolutions greater than 1024x768
      windowTop = (screen.height - windowMaxHeight) / 2;
    }
    else
    {
      // Do not center window because of window taskbar
      windowTop = 5;
    }

    if (! false)
      window.open(url, "_self");
    else
      window.open(url, "_blank",
          "width=" + windowMaxWidth + ",height=" + windowMaxHeight + ",top=" + windowTop + ",left=" + windowLeft + "," +
          "resizable=yes,location=yes,menubar=no,status=yes,toolbar=no,scrollbars=no" );
  }
  </script>
</head>

<body>
  <form id="defaultForm" method="post" runat="server">
    <div id="PageHeader">
      <img src="Images/rublogo.bmp" alt="re-motion">
    </div>
    <h1>Admire our PhoneBook application!</h1>
    <p>
      To start the application just click 'Start'
      <br>
      <img class="pfeil" src="Images/arrow.gif">&nbsp;<a href="javascript:StartApp('EditLocation.wxe?WxeReturnToSelf=true');">Start</a>
    </p>
  </form>
</body>

</html>