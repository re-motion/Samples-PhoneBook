<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResult$DOMAIN_CLASSNAME$Form.aspx.cs" Inherits="$PROJECT_ROOTNAMESPACE$.UI.SearchResult$DOMAIN_CLASSNAME$Form" %>
<%@ Register TagPrefix="remotion" TagName="SearchResult$DOMAIN_CLASSNAME$Control" Src="SearchResult$DOMAIN_CLASSNAME$Control.ascx" %>
<%@ Register TagPrefix="app" TagName="NavigationTabs" Src="NavigationTabs.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <title><!-- Page title set in Page_Load !--></title>
  <remotion:htmlheadcontents id="HtmlHeadContents" runat="server"></remotion:htmlheadcontents>
</head>

<body>
  <remotion:FormGridManager id="FormGridManager" runat="server" />
  <form id="SearchResultForm" method="post" runat="server">
    <remotion:BindableObjectDataSourceControl id="$DOMAIN_CLASSNAME$SearchDataSource" runat="server" Type="$DOMAIN_QUALIFIEDCLASSTYPENAME$" Mode="Read" />
    <remotion:TabbedMultiView ID="MultiView" runat="server" CssClass="tabbedMultiView">
      <TopControls>
        <app:NavigationTabs ID="TheNavigationTabs" runat="server" />
      </TopControls>
      <Views>
        <remotion:TabView ID="SearchResult$DOMAIN_CLASSNAME$View" Title="$res:Details" runat="server">
          <remotion:SearchResult$DOMAIN_CLASSNAME$Control id="SearchResult$DOMAIN_CLASSNAME$Control" runat="server" />
        </remotion:TabView>
      </Views>
    </remotion:TabbedMultiView>

  </form>
</body>

</html>
