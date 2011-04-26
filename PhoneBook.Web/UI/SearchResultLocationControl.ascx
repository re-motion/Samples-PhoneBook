<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResultLocationControl.ascx.cs" Inherits="PhoneBook.Web.UI.SearchResultLocationControl" %>

<remotion:BindableObjectDataSourceControl id="CurrentObject" runat="server" Type="PhoneBook.Domain.Location, PhoneBook.Domain" />
<remotion:FormGridManager id="FormGridManager" runat="server" />

<div>
  <remotion:BocList id="LocationList" runat="server" DataSourceControl="CurrentObject" OnListItemCommandClick="LocationList_ListItemCommandClick">
    <FixedColumns>
      <remotion:BocAllPropertiesPlaceholderColumnDefinition />
      <remotion:BocCommandColumnDefinition ItemID="Edit" Text="$res:Edit">
        <PersistedCommand>
          <remotion:BocListItemCommand Type="Event" />
        </PersistedCommand>
      </remotion:BocCommandColumnDefinition>
    </FixedColumns>
  </remotion:BocList>
</div>