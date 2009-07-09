using System;

using Remotion.Data.DomainObjects;
using Remotion.ObjectBinding;
using Remotion.ObjectBinding.Web;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.Web.UI.Controls;

namespace PhoneBook.Web.Classes
{
  public class WebUiService : IBusinessObjectWebUIService
  {
    public IconInfo GetIcon (IBusinessObject obj)
    {
      if (obj == null)
      {
        return new IconInfo ("Images/Icon-Null.gif", "16px", "16px");
      }
      else
      {
        Type staticType = ((DomainObject) obj).GetPublicDomainObjectType ();
        return new IconInfo ("Images/Icon-" + staticType.Name + ".gif", "16px", "16px");

      }
    }

    public string GetToolTip (IBusinessObject obj)
    {
      return null;
    }

    public HelpInfo GetHelpInfo (IBusinessObjectBoundWebControl businessObjectBoundWebControl,
                                IBusinessObjectClass businessObjectClass,
                                IBusinessObjectProperty businessObjectProperty,
                                IBusinessObject businessObject)
    {
      return null;
    }

  }
}
