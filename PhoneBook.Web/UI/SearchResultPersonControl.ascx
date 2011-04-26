<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResultPersonControl.ascx.cs" Inherits="PhoneBook.Web.UI.SearchResultPersonControl" %>

<remotion:BindableObjectDataSourceControl id="CurrentObject" runat="server" Type="PhoneBook.Domain.Person, PhoneBook.Domain" />
<remotion:FormGridManager id="FormGridManager" runat="server" />

<div>
  <remotion:BocList id="PersonList" runat="server" DataSourceControl="CurrentObject" OnListItemCommandClick="PersonList_ListItemCommandClick">
    <FixedColumns>
      <remotion:BocCompoundColumnDefinition ColumnTitle="Name" ItemID="CompoundEdit" 
        FormatString="{0}, {1}">
        <propertypathbindings>
          <remotion:PropertyPathBinding PropertyPathIdentifier="LastName" />
          <remotion:PropertyPathBinding PropertyPathIdentifier="FirstName" />
        </propertypathbindings>
        <persistedcommand>
          <remotion:BocListItemCommand Type="Event"/>
        </persistedcommand>
      </remotion:BocCompoundColumnDefinition>
      <remotion:BocSimpleColumnDefinition EnableIcon="False" 
        PropertyPathIdentifier="Location">
        <persistedcommand>
          <remotion:BocListItemCommand />
        </persistedcommand>
      </remotion:BocSimpleColumnDefinition>
      <remotion:BocCustomColumnDefinition 
        PropertyPathIdentifier="PhoneNumbers" CustomCellType="PhoneBook.Web.Classes.PhoneNumberCell"
        CustomCellArgument="MaxPhoneNumbers=3,Commit=true">
      </remotion:BocCustomColumnDefinition>
      <remotion:BocCommandColumnDefinition ItemID="Edit" Text="$res:Edit">
        <PersistedCommand>
          <remotion:BocListItemCommand Type="Event" />
        </PersistedCommand>
      </remotion:BocCommandColumnDefinition>
    </FixedColumns>
  </remotion:BocList>
</div>