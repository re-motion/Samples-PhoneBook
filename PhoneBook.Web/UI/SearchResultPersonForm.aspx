<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResultPersonForm.aspx.cs" Inherits="PhoneBook.Web.UI.SearchResultPersonForm" %>
<%@ Register TagPrefix="remotion" TagName="SearchResultPersonControl" Src="SearchResultPersonControl.ascx" %>
<%@ Register TagPrefix="app" TagName="NavigationTabs" Src="NavigationTabs.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
  <title><!-- Page title set in Page_Load !--></title>
  <remotion:htmlheadcontents id="HtmlHeadContents" runat="server"></remotion:htmlheadcontents>
</head>

<body>
  <remotion:FormGridManager id="FormGridManager" runat="server" />
  <form id="SearchResultForm" method="post" runat="server">
    <remotion:BindableObjectDataSourceControl id="CurrentObject" runat="server" Type="PhoneBook.Domain.Person, PhoneBook.Domain" Mode="Read" />
    <remotion:TabbedMultiView ID="MultiView" runat="server" CssClass="tabbedMultiView">
      <TopControls>
        <app:NavigationTabs ID="TheNavigationTabs" runat="server" />
      </TopControls>
      <Views>
        <remotion:TabView ID="SearchResultPersonView" Title="$res:Details" runat="server">
          <remotion:SearchResultPersonControl ID="SearchResultPersonControl" runat="server" />
        </remotion:TabView>
      </Views>
    </remotion:TabbedMultiView>
  </form>
</body>

</html>