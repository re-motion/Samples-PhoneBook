<%@ Page Language="C#" CodeBehind="PickLocation.aspx.cs" Inherits="PhoneBook.Web.UI.PickLocation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="PickALocationHeader" runat="server">
  <title><!-- Page title set in Page_Load !--></title>
</head>
<body>
<form id="PickLocationForm" runat="server">
<remotion:FormGridManager ID="FormGridManager" runat="server" />
<remotion:BindableObjectDataSourceControl ID="PickLocationDataSource" 
  runat="server" Mode="Search" Type="PhoneBook.Domain.Location, PhoneBook.Domain" />
<table id="CountryFormGrid" runat="server">
  <tr>
    <td>
      <remotion:SmartLabel runat="server" id="CountryLabel" ForControl="CountryField" />
    </td>
    <td>
      <remotion:BocEnumValue ID="CountryField" runat="server" 
        DataSourceControl="PickLocationDataSource" PropertyIdentifier="Country" />
    </td>
    <td>
      <remotion:WebButton ID="SearchButton" runat="server" onclick="SearchButton_Click" Text="$res:Search" />
    </td>
    <td>
      <remotion:WebButton ID="CancelButton" runat="server" onclick="CancelButton_Click" Text="$res:Cancel" />
    </td>
  </tr>
</table>

<remotion:BocList ID="FilteredLocationsList" runat="server" 
  DataSourceControl="PickLocationDataSource" OnListItemCommandClick="FilteredLocationsList_ListItemCommandClick">
  <FixedColumns>
    <remotion:BocSimpleColumnDefinition 
      PropertyPathIdentifier="Street" ItemID="LocationPick">
      <persistedcommand>
        <remotion:BocListItemCommand Type="Event" />
      </persistedcommand>
    </remotion:BocSimpleColumnDefinition>
    <remotion:BocSimpleColumnDefinition PropertyPathIdentifier="Number" />
    <remotion:BocSimpleColumnDefinition PropertyPathIdentifier="City" />
    <remotion:BocSimpleColumnDefinition PropertyPathIdentifier="Country" />
    <remotion:BocSimpleColumnDefinition PropertyPathIdentifier="ZipCode" />
  </FixedColumns>
</remotion:BocList>
</form>
</body>
</html>


