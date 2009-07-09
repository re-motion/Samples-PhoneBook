<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResultPhoneNumberForm.aspx.cs" Inherits="PhoneBook.Web.UI.SearchResultPhoneNumberForm" %>
<%@ Register TagPrefix="remotion" TagName="SearchResultPhoneNumberControl" Src="SearchResultPhoneNumberControl.ascx" %>
<%@ Register TagPrefix="app" TagName="NavigationTabs" Src="NavigationTabs.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
  <title><!-- Page title set in Page_Load !--></title>
  <remotion:htmlheadcontents id="HtmlHeadContents" runat="server"></remotion:htmlheadcontents>
</head>

<body>
  <remotion:FormGridManager ID="FormGridManager" runat="server" />
  <form id="SearchResultForm" method="post" runat="server">
    <remotion:BindableObjectDataSourceControl id="CurrentObject" runat="server" Type="PhoneBook.Domain.PhoneNumber, PhoneBook.Domain" />
    <remotion:TabbedMultiView ID="MultiView" runat="server" CssClass="tabbedMultiView">
      <TopControls>
        <app:NavigationTabs ID="TheNavigationTabs" runat="server" />
      </TopControls>
      <Views>
        <remotion:TabView ID="SearchResultPhoneNumberView" Title="$res:Details" runat="server">
          <remotion:SearchResultPhoneNumberControl id="SearchResultPhoneNumberControl" runat="server" />
        </remotion:TabView>
      </Views>
    </remotion:TabbedMultiView>
  </form>
</body>

</html>