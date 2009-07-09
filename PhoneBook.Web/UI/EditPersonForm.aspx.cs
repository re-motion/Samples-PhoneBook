using System;
using System.Collections.Generic;
using Remotion.Data.DomainObjects;
using Remotion.Web.ExecutionEngine;
using Remotion.Web.UI.Globalization;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.Web.UI.Controls;
using PhoneBook.Web;
using PhoneBook.Web.Classes;
using PhoneBook.Domain;

namespace PhoneBook.Web.UI
{
  // <WxeFunction>
  //   <Parameter name="obj" type="Person" />
  // </WxeFunction>
  public partial class EditPersonForm : EditFormPage
  {
    protected void Page_Load (object sender, EventArgs e)
    {
      Title = ResourceManagerUtility.GetResourceManager(this).GetString("Edit~Person");
      if (!IsPostBack)
      {
        if (obj == null)
          obj = Person.NewObject();
      }

      LoadObject (obj);
    } // END Page_Load

    protected override IBusinessObjectDataSourceControl DataSource
    {
      get { return CurrentObject; }
    } // END DataSource

    protected override TabbedMultiView UserControlMultiView
    {
      get { return MultiView; }
    } // END UserControlMultiView

    protected void SaveButton_Click (object sender, EventArgs e)
    {
      if (SaveObject())
        Return();
    } // END SaveButton_Click

    protected void CancelButton_Click (object sender, EventArgs e)
    {
      throw new WxeUserCancelException ();
    } // END CancelButton_Click

    // BEGIN CUSTOM
    // END CUSTOM
  }
}