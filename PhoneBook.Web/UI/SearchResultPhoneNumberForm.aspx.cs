using System;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.Queries;
using Remotion.Web.ExecutionEngine;
using Remotion.Web.UI.Globalization;
using Remotion.ObjectBinding;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.Data.DomainObjects.ObjectBinding;
using PhoneBook.Web;
using PhoneBook.Web.Classes;
using PhoneBook.Domain;

namespace PhoneBook.Web.UI
{
  // <WxeFunction>
  //   <Parameter name="query" type="IQuery" />
  //   <Variable name="searchResult" type="DomainObjectCollection" />
  // </WxeFunction>
  public partial class SearchResultPhoneNumberForm : BasePage
  {
    private void Page_Load(object sender, System.EventArgs e)
    {
      Title = ResourceManagerUtility.GetResourceManager(this).GetString("SearchResult~PhoneNumber");
    } // END Page_Load

    protected void PhoneNumberList_ListItemCommandClick (object sender, BocListItemCommandClickEventArgs e)
    {
      if (e.Column.ItemID == "Edit")
      {
        try
        {
          EditPhoneNumberForm.Call (this, (PhoneNumber)e.BusinessObject);
          ClientTransaction.Current.Commit ();
        }
        catch (WxeUserCancelException)
        {
        }
      }
    } // END PhoneNumberList_ListItemCommandClick
  }
}
