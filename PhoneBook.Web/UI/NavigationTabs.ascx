<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationTabs.ascx.cs" Inherits="PhoneBook.Web.UI.NavigationTabs" %>

<!-- Place your logo here
   <div style="background-color:#083779; margin:0px; padding:10px">
  <img alt="re-motion logo" src="../Images/re-motion-logo-single.PNG" />
  </div>
  -->

<remotion:TabbedMenu ID="TheTabbedMenu" runat="server">
  <Tabs>
    
    <remotion:MainMenuTab ItemID="LocationTab" Text="$res:Location">
      <PersistedCommand>
        <remotion:NavigationCommand type="None" />
      </PersistedCommand>
      <SubMenuTabs>
        <remotion:SubMenuTab ItemID="EditLocationTab" Text="$res:New">
          <PersistedCommand>
            <remotion:NavigationCommand Type="WxeFunction" WxeFunctionCommand-MappingID="EditLocation" />
          </PersistedCommand>
        </remotion:SubMenuTab>
        <remotion:SubMenuTab ItemID="SearchLocationTab" Text="$res:List">
          <PersistedCommand>
            <remotion:NavigationCommand Type="WxeFunction" WxeFunctionCommand-MappingID="SearchLocation" />
          </PersistedCommand>
        </remotion:SubMenuTab>
      </SubMenuTabs>
    </remotion:MainMenuTab>
    
    <remotion:MainMenuTab ItemID="PersonTab" Text="$res:Person">
      <PersistedCommand>
        <remotion:NavigationCommand type="None" />
      </PersistedCommand>
      <SubMenuTabs>
        <remotion:SubMenuTab ItemID="EditPersonTab" Text="$res:New">
          <PersistedCommand>
            <remotion:NavigationCommand Type="WxeFunction" WxeFunctionCommand-MappingID="EditPerson" />
          </PersistedCommand>
        </remotion:SubMenuTab>
        <remotion:SubMenuTab ItemID="SearchPersonTab" Text="$res:List">
          <PersistedCommand>
            <remotion:NavigationCommand Type="WxeFunction" WxeFunctionCommand-MappingID="SearchPerson" />
          </PersistedCommand>
        </remotion:SubMenuTab>
      </SubMenuTabs>
    </remotion:MainMenuTab>
    
    <remotion:MainMenuTab ItemID="PhoneNumberTab" Text="$res:PhoneNumber">
      <PersistedCommand>
        <remotion:NavigationCommand type="None" />
      </PersistedCommand>
      <SubMenuTabs>
        <remotion:SubMenuTab ItemID="EditPhoneNumberTab" Text="$res:New">
          <PersistedCommand>
            <remotion:NavigationCommand Type="WxeFunction" WxeFunctionCommand-MappingID="EditPhoneNumber" />
          </PersistedCommand>
        </remotion:SubMenuTab>
        <remotion:SubMenuTab ItemID="SearchPhoneNumberTab" Text="$res:List">
          <PersistedCommand>
            <remotion:NavigationCommand Type="WxeFunction" WxeFunctionCommand-MappingID="SearchPhoneNumber" />
          </PersistedCommand>
        </remotion:SubMenuTab>
      </SubMenuTabs>
    </remotion:MainMenuTab>
    
  </Tabs>
</remotion:TabbedMenu>
