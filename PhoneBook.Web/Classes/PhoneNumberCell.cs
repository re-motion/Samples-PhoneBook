using System;
using System.Collections;
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
      var propertyPath = arguments.ColumnDefinition.GetPropertyPath();
      var bo = arguments.BusinessObject;

      var phoneNumbers = (IList) propertyPath.GetValue (bo, false, true);
      for (int i = 0; i < MaxPhoneNumbers && i < phoneNumbers.Count; ++i)
      {
        var phoneNumber = (BindableDomainObject) phoneNumbers[i];
        string renderedLink = String.Format ("<a href=\"#\" onclick=\"{0}\">{1}</a>",
                                             GetPostBackClientEvent (phoneNumber.ID.ToString()),
                                             HttpUtility.HtmlEncode (phoneNumber.DisplayName));
        writer.Write (renderedLink);
        writer.Write ("<br>");
      }
    }

    protected override void OnClick (BocCustomCellClickArguments arguments, string eventArgument)
    {
      try
      {
        var id = ObjectID.Parse (eventArgument);
        var page = (IWxePage) arguments.List.Page;
        PhoneNumber number = PhoneNumber.GetObject (id);
        var externalOption = new WxeCallOptionsExternal ("_blank");
        var externalOptionArgument = new WxeCallArguments ((Control) page, externalOption);
        EditPhoneNumberForm.Call (page, externalOptionArgument, number);
        if (Commit)
        {
          ClientTransaction.Current.Commit();
        }
      }
      catch (WxeIgnorableException) { }
    }

  }
}
