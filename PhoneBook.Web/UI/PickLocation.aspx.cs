using System;
using System.Linq;
using PhoneBook.Web.Classes;
using Remotion.Data.DomainObjects.Queries;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.Web.ExecutionEngine;
using Remotion.Web.UI.Globalization;

using PhoneBook.Domain;


namespace PhoneBook.Web.UI
{
  // <WxeFunction>
  //   <ReturnValue type="Location" />
  //   <Variable name="items" type="Location[]" />
  // </WxeFunction>
  public partial class PickLocation : BasePage
  {
    protected void Page_Load (object sender, EventArgs e)
    {
      Title = ResourceManagerUtility.GetResourceManager (this).GetString ("Pick~Location");
      if (IsPostBack)
      {
        FilteredLocationsList.LoadUnboundValue (items, true);
      }
    }

    protected void FilteredLocationsList_ListItemCommandClick (object sender, BocListItemCommandClickEventArgs e)
    {
      if (e.Column.ItemID == "LocationPick")
      {
        ReturnValue = (Location) e.BusinessObject;
        Return ();
      }
      else
      {
        throw new ArgumentException ();
      }
    }

    protected void SearchButton_Click (object sender, EventArgs e)
    {
      var locations = from loc in QueryFactory.CreateLinqQuery<Location> ()
                      where loc.Country == (Country?) CountryField.Value
                      select loc;

      items = locations.ToArray ();

      FilteredLocationsList.LoadUnboundValue (items, false);
    }



    protected void CancelButton_Click (object sender, EventArgs e)
    {
      throw new WxeUserCancelException ();
    }
  }
}
