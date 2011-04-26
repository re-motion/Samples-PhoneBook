using System;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.Web.UI.Globalization;
using Remotion.Web.ExecutionEngine;

using PhoneBook.Domain;
using PhoneBook.Web.Classes;

namespace PhoneBook.Web.UI
{
  public partial class EditPersonControl : BaseControl
  {
    protected void Page_Load (object sender, EventArgs e)
    {
    }

    public override IBusinessObjectDataSourceControl DataSource
    {
      get { return CurrentObject; }
    }

    
    protected void PhoneNumbersField_MenuItemClick (object sender, Remotion.Web.UI.Controls.WebMenuItemClickEventArgs e)
    {
      if (e.Item.ItemID == "AddMenuItem")
      {
        PhoneNumber row = PhoneNumber.NewObject();
        PhoneNumbersField.AddAndEditRow (row);
      }
    }
    


    // BEGIN CUSTOM
    // END CUSTOM
  }
}
