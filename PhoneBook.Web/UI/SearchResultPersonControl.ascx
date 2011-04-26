<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResultPersonControl.ascx.cs" Inherits="PhoneBook.Web.UI.SearchResultPersonControl" %>

<remotion:BindableObjectDataSourceControl id="CurrentObject" runat="server" Type="PhoneBook.Domain.Person, PhoneBook.Domain" />
<remotion:FormGridManager id="FormGridManager" runat="server" />

<div>
  <remotion:BocList id="PersonList" runat="server" DataSourceControl="CurrentObject" OnListItemCommandClick="PersonList_ListItemCommandClick">
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