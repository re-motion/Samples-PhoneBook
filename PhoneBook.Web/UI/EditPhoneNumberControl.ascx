<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditPhoneNumberControl.ascx.cs" Inherits="PhoneBook.Web.UI.EditPhoneNumberControl" %>

<remotion:FormGridManager ID="FormGridManager" runat="server" />
<remotion:BindableObjectDataSourceControl ID="CurrentObject" runat="server" Type="PhoneBook.Domain.PhoneNumber, PhoneBook.Domain" />

<div>
  <table id="PhoneNumberFormGrid" runat="server">
  
  <tr>
    <td><remotion:SmartLabel ID="CountryCodeLabel" runat="server" ForControl="CountryCodeField" /></td>
    <td>
      <remotion:BocTextValue ID="CountryCodeField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="CountryCode" >
        
      </remotion:BocTextValue>
    </td>
  </tr>
  <tr>
    <td><remotion:SmartLabel ID="AreaCodeLabel" runat="server" ForControl="AreaCodeField" /></td>
    <td>
      <remotion:BocTextValue ID="AreaCodeField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="AreaCode" >
        
      </remotion:BocTextValue>
    </td>
  </tr>
  <tr>
    <td><remotion:SmartLabel ID="NumberLabel" runat="server" ForControl="NumberField" /></td>
    <td>
      <remotion:BocTextValue ID="NumberField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="Number" >
        
      </remotion:BocTextValue>
    </td>
  </tr>
  <tr>
    <td><remotion:SmartLabel ID="ExtensionLabel" runat="server" ForControl="ExtensionField" /></td>
    <td>
      <remotion:BocTextValue ID="ExtensionField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="Extension" >
        
      </remotion:BocTextValue>
    </td>
  </tr>
  <tr>
    <td><remotion:SmartLabel ID="PersonLabel" runat="server" ForControl="PersonField" /></td>
    <td>
      <remotion:BocReferenceValue ID="PersonField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="Person" >
        
      </remotion:BocReferenceValue>
    </td>
  </tr>
</table>

</div>
