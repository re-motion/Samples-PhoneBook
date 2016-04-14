using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using PhoneBook.Domain;
using PhoneBook.Web.UI;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.ObjectBinding;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.Web.ExecutionEngine;

namespace PhoneBook.Web.Classes
{
  public class PhoneNumberCell : BocCustomColumnDefinitionCell
  {
    public int MaxPhoneNumbers { get; set; }
    public bool Commit { get; set; }

    protected override void Render (HtmlTextWriter writer, BocCustomCellRenderArguments arguments)
    {
      var renderedPhoneNumbers = GetPhoneNumbers(arguments)
        .Take (MaxPhoneNumbers)
        .Select (phoneNumber => $"<a href=\"#\" onclick=\"{GetPostBackClientEvent (phoneNumber.ID.ToString())}\">{HttpUtility.HtmlEncode (phoneNumber.DisplayName)}</a>");

      foreach (var renderedPhoneNumber in renderedPhoneNumbers)
      {
        writer.Write (renderedPhoneNumber);
        writer.Write ("<br/>");
      }
    }

    private static IEnumerable<BindableDomainObject> GetPhoneNumbers (BocCustomCellRenderArguments arguments)
    {
      var propertyPath = arguments.ColumnDefinition.GetPropertyPath();
      var businessObject = arguments.BusinessObject;
      var phoneNumbers = propertyPath.GetValue (businessObject, false, true) as IEnumerable ?? new BindableDomainObject[] { };
      return phoneNumbers.OfType<BindableDomainObject> ();
    }

    protected override void OnClick (BocCustomCellClickArguments arguments, string eventArgument)
    {
      OpenEditPhoneNumberForm(arguments, eventArgument);
    }

    private void OpenEditPhoneNumberForm (BocCustomCellArguments arguments, string eventArgument)
    {
      try
      {
        var id = ObjectID.Parse (eventArgument);
        var page = (IWxePage) arguments.List.Page;
        var number = PhoneNumber.GetObject (id);
        var externalOption = new WxeCallOptionsExternal ("_blank");
        var externalOptionArgument = new WxeCallArguments ((Control) page, externalOption);

        EditPhoneNumberForm.Call (page, externalOptionArgument, number);

        if (Commit)
        {
          ClientTransaction.Current.Commit();
        }
      }
      catch (WxeIgnorableException)
      {
      }
    }
  }
}
