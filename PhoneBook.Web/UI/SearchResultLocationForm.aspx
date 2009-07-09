<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResultLocationForm.aspx.cs" Inherits="PhoneBook.Web.UI.SearchResultLocationForm" %>
<%@ Register TagPrefix="remotion" TagName="SearchResultLocationControl" Src="SearchResultLocationControl.ascx" %>
<%@ Register TagPrefix="app" TagName="NavigationTabs" Src="NavigationTabs.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <title><!-- Page title set in Page_Load !--></title>
  <remotion:htmlheadcontents id="HtmlHeadContents" runat="server"></remotion:htmlheadcontents>
</head>

<body>
  <remotion:FormGridManager id="FormGridManager" runat="server" />
  <form id="SearchResultLocationForm" method="post" runat="server">
    <remotion:BindableObjectDataSourceControl id="CurrentObject" runat="server" Type="PhoneBook.Domain.Location, PhoneBook.Domain" Mode="Read" />
    <remotion:TabbedMultiView ID="MultiView" runat="server" CssClass="tabbedMultiView">
      <TopControls>
        <app:NavigationTabs ID="TheNavigationTabs" runat="server" />
      </TopControls>
      <Views>
        <remotion:TabView ID="SearchResultLocationView" Title="$res:Details" runat="server">
          <remotion:SearchResultLocationControl ID="SearchResultLocationControl" runat="server" />
        </remotion:TabView>
      </Views>
    </remotion:TabbedMultiView>
  </form>
</body>

</html>
