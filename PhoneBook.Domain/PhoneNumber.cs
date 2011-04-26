using System;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.ObjectBinding;
using Remotion.Globalization;
using Remotion.Reflection;

namespace PhoneBook.Domain
{
  [DBTable]
  [MultiLingualResources ("PhoneBook.Domain.Globalization.PhoneNumber")]
  public class PhoneNumber : BindableDomainObject
  {
    [StringProperty(MaximumLength = 8)]
    public virtual string CountryCode { get; set; }

    [StringProperty(MaximumLength = 8)]
    public virtual string AreaCode { get; set; }

    [StringProperty(MaximumLength = 12, IsNullable = false)]
    public virtual string Number { get; set; }

    [StringProperty(MaximumLength = 8)]
    public virtual string Extension { get; set; }

    [DBBidirectionalRelation("PhoneNumbers")]
    public virtual Person Person { get; set; }

    protected PhoneNumber ()
    {
    }

    protected PhoneNumber(string cc, string ac, string nu, string ext, Person p)
    {
      CountryCode = cc;
      AreaCode = ac;
      Number = nu;
      Extension = ext;
      Person = p;
    }

    public static PhoneNumber NewObject ()
    {
      return DomainObject.NewObject<PhoneNumber>();
    }

    public static PhoneNumber NewObject (string cc, string ac, string nu, string ext, Person p)
    {
      return DomainObject.NewObject<PhoneNumber> (ParamList.Create(cc,ac,nu,ext,p));
    }

    public static PhoneNumber GetObject(ObjectID objid)
    {
      return DomainObject.GetObject<PhoneNumber>(objid);
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
