<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResult$DOMAIN_CLASSNAME$Control.ascx.cs" Inherits="$PROJECT_ROOTNAMESPACE$.UI.SearchResult$DOMAIN_CLASSNAME$Control" %>

<remotion:BindableObjectDataSourceControl id="CurrentObject" runat="server" Type="$DOMAIN_QUALIFIEDCLASSTYPENAME$" />
<remotion:FormGridManager id="FormGridManager" runat="server" />

<div>
  <remotion:BocList id="$DOMAIN_CLASSNAME$List" runat="server" DataSourceControl="CurrentObject" OnListItemCommandClick="$DOMAIN_CLASSNAME$List_ListItemCommandClick">
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