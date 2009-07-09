using System;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.Queries;
using Remotion.Web.ExecutionEngine;
using Remotion.Web.UI.Controls;
using Remotion.Web.UI.Globalization;
using Remotion.ObjectBinding;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.Data.DomainObjects.ObjectBinding;

using $DOMAIN_ROOTNAMESPACE$;
using $PROJECT_ROOTNAMESPACE$;
using $PROJECT_ROOTNAMESPACE$.Classes;

namespace $PROJECT_ROOTNAMESPACE$.UI
{
  public partial class SearchResult$DOMAIN_CLASSNAME$Control : BaseControl
  { 
    protected override void OnLoad (EventArgs e)
    {
      base.OnLoad (e);
      var searchAllService = new BindableDomainObjectSearchAllService ();
      var list$DOMAIN_CLASSNAME$ = searchAllService.GetAllObjects (ClientTransaction.Current, typeof ($DOMAIN_CLASSNAME$));
      $DOMAIN_CLASSNAME$List.LoadUnboundValue (list$DOMAIN_CLASSNAME$, IsPostBack);
    }

    protected void $DOMAIN_CLASSNAME$List_ListItemCommandClick (object sender, BocListItemCommandClickEventArgs e)
    {
      if (e.Column.ItemID == "Edit")
      {
        try
        {
          Edit$DOMAIN_CLASSNAME$Form.Call (WxePage, ($DOMAIN_CLASSNAME$) e.BusinessObject);
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
