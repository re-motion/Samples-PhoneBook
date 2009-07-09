using System;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.Queries;
using Remotion.Web.ExecutionEngine;
using Remotion.Web.UI.Controls;
using Remotion.Web.UI.Globalization;
using Remotion.ObjectBinding;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.Data.DomainObjects.ObjectBinding;
using PhoneBook.Web;
using PhoneBook.Web.Classes;
using PhoneBook.Domain;    

namespace PhoneBook.Web.UI
{
  //<WxeFunction>
  //  <Parameter name="query" type="IQuery" />
  //  <Variable name="searchResult" type="DomainObjectCollection" />
  //</WxeFunction>
  public partial class SearchResultPersonForm : EditFormPage
  {
    protected void Page_Load (object sender, EventArgs e)
    {
      Title = ResourceManagerUtility.GetResourceManager (this).GetString ("Search~Person");
    }

    protected override IBusinessObjectDataSourceControl DataSource
    {
      get { return CurrentObject; }
    }

    protected override TabbedMultiView UserControlMultiView
    {
      get { return MultiView; }
    }
  }
}