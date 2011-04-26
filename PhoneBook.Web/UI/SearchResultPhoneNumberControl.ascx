<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResultPhoneNumberControl.ascx.cs" Inherits="PhoneBook.Web.UI.SearchResultPhoneNumberControl" %>

<remotion:BindableObjectDataSourceControl id="CurrentObject" runat="server" Type="PhoneBook.Domain.PhoneNumber, PhoneBook.Domain" />
<remotion:FormGridManager id="FormGridManager" runat="server" />

<div>
  <remotion:BocList ID="PhoneNumberList" runat="server" DataSourceControl="CurrentObject" OnListItemCommandClick="PhoneNumberList_ListItemCommandClick">
  <FixedColumns>
    <remotion:BocSimpleColumnDefinition propertyPathIdentifier="CountryCode" />
      <remotion:BocSimpleColumnDefinition propertyPathIdentifier="AreaCode" />
      <remotion:BocSimpleColumnDefinition propertyPathIdentifier="Number" />
      <remotion:BocSimpleColumnDefinition propertyPathIdentifier="Extension" />
      <remotion:BocSimpleColumnDefinition propertyPathIdentifier="Person" />
      <remotion:BocCommandColumnDefinition ItemID="Edit" Text="$res:Edit">
        <PersistedCommand>
          <remotion:BocListItemCommand Type="Event" />
        </PersistedCommand>
      </remotion:BocCommandColumnDefinition>
    </FixedColumns>
  </remotion:BocList>
</div>