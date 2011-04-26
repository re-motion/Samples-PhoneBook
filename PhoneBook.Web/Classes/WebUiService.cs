using System;
using System.Web;
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
        return new IconInfo ("~/Images/Icon-Null.gif", "16px", "16px");
      }
      else
      {
        // determine the static type of the 
        // passed object, i.e. the originally declared domain object
        // class (Person, PhoneNumber or Location). 
        Type staticType = ((DomainObject) obj).GetPublicDomainObjectType ();
        // assemble the path to the icon bitmap based on the class of the
        // object
        return new IconInfo ("~/Images/Icon-" + staticType.Name + ".gif", "16px", "16px");

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
