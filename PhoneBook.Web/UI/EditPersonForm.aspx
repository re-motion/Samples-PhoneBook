<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPersonForm.aspx.cs" Inherits="PhoneBook.Web.UI.EditPersonForm" %>
<%@ Register TagPrefix="app" TagName="NavigationTabs" Src="NavigationTabs.ascx" %>
<%@ Register TagPrefix="remotion" TagName="EditPersonControl" Src="EditPersonControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <title><!-- Page title set in Page_Load !--></title>
  <remotion:htmlheadcontents id="HtmlHeadContents" runat="server"></remotion:htmlheadcontents>
</head>

<body>
  <form id="EditForm" runat="server">
    <remotion:BindableObjectDataSourceControl ID="CurrentObject" runat="server" Type="PhoneBook.Domain.Person, PhoneBook.Domain" />
    <remotion:TabbedMultiView ID="MultiView" runat="server" CssClass="tabbedMultiView" >
      <TopControls>
        <app:NavigationTabs ID="TheNavigationTabs" runat="server" />
      </TopControls>
      <Views>
        <remotion:TabView ID="EditPersonView" Title="$res:Details" runat="server">
          <remotion:EditPersonControl ID="EditPersonControl" runat="server" />
        </remotion:TabView>
      </Views>
      <BottomControls>
        <remotion:WebButton ID="SaveButton" runat="server" Text="$res:Save" OnClick="SaveButton_Click" />
        <remotion:SmartLabel runat="server" Text="&nbsp;" />
        <remotion:WebButton ID="CancelButton" runat="server" Text="$res:Cancel" OnClick="CancelButton_Click" />
      </BottomControls>
    </remotion:TabbedMultiView>
  </form>
</body>

</html>
