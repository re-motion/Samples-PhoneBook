<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditPersonControl.ascx.cs" Inherits="PhoneBook.Web.UI.EditPersonControl" %>

<remotion:FormGridManager ID="FormGridManager" runat="server" />
<remotion:BindableObjectDataSourceControl ID="CurrentObject" runat="server" Type="PhoneBook.Domain.Person, PhoneBook.Domain" />

<div>
  <table id="PersonFormGrid" runat="server">
  
  <tr>
    <td><remotion:SmartLabel ID="FirstNameLabel" runat="server" ForControl="FirstNameField" /></td>
    <td>
      <remotion:BocTextValue ID="FirstNameField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="FirstName" >
        
      </remotion:BocTextValue>
    </td>
  </tr>
  <tr>
    <td><remotion:SmartLabel ID="SurnameLabel" runat="server" ForControl="SurnameField" /></td>
    <td>
      <remotion:BocTextValue ID="SurnameField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="Surname" >
        
      </remotion:BocTextValue>
    </td>
  </tr>
  <tr>
    <td><remotion:SmartLabel ID="LocationLabel" runat="server" ForControl="LocationField" /></td>
    <td>
      <remotion:BocReferenceValue ID="LocationField" runat="server" 
       DataSourceControl="CurrentObject" PropertyIdentifier="Location" 
        OnMenuItemClick = "LocationField_MenuItemClick" 
        OptionsTitle="$res:OptionsActions">
        <PersistedCommand>
<remotion:BocCommand></remotion:BocCommand>
</PersistedCommand>
        <OptionsMenuItems>
          <remotion:BocMenuItem Text="$res:NewLocation" ItemID="NewLocation">
          </remotion:BocMenuItem>
          <remotion:BocMenuItem Text="$res:PickLocation" ItemID="PickLocation">
          </remotion:BocMenuItem>
        </OptionsMenuItems>  
      </remotion:BocReferenceValue>
    </td>
  </tr>
  <tr>
    <td><remotion:SmartLabel ID="PhoneNumbersLabel" runat="server" ForControl="PhoneNumbersField" /></td>
    <td>
      <remotion:BocList ID="PhoneNumbersField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="PhoneNumbers" OnMenuItemClick="PhoneNumbersField_MenuItemClick">
        <FixedColumns>
          <remotion:BocRowEditModeColumnDefinition CancelText="$res:Cancel" EditText="$res:Edit" SaveText="$res:Save" />
          <remotion:BocSimpleColumnDefinition EnableIcon="False" 
            PropertyPathIdentifier="CountryCode">
            <persistedcommand>
              <remotion:BocListItemCommand />
            </persistedcommand>
          </remotion:BocSimpleColumnDefinition>
          <remotion:BocSimpleColumnDefinition EnableIcon="False" 
            PropertyPathIdentifier="AreaCode">
            <persistedcommand>
              <remotion:BocListItemCommand />
            </persistedcommand>
          </remotion:BocSimpleColumnDefinition>
          <remotion:BocSimpleColumnDefinition EnableIcon="False" 
            PropertyPathIdentifier="Number">
            <persistedcommand>
              <remotion:BocListItemCommand />
            </persistedcommand>
          </remotion:BocSimpleColumnDefinition>
          <remotion:BocSimpleColumnDefinition EnableIcon="False" 
            PropertyPathIdentifier="Extension">
            <persistedcommand>
              <remotion:BocListItemCommand />
            </persistedcommand>
          </remotion:BocSimpleColumnDefinition>
        </FixedColumns>
        <ListMenuItems>
          <remotion:BocMenuItem ItemID="AddMenuItem" Text="$res:Add" >
            <PersistedCommand>
<remotion:BocMenuItemCommand></remotion:BocMenuItemCommand>
</PersistedCommand>
          </remotion:BocMenuItem>
        </ListMenuItems>
      </remotion:BocList>
    </td>
  </tr>
</table>

</div>
