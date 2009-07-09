using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.ObjectBinding;
using Remotion.Globalization;

namespace PhoneBook.Domain
{
  [DBTable]
  [MultiLingualResources("PhoneBook.Domain.Globalization.PhoneNumber")]
  public class PhoneNumber : BindableDomainObject
  {
    [StringProperty(MaximumLength=8)]
    public virtual string CountryCode { get; set; }

    [StringProperty(MaximumLength=8)]
    public virtual string AreaCode { get; set; }

    [StringProperty(MaximumLength=12, IsNullable=false)]
    public virtual string Number { get; set; }

    [StringProperty(MaximumLength=8)]
    public virtual string Extension { get; set; }

    [DBBidirectionalRelation("PhoneNumbers")]
    public virtual Person Person { get; set; }

    public static PhoneNumber NewObject ()
    {
      return DomainObject.NewObject<PhoneNumber> ();
    }

    public static PhoneNumber GetObject (ObjectID objid)
    {
      return DomainObject.GetObject<PhoneNumber> (objid);
    }

    public new void Delete ()
    {
      base.Delete ();
    }

    public override string DisplayName
    {
      get
      {
        string displayName = "";
        if (!String.IsNullOrEmpty (CountryCode))
        {
          displayName += CountryCode + " ";
        }
        if (!String.IsNullOrEmpty (AreaCode))
        {
          displayName += AreaCode + "/";
        }
        displayName += Number;
        if (!String.IsNullOrEmpty (Extension))
        {
          displayName = displayName + "-" + Extension;
        }
        return displayName;
      }
    }
  }
}
