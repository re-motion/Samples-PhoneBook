using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.Queries;
using Remotion.Data.DomainObjects.ObjectBinding;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.Web.ExecutionEngine;
using PhoneBook.Web.Classes;
using PhoneBook.Domain;

namespace PhoneBook.Web.UI
{
  public partial class SearchResultPhoneNumberControl : BaseControl
  {
    private void Page_Load (object sender, System.EventArgs e)
    {
      var searchAllService = new BindableDomainObjectSearchAllService ();
      var listPhoneNumbers = searchAllService.GetAllObjects (ClientTransaction.Current, typeof (PhoneNumber));
      PhoneNumberList.LoadUnboundValue (listPhoneNumbers, IsPostBack);
    }

    protected void PhoneNumberList_ListItemCommandClick (object sender, BocListItemCommandClickEventArgs e)
    {
      if (e.Column.ItemID == "Edit")
      {
        try
        {
          EditPhoneNumberForm.Call (WxePage, (PhoneNumber) e.BusinessObject);
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
