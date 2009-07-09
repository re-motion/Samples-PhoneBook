using System;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.Queries;
using Remotion.Web.ExecutionEngine;
using Remotion.Web.UI.Controls;
using Remotion.Web.UI.Globalization;
using Remotion.ObjectBinding;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.Data.DomainObjects.ObjectBinding;

using PhoneBook.Domain;
using PhoneBook.Web;
using PhoneBook.Web.Classes;

namespace PhoneBook.Web.UI
{
  public partial class SearchResultLocationControl : BaseControl
  { 
    protected override void OnLoad (EventArgs e)
    {
      base.OnLoad (e);
      var searchAllService = new BindableDomainObjectSearchAllService ();
      var listLocation = searchAllService.GetAllObjects (ClientTransaction.Current, typeof (Location));
      LocationList.LoadUnboundValue (listLocation, IsPostBack);
    }

    protected void LocationList_ListItemCommandClick (object sender, BocListItemCommandClickEventArgs e)
    {
      if (e.Column.ItemID == "Edit" || e.Column.ItemID == "LeftColumnEdit")
      {
        try
        {
          EditLocationForm.Call (WxePage, (Location) e.BusinessObject);
          ClientTransaction.Current.Commit ();
        }
        catch (WxeUserCancelException)
        {
        }
      }
      // BEGIN CUSTOM
      else if (e.Column.ItemID == "Delete")
      {
        ((Location) e.BusinessObject).DeleteMakeHomeless ();
        ClientTransaction.Current.Commit ();
        var searchAllService = new BindableDomainObjectSearchAllService ();
        var listLocations = searchAllService.GetAllObjects (ClientTransaction.Current, typeof (Location));
        LocationList.LoadUnboundValue (listLocations, IsPostBack);
      }
      // END CUSTOM
    }

    public override IBusinessObjectDataSourceControl DataSource
    {
      get { return CurrentObject; }
    }
  }
}
