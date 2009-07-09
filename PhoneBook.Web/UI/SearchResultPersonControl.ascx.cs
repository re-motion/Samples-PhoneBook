using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.Queries;
using Remotion.Data.DomainObjects.ObjectBinding;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.Web.ExecutionEngine;
using PhoneBook.Web.Classes;
using PhoneBook.Domain;

namespace PhoneBook.Web.UI
{
  public partial class SearchResultPersonControl : BaseControl
  {
    private void Page_Load (object sender, System.EventArgs e)
    {
      var searchAllService = new BindableDomainObjectSearchAllService ();
      var listPersons = searchAllService.GetAllObjects (ClientTransaction.Current, typeof (Person));
      PersonList.LoadUnboundValue (listPersons, IsPostBack);
    }

    protected void PersonList_ListItemCommandClick (object sender, BocListItemCommandClickEventArgs e)
    {
      if (e.Column.ItemID == "Edit" || e.Column.ItemID == "CompoundEdit")
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

