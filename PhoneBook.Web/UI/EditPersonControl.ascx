<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditPersonControl.ascx.cs" Inherits="PhoneBook.Web.UI.EditPersonControl" %>
<remotion:FormGridManager ID="FormGridManager" runat="server" />
<remotion:BindableObjectDataSourceControl ID="CurrentObject" runat="server" Type="PhoneBook.Domain.Person, PhoneBook.Domain" />
<div>
  <table id="PersonFormGrid" runat="server">
    <tr>
      <td>
        <remotion:SmartLabel ID="FirstNameLabel" runat="server" ForControl="FirstNameField" />
      </td><td>
        <remotion:BocTextValue ID="FirstNameField" runat="server" DataSourceControl="CurrentObject" PropertyIdentifier="FirstName" />
      </td>
    </tr>
    <tr>
      <td>
        <remotion:SmartLabel ID="LastNameLabel" runat="server" ForControl="LastNameField" />
      </td><td>
        <remotion:BocTextValue ID="LastNameField" runat="server" DataSourceControl="CurrentObject" PropertyIdentifier="LastName" />
      </td>
    </tr>
    <tr>
      <td>
        <remotion:SmartLabel ID="LocationLabel" runat="server" ForControl="LocationField" />
      </td><td>
        <remotion:BocReferenceValue ID="LocationField" runat="server" DataSourceControl="CurrentObject" PropertyIdentifier="Location" 
              OnMenuItemClick="LocationField_MenuItemClick" OptionsTitle="$res:OptionsActions" />
      </td>
    </tr>
    <tr>
      <td>
        <remotion:SmartLabel ID="PhoneNumbersLabel" runat="server" ForControl="PhoneNumbersField" />
      </td><td>
        <remotion:BocList ID="PhoneNumbersField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="PhoneNumbers" OnMenuItemClick="PhoneNumbersField_MenuItemClick">
          <FixedColumns>
            <remotion:BocRowEditModeColumnDefinition CancelText="$res:Cancel" EditText="$res:Edit" SaveText="$res:Save" />
            <remotion:BocSimpleColumnDefinition EnableIcon="False" PropertyPathIdentifier="CountryCode"/>
            <remotion:BocSimpleColumnDefinition EnableIcon="False" PropertyPathIdentifier="AreaCode"/>
            <remotion:BocSimpleColumnDefinition EnableIcon="False" PropertyPathIdentifier="Number"/>
            <remotion:BocSimpleColumnDefinition EnableIcon="False" PropertyPathIdentifier="Extension"/>
          </FixedColumns>
          <ListMenuItems>
            <remotion:BocMenuItem ItemID="AddMenuItem" Text="$res:Add"/>
          </ListMenuItems>
        </remotion:BocList>
      </td>
    </tr>
  </table>
</div>
