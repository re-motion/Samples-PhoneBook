<%@ Control Language="C#" AutoEventWireUp="true" CodeBehind="SearchResultPhoneNumberControl.ascx.cs" Inherits="PhoneBook.Web.UI.SearchResultPhoneNumberControl" %>

<remotion:BindableObjectDataSourceControl ID="CurrentObject" runat="server" Type="PhoneBook.Domain.PhoneNumber, PhoneBook.Domain" />

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