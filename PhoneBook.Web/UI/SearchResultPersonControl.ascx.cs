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
  public partial class SearchResultPersonControl : BaseControl
  { 
    protected override void OnLoad (EventArgs e)
    {
      base.OnLoad (e);
      var searchAllService = new BindableDomainObjectSearchAllService ();
      var listPerson = searchAllService.GetAllObjects (ClientTransaction.Current, typeof (Person));
      PersonList.LoadUnboundValue (listPerson, IsPostBack);
    }

    protected void PersonList_ListItemCommandClick (object sender, BocListItemCommandClickEventArgs e)
    {
      if (e.Column.ItemID == "Edit")
      {
        try
        {
          EditPersonForm.Call (WxePage, (Person) e.BusinessObject);
          ClientTransaction.Current.Commit ();
        }
        catch (WxeUserCancelException)
        {
        }
      }
      // BEGIN HANDLER
      // END HANDLER
    }

    public override IBusinessObjectDataSourceControl DataSource
    {
      get { return CurrentObject; }
    }
  }
}
