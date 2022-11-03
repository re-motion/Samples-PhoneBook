using System.Text;
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
      return NewObject<PhoneNumber>();
    }

    public static PhoneNumber NewObject (string cc, string ac, string nu, string ext, Person p)
    {
      return NewObject<PhoneNumber> (ParamList.Create(cc,ac,nu,ext,p));
    }

    public static PhoneNumber GetObject(ObjectID objid)
    {
      return GetObject<PhoneNumber>(objid);
    }

    public new void Delete ()
    {
      base.Delete ();
    }

    public override string DisplayName
    {
      get
      {
        var displayName = new StringBuilder();
        if (!string.IsNullOrEmpty (CountryCode))
        {
          displayName.Append(CountryCode).Append(" ");
        }

        if (!string.IsNullOrEmpty (AreaCode))
        {
          displayName.Append(AreaCode).Append("/");
        }
        displayName.Append(Number);
        if (!string.IsNullOrEmpty (Extension))
        {
          displayName.Append("-").Append(Extension);
        }
        return displayName.ToString();
      }
    }
  }
}
