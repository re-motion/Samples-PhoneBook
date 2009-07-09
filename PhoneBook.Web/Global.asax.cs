using System;
using PhoneBook.Web.Classes;
using Remotion.ObjectBinding.BindableObject;
using Remotion.Data.DomainObjects.ObjectBinding;
using Remotion.ObjectBinding;

using PhoneBook.Domain;
using Remotion.ObjectBinding.Web;

namespace PhoneBook.Web
{
  public class Global : System.Web.HttpApplication
  {
    protected void Application_Start (object sender, EventArgs e)
    {
      BindableObjectProvider.GetProvider<BindableDomainObjectProviderAttribute>().AddService (
          typeof (BindableDomainObjectGetObjectService), new BindableDomainObjectGetObjectService ());
      BindableObjectProvider.GetProvider<BindableDomainObjectProviderAttribute> ().AddService (
          typeof (IBusinessObjectWebUIService), new WebUiService ());
    }

    protected void Application_End (object sender, EventArgs e)
    {

    }
  }
}