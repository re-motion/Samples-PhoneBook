using System;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.Web.UI.Globalization;
using Remotion.Web.ExecutionEngine;

using PhoneBook.Domain;
using PhoneBook.Web.Classes;

namespace PhoneBook.Web.UI
{
  public partial class EditLocationControl : BaseControl
  {
    protected void Page_Load (object sender, EventArgs e)
    {
    }

    public override IBusinessObjectDataSourceControl DataSource
    {
      get { return CurrentObject; }
    }

    


    // BEGIN CUSTOM
    // END CUSTOM
  }
}
