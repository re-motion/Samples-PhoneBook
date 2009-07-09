<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditLocationControl.ascx.cs" Inherits="PhoneBook.Web.UI.EditLocationControl" %>

<remotion:FormGridManager ID="FormGridManager" runat="server" />
<remotion:BindableObjectDataSourceControl ID="CurrentObject" runat="server" Type="PhoneBook.Domain.Location, PhoneBook.Domain" />

<div>
  <table id="LocationFormGrid" runat="server">
  
  <tr>        
    <td><remotion:SmartLabel ID="StreetLabel" runat="server" ForControl="StreetField" /></td>
    <td>
      <remotion:BocTextValue ID="StreetField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="Street" >
        
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
    <td><remotion:SmartLabel ID="CityLabel" runat="server" ForControl="CityField" /></td>
    <td>
      <remotion:BocTextValue ID="CityField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="City" >
        
      </remotion:BocTextValue>
    </td>
  </tr>
  <tr>
    <td><remotion:SmartLabel ID="CountryLabel" runat="server" ForControl="CountryField" /></td>
    <td>
      <remotion:BocEnumValue ID="CountryField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="Country" >
        
      </remotion:BocEnumValue>
    </td>
  </tr>
  <tr>
    <td><remotion:SmartLabel ID="ZipCodeLabel" runat="server" ForControl="ZipCodeField" /></td>
    <td>
      <remotion:BocTextValue ID="ZipCodeField" runat="server" DataSourceControl="CurrentObject"
          PropertyIdentifier="ZipCode" >
        
      </remotion:BocTextValue>
    </td>
  </tr>
</table>

</div>
